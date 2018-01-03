<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurrentYearEmployeeAttritionReport.aspx.cs" Inherits="SchoolNet.CurrentYearEmployeeAttritionReport" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Employee Attrition Report - Current Year</center></td>
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
		 
			 &nbsp;&nbsp;<asp:button id=Export runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export"></asp:button></td>
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



>


