<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MissingLeaveEntitlement.aspx.cs" Inherits="SchoolNet.MissingLeaveEntitlement" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Missing Annual Leave Entitlements(Current Leave Year) Report </center></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr><td class="mainheadtxt">&nbsp;</td>
			    <td class="mainheadtxt" align="center">Business Unit</td>
			    <td class="mainheadtxt" align="left">Business Unit Location</td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr><td class="mainheadtxt">&nbsp;</td>
		        <td class="mainheadtxt" align="center"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"  align="left"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			<tr>
			    <td colspan="2" class="validationtxt">&nbsp;</td>
			    <td colspan="2" class="validationtxt">&nbsp;</td>
			
			</tr>
    	   <tr class="PartWhite" align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Export runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export" ></asp:button></center></td>
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




