using System;
using System.Configuration;

namespace PresentationManager.Web.UI.MasterPages
{
	public class Configuration
	{
        private static Configuration current = (Configuration)ConfigurationSettings.GetConfig("PresentationManager/Web/UI/MasterPages");

		#region Current
		public static Configuration Current
		{
			get
			{
				return current;
			}
		}
		#endregion

		private	String	masterPageFile	= String.Empty;

		#region Constructor
		public Configuration(String masterPageFile)
		{
			this.masterPageFile = masterPageFile;
		}
		#endregion

		#region MasterPageFile
		public String MasterPageFile
		{
			get
			{
				return this.masterPageFile;
			}
		}
		#endregion
	}
}
