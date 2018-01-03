<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeePhoneBook.aspx.cs" Inherits="SchoolNet.EmployeePhoneBook" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Employee Phone Directory</center></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Employee Name</td>
			    <td class="mainheadtxt">Employee ID</td>
			    <td class="mainheadtxt">Supervisor Name</td>
			    <td class="mainheadtxt">Employement Status</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=empName  Maxlength="50" width="180px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=empID  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=mgrName  Maxlength="50" width="180px" runat="server"></asp:textbox></td>
  			    <td class="mainheadtxt"><asp:dropdownlist id="empStatusDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
		    </tr>

		    <tr>			   
			    <td class="mainheadtxt">Designation</td>
			    <td class="mainheadtxt">Division</td>
			    <td class="mainheadtxt">Location/Country</td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="jobTitleDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			
    	<tr class="PartWhite" align=center>
			<td  valign="middle" colspan="3"><center><asp:button id=Search runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Search"></asp:button>
			&nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			</center>
			</td>
		    <td class="mainheadtxt" align=right><asp:button id=Export Visible=false runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export Employee Phone Book"></asp:button></td>
		</tr>	
	    </table>
	   </td>						
	</tr>
</asp:PlaceHolder>

<!---  Data Content Area -->						
<asp:PlaceHolder id=searchDataArea Runat="server">
<tr width="100%">
  <td>
  <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnSorting="Grid_SortCommand">
                 
              <Columns>
                    <asp:BoundColumn HeaderText="Emp ID" DataField="Employee_ID" SortExpression="Employee_ID" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Employee Name" DataField="Name" SortExpression="Name" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Work Phone" DataField="Work_Phone" SortExpression="Work_Phone" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Email Address" DataField="Work_Email" SortExpression="Work_Email" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Work Location" DataField="Work_City" SortExpression="Work_City" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="15%" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="BU Location" DataField="DivisionLocation" visible=false SortExpression="DivisionLocation" ItemStyle-Width="0%"></asp:BoundColumn>                    
               </Columns>     
                <FooterStyle CssClass="GridFooter" />
                <SelectedItemStyle CssClass="GridSelectedItem" />
                <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="GridAltItem" />
                <ItemStyle CssClass="GridItem" />
                <HeaderStyle CssClass="GridHeader" />
</asp:DataGrid>
       <center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
</td>
    
</tr>
</ASP:PlaceHolder>


</table>
	<!--   End of Data Area -->
										
</master:content>


