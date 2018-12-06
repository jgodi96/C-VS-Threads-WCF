using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Proj2
{
	public delegate void priceCutEvent(Int32 pr); //Define a delegate
	public delegate void orderProcess(double p);
	public delegate void createOrder();
	class Publisher
	{
		static Random rng = new Random(); // To generate random numbers
		public static event priceCutEvent priceCut; // Link event to delegate
		private static Int32 bookPrice = 200;
		private static Int32 priceCutNum = 0;
		public static bool bookRun = true;


		public double getPrice() { return bookPrice; }
		public static void changePrice(Int32 price)
		{
			
			
			if (price < bookPrice) //a price cut
			{
					priceCut(price);//emit event to subscribers
					priceCutNum++;
			}
			bookPrice = price;

		}
		public void publishFunc()
		{
			while (priceCutNum!=20)
			{
				Thread.Sleep(500);
				Int32 priceFinal = PricingModel();
				changePrice(priceFinal);
				Int32 p = rng.Next(50, 200);
				//Console.WriteLine("Price is {0}",p);
				Publisher.changePrice(p);
			}
			bookRun = false;
		}
		public Int32 PricingModel()
		{
			Int32 p = rng.Next(50, 201);
			return p;
		}

		public void startingOrder(MultiCellBuffer obj) //start order will start
		{

			Console.WriteLine("Starting Order");
			Decoder dobj = new Decoder();
			//MultiCellBuffer cellbuff = new MultiCellBuffer(2);
			//Console.WriteLine("axxx");
			string multiCellString = obj.getTheCell();
			//Console.Write("bxxxx");
			OrderClass orderdecode = dobj.decode(multiCellString);
			Thread OrderProcessingThread = new Thread(() => OrderProcessing.processOrder(orderdecode, getPrice()));
			OrderProcessingThread.Start();

		}
	}
		public class OrderProcessing
		{


		public static void processOrder(OrderClass obj, double p) //initialize a new instance
		{
			Console.WriteLine("Order Processing");

				Console.WriteLine("Credit Card Valid");


			double total = (obj.getunitPrice() * obj.getAmount()) + obj.getTax() + obj.getLocationCharge();




			Console.WriteLine("Order from {0} ", obj.getSenderId(), 
				"ordered ", obj.getAmount(), 
				"book(s).\nCredit Card Number:", obj.getcardNo(),
				"\nPrice:", obj.getunitPrice());
			Console.WriteLine("The total is:" + total);

			


		}
		

		}
	public class OrderClass
	{
		private string senderId;
		private int cardNo;
		private int amount;
		private double unitPrice;
		private double tax;
		private double locationCharge;
		static Random rng = new Random();

		public OrderClass(string id, int card, int amt, double up)
		{
			senderId = id;
			cardNo = card;
			amount = amt;
			unitPrice = up;
		}

		/*public double Tax
		{
			get { return tax; }
			set { tax = rng.NextDouble(); }
		}
		public double LocationCharge
		{
			get { return locationCharge ; }
			set { locationCharge = rng.NextDouble(); }
		}
		public string SenderId
		{
			get { return senderId; }
			set { senderId = value; }
		}
		public int CardNo
		{
			get { return cardNo; }
			set { cardNo = value; }
		}
		public int Amount
		{
			get { return amount; }
			set { amount = value; }
		}
		public double UnitPrice
		{
			get { return unitPrice; }
			set { unitPrice = value; }
		}*/
		public double getTax()
		{
			return tax;
		}
		public void setTax()
		{
			tax = rng.NextDouble();
		}
		public double getLocationCharge()
		{
			return locationCharge;
		}
		public void setLocationCharge()
		{
			locationCharge = rng.NextDouble();
		}

		public string getSenderId()
		{
			return senderId;
		}
		public void setSenderId(string s)
		{
			s = senderId;
		}
		public int getcardNo()
		{ 
			return cardNo;
		}
			public void setCardNo(int number)
			{
				cardNo = number;
			}
			public int getAmount()
			{
				return amount;
			}
			public void setAmount(int amt)
			{
				amount = amt;
			}
			public double getunitPrice()
			{
				return unitPrice;
			}
			public void setunitPrice(double uprice)
			{
				unitPrice = uprice;

			}


		}
		public class BookStore {
		public static event createOrder createdAnOrder;
		public static Random rnd = new Random();
	    static MultiCellBuffer cellbuff = new MultiCellBuffer(2);
			public void bookStoreFunc()
			{//for starting thread
				Publisher book = new Publisher();
			while (Publisher.bookRun)
			{
				Thread.Sleep(1000);
				double p = book.getPrice();
				//Console.WriteLine("BookStore {0} has everyday low price: ${1} each",
					//Thread.CurrentThread.Name, p); //Thread.CurrentThread.Name prints thread name
				createsOrder(Thread.CurrentThread.Name, p);

				

			}
				
			}
			public void bookOnSale(Int32 p) { //event handler
					 
					//Console.WriteLine("Price cut occurs");
					
		
			}
		public void createsOrder(string senderId, double finalprice) //creating order passing sender id and the final price thast has changed
		{
			Console.WriteLine("\nCreating Order for id {0}",senderId);

			string sender = senderId;
			//Console.WriteLine(senderId);
			Int32 cardNumber = rnd.Next(5000, 7000);
			Int32 amount = rnd.Next(20, 100);
			double unitPrice = finalprice;

			//gather info into order object
			OrderClass order = new OrderClass(sender, cardNumber, amount, unitPrice);
		
			//pass order into encoder and return a string
			string bookOrderString = Encoder.encode(order);
			//Console.WriteLine(bookOrderString);
			//pass string into multicellbuffer
			
		    cellbuff.setTheCell(bookOrderString);
			Publisher pobj = new Publisher();
			pobj.startingOrder(cellbuff);


		}
		

			

	}
		

		public class myApplication {
		static void Main(string[] args) {
			    
				Publisher publish = new Publisher();
			    BookStore bookStore = new BookStore();
				
				Thread publisher = new Thread(new ThreadStart(publish.publishFunc));
				publisher.Start(); //start one publisher thread

			    Publisher.priceCut += new priceCutEvent(bookStore.bookOnSale);
			   // BookStore.createdAnOrder += new createOrder(publish.startingOrder);
				
				
				
				Thread[] bookstore = new Thread[5];
				for (int i = 0; i < 5; i++) { //N=5 here
											  //start n retailer threads
					bookstore[i] = new Thread(new ThreadStart(bookStore.bookStoreFunc));
					bookstore[i].Name = (i + 1).ToString();
					bookstore[i].Start();
				}
			}
		}
	}


				

