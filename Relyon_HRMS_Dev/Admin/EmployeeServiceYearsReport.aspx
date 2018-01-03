<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeServiceYearsReport.aspx.cs" Inherits="SchoolNet.EmployeeServiceYearsReport" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Employee Service Years Report </center></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Business Unit Location</td>
			    <td class="mainheadtxt">Service Years</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab1_Rb1" runat="server" Text="5 years"  Checked="true" value ="1"  GroupName="ServiceYears"/> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb2" runat="Server" Text="10 Years" value ="2"  GroupName="ServiceYears" /> &nbsp;&nbsp;
			                            <asp:RadioButton ID="Tab1_Rb3" runat="Server" Text="15 Years" value ="3"  GroupName="ServiceYears" />
			                            <asp:RadioButton ID="Tab1_Rb4" runat="Server" Text="20 Years" value ="4"  GroupName="ServiceYears" />
			                            <asp:RadioButton ID="Tab1_Rb5" runat="Server" Text="25 Years & Above" value ="5"  GroupName="ServiceYears" />
			                            
			    
			    
			    </td>
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




