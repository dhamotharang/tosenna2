<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmpCategory.aspx.cs" Inherits="SchoolNet.EmpCategory" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Catagory Master Data</span></td>
	</tr>	
 <ASP:PlaceHolder id="ManageCRUD" Runat="server" Visible="true">
   
    
	<tr>
	  <td> 
		<table width="100%" border="0" class="Partgrayblock">
		<tr><td colspan="4">&nbsp;</td></tr>	
        <ASP:PlaceHolder id="ManageCRUDEntry" Runat="server" Visible="false">
		<tr>
			<td class="mainheadtxt" width="18%">Employee Category Name<font color="red">*</font></td>
			<td class="mainheadtxt"><asp:textbox id=EmpCategoryName cssclass="textfield" Maxlength="50" Width="220px" runat="server"></asp:textbox></td>
			<td class="mainheadtxt" colspan="2">Status: &nbsp;<asp:RadioButton id="Radio1" Text="Active"  Checked="True" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;
			                                     <asp:RadioButton id="Radio2" Text="InActive" GroupName="RadioGroup1" runat="server"/>
            </td>			                                     		
		</tr>
	    <tr>
		        <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=EmpCategoryName  ErrorMessage="Employee Category Name is required." /></td>   
	            <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt">&nbsp;</td>
		 </tr>			
    	 
         <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center> 
			</td>
         </tr>
		 <tr>
                <td colspan="4" align=center><asp:label id="Tab1_Message" runat="server" visible=false />
                                             <asp:Label id="Tab1_KeyField" runat="server" visible=false />
                </td>
          </tr>	
        <tr><td colspan="4"><hr /></td></tr>
           </ASP:PlaceHolder>
        <tr>
  <td colspan="4" width=100%>
          <asp:DataGrid ID="Grid" CssClass="Tabular2"  runat="server" Width="100%" PageSize="15"  AllowPaging="True"  DataKeyField="EmpCategoryID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onPageIndexChanged="Grid_PageIndexChanged" 
                         OnEditCommand="Grid_EditCommand" Caption='' CaptionAlign="Top">
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee Category Name" DataField="EmpCategoryName" ItemStyle-Width="65%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Active" DataField="Status" ItemStyle-Width="35%"></asp:BoundColumn>
                     
                    </Columns>
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
        </asp:DataGrid>
  </td>      
 </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
	    </table>
	   </td>						
   </tr>

 
</ASP:PlaceHolder>
</TABLE>
</master:content>



