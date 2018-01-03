using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace PresentationManager.Web.UI.MasterPages
{
	/// <summary>
	/// Any inheriting class should specify the template file to use or one should be specified in the web configuration file.
	/// This is a modified version of the MasterPages sample provided by the MS ASP.Net team, available
	/// <a href="http://www.asp.net/ControlGallery/ControlDetail.aspx?control=385&tabindex=2">here</a>.
	/// </summary>
	public class MasterPage : System.Web.UI.Page, INamingContainer
	{
		private		String		masterPageFile		= String.Empty;
		private		ArrayList	contentControls		= new ArrayList();

		#region AddParsedSubObject
		/// <summary>
		/// Intercepts the Content controls that were defined within this page 
		/// and stores them for later insertion into the template.
		/// </summary>
		protected override void AddParsedSubObject(Object content) 
		{
			if (content is Content) 
			{
				this.contentControls.Add(content);
			}
		}
		#endregion

		#region OnInit
		/// <summary>
		/// Sets up the template and copies all the necessary controls to the base page control collection.
		/// </summary>
		protected override void OnInit(EventArgs e) 
		{
			this.EnableViewState = false;

			if (MasterPageFile == null)
			{
				throw new Exception("Either the MasterPageFile property must set or a configuration entry be added to designate a default template.");
			}
			else
			{
				// Pull all the controls out of the master and push them into this page's controls collection.
				// This is to remove the master's id being prefixed on all controls in the page.
				Template	master	= (Template) Page.LoadControl(this.MasterPageFile);

				master.LoadTemplate();

				this.MoveControlsToParent(master, this, 0);
			}

			Content		content	= null;
			Control		region	= null;
			Int32		index	= 0;

			for(int i = 0; i < this.contentControls.Count; i++)
			{
            	content = (Content)this.contentControls[i];

				// Look for a region with the same ID as the content control
				region = FindControl(content.ID, this);

				if (region == null) 
				{
					throw new Exception(String.Format(CultureInfo.InvariantCulture, "Could not find matching region for content with ID '{0}'", content.ID));
				}

				// Pull all of the controls the child specified and put them in place of the region.
				// This should make them appear as if they were a child of the page, instead of being 
				// a child of the region, again, cleans up the UniqueIDs.
				switch(content.CombinationType)
				{
					case(CombinationType.Append):
					{
						index = region.Controls.Count;
						break;
					}
					case(CombinationType.Prepend):
					{
						index = 0;
						break;
					}
					case(CombinationType.Replace):
					{
						index = 0;
						region.Controls.Clear();
						break;
					}
				}

				this.MoveControlsToParent(content, region, index);
			}

			this.CleanupRegions(this);

			// Collapse any serieses of literal controls into a single literal control.
			this.CollapseLiterals(this);

			// Look for any protected fields which are controls.
			// There is a chance these might be controls in the base classes that should be 
			// linked up to the controls declared in the templates.
			FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

			Type baseType = typeof(System.Web.UI.Control);

			FieldInfo	field = null;
			Control		control = null;

			for(Int32 i = 0; i < fields.Length; i++)
			{
				field = fields[i];

				if((field.FieldType.IsSubclassOf(baseType) || field.FieldType == baseType) && (field.GetValue(this) == null))
				{
					control = this.FindControl(field.Name, this);

					field.SetValue(this, control);
				}
			}

			// Rebuild the list of validators now that the page is complete.
			BaseValidator[] validators = (BaseValidator[])FindControls(typeof(BaseValidator), this);

			for(Int32 i = 0; i < validators.Length; i++)
			{
				if(!this.Page.Validators.Contains(validators[i]))
				{
					this.Page.Validators.Add(validators[i]);
				}
			}

			base.OnInit(e);
		
		}
		#endregion

		#region CleanupRegions
		/// <summary>
		/// Finds all the regions within a particular control and moves their contents up a level to replace the region.
		/// </summary>
		private void CleanupRegions(Control control)
		{
			ContentPlaceHolder[]	regions = (ContentPlaceHolder[])FindControls(typeof(ContentPlaceHolder), control);
			ContentPlaceHolder		region = null;

			for (int i = 0; i < regions.Length; i++)
			{
				region = regions[i];
				// Cleanup nested regions.
				for (int j = 0; j < region.Controls.Count; j++)
				{
                	CleanupRegions(region.Controls[j]);
				}

				// Likewise, pull the default content out of the template's regions and push 
				// them into the parent in place of the region.
				MoveControlsToParent(region);
			}

		}
		#endregion

		#region MoveControlsToParent
		private void MoveControlsToParent(Control child)
		{
			Control parent = child.Parent;
			Int32	index = child.Parent.Controls.IndexOf(child);

			parent.Controls.Remove(child);

			this.MoveControlsToParent(child, parent, index);
		}

		private void MoveControlsToParent(Control child, Control parent, Int32 index)
		{
			while(child.Controls.Count > 0)
			{
				parent.Controls.AddAt(index, child.Controls[child.Controls.Count - 1]);
			}
		}
		#endregion

		#region FindControl
		/// <summary>
		/// Locates a control anywhere in the hierarchy. The Control.FindControl implementation 
		/// does not search recursively and will fail if there are two controls anywhere in the 
		/// tree with the same id.
		/// </summary>
		private Control FindControl(String id, Control control)
		{
			Control result = null;

			if(control.ID == id)
			{
				result = control;
			}

			Int32 i = 0;

			while(i < control.Controls.Count && result == null)
			{
				result = FindControl(id, control.Controls[i]);
				i++;
			}

			return result;
		}
		#endregion

		#region FindControls
		/// <summary>
		/// Retrieves a list of all the controls of a particular type or whose type inherits from 
		/// the given type which are anywhere within the control tree.
		/// </summary>
		private Control[] FindControls(Type type, Control parent)
		{
			ArrayList list = new ArrayList();

			FindControls(type, parent, list);

			return (Control[])list.ToArray(type);
		}

		private void FindControls(Type type, Control parent, ArrayList list)
		{
			if(parent.GetType() == type || parent.GetType().IsSubclassOf(type))
			{
				list.Add(parent);
			}
			else
			{
				for(Int32 i = 0; i < parent.Controls.Count; i++)
				{
					FindControls(type, parent.Controls[i], list);
				}
			}
		}
		#endregion

		#region MasterPageFile
		/// <summary>
		/// Specifies which template file to use. If this property is not set, the default 
		/// will be retrieved from the configuration file. 
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("The template control that specifies the layout used to render the contained content.")
		]
		protected String MasterPageFile
		{
			get
			{
				if(this.masterPageFile.Length == 0)
				{
					String		folder = System.IO.Path.GetDirectoryName(Page.Request.Url.AbsolutePath);
					String[]	parts = folder.Split('\\');
					String		path = null;

					Int32		i = parts.Length;

					while(i >= 0 && this.masterPageFile.Length == 0)
					{
						path = String.Format(CultureInfo.InvariantCulture, "{0}/template.ascx", String.Join("/", parts, 0, i));

						if(File.Exists(Page.Server.MapPath(path)))
						{
							this.masterPageFile = path;
						}

						i--;
					}
				}
				if(this.masterPageFile.Length == 0)
				{
					this.masterPageFile = Configuration.Current.MasterPageFile;
				}

				return this.masterPageFile;
			}
			set
			{
				if(value != null)
				{
					this.masterPageFile = value;
				}
				else
				{
					throw new ArgumentException("MasterPageFile cannot be null.");
				}
			}
		}
		#endregion

		#region CollapseLiterals
		/// <summary>
		/// Collapses each series of literal controls into a single literal control.
		/// </summary>
		private void CollapseLiterals(Control control)
		{
			ArrayList collapsed = new ArrayList();
			LiteralControl last = null;
			LiteralControl literal = null;

			for(Int32 i = control.Controls.Count - 1; i >= 0; i--)
			{
				if(control.Controls[i] is LiteralControl)
				{
					literal = (LiteralControl)control.Controls[i];

					if(last == null)
					{
						last = literal;
						collapsed.Add(last.Text);
					}
					else
					{
						collapsed.Add(literal.Text);

						control.Controls.RemoveAt(i);
					}
				}
				else if(last != null)
				{
					collapsed.Reverse();

					last.Text = String.Join("", (String[])collapsed.ToArray(typeof(String)));

					collapsed.Clear();

					last = null;

					this.CollapseLiterals(control.Controls[i]);
				}
			}

			if(last != null)
			{
				if(collapsed.Count > 0)
				{
					collapsed.Reverse();

					last.Text = String.Join("", (String[])collapsed.ToArray(typeof(String)));
				}
			}
		}
		#endregion

		#region SetFocus
		public void SetFocus(Control control)
		{
			this.SetFocus(control.ClientID);
		}
 
		public void SetFocus(String id)
		{
			this.Page.RegisterClientScriptBlock("setFocus", "<noscript><script type=\"text/javascript\" langauge=\"javascript\">function f(id){var x=document.getElementById(id);x.focus();x.select();}</script></noscript>");
			this.Page.RegisterStartupScript("setFocus", String.Format(CultureInfo.InvariantCulture, "<noscript><script type=\"text/javascript\" language=\"javascript\">f('{0}')</script></noscript>", id));
		}
		#endregion
	}
}
