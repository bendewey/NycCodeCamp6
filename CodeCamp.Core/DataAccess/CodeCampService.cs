using System;
using System.IO;
using CodeCamp.Core.Messaging;
using CodeCamp.Core.Messaging.Messages;

namespace CodeCamp.Core.DataAccess
{
	public class CodeCampService
	{
		public CodeCampRepository Repository { get; private set; }
		
		private readonly CodeCampDataClient _client;
	    private readonly IFileSystemHelper _fileHelper;
	    private readonly string _fileName;
		
		public CodeCampService(string baseUrl, string campKey)
		{
            // ideally each app would just send in its folder path or helper instead of doing it this way
            // including this as a example of how to use compiler directives in shared layers
#if WINDOWS_PHONE
            _fileHelper = new IsolatedStorageFileSystemHelper();
#elif Metrostyle
            _fileHelper = new ApplicationDataFileSystemHelper();
#elif __ANDROID__
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                             "../cache");
            _fileHelper = new StandardFileSystemHelper(folderPath);
#else
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), 
											 "../Library/Caches");
            _fileHelper = new StandardFileSystemHelper(folderPath);
#endif

            _fileName = campKey + ".xml";
			Repository = new CodeCampRepository(null);
			_client = new CodeCampDataClient(baseUrl, campKey);

            Initialize();
		}

#if Metrostyle
        async void Initialize()
        {
            try
            {
                var fileExists = await _fileHelper.FileExists(_fileName);
                if (!fileExists)
                {
                    downloadNewXmlFile();
                }
                else
                {
                    Repository = new CodeCampRepository(await _fileHelper.ReadFile(_fileName));
                    MessageHub.Instance.Publish(new FinishedLoadingScheduleFromStorageMessage(this));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
#else
        void Initialize()
        {
            if (!_fileHelper.FileExists(_fileName))
            {
                downloadNewXmlFile();
            }
            else
            {
                Repository = new CodeCampRepository(_fileHelper.ReadFile(_fileName));
                MessageHub.Instance.Publish(new FinishedLoadingScheduleFromStorage(this));
            }
        }
#endif

        public void CheckForUpdatedSchedule()
		{
			MessageHub.Instance.Publish(new StartedCheckingForUpdatedScheduleMessage(this));
			
			_client.GetCurrentVersion(version =>
			{
				if (version < 0)
				{
					MessageHub.Instance.Publish(new ErrorCheckingForUpdatedScheduleMessage(this));
				}
				else if (version > Repository.CurrentVersion)
				{
					MessageHub.Instance.Publish(new FoundUpdatedScheduleMessage(this));
					
					downloadNewXmlFile();
				}
				else
				{
					MessageHub.Instance.Publish(new NoUpdatedScheduleAvailableMessage(this));
				}
			});
		}
		
		private void downloadNewXmlFile()
		{
			MessageHub.Instance.Publish(new StartedDownloadingUpdatedScheduleMessage(this));
			
			_client.GetXml(xml =>
			{
				if (string.IsNullOrEmpty(xml))
				{
					MessageHub.Instance.Publish(new ErrorDownloadingUpdatedScheduleMessage(this));
				}
				else
				{
				    _fileHelper.WriteFile(_fileName, xml);

                    Repository = new CodeCampRepository(xml);
					
					MessageHub.Instance.Publish(new FinishedUpdatingScheduleMessage(this));
				}
			});
		}
	}
}

