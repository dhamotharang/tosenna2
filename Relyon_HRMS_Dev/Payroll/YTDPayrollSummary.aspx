<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YTDPayrollSummary.aspx.cs" Inherits="SchoolNet.YTDPayrollSummary" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>YTD Payroll Summary Report</center></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>	
		    <tr>
			    <td class="mainheadtxt">Select Year<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit Location</td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr><td class="mainheadtxt" ><asp:textbox id=Pay_Year cssclass="date-picker-year" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			<tr>
			  	<td colspan="1" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Pay_Year  ErrorMessage="Select the year to run the report." /></td>
			    <td colspan="1" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=businessUnitDDList  InitialValue=-1 ErrorMessage="Select the business unit." /></td>
			    <td colspan="2" class="validationtxt">&nbsp;</td>
			
			</tr>
    	   <tr class="PartWhite" align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Preview runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export" ></asp:button></center></td>
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
