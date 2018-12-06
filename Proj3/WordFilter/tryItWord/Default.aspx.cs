using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tryItWord
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void TextBox1_TextChanged(object sender, EventArgs e)
		{
			
		}



		protected void Button1_Click(object sender, EventArgs e)
		{
			filterReference.Service1Client mypxy = new filterReference.Service1Client();
			string input = this.txtWord.Text;
			string result = mypxy.WordFilter(input);
			this.txtFilter.Text = result.ToString();
		}

		protected void TextChanged(object sender, EventArgs e)
		{

		}
	}
}