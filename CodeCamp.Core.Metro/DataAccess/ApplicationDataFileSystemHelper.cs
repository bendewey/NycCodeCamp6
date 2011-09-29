using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace CodeCamp.Core.DataAccess
{
    public class ApplicationDataFileSystemHelper: IFileSystemHelper
    {
        /// <summary>
        /// Checks whether a file exists in the WinRT ApplicationData API.  Currently
        /// returning true/false is not supported.  For that reason an attempt to catch an exception
        /// only solution available.  http://social.msdn.microsoft.com/Forums/en-US/winappswithcsharp/thread/1eb71a80-c59c-4146-aeb6-fefd69f4b4bb
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<bool> FileExists(string file)
        {
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync(file);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public async Task<string> ReadFile(string file)
        {
            try
            {
                var storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(file);
                IRandomAccessStream readStream = await storageFile.OpenAsync(FileAccessMode.Read);

                // Read the file to an IInputStream stream, then get and load the DataReader.
                IInputStream inputStream = readStream.GetInputStreamAt(0);
                DataReader dataReader = new DataReader(inputStream);
                uint numBytesLoaded = await dataReader.LoadAsync((uint)readStream.Size);

                return dataReader.ReadString(numBytesLoaded);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public async void WriteFile(string file, string content)
        {
            try
            {
                var localFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await localFolder.CreateFileAsync(file, CreationCollisionOption.ReplaceExisting);
                IRandomAccessStream writeStream = await sampleFile.OpenAsync(FileAccessMode.ReadWrite);
                IOutputStream outputStream = writeStream.GetOutputStreamAt(0);
                DataWriter dataWriter = new DataWriter(outputStream);
                dataWriter.WriteString(content);

                await dataWriter.StoreAsync();
                outputStream.FlushAsync().Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
