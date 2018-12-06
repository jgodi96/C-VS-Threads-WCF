using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	[ServiceBehavior(IncludeExceptionDetailInFaults =true)]
	public class Service1 : IService1
	{
		public string Weather5day(string zipcode)
		{
			WeatherService.ndfdXMLPortTypeClient weatherpxy = new WeatherService.ndfdXMLPortTypeClient();

			string latlong = weatherpxy.LatLonListZipCode(zipcode);
			string[] splitting = latlong.Split(',');

			Decimal latitude = Convert.ToDecimal(splitting[0]);
			Decimal longitude = Convert.ToDecimal(splitting[1]);
			string date = "Jan 1, 2009";
			DateTime parseData = DateTime.Parse(date);

			string test = weatherpxy.NDFDgenByDay(latitude, longitude, parseData, "5", "e", "24 hourly");

			return test;
			

	                   



		}
	}
}
