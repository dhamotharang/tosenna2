using System;
using System.Xml;
using System.Configuration;

namespace PresentationManager.Web.UI.MasterPages
{
	public class ConfigurationHandler : IConfigurationSectionHandler
	{
		#region Create
		public Object Create(Object parent, Object configContext, XmlNode section)
		{
			String	masterPageFile	= String.Empty;

			if(section.Attributes["masterPageFile"] != null)
			{
				masterPageFile = section.Attributes["masterPageFile"].Value;
			}

			return new Configuration(masterPageFile);
		}
		#endregion
	}
}
