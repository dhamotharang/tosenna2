<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveList.aspx.cs" Inherits="SchoolNet.LeaveList" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Employee Leave List</center></td>
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
			    <td class="mainheadtxt">Department</td>
			    <td class="mainheadtxt">Job Title</td>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Location</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="departmentDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="jobTitleDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>
		     <tr><td colspan="4"><hr /></td></tr>
			
    	<tr class="PartWhite" align=center>
			<td  valign="middle" colspan="2"><center><asp:button id=Search runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Search"></asp:button>
			&nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			</center>
			</td>
			<td class="mainheadtxt" align=right colspan="2"><asp:button id=Export Visible=false runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export Employee Leave Master"></asp:button></td>
		</tr>	
	    </table>
	   </td>						
	</tr>
</asp:PlaceHolder>

<!---  Data Content Area -->						
<asp:PlaceHolder id=searchDataArea Runat="server">
<tr width="100%">
  <td>
  <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="15" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"            OnCancelCommand="Grid_CancelCommand" OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">
                           
              <Columns>
                    <asp:BoundColumn HeaderText="Employee ID" DataField="Employee_ID" ItemStyle-Width="15%" SortExpression="Employee_ID"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Employee Name" DataField="EmployeeName" ItemStyle-Width="22%" SortExpression="EmployeeName"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Job Title" DataField="Designation" ItemStyle-Width="16%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Leave Start Date" DataField="Leave_StartDate" ItemStyle-Width="15%" SortExpression="Leave_StartDate"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Leave End Date" DataField="Leave_EndDate" ItemStyle-Width="15%" SortExpression="Leave_EndDate"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="22%" SortExpression="LeaveTypeName"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="18%"></asp:BoundColumn>
               </Columns>     
                <FooterStyle CssClass="GridFooter" />
                <SelectedItemStyle CssClass="GridSelectedItem" />
                <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="GridAltItem" />
                <ItemStyle CssClass="GridItem" />
                <HeaderStyle CssClass="GridHeader" />
</asp:DataGrid>
</br>
<center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
</td>    
</tr>
</ASP:PlaceHolder>

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			


</table>
	<!--   End of Data Area -->
										
</master:content>

