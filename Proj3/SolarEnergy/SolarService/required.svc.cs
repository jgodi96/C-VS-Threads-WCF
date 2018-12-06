using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;




namespace SolarService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1
	{
	
		 
		public decimal SolarIntensity(decimal latitude, decimal longitude)
		{

	
			string url = "http://api.openweathermap.org/data/2.5/uvi?appid=52adb63382763c3b640a61c44dbc31d0&lat=" + latitude + "&lon=" + longitude;

			WebRequest req = HttpWebRequest.Create(url);
			WebResponse res = req.GetResponse();
			StreamReader read = new StreamReader(res.GetResponseStream());


			string abc = read.ReadToEnd();

			RootObject rootobj = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(abc);

			decimal index = Convert.ToDecimal(rootobj.value);

			return index;
			
		

		}
		public string WordFilter(string str)
		{
			WordSR.Service1Client mypxy = new WordSR.Service1Client();
			string result = mypxy.WordFilter(str);
			return result;
		}
	}

	public class RootObject
	{
		public int lat { get; set; }
		public int lon { get; set; }
		public DateTime date_iso { get; set; }
		public int date { get; set; }
		public double value { get; set; }
	}
}
