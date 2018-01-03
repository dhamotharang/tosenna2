<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeNonPayrollIncentivesReport.aspx.cs" Inherits="SchoolNet.EmployeeNonPayrollIncentivesReport" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employees Incentives(Non-Payroll) Data Report </span></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
		     <td>&nbsp;</td>
		     <td class="mainheadtxt" align="right">Business Unit:&nbsp;<asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			 <td class="mainheadtxt" align="center">Country:&nbsp;<asp:dropdownlist id="DivisionLocationList" AutoPostBack=true onselectedindexchanged="DivisionLocationList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist>
			 <td class="mainheadtxt" align="left">Office Location:&nbsp;<asp:dropdownlist id="CountryBranchList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist>
		 
			 &nbsp;&nbsp;<asp:button id=Export runat="server" CausesValidation="True" CssClass="Button ExportButton" Text="Export"></asp:button></td>
		 </tr>				     
			     
	
	    </table>
	   </td>						
	</tr>
</asp:placeholder>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" Visible=false /></td>			
</tr> 	
</table>								
</master:content>







