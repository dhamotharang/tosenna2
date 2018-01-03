using System;
using System.Configuration;
using System.Xml;

namespace DatabaseManager.Data
{
	public class ConfigurationHandler : IConfigurationSectionHandler
	{
		private String securityRole;
		private String securityApp;
		private String applicationRole;
		private String applicationName;
		private String logRole;
		private String logApp;
		private String logResourceName;

		#region Create
		/// <summary>
		/// This method was modied to allow the 
		/// data access attribute to be consumed in the application
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="configContext"></param>
		/// <param name="section"></param>
		/// <returns></returns>
		public Object Create(Object parent, Object configContext, XmlNode section)
		{
			String rootPath = String.Empty;

			if(section.Attributes["securityRole"] != null) 
				securityRole = section.Attributes["securityRole"].Value;

			if(section.Attributes["securityApp"] != null)
				securityApp = section.Attributes["securityApp"].Value;
			
			if(section.Attributes["applicationRole"] != null)
				applicationRole = section.Attributes["applicationRole"].Value;
			
			if(section.Attributes["applicationName"] != null)
				applicationName = section.Attributes["applicationName"].Value;
			
			if(section.Attributes["logRole"] != null)
				logRole = section.Attributes["logRole"].Value;
			
			if(section.Attributes["logApp"] != null)
				logApp = section.Attributes["logApp"].Value;
			
			if(section.Attributes["logResourceName"] != null) 
				logResourceName = section.Attributes["logResourceName"].Value;
			
			return new Configuration(securityRole, securityApp, applicationRole
						, applicationName, logRole, logApp, logResourceName);
			
		}
		#endregion
	}

	public class Configuration
	{
		private	static	Configuration	current		= (Configuration)ConfigurationSettings.GetConfig("Nish/Data");

		#region Current
		public static Configuration Current
		{
			get
			{
				return current;
			}
		}
		#endregion

		private String securityRole;
		private String securityApp;
		private String applicationRole;
		private String applicationName;
		private String logRole;
		private String logApp;
		private String logResourceName;

		#region Constructor
		internal Configuration()
		{
		}
		#endregion

		#region Constructor
		//		public Configuration(String rootPath)
		//		{
		//			this.rootPath = rootPath;
		//		}
		//
		/// <summary>
		/// To support changes to redirect application as a default back to the 
		/// Portal's homepage, the Configuration Constructor was modified to 
		/// support a property that is used to Redirect the application back to 
		/// the Portal Login Home Page called portalRedirect.
		/// </summary>
		/// <param name="rootPath"></param>
		/// <param name="portalRedirect"></param>
		public Configuration(String securityRole, String securityApp, String applicationRole, String applicationName
			, String logRole, String logApp, String logResourceName) 
		{
			this.securityRole		= securityRole;
			this.securityApp		= securityApp;
			this.applicationRole	= applicationRole;
			this.applicationName	= applicationName;
			this.logRole			= logRole;
			this.logApp				= logApp;
			this.logResourceName	= logResourceName;
		}

		#endregion

		#region SecurityRole
		public String SecurityRole
		{
			get
			{
				return this.securityRole;
			}
//			set
//			{
//				this.securityRole = value;
//			}
		}
		#endregion
		
		#region SecurityApplicationName
		public String SecurityApplicationName
		{
			get
			{
				return this.securityApp;
			}
//			set
//			{
//				this.securityApp = value;
//			}
		}
		#endregion
		
		#region ApplicationRoleName
		public String ApplicationRoleName
		{
			get
			{
				return this.applicationRole;
			}
			set
			{
				this.applicationRole = value;
			}
		}
		#endregion
		
		#region ApplicationName
		public String ApplicationName
		{
			get
			{
				return this.applicationName;
			}
//			set
//			{
//				this.applicationName = value;
//			}
		}
		#endregion
		
		#region ApplicationLogRoleName
		public String ApplicationLogRoleName
		{
			get
			{
				return this.logRole;
			}
//			set
//			{
//				this.logRole = value;
//			}
		}
		#endregion
		
		#region ApplicationLogName
		public String ApplicationLogName
		{
			get
			{
				return this.logApp;
			}
//			set
//			{
//				this.logApp = value;
//			}
		}
		#endregion
		
		#region ApplicationLogResourceName
		public String ApplicationLogResourceName
		{
			get
			{
				return this.logResourceName;
			}
//			set
//			{
//				this.logResourceName = value;
//			}
		}
		#endregion
		
	}
}
