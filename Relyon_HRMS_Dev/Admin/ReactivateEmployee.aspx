<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReactivateEmployee.aspx.cs" Inherits="SchoolNet.ReactivateEmployee" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--    Edit Employee Data Area -->
 <tr><td width="100%">
  <asp:PlaceHolder id=EditArea Runat="server" visible="true">
 <fieldset><Legend>Reactivate Employee Profile</Legend>		
	  <table width="100%" border="0" class="Partgrayblock">    
		     
		     <tr>
			    <td class="mainheadtxt3" colspan="4"><font color="red">WARNING:</font>&nbsp;Please note that you can only reactivate previously deactivated employee profile via HRM System.
			    </td>
	         </tr>
	         <tr><td colspan="5"><hr /></td></tr>
		    <tr>
		        <td class="mainheadtxt">Local Employee ID<font color="red">*</font></td>
		        <td class="mainheadtxt">Employee Name</td>
		        <td class="mainheadtxt">Employement Status</td>
		        <td class="mainheadtxt">Hire Date</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:textbox id=Tab1_EmployeeID   AutoPostBack=true Text="" TabIndex=1 cssclass="textfield"   Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:label id=Tab1_EmployeeName   readonly=true   cssclass="textfield"    width="220px"  runat="server" ></asp:label></td>
                <td class="mainheadtxt"><asp:label id=Tab1_EmpStatusName  readonly=true   cssclass="textfield"    width="200px" runat="server" ></asp:label></td>
                <td class="mainheadtxt"><asp:label id=Tab1_HireDateLbl       readonly=true   cssclass="textfield"    width="150px" runat="server" ></asp:label></td>					    
		    </tr>
 	   		<tr><td class="validationtxt" colspan="4"><asp:RequiredFieldValidator runat=server Display="Dynamic" ControlToValidate=Tab1_EmployeeID ErrorMessage="Employee ID is required." /> </tr> 	   		    
    	    <tr><td colspan="4"><hr /></td></tr>
            <tr align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=Reactivate_Employee TabIndex = 2 runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Reactivate Employee" OnClientClick="return confirm('Are you sure you want to Reactivate this employee profile as this will effective immediately and will allow employee to login into self service portal?');"></asp:button>
			        &nbsp;&nbsp;&nbsp;<asp:button id=Cancel runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>			        
	    </table>
	    
  </fieldset>
 </asp:placeholder>
</td>
</tr>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
										
</master:content>


