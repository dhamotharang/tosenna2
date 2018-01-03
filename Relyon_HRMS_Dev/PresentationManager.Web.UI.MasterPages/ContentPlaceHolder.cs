using System;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;

namespace PresentationManager.Web.UI.MasterPages
{
	/// <summary>
	/// The control marks a place holder for content in a master page.
	/// </summary>
	[ToolboxData("<{0}:ContentPlaceHolder width=\"100%\" height=\"100%\" runat=\"server\"></{0}:ContentPlaceHolder>")]
	public class ContentPlaceHolder : Panel
	{
		#region Constructor
		/// <summary>
		/// Makes the placeholder appear as a large grey box in the designer. This is handy for discerning which is which.
		/// </summary>
		public ContentPlaceHolder()
		{
			base.BackColor = Color.Wheat;
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
	}
}
