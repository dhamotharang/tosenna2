<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyWPSPayroll.aspx.cs" Inherits="SchoolNet.MonthlyWPSPayroll" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Monthly WPS Generation</center></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>	
		    <tr>
			    <td class="mainheadtxt">Select Month/Year<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Business Unit Location<font color="red">*</font></td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr><td class="mainheadtxt" ><asp:textbox id=Payroll_Date cssclass="monthPicker" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			<tr>
			  <td colspan="2" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Payroll_Date  ErrorMessage="Select Month/Year to prepare Payroll." /></td>
			  <td colspan="2" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=DivisionLocationList  InitialValue=-1 ErrorMessage="Select the location." /></td>
			</tr>
    	   <tr class="PartWhite" align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Submit runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Generate Monthly WPS Extract" 
			    OnClientClick="return confirm('Please note that this is a one time batch process for monthly payroll.You must have processed monthly payroll process first before you generate WPS.Are you sure you want to run this?');"
			    ></asp:button></center></td>
		   </tr>
		   <tr><td colspan="4">&nbsp;</td></tr>
		   <tr><td class="mainheadtxt" colspan="4" align=center >
		       <asp:HyperLink ID="WPSDownloadLink" runat="server" visible=false></asp:HyperLink>
		       </td>
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


