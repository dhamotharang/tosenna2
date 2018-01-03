<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewMonthlyPayroll.aspx.cs" Inherits="SchoolNet.PreviewMonthlyPayroll" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Preview Monthly Payroll</span></td>
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
		    <tr><td class="mainheadtxt" ><asp:textbox id=Payroll_Date cssclass="monthPicker2 textfield" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			<tr>
			  	<td colspan="2" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Payroll_Date  ErrorMessage="Select Month/Year to prepare Payroll." /></td>
			    <td colspan="2" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=DivisionLocationList  InitialValue=-1 ErrorMessage="Select the location." /></td>
			
			</tr>

            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Preview runat="server" CausesValidation="True" CssClass="Button SendButton" Text="Go"></asp:button>
            </center>
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


