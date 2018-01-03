<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Designation.aspx.cs" Inherits="SchoolNet.Designation" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
   <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Manage Designation Details</span></td>
	</tr>	 
  <ASP:PlaceHolder id="ManageCRUD" Runat="server" Visible="true">
    
	<tr>
	  <td> 
	    <table width="100%" border="0" class="Partgrayblock">
   		<tr><td colspan="4">&nbsp;</td></tr>
		<tr>
			<td class="mainheadtxt">Designation Name<font color="red">*</font></td>
			<td class="mainheadtxt">Visa Designation</td>
			<td class="mainheadtxt">Remark</td>
			<td class="mainheadtxt">Status</td>			
		</tr>
		<tr>
			<td class="mainheadtxt"><asp:textbox id=DesignationName  Maxlength="50" runat="server" Width="160px" CssClass="textfield"></asp:textbox></td>
			<td class="mainheadtxt"><asp:textbox id=VisaDesignation  Maxlength="50" runat="server" Width="160px" CssClass="textfield"></asp:textbox></td>
   		    <td class="mainheadtxt"><asp:textbox id=Remark  Maxlength="100" runat="server" Width="220px" CssClass="textfield"></asp:textbox></td>
   		    <td class="mainheadtxt"><asp:RadioButton id="Radio1" Text="Active"  Checked="True" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;
			                        <asp:RadioButton id="Radio2" Text="InActive" GroupName="RadioGroup1" runat="server"/>
            </td>
		</tr>     
		 <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=DesignationName  ErrorMessage="Designation Name is required." /></td>   
		        <td class="validationtxt">&nbsp;</td>
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
          <tr><td colspan="4"><hr/></td></tr>			
    	  <tr>
    <td  colspan="4" width=100%>
          <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="8"  AllowPaging="True"  DataKeyField="DesignID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onPageIndexChanged="Grid_PageIndexChanged" 
                         OnEditCommand="Grid_EditCommand" Caption='' CaptionAlign="Top">
                      <Columns>
                            <asp:BoundColumn HeaderText="Designation Name" DataField="Designation" ItemStyle-Width="45%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Visa Designation" DataField="VisaDesignation" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Remark" DataField="Remark" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Active" DataField="Status" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                 <ItemTemplate> 
                                     
                                     <asp:ImageButton ImageUrl="~/images/buttons/blue_edit1.png" name="Edit" commandName="Edit" alt="Edit" ToolTip="Edit" CausesValidation="false" runat="server" height="28" width="28" />
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
   </td>     
</tr>
	    </table>
	   </td>						
  </tr>
  
</ASP:PlaceHolder>
</TABLE>
</master:content>




