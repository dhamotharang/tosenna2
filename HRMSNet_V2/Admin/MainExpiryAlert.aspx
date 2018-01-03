<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainExpiryAlert.aspx.cs" Inherits="SchoolNet.MainExpiryAlert" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Main Data Expiry Alert Enquiry </span></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Select DataType<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Business Unit Location</td>
			    <td class="mainheadtxt">Alerting Period</td>
		    </tr>
		    <tr><td class="mainheadtxt" ><asp:dropdownlist id="ExpiryAlertDataTypeList" TabIndex=1 AutoPostBack=false runat="server" Width="180Px" CssClass="textfield"></asp:dropdownlist></td>		    
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab1_Rb1" runat="server" Text="30 Days"  Checked="true" value ="1"  GroupName="AlertPeriodList"/> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb2" runat="Server" Text="60 Days" value ="2"  GroupName="AlertPeriodList" /> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb3" runat="Server" Text="90 Days" value ="3"  GroupName="AlertPeriodList" /> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb4" runat="Server" Text="120 days" value ="4"  GroupName="AlertPeriodList" />
			    
			    
			    </td>
		    </tr>
			<tr>
			  	<td colspan="1" class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=ExpiryAlertDataTypeList InitialValue=-1 ErrorMessage="Select the expiry alert data type." /></td>
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




