<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="SchoolNet.ChangePassword" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--    Edit Employee Data Area -->
 <tr><td width="100%">
  <asp:PlaceHolder id=EditArea Runat="server" visible="true">
 <fieldset><Legend>Change Password</Legend>		
	  <table width="100%" border="0" class="Partgrayblock">    
		     <tr><td colspan="3">&nbsp;</td></tr>
		     <tr>
		        <td class="mainheadtxt" width="20%">Password Rules</td>
		        <td colspan="2" class="mainheadtxt2">New Password can't be same as current password.Password length should be greater than 8 and less than 15 characters. Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]</td>  
		     </tr>
		     <tr><td colspan="3">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt">Current Password<font color="red">*</font></td>
   			    <td class="mainheadtxt"><asp:textbox id="Tab1_password"   TextMode="Password"  TabIndex=1 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox></td>	    		 
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_password  display="dynamic" ErrorMessage="Current Password is Required." />
                 </td>                        
		    </tr>
		    <tr><td colspan="3">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt">New Password<font color="red">*</font></td>
   			    <td class="mainheadtxt"><asp:textbox id="Tab1_NewPassword"   TextMode="Password"  TabIndex=2 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox></td>	    		 
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_NewPassword  ErrorMessage="New Password is Required." />
                                         <asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_NewPassword  ValidationExpression="(?=^.{8,15}$)(?=.*\d)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ErrorMessage="Password length should be greater than 8 and less than 15 characters. Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]." />
                </td>                        
		    </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Confirm New Password<font color="red">*</font></td>
   			    <td class="mainheadtxt"><asp:textbox id="Tab1_ConfirmNewPassword"   TextMode="Password"  TabIndex=2 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox></td>	    		 
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ConfirmNewPassword  ErrorMessage="Confirm Password is Required." />
                                          <asp:CompareValidator      runat="server" ErrorMessage="New and Confirm New Passwords do not match!"  ControlToValidate="Tab1_ConfirmNewPassword"  ControlToCompare="Tab1_NewPassword"></asp:CompareValidator>                                      
                </td>                        
		    </tr>
		    <tr><td colspan="3"><asp:Label id="keyField" runat="server" visible=false /></td></tr>
    	    <tr align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=Change_Password TabIndex = 20 runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			        &nbsp;&nbsp;&nbsp;<asp:button id=Cancel runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Cancel"></asp:button>
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

