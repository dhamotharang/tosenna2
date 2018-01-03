<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageEmpResources.aspx.cs" Inherits="SchoolNet.ManageEmpResources" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="true">
<tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Resources & HR Policy Documents</span></td>
	</tr>	
<!--    Start: Tab 1 -->
<tr><td width="100%">
 <asp:PlaceHolder id="EmployeeDocumentsTab" Runat="server" visible="true">
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4">&nbsp;</td></tr>
             <tr>
			    <td class="mainheadtxt" colspan="2">Select the document to upload</td>
			    <td class="mainheadtxt">Document Name</td>
			    <td class="mainheadtxt">Document Type</td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt" colspan="2"><input id="Tab1_FileName" type="file" class="textfield" TabIndex=1 runat="server" size="50"></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_DocumentName  width="180px" cssclass="textfield" TabIndex=2 Maxlength="50" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab1_DocumentType cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="220px"></asp:dropdownlist></td>
			  	    
		    </tr>	
           <tr>
		        <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_FileName ErrorMessage="Select the File." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DocumentName  ErrorMessage="Document Name is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DocumentType InitialValue=-1 ErrorMessage="Document Type is required." /></td>               
            
		    </tr>		    
		    <tr>
		        <td class="mainheadtxt" colspan="3">Comments</td>
		        <td class="mainheadtxt">Document Visibility</td>
		    </tr>
		     <tr>		     
			    <td class="mainheadtxt" colspan="3"><asp:textbox id=Tab1_Comments  cssclass="textfield" TabIndex=4 size="100" Maxlength="100" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab1_DocumentVisibility cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="150px"></asp:dropdownlist></td>			  	    
		    </tr>	
		     
	 	    <tr>
		        <td class="validationtxt" colspan="2">&nbsp;</td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DocumentVisibility InitialValue=-1 ErrorMessage="Document Visibility Type is required." /></td>                           
		    </tr>	
		    	
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Doc_Upload runat="server" CausesValidation="True" CssClass="Button UploadButton" Text="Upload"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			</center>
			</td>
            </tr>
		    	
            <tr>
                <td colspan="4" align=center><asp:label id="docmessage" runat="server" visible=false />
                <asp:Label id="keyField" runat="server" visible=false />
                </td>
            </tr>    			
           <tr><td colspan="4"><hr /></td></tr>

            <tr>
                <td colspan="4">
                    <asp:DataGrid ID="DOCGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="DocumentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="DOCGrid_PageIndexChanged"                                  OnCancelCommand="DOCGrid_CancelCommand" OnDeleteCommand="DOCGrid_DeleteCommand" OnEditCommand="DOCGrid_EditCommand" OnUpdateCommand="DOCGrid_UpdateCommand">
                                   
                      <Columns>
                            <asp:TemplateColumn HeaderText="Document Name" ItemStyle-Width="30%">                                
                                <ItemTemplate>
                                    <a id="A1" href='<%# "~/DocResources/" + Eval("DocumentName")%>' runat="server" target="_blank"><%# Eval("DocumentName")%></a> 
                                </ItemTemplate> 
                            </asp:TemplateColumn>
                            
                             <asp:BoundColumn HeaderText="Doc Visibility" DataField="RoleName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Document Type" DataField="DocumentTypeName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Comments" DataField="Doc_Comments" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Last Updated" DataField="Date_Updated" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                   <ItemTemplate> 
                                      <asp:ImageButton ImageUrl="~/images/buttons/blue_delete1.png" name="Delete" commandName="Delete" alt="Delete" ToolTip="Delete" CausesValidation="false" runat="server" height="28" width="28" OnClientClick="return confirm('Are you sure you want to delete the document?');" /> 
                                   </ItemTemplate>
                            </asp:TemplateColumn>

                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br/>
                    <center><asp:label id ="emptyRow3" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>           				    	    
	     </table>
	   
 </asp:placeholder>
</td>
</tr>
<!---  End of Tab 8 -->



</asp:PlaceHolder>
<!--- Common for all tabs --->

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			


</table>
	<!--   End of Data Area -->
										
</master:content>


