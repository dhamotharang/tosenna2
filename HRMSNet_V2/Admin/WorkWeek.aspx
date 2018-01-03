<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkWeek.aspx.cs" Inherits="SchoolNet.WorkWeek" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
  <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Business Week Definition</span></td>
	</tr>	
 <asp:PlaceHolder id="WorkWeekTab" Runat="server" visible="true">
 <ASP:PlaceHolder id="ManageCRUDEntry" Runat="server" Visible="false">
 <tr><td width="100%"> 
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
	        <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=WorkWeek_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
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
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="12" AllowPaging="True" DataKeyField="CountryID" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand">
                      <Columns>
                            <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="55%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Work Week Definition" DataField="Businessweek" ItemStyle-Width="40%"></asp:BoundColumn>
                                                 
                                                           
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
</asp:placeholder>
</table>
								
</master:content>

