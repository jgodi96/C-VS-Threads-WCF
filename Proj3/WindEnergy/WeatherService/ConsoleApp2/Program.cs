using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceReference1.Service1Client mypxy = new ServiceReference1.Service1Client();
			string test1 = "92592";
			string result = mypxy.Weather5day(test1);
			Console.WriteLine("test: [0]", result);

		}
	}
}
