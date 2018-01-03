using System;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;

namespace PresentationManager.Web.UI.MasterPages
{
	/// <summary>
	/// This control contains the content for a particular region
	/// </summary>
	[ToolboxData("<{0}:Content width=\"100%\" height=\"100%\" runat=\"server\"></{0}:Content>")]
	public class Content : Panel
	{
		private		CombinationType		combinationType		= CombinationType.Replace;

		#region Constructor
		/// <summary>
		/// Makes the placeholder appear as a large grey box in the designer. This is handy for discerning which is which.
		/// </summary>
		public Content()
		{
			base.BackColor = Color.WhiteSmoke;
			base.Width = Unit.Percentage(100);
			base.Height = Unit.Percentage(100);
		}
		#endregion

		#region RenderBeginTag
		/// <summary>
		/// Overridden to do nothing. This will prevent anything being output to the response.
		/// </summary>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
		}
		#endregion

		#region RenderEndTag
		/// <summary>
		/// Overridden to do nothing. This will prevent anything being output to the response.
		/// </summary>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
		}
		#endregion

		#region CombinationType
		public CombinationType CombinationType
		{
			get
			{
				return this.combinationType;
			}
			set
			{
				this.combinationType = value;
			}
		}
		#endregion
	}
}
