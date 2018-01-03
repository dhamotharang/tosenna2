using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Principal;


namespace SchoolNet 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
            HttpContext currentContext = HttpContext.Current;
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        String[] roles = ticket.UserData.Split('|');
                        GenericIdentity identity = new GenericIdentity(ticket.Name);
                        GenericPrincipal principal = new GenericPrincipal(identity, roles);
                        this.Context.User = principal;

                      
                    }
                }
            }
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
            // find out the last error
        //    Exception ee = Server.GetLastError().GetBaseException();
            // log the error now
         //   ErrorLogging.LogError(ee, "");

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

