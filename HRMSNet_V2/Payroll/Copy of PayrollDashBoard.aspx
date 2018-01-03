<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of PayrollDashBoard.aspx.cs" Inherits="SchoolNet.PayrollDashBoard" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
<%@ Register Assembly="skmControls2" Namespace="skmControls2.GoogleChart" TagPrefix="cc1" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%"> 
 <asp:PlaceHolder id=DashBoardArea1 Runat="server" visible="true">
 
 <tr>
    <td colspan="2">
    <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
        <table width="100%" border="0" class="Partgrayblock">
 	   	 <tr><td>&nbsp;</td>
		     <td class="mainheadtxt" align="right">Business Unit:&nbsp;<asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			 <td class="mainheadtxt" align="left">Location:&nbsp;<asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist>
			 &nbsp;&nbsp;<asp:button id=Search runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Go"></asp:button></td>
		 </tr>				     
	    </table>
   </asp:PlaceHolder>
   </td>
 </tr> 
  <tr><td colspan="2">&nbsp;</td></tr>
<tr>
    <td valign="top" style="width:50%;">
        <div id="container">
         <div id="scrollable_content">
          <table width="100%">
             <tr class="HomeTitles"><td valign="top"><center>Current Month Payroll Status</center></td></tr>
             <tr>            
                 <td width="100%" valign="top">
                        <asp:DataGrid ID="Grid1" CssClass="Tabular2" Width="100%" runat="server" PageSize="6" AllowPaging="True" DataKeyField="DivisionName" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnItemDataBound="Grid1_ItemDataBound" OnPageIndexChanged="Grid1_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="20%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="YYYY-MM" DataField="Year-Month" ItemStyle-Width="8%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Company Code" visible=false DataField="CompanyCode" ItemStyle-Width="0%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Emp Count" DataField="EmployeesCount" ItemStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="EOS Count" DataField="EOSCount" ItemStyle-Width="10%"></asp:BoundColumn>  
                                    <asp:BoundColumn HeaderText="Posted Amt" DataField="TotalPostedAmount" ItemStyle-Width="12%"></asp:BoundColumn> 
                                    <asp:BoundColumn HeaderText="Status" DataField="Status" ItemStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Run Date" visible=false DataField="RunDate" ItemStyle-Width="0%"></asp:BoundColumn>                                                                                                                                                                                                                           
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
              </div>
             </div>
          </td>     
          <td width="50%" valign="top">
           <div id="container">
           <div id="scrollable_content">          
            <table width="100%">
             <tr class="HomeTitles"><td valign="top"><center>Payroll Status History</center></td></tr>
             <tr>            
                 <td width="100%" valign="top">
                        <asp:DataGrid ID="Grid2" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="True" DataKeyField="CompanyCode" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnItemDataBound="Grid2_ItemDataBound" OnPageIndexChanged="Grid2_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="YYYY-MM" DataField="Year-Month" ItemStyle-Width="8%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="20%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Company Code" visible="false" DataField="CompanyCode" ItemStyle-Width="12%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Total Posted Amt" DataField="PostedAmount" ItemStyle-Width="16%"></asp:BoundColumn> 
                                    <asp:BoundColumn HeaderText="Payroll Status" DataField="Status" ItemStyle-Width="12%"></asp:BoundColumn>
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
            </div>
          </div>               
        </td>             
  </tr>
   <tr><td colspan="2">&nbsp;</td></tr>      
  <tr width="100%">
        <td width="50%" valign="top">
             <div>
     <asp:Literal ID="FCLiteral2" runat="server" visible="true"></asp:Literal>
    </div>
    <cc1:Chart ID="EmpListChart1" runat="server" Width="540px" Height="250px" ChartType="PieChart" LineColor="Olive" AlternateText="Employee Count Breakdown By Business Unit/Dept." ChartTitle="Employee Count Breakdown By Business Unit/Dept" ImageAlign="Left"></cc1:Chart>
        </td>
        <td width="50%" valign="top">
            <cc1:Chart ID="EmpListChart2" runat="server" Width="540px" Height="250px" ChartType="PieChart" LineColor=Crimson AlternateText="Employee Count Breakdown By Location" ChartTitle="Employee Count Breakdown By Country" ImageAlign="Left"></cc1:Chart>
        </td>
 </tr>
  <tr><td colspan="2">&nbsp;</td></tr> 

</ASP:PlaceHolder>
</table>
 </master:content>