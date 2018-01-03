<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeavePeriod.aspx.cs" Inherits="SchoolNet.LeavePeriod" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Current Leave Period Definition</span></td>
	</tr>	
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
		 <tr><td colspan="4">&nbsp;</td></tr>
		 <tr>
			    <td class="mainheadtxt">Current Leave Period Name(<small>Example Leave Year 2012</small>)<font color="red">*</font></td>
			    <td class="mainheadtxt">Start Date<font color="red">*</font></td>
			    <td class="mainheadtxt">End Date<font color="red">*</font></td>
			    <td class="mainheadtxt">Current Leave Period</td>
		 </tr>			 
		 <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LeavePeriodName cssclass="textfield" TabIndex=1 Maxlength="50" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_StartDate cssclass="textfield" TabIndex=2 Maxlength="15" runat="server"></asp:textbox></td>
   			    <td class="mainheadtxt"><asp:textbox id=Tab1_EndDate cssclass="textfield" TabIndex=3 Maxlength="15" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:label id=Tab1_LeavePeriod cssclass="textfield" TabIndex=4 Maxlength="50" runat="server"></asp:label></td>
		  </tr>  
		  <tr>
			    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_LeavePeriodName  ErrorMessage="Leave Period Name is required." /></td>
			    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_StartDate  ErrorMessage="Start Date is required." /></td>
			    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EndDate  ErrorMessage="End Date is required." /></td>
                <td>&nbsp;</td>
		   </tr> 
		
	        <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=LeaveWeek_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			</center>
			</td>
            </tr>
           <tr><td colspan="4" align=center><asp:label id="message" runat="server" visible=false /></td></tr>                 
           <tr><td colspan="4"></td></tr>
	    </table>   	 
	 </td>
</tr>
</asp:placeholder>
</table>
</master:content>

