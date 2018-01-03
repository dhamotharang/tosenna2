<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeePhoneBook.aspx.cs" Inherits="SchoolNet.EmployeePhoneBook" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Phone Directory</span></td>
	</tr>	
    <asp:PlaceHolder id=searchDataArea Runat="server">
<tr width="100%">
  <td>
  <div class="ManageEmpGrid">
  <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="15" AllowPaging="True" AllowSorting="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnSorting="Grid_SortCommand">
                 
              <Columns>
                    <asp:BoundColumn HeaderText="Emp ID" DataField="Employee_ID" SortExpression="Employee_ID" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Employee Name" DataField="Name" SortExpression="Name" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Work Phone" DataField="Work_Phone" SortExpression="Work_Phone" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Email Address" DataField="Work_Email" SortExpression="Work_Email" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Work Location" DataField="Work_City" SortExpression="Work_City" ItemStyle-Width="12%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="15%" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="BU Location" DataField="DivisionLocation" visible=false SortExpression="DivisionLocation" ItemStyle-Width="0%"></asp:BoundColumn>                    
               </Columns>     
                <FooterStyle CssClass="EmpsFooter" />
                <SelectedItemStyle CssClass="EmpsSelectedItem" />
                <PagerStyle CssClass="EmpsPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="EmpsAltItem" />
                <ItemStyle CssClass="EmpsItem" />
                <HeaderStyle CssClass="EmpsHeader" />
</asp:DataGrid>
       <center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
</div>
</td>
    
</tr>
</ASP:PlaceHolder>

	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		      <tr class="PartWhite" align=center>
            <td valign="left" class="mainheadtxt">&nbsp;&nbsp;
                <a id="adv_search" href="#" runat="server"><IMG src="~/images/buttons/blue_adv_search.jpg" runat="server" alt="Advanced Search" title="Advanced Search" height="27" width="28" style="float:left;">
                <span style="text-decoration:underline;color:#FFF;float:left;margin:0;padding:5px 0 0 0;">Advanced Search</span></a>
            </td>
			<td  align="right" colspan="2" class="mainsearchtxt">
            Employee ID&nbsp;<asp:textbox id=empID cssclass="textfield" Maxlength="30" runat="server"></asp:textbox>
			</td>
			<td class="mainheadtxt" align=left>
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
                <asp:ImageButton id=Search runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_search.png" ToolTip="Search" alt="Search" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>&nbsp
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
			    <asp:ImageButton id=Reset runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_reset.png" ToolTip="Reset" alt="Reset" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>&nbsp;
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
                <asp:ImageButton id=Export runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_export2.png" ToolTip="Export" alt="Export" height="30" width="30" style="vertical-align:middle;" visible=false></asp:ImageButton>&nbsp;  
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
            </td>
        </tr>
		    <tr>
			    <td class="mainheadtxt">Employee Name</td>
			    <td class="mainheadtxt">Supervisor Name</td>
			    <td class="mainheadtxt">Employement Status</td>
                <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=empName  Maxlength="50" width="180px" runat="server" CssClass="textfield"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=mgrName  Maxlength="50" width="180px" runat="server" CssClass="textfield"></asp:textbox></td>
  			    <td class="mainheadtxt"><asp:dropdownlist id="empStatusDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
                <td class="mainheadtxt">&nbsp;</td>
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
			

	    </table>
	   </td>						
	</tr>
</asp:PlaceHolder>

<!---  Data Content Area -->						


</table>
	<!--   End of Data Area -->
										
</master:content>


