using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Proj2
{
	class MultiCellBuffer
	{
		public string[] bString;

		private int n; 

		private static int c;
		private static Semaphore writing;
		private static Semaphore reading; 
		public MultiCellBuffer(int n) //constructor 
		{
	
			lock (this)
			{
				c = 0; 
				if (n <= 5)
				{
					this.n = n;
					writing = new Semaphore(n, n);
					reading = new Semaphore(n, n);
					bString = new string[n]; 

					for (int i = 0; i < n; i++)
					{
						bString[i] = "0"; 
					}
				}
	
					//Console.WriteLine("'n' value for number of buffer cells needs to be less than {0}.", 5);
			}
		}



		public void setTheCell(string order)
		{
		writing.WaitOne();
			lock (this)
			{
				while (c == n) 
				{
					Monitor.Wait(this);
				}
				for (int i = 0; i < n; i++)
				{
					if (bString[i] == "0") 
					{
						//Console.WriteLine("asas");
						bString[i] = order;
						c++;
						i = n; 
					}
				}
				writing.Release();
				Monitor.Pulse(this);
			}
		}



		public string getTheCell()
		{
			reading.WaitOne();
			string output = "";
			lock (this)
			{
				while (c == 0) 
				{
				Monitor.Wait(this);
				}

				for (int i = 0; i < n; i++)
				{
				if (bString[i] != "0") 
					{
						output = bString[i];
						bString[i] = "0";
						c--;
						i = n; 
					}
				}
				reading.Release();
				Monitor.Pulse(this);
			}
			return output;
		}
	}
}
