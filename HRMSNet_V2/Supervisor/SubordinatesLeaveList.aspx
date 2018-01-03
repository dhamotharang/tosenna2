<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubordinatesLeaveList.aspx.cs" Inherits="SchoolNet.SubordinatesLeaveList" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
        <td class="colheader"><span class="maintitledesign">My Team's Leave Register</span></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
			    <td class="mainheadtxt">Show the Leave List For</td>
			    <td class="mainheadtxt" colspan="3"><asp:RadioButton ID="Tab1_Rb1" runat="server" Text="Today"  Checked="true" value ="1"  GroupName="LeaveList"/> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb2" runat="Server" Text="This Week" value ="2"  GroupName="LeaveList" /> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb3" runat="Server" Text="This Month" value ="3"  GroupName="LeaveList" /> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb4" runat="Server" Text="This Leave Year" value ="4"  GroupName="LeaveList" /> 
                </td>
		    </tr>
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt" colspan="2">Select Employee </td>
			    <td class="mainheadtxt" colspan="2">Employee Work Location/City</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt" colspan="2"><asp:dropdownlist id="SubordinatesDDList" AutoPostBack=false runat="server" Width="220px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt" colspan="2"><asp:dropdownlist id="WorkCityDDList" AutoPostBack=false runat="server" Width="220px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>
		     <tr><td colspan="4">&nbsp;</td></tr>
			
        <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Search runat="server" CausesValidation="True" CssClass="Button SearchButton" Text="Search"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Export runat="server" CausesValidation="false" CssClass="Button ExportButton" Text="Export"></asp:button>
            </center>
			</td>
            </tr>
        <tr><td colspan="4"><hr /></td></tr>
        <asp:PlaceHolder id=searchDataArea Runat="server">
<tr>
  <td  colspan="4" width="100%">
  <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="15" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"            OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">
                           
              <Columns>
                    <asp:BoundColumn HeaderText="Employee ID" DataField="Employee_ID" ItemStyle-Width="10%" SortExpression="Employee_ID"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Employee Name" DataField="EmployeeName" ItemStyle-Width="18%" SortExpression="EmployeeName"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Job Title" DataField="Designation" ItemStyle-Width="19%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Start Date" DataField="Leave_StartDate" ItemStyle-Width="10%" SortExpression="Leave_StartDate"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="End Date" DataField="Leave_EndDate" ItemStyle-Width="10%" SortExpression="Leave_EndDate"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="18%" SortExpression="LeaveTypeName"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="15%"></asp:BoundColumn>
               </Columns>     
                <FooterStyle CssClass="DashGridFooter" />
                <SelectedItemStyle CssClass="DashGridSelectedItem" />
                <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="DashGridAltItem" />
                <ItemStyle CssClass="DashGridItem" />
                <HeaderStyle CssClass="DashGridHeader" />
</asp:DataGrid>
</br>
<center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
</td>    
</tr>
</ASP:PlaceHolder>

	    </table>
	   </td>						
	</tr>
</asp:PlaceHolder>

<!---  Data Content Area -->						

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			


</table>
	<!--   End of Data Area -->
										
</master:content>

