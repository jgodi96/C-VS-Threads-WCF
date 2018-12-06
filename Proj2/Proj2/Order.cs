using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj2
{
	public class Order
	{
		private string senderId;

		private Int32 cardNo;

		private Int32 amount;

		private double unitPrice;

		public Order(string si, Int32 card, Int32 amt, double up) 

		{
			si = senderId;
			card = cardNo;
			amt = amount;
			up = unitPrice;
		}

		public string getSenderId()

		{
			return senderId;
		}

		public Int32 getCardNo()

		{
			return cardNo;
		}

		public Int32 getAmount()

		{
			return amount;
		}
		public double getUnitPrice()
		{
			return unitPrice;
		}
	}
}
