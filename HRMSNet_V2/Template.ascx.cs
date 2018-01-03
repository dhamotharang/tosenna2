namespace SchoolNet
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web.SessionState;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Data.SqlClient;
	

	/// <summary>
	///		Summary description for Template.
	/// </summary>
	public partial class Template : PresentationManager.Web.UI.MasterPages.Template
	{
		protected System.Web.UI.WebControls.Label TodayLbl;
		protected System.Web.UI.WebControls.Button ThemeButton_Navy;
		protected System.Web.UI.WebControls.Button ThemeButton_Green;
		protected System.Web.UI.WebControls.Button ThemeButton_Red;
		protected System.Web.UI.WebControls.Button ThemeButton_Gray;
		protected System.Web.UI.WebControls.Button ThemeButton_Orange;



		protected void Page_Load(object sender, System.EventArgs e)
		{
              if (Page.User.Identity.Name.ToString() != null && Page.User.Identity.Name.ToString() != "")
              {
                this.UserName.Text = Page.User.Identity.Name.ToString();
              }
             else
            {
                this.UserName.Visible = false;
                this.UserName.Text = "";
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
			this.EnableViewState = true;

		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
		}
}
