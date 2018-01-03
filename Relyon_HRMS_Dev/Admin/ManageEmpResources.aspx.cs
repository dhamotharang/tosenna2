using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PresentationManager.Web.UI.MasterPages;

namespace SchoolNet
{
    public partial class ManageEmpResources : SchoolNetBase
    {
        // protected HtmlInputFile Tab8_FileName;
        public int EmpId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpId = Int32.Parse(Page.User.Identity.Name.ToString());
            keyField.Text = EmpId.ToString();

            if (!Page.IsPostBack)
            {
                LoadRoleTypeLookup(Tab1_DocumentVisibility);
                LoadDocumentType(Tab1_DocumentType);
                // LoadEmpStatusLookup(this.empStatusDDList);
               // LoadDesignationLookup(this.jobTitleDDList);
               // LoadDivisionLookup(this.businessUnitDDList);
            }
            LoadDocuments(); 
       

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            DOCGrid.PageIndexChanged += new DataGridPageChangedEventHandler(DOCGrid_PageIndexChanged);
            Doc_Upload.Click += new EventHandler(Doc_Upload_Click);
        }
        #endregion

        #region  LoadDocuments
        private void LoadDocuments()
        {
            DataSet _DataList = null;
           _DataList = DatabaseManager.Data.DBAccessManager.RetrieveDocumentList();
            if (_DataList.Tables[0].Rows.Count > 0)  // Document Information.
            {
                DataTable _DocDataTable = _DataList.Tables[0];
                this.DOCGrid.DataSource = _DocDataTable;
                this.DOCGrid.DataBind();
            }
            else
            {
                this.DOCGrid.DataSource = null;
                this.DOCGrid.DataBind();
            }
        }
        #endregion

        protected void Doc_Upload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                if (Tab1_FileName.PostedFile != null && Tab1_FileName.PostedFile.FileName != "")
                    try
                    {
                        HttpPostedFile myFile = Tab1_FileName.PostedFile;
                        String Ext = System.IO.Path.GetExtension(myFile.FileName);

                        String FilePath = Server.MapPath(Page.ResolveUrl("~\\DocResources\\" + Tab1_DocumentName.Text.ToString() + Ext));

                        this.docmessage.Visible = true;
                        this.docmessage.CssClass = "errorMessage";
                        myFile.SaveAs(FilePath);
                        String ActualFileName = Tab1_DocumentName.Text.ToString() + Ext;

                        String Result = DatabaseManager.Data.DBAccessManager.UpdateDocuments(Int32.Parse(keyField.Text.ToString()),Int32.Parse(Tab1_DocumentType.SelectedValue), Int32.Parse(Tab1_DocumentVisibility.SelectedValue), ActualFileName, FilePath, Tab1_Comments.Text.ToString());

                        if (Result == "")
                        {
                           ResetDOCFields();

                        }

                        else
                        {
                            this.docmessage.Text = Result;
                            this.docmessage.CssClass = "errorMessage";

                        }

                    }
                    catch (Exception exception)
                    {
                        this.docmessage.Text = ErrorLogging.LogError(exception, "Unknown Exception Occured.Please contact Support.");
                    }
                else
                {
                    this.docmessage.Text = "You have not specified a file.";
                }
            }
            LoadDocuments();
        }

     
        private void ResetDOCFields()
        {
            Tab1_DocumentName.Text = "";
            Tab1_DocumentType.SelectedIndex = -1;
            Tab1_Comments.Text = "";
            Tab1_DocumentVisibility.SelectedIndex = -1;
        }
        private void DeleteDocument(Int32 DocumentID)
        {
            String document =  DatabaseManager.Data.DBAccessManager.DeleteDocument(DocumentID);

            if (document != "")
            {
                try
                {
                    System.IO.File.Delete(document);
                }
                catch (Exception exception)
                {
                    this.docmessage.Text = ErrorLogging.LogError(exception,"Error:Could not delete the file.");
                    this.docmessage.CssClass = "errorMessage";
                }
            }

            else
            {
                this.docmessage.Text = document;
                this.docmessage.CssClass = "errorMessage";

            }
            DOCGrid.CurrentPageIndex = 0;
            LoadDocuments();

        }

    
        protected void Reset_Click(object sender, EventArgs e)
        {

        }
           protected void DOCGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DOCGrid.CurrentPageIndex = e.NewPageIndex;
            LoadDocuments();

        }
        protected void DOCGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
        }
        protected void DOCGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            //ECGrid.EditItemIndex = -1;

        }
        protected void DOCGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int documentID = (int)DOCGrid.DataKeys[(int)e.Item.ItemIndex];
            DOCGrid.EditItemIndex = -1;
            DeleteDocument(documentID);

        }
        protected void DOCGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

        }


    }
}