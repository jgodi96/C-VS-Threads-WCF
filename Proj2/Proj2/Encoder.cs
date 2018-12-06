using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj2
{
	class Encoder
	{
		public static string encode(OrderClass OrderObject)

		{
			//Console.WriteLine("in encoder");


			string data = OrderObject.getSenderId() + "-" + OrderObject.getcardNo().ToString()
			

					+ "-" + OrderObject.getAmount().ToString() + "-" + OrderObject.getunitPrice().ToString();
					

			return data;

		}


	}
}
