<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageLeaveEntitlement.aspx.cs" Inherits="SchoolNet.ManageLeaveEntitlement" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
<master:content id="formData" runat="server" height="100%" width="100%">
<table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><center>Employee Annual Leave Entitlement (Yearly)</center></td>
	</tr>	
	<tr>
		<td>
		    <table width="100%" border="0" class="Partgrayblock">
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Select Leave Type</td>
			    <td class="mainheadtxt">Leave Period</td>
			    <td class="mainheadtxt">Entitled Days</td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_LeaveTypeList"  TabIndex=1 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_LeavePeriodList"  TabIndex=2 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox  id=Tab1_Entitlement cssclass="textfield" TabIndex=3  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>	
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server  display="Dynamic" ControlToValidate=Tab1_LeaveTypeList InitialValue=-1 ErrorMessage="Leave Type is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server  display="Dynamic" ControlToValidate=Tab1_LeavePeriodList InitialValue=-1  ErrorMessage="Leave Period is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server  display="Dynamic" ControlToValidate=Tab1_Entitlement  ErrorMessage="Entitlement is required." />
                                           <br /><asp:CompareValidator  ControlToValidate=Tab1_Entitlement Type=Integer Display=Dynamic Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator>
                </td>                           
                <td class="validationtxt">&nbsp;</td>
		    </tr>
            <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
		        <td class="mainheadtxt">Employee Name</td> 			   
			    <td class="mainheadtxt">Designation</td>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Business Unit Location</td>
		    </tr>
		    <tr>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_EmpName  Maxlength="50" width="180px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_JobTitleDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_BusinessUnitDDList" AutoPostBack=true runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			<tr><td colspan="4">&nbsp;</td></tr>
		
            <tr align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Entitlement_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>&nbsp;&nbsp;
			                                             <asp:button id=Entitlement_Cancel runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			                                    </center>
			    </td>
            </tr>
             <tr>
                <td colspan="4" align=center><asp:label id="Tab1_Message" runat="server" visible=false /></td>
            </tr>
		
        </table>
	   </td>						
	</tr>
</asp:PlaceHolder>
</table>
</master:content>
