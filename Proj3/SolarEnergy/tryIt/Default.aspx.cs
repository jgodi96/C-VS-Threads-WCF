using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tryIt
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}


		protected void btnIndex_Click(object sender, EventArgs e)
		{
			SolarReference.Service1Client mypxy = new SolarReference.Service1Client();
			decimal lat = Convert.ToDecimal(this.txtLat.Text);
			decimal lon = Convert.ToDecimal(this.txtLon.Text);
			decimal result = mypxy.SolarIntensity(lat, lon);
			this.lblIndex.Text = result.ToString();

		}

		protected void TextChanged(object sender, EventArgs e)
		{

		}
	}
}