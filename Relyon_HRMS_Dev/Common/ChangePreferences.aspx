<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePreferences.aspx.cs" Inherits="SchoolNet.ChangePreferences" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--    Edit Employee Data Area -->
 <tr><td width="100%">
  <asp:PlaceHolder id=EditArea Runat="server" visible="true">
 <fieldset><Legend>Change My Preferences</Legend>		
	  <table width="100%" border="0" class="Partgrayblock">    
		     <tr><td colspan="3">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt" colspan="2" width="45%">Email Alerts to Business Process Tasks and Notifications</td>
			    <td align="left" ><asp:CheckBox ID="Tab1_ApprCheckBox1" TabIndex=1 runat="server" Text="" ></asp:CheckBox></td>
		    </tr>	
		     <tr><td colspan="3">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt" colspan="2">Email Address for Business Process Notification</td>
			    <td><asp:textbox  id=Tab1_EmailAddress  cssclass="textfield" TabIndex=2  Maxlength="50" width="250px" runat="server"></asp:textbox></td>
		    </tr>
		    <tr><td colspan="3">&nbsp;</td></tr>	
		     <tr>
			    <td class="mainheadtxt" colspan="2">Mobile Phone for Business Process or Emergency Contact</td>
			    <td><asp:textbox  id=Tab1_EmergencyPhone cssclass="textfield" TabIndex=3  Maxlength="30" width="150px" runat="server"></asp:textbox></td>
		    </tr>	
            <tr><td colspan="3">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt" colspan="2">No of Days to show the completed requests in your request tab</td>
			    <td><asp:textbox  id=Tab1_PersistDays cssclass="textfield" TabIndex=4  Maxlength="30" width="30px"  runat="server"></asp:textbox></td>
		    </tr>	

		    <tr><td colspan="3">&nbsp;</td></tr>
		    <tr><td colspan="3"><asp:Label id="keyField" runat="server" visible=false /></td></tr>
    	    <tr align=center>
			    <td  valign="middle" colspan="3"><center><asp:button id=Save_Preference TabIndex = 20 runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			        
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


