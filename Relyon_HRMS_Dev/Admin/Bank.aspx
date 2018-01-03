<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bank.aspx.cs" Inherits="SchoolNet.Bank" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" height="100%" width="100%"> 
 <ASP:PlaceHolder id="ManageCRUD" Runat="server" Visible="true">
      <tr width="100%">
		    <td class="colheader"><center>Manage Banking Information</center></td>
     </tr>
 	<tr>
	  <td> 
		<table width="100%" border="0" class="Partgrayblock">
        <tr><td colspan="4">&nbsp;</td></tr>			
		<tr>
			<td class="mainheadtxt">Bank Name<font color="red">*</font></td>
			<td class="mainheadtxt">Bank Branch<font color="red">*</font></td>
			<td class="mainheadtxt">Bank Code</td>
			<td class="mainheadtxt">Routing Code<font color="red">*</font></td>
			
		</tr>
		<tr>
			<td class="mainheadtxt"><asp:textbox id=BankName   Maxlength="100" runat="server" Width="220px"></asp:textbox></td>
			<td class="mainheadtxt"><asp:textbox id=BankBranch Maxlength="50"  runat="server" Width="160px" CssClass="textfield"></asp:textbox></td>
   		    <td class="mainheadtxt"><asp:textbox id=BankCode   Maxlength="10" runat="server"></asp:textbox></td>
			<td class="mainheadtxt"><asp:textbox id=RoutingCode  Maxlength="9" runat="server"></asp:textbox></td>

		</tr>
		 <tr>
		    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=BankName  ErrorMessage="Bank Name is required." /></td>   
		    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=BankBranch  ErrorMessage="Bank Branch is required." /></td>   
            <td class="validationtxt">&nbsp;</td>
		    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=RoutingCode  ErrorMessage="Routing Code is required." /></td>   
		 </tr>

		<tr>
			<td class="mainheadtxt">Swift Code</td>
			<td class="mainheadtxt">Status</td>
			<td class="mainheadtxt"></td>
			<td class="mainheadtxt"></td>
		</tr>
		
		<tr>
			<td class="mainheadtxt"><asp:textbox id=SwfitCode Maxlength="50" runat="server"></asp:textbox></td>
			<td class="mainheadtxt"><asp:RadioButton id="Radio1" Text="Active"  Checked="True" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;
			                        <asp:RadioButton id="Radio2" Text="InActive" GroupName="RadioGroup1" runat="server"/>
			<td class="mainheadtxt"></td>
			<td class="mainheadtxt"></td>
		</tr>			
		 <tr>
		    <td class="validationtxt">&nbsp;</td>   
		    <td class="validationtxt"></td>   
            <td class="validationtxt">&nbsp;</td>
		    <td class="validationtxt"></td>
		 </tr>
			
         <tr><td colspan="4"><hr /></td></tr>			
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
  <tr>
   <td width=100%>
          <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="15" AllowPaging="True"  DataKeyField="BankID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onPageIndexChanged="Grid_PageIndexChanged" 
                         OnEditCommand="Grid_EditCommand"  Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Banking Information</td></tr></table>' CaptionAlign="Top">
                      <Columns>
                            <asp:BoundColumn HeaderText="Bank Name" DataField="BankName" ItemStyle-Width="30%" SortExpression="BankName"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Bank Branch" DataField="BankBranch" ItemStyle-Width="20%" SortExpression="BankBranch"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Bank Code" DataField="BankCode" ItemStyle-Width="15%" SortExpression="BankCode"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Routing Code" DataField="RoutingCode" ItemStyle-Width="15%" SortExpression="RoutingCode" ></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Swift Code" DataField="SwiftCode" ItemStyle-Width="15%" SortExpression="SwiftCode"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Active" DataField="Status" ItemStyle-Width="15%" SortExpression="Status" ></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="12%">
                                <ItemTemplate> 
                                       <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                </ItemTemplate>
                            </asp:TemplateColumn>
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
</asp:placeholder>
</TABLE>									
</master:content>


