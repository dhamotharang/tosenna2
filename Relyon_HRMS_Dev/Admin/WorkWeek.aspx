<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkWeek.aspx.cs" Inherits="SchoolNet.WorkWeek" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="WorkWeekTab" Runat="server" visible="true">
 <ASP:PlaceHolder id="ManageCRUDEntry" Runat="server" Visible="false">
 <tr><td width="100%"> 
    <fieldset><legend>Work Week Definition</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Country<font color="red">*</font></td>
			    <td class="mainheadtxt">Work Week<font color="red">*</font></td>
			    <td colspan="2">&nbsp;</td>
            </tr>
            
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_CountryList" runat="server" Width="150px" TabIndex=1 CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_BusinessweekTypeList" runat="server" Width="200px" TabIndex=2 CssClass="textfield"></asp:dropdownlist></td>	     
			    <td colspan="2">&nbsp;</td>
            </tr>
		    <tr>
	            <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_CountryList InitialValue=-1  ErrorMessage="Country is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_BusinessweekTypeList InitialValue=-1 ErrorMessage="Work Week is required." /></td>   
			    <td colspan="2"><asp:Label id="Tab1_keyField" runat="server" visible=false /></td>
            </tr>        
	        <tr><td colspan="4"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id="WorkWeek_Save" runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                        &nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center>
			   </td>
			    
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="message" runat="server" visible=false /></td>
            </tr>
                       
           <tr><td colspan="4"><hr /></td></tr>
           </asp:placeholder>
               <!-- Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="12" AllowPaging="True" DataKeyField="CountryID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Work Week Definition</td></tr></table>' CaptionAlign="Top">
                      <Columns>
                            <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="55%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Work Week Definition" DataField="Businessweek" ItemStyle-Width="40%"></asp:BoundColumn>
                                                 
                                                           
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
	       </table>   	 
	       </fieldset>
 </td>
</tr>
</asp:placeholder>
</table>
								
</master:content>

