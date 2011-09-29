using System;
using System.Net;

namespace CodeCamp.Core.DataAccess
{
	public class CodeCampDataClient
	{
		private readonly string _baseUrl;
		
		public CodeCampDataClient(string baseUrl, string campKey)
		{
			_baseUrl = string.Format("{0}/{1}", baseUrl, campKey);
		}

#if !Metrostyle
		public void GetCurrentVersion(Action<int> callback) 
		{
			var client = new WebClient();
			
			client.DownloadStringCompleted += delegate(object sender, DownloadStringCompletedEventArgs e) {
				int version = e.Error != null
								? -1
								: int.Parse(e.Result);
				
				callback(version);
			};
			
			client.DownloadStringAsync(
				new Uri(_baseUrl + "/Version"));
		}
		
		public void GetXml(Action<string> callback)
		{
			var client = new WebClient();
			
			client.DownloadStringCompleted += delegate(object sender, DownloadStringCompletedEventArgs e) {
				string xml = e.Error != null
								? null
								: e.Result;
				
				callback(xml);
			};
			
			client.DownloadStringAsync(
				new Uri(_baseUrl + "/Xml"));
		}
#else
        public async void GetCurrentVersion(Action<int> callback)
        {
            try
            {
                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync(new Uri(_baseUrl + "/Version"));
                callback(int.Parse(response.Content.ReadAsString()));
            }
            catch (Exception)
            {
                callback(-1);
            }
        }

        public async void GetXml(Action<string> callback)
        {
            string xml = null;
            try
            {
                var client = new System.Net.Http.HttpClient() { MaxResponseContentBufferSize = Int32.MaxValue };
                var response = await client.GetAsync(new Uri(_baseUrl + "/Xml"));
                xml = response.Content.ReadAsString();
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            callback(xml);
        }
#endif
	}
}