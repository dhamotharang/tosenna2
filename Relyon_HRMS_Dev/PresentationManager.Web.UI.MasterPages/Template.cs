using System;
using System.Web.UI;
using System.Reflection;
using System.Collections;

namespace PresentationManager.Web.UI.MasterPages
{
	public class Template : UserControl
	{
		private		ArrayList	contents		= new ArrayList();
		private		String		masterTemplate	= null;

		#region AddParsedSubObject
		protected override void AddParsedSubObject(object obj)
		{
			if(obj is Content)
			{
				if(this.Controls.Count > 0)
				{
					this.Controls.Clear();
				}

				this.contents.Add(obj);
			}
			else if(this.contents.Count == 0)
			{
				base.AddParsedSubObject (obj);
			}
		}
		#endregion

		#region LoadTemplate
		public virtual void LoadTemplate()
		{
			if(this.MasterTemplate != null && this.MasterTemplate.Length > 0)
			{
				this.Controls.Clear();

				Template	masterControl = (Template)this.LoadControl(this.MasterTemplate);
				
				masterControl.LoadTemplate();

				for (int i = 0; i < this.contents.Count; i++)
				{
					Content		content = (Content)this.contents[i];                	
					Control		placeHolder = FindControl(content.ID, masterControl);
					Int32		index = 0;

					switch(content.CombinationType)
					{
						case(CombinationType.Append):
						{
							index = placeHolder.Controls.Count;
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
							placeHolder.Controls.Clear();
							break;
						}
					}

					// Move all the controls from the content control to the region's placeholder.
					this.MoveControlsToParent(content, placeHolder, 1, index);
				}


				this.Controls.Clear();

				// Move all the controls from the master to this.
				this.MoveControlsToParent(masterControl, this, 2, 0);

				FieldInfo namingContainer = typeof(Control).GetField("_namingContainer", BindingFlags.NonPublic | BindingFlags.Instance);

				for (int i = 0; i < this.Controls.Count; i++)
				{
					namingContainer.SetValue(this.Controls[i], null);
				}
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

		#region MoveControlsToParent
		private void MoveControlsToParent(Control child, Control parent, Int32 unique, Int32 index)
		{
			while(child.Controls.Count > 0)
			{
				Control x = child.Controls[child.Controls.Count - 1];
				parent.Controls.AddAt(index, x);
			}
		}
		#endregion

		#region MasterTemplate
		public String MasterTemplate
		{
			get
			{
				return this.masterTemplate;
			}
			set
			{
				this.masterTemplate = value;
			}
		}
		#endregion

		#region UniqueID
		public override string UniqueID
		{
			get
			{
				return base.ID;
			}
		}
		#endregion
	}
}
