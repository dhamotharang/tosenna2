<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeStatus.aspx.cs" Inherits="SchoolNet.EmployeeStatus" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <ASP:PlaceHolder id="ManageCRUD" Runat="server" Visible="True">
  <ASP:PlaceHolder id="ManageCRUDEntry" Runat="server" Visible="false">
    <tr width="100%">
		<td class="colheader"><center>Manage Employement Status Information</center></td>
	</tr>
	<tr>
	  <td> 
		<table width="100%" border="0" class="Partgrayblock">
		<tr><td colspan="4">&nbsp;</td></tr>	
		<tr>
			<td class="mainheadtxt" width="18%">Employment Status Name<font color="red">*</font></td>
			<td class="mainheadtxt"><asp:textbox id=EmpStatusName  Maxlength="50" Width="220px" runat="server"></asp:textbox></td>
			<td class="mainheadtxt" colspan="2">Status: &nbsp;<asp:RadioButton id="Radio1" Text="Active"  Checked="True" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;
			                                     <asp:RadioButton id="Radio2" Text="InActive" GroupName="RadioGroup1" runat="server"/>
            </td>			                                     		
		</tr>
	    <tr>
		        <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=EmpStatusName  ErrorMessage="Employement Status is required." /></td>   
	            <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt">&nbsp;</td>
		 </tr>
         <tr><td colspan="4">&nbsp;</td></tr>			
    	 <tr class="PartWhite" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			</center>
			</td>
		</tr>
		 <tr>
                <td colspan="4" align=center><asp:label id="Tab1_Message" runat="server" visible=false />
                                             <asp:Label id="Tab1_KeyField" runat="server" visible=false />
                </td>
          </tr>	
	    </table>
	   </td>						
   </tr>
 </ASP:PlaceHolder>
 <tr>
  <td width=100%>
          <asp:DataGrid ID="Grid" Width="100%" runat="server" PageSize="15"  AllowPaging="True"  DataKeyField="EmpStatusID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onPageIndexChanged="Grid_PageIndexChanged" 
                         OnEditCommand="Grid_EditCommand" Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Employee Status List</td></tr></table>' CaptionAlign="Top">
                      <Columns>
                            <asp:BoundColumn HeaderText="Employement Status Name" DataField="EmpStatusName" ItemStyle-Width="65%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Active" DataField="Status" ItemStyle-Width="35%"></asp:BoundColumn>
    
                    </Columns>
                        <FooterStyle CssClass="GridFooter" />
                        <SelectedItemStyle CssClass="GridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAltItem" />
                        <ItemStyle CssClass="GridItem" />
                        <HeaderStyle CssClass="GridHeader" />
        </asp:DataGrid>
  </td>      
 </tr>
</ASP:PlaceHolder> 
</TABLE>								
</master:content>



