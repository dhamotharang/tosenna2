<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeLeaveReport.aspx.cs" Inherits="SchoolNet.EmployeeLeaveReport" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Leave Report(Current Year) </span></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Select Leave Data Type<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Country</td>
			    <td class="mainheadtxt">Office Location</td>
		    </tr>
		    <tr><td class="mainheadtxt" ><asp:dropdownlist id="LeaveDataTypeList" TabIndex=1 AutoPostBack=false runat="server" Width="180Px" CssClass="textfield"></asp:dropdownlist></td>		    
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=true onselectedindexchanged="DivisionLocationList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"><asp:dropdownlist id="CountryBranchList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>
			<tr>
			  	<td colspan="1" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=LeaveDataTypeList InitialValue=-1 ErrorMessage="Select the Leave Type." /></td>
			    <td colspan="1" class="validationtxt">&nbsp;</td>
			    <td colspan="2" class="validationtxt">&nbsp;</td>
			
			</tr>
    	   <tr class="PartButtons" align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Export runat="server" CausesValidation="True" CssClass="Button ExportButton" Text="Export"></asp:button></center></td>
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






