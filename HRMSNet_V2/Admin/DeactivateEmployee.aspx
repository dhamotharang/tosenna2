<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeactivateEmployee.aspx.cs" Inherits="SchoolNet.DeactivateEmployee" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--    Edit Employee Data Area -->
 <tr><td width="100%">
  <asp:PlaceHolder id=EditArea Runat="server" visible="true">
     <table width="100%" border="0"><tr><td class="colheader" colspan="5"><span class="maintitledesign">Deactivate Employee Profile<span></td></tr>
    </table>
	  
	  <table width="99%" border="0" class="Partgrayblock">    
		     
		     <tr>
			    <td class="mainheadtxt3" colspan="4"><font color="red">WARNING:</font>&nbsp;Please note that deactivating an employee profile will effective immediately disable the employee information from HRM System including current month pending employee's payroll data purged. You should deactivate only if the employee has already left the organization or you do not want the employee profile active in the system for some reason. It will effective immediately disable the self-service access to employee as well. Please use it carefully.
			    </td>
	         </tr>

	         <tr><td colspan="4"><hr /></td></tr>
             <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
		        <td class="mainheadtxt">Local Employee ID<font color="red">*</font></td>
		        <td class="mainheadtxt">Employee Name</td>
		        <td class="mainheadtxt">Employement Status</td>
		        <td class="mainheadtxt">Hire Date</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:textbox id=Tab1_EmployeeID   AutoPostBack=true Text="" TabIndex=1 cssclass="textfield"   Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:label id=Tab1_EmployeeName   readonly=true   width="220px"  runat="server" ></asp:label></td>
                <td class="mainheadtxt"><asp:label id=Tab1_EmpStatusName  readonly=true  width="200px" runat="server" ></asp:label></td>
                <td class="mainheadtxt"><asp:label id=Tab1_HireDateLbl       readonly=true   width="150px" runat="server" ></asp:label></td>					    
		    </tr>
 	   		<tr><td class="validationtxt" colspan="4"><asp:RequiredFieldValidator runat=server Display="Dynamic" ControlToValidate=Tab1_EmployeeID ErrorMessage="Employee ID is required." /> </tr> 	   		    
    	    <tr><td colspan="4">&nbsp;</td></tr>
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Deactivate_Employee runat="server" CausesValidation="True" CssClass="Button CancelButton" Text="Disable"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Cancel runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
		    </tr>			        
	    </table>
	    
  
 </asp:placeholder>
</td>
</tr>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
										
</master:content>


