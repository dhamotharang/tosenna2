<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LineManager.aspx.cs" Inherits="SchoolNet.LineManager" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <!--   Placeholder 1: DataGrid to List Division -->
 <ASP:PlaceHolder id=EmpCatGrid Runat="server">

 <tr>
  <td width=100%>
  <asp:DataGrid ID="Grid" runat="server" PageSize="10" Width="100%"  AllowPaging="True" AllowSorting="True" DataKeyField="LineMgrID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
                 OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand"
                 Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Line Managers List</td></tr></table>' CaptionAlign="Top">
              <Columns>
                    <asp:BoundColumn HeaderText="Line Manager Name" DataField="LineManager" ItemStyle-Width="65%" SortExpression="LineManager"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Employee ID" DataField="EmployeeID" ItemStyle-Width="35%" SortExpression="EmployeeID" ></asp:BoundColumn>
                    <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit"></asp:EditCommandColumn>
                    <asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete"></asp:ButtonColumn>
            </Columns>
                <FooterStyle CssClass="GridFooter" />
                <SelectedItemStyle CssClass="GridSelectedItem" />
                <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="GridAltItem" />
                <ItemStyle CssClass="GridItem" />
                <HeaderStyle CssClass="GridHeader" />
                
</asp:DataGrid> </td>
<center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
 <td width=2%>&nbsp;</td>
</tr>
</ASP:PlaceHolder>

<!--   Placeholder 2: Area to allow new add, edit and delete  -->
 
 
 <ASP:PlaceHolder id="ManageCRUD" Runat="server" Visible="false">
    <TR width="100%">
		<td colspan="2"><center>Manage LineManager Information</center></td>
		<table width="100%" border="0" class="Partgrayblock">
		<tr>
			<td class="mainheadtxt">Line Manager Name</td>
			<td class="mainheadtxt">Status</td>
			<td class="mainheadtxt"></td>
			<td class="mainheadtxt"></td>
			
		</tr>
		<tr>
			<td class="mainheadtxt"><asp:textbox id=LineManagerName  Maxlength="50" runat="server"></asp:textbox></td>
			<td class="mainheadtxt"><asp:RadioButton id="Radio1" Text="Active"  Checked="True" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;
			                        <asp:RadioButton id="Radio2" Text="InActive" GroupName="RadioGroup1" runat="server"/>


		</tr>

			
			
    	<tr class="PartWhite" align=center>
			<td  colspan="3">
			<center>
			    <asp:button id=Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Delete runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Delete" visible="false"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Cancel runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Cancel"></asp:button>
			</center>
			</td>
		</tr>	
	    </table>
	   </td>						
	</TR>
</asp:PlaceHolder>
<!---  Data Content Area -->						

</TABLE>
	<!--   End of Data Area -->
										
</master:content>



