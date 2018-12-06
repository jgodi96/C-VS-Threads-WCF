
using System.Collections;
using System.Text.RegularExpressions;
namespace WcfService1
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1
	{

		public string WordFilter(string str)

		{

			string idStr = @str; //enables use of keywords as identifiers
			string oldStr = @"(</?)[^>]+?(/?>)|[^a-zA-Z]"; //match all strings that start with a letter and match all strings that contain a non-letter
			string oldStr2 = @"\bare\b|\bam\b|\ba\b|\bthe\b|\ban\b|
			\bon\b|\bin\b|\bat\b|\bunder\b|\babove\b|\bto\b|\band\b|
			\bhence\b|\bif\b|\belse\b|\bbe\b|\bis\b|\bwhen\b|\bwhere\b|\bwho\b|\bwhat\b|\bwhich\b|
			\bbut\b|\bas\b|\bbecause\b|\bwith\b|\bfor\b|\bso\b|\bthus\b|\btherefore\b|
			\bby\b|\bbeen\b|\bwas\b|\bwere\b|\bwhose\b|\binto\b|\bonto\b|\bor\b|\bmoreover\b|\byet\b|
			\bnevertheless\b|\beither\b|\btoo\b|\bnor\b|\bneither\b|\bonly\b|\bjust\b|\balso\b|\bmerely\b|
			\bhow\b|\bof\b|\bbefore\b|\bafter\b|\bthan\b|\bbehind\b|\bbeside\b|\balong\b|\bthrough\b|
			\bsince\b|\bfrom\b|\babout\b|\bout\b"; 
			//list of stop wortds
			// using word boundary \b which finds keyword when not part of a bigger word



			string dataStr1 = Regex.Replace(idStr, oldStr, " ").ToLower();

			string dataStr = Regex.Replace(dataStr1, oldStr2, " ");
			//regex.replace will replace the string yhat match a regex pattern


			ArrayList listOfWords = new ArrayList();
			//make arrayList Obj

			/*int[] fibarray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
			foreach (int element in fibarray)
			{
				System.Console.WriteLine(element);
			}
			System.Console.WriteLine();*/
			foreach (string element in dataStr.Split())
			{
			if (element.Trim().Length != 0)
				{
					listOfWords.Add(element);
				}
			}

			string outputTest = string.Join(" ", (string[])listOfWords.ToArray(typeof(string)));
			return outputTest;
		}

	}	
}
