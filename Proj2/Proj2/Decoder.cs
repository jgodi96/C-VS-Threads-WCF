using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj2
{
	class Decoder
	{
		public OrderClass decode(string seperate)

		{
			String[] dataString = seperate.Split( '-' );
			string id = Convert.ToString(dataString[0]);
			int card = Convert.ToInt32(dataString[1]);
			int amount = Convert.ToInt32(dataString[2]);
			double unitprice = Convert.ToDouble(dataString[3]);


			OrderClass orderBook = new OrderClass(id, card, amount, unitprice);

			return orderBook;

			

	
			
		
		}
	}
}
