<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateEmployeeProfile.aspx.cs" Inherits="SchoolNet.UpdateEmployeeProfile" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
<tr><td class="colheader"><span class="maintitledesign">Update Employee Information</span></td></tr>
  <!--    Edit Employee Data Area -->
 <tr><td width="100%">
  <asp:PlaceHolder id=EditArea Runat="server" visible="true">
 
	  <table width="100%" border="0" class="Partgrayblock"> 
    
		     <tr><td colspan="4">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt">Employee Name(First,Mid & Last Names)</td>			    
			    <td class="mainheadtxt">Marital Status<font color="red">*</font></td>
			    <td class="mainheadtxt">Education<font color="red">*</font></td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt">
			                            <asp:dropdownlist id="Tab1_SaluationType"   ReadOnly=true AutoPostBack=false runat="server" Width="70px" CssClass="textfield"></asp:dropdownlist>
			                            <asp:textbox id=Tab1_FName   cssclass="textfield"  ReadOnly=true  Maxlength="30" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_MidName cssclass="textfield"  ReadOnly=true  width="70px"  Maxlength="15" runat="server" ></asp:textbox>
			                            <asp:textbox id=Tab1_LName   cssclass="textfield"  ReadOnly=true  Maxlength="30" runat="server" ></asp:textbox>
			                            <asp:Label id="Tab1_KeyField" runat="server" visible=false />
			    </td>			   
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_MaritalStatus" TabIndex=1 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Education" TabIndex=2 AutoPostBack=false runat="server" Width="190px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt">&nbsp;</td>		    	    
		    </tr>
		    <tr>
  			    <td class="mainheadtxt"></td>
			    <td class="mainheadtxt"></td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_MaritalStatus InitialValue="-1" ErrorMessage="Marital Status is Required." /></td>                        
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Education InitialValue="-1" ErrorMessage="Education is Required." /></td>                        
 		    </tr>	
		   
            <tr>
			    <td class="mainheadtxt">Home Address<font color="red">*</font></td>
			    <td class="mainheadtxt">City<font color="red">*</font></td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HAddress1 cssclass="textfield" TabIndex=4 Maxlength="50" width="160px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_HAddress2 cssclass="textfield" TabIndex=5 Maxlength="50" width="160px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HCity  cssclass="textfield" TabIndex=6 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HState  cssclass="textfield" TabIndex=7 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_CountryDDList" TabIndex=8 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		    <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_HAddress1  ErrorMessage="Home Address is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_HCity  ErrorMessage="City is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab1_CountryDDList  InitialValue="-1" ErrorMessage="Country is reqired." /></td> 		    
		    </tr>
	        <tr>
			    <td class="mainheadtxt">Work Address<font color="red">*</font></td>
			    <td class="mainheadtxt">City<font color="red">*</font></td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WAddress1 cssclass="textfield" TabIndex=9 Maxlength="50" width="160px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_WAddress2 cssclass="textfield" TabIndex=10 Maxlength="50" width="160px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WCity cssclass="textfield" TabIndex=11  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WState  cssclass="textfield" TabIndex=12 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_WCountryDDList"  TabIndex=13 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		     <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WAddress1  ErrorMessage="Work Address is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WCity  ErrorMessage="Work City is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab1_WCountryDDList  InitialValue="-1" ErrorMessage="Country is reqired." /></td> 		    
		    </tr>

		    <tr>
			    <td class="mainheadtxt">Home Telephone<font color="red">*</font></td>
			    <td class="mainheadtxt">Work Telephone<font color="red">*</font></td>
			    <td class="mainheadtxt">Mobile</td>
			    <td class="mainheadtxt">Work Email<font color="red">*</font></td>
		    </tr>
		    <tr>		 
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HPhone  cssclass="textfield" TabIndex=14 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WPhone  cssclass="textfield" TabIndex=15 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Mobile  cssclass="textfield" TabIndex=16 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WorkEmail cssclass="textfield" TabIndex=17  Maxlength="50" width="150px" runat="server"></asp:textbox></td>
		    </tr>
		     <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_HPhone  ErrorMessage="Home Phone is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WPhone  ErrorMessage="Work Phone is required." /></td>                           
                <td class="validationtxt"></td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab1_WorkEmail ErrorMessage="Work Email Address is reqired." />                   
                                           <asp:RegularExpressionValidator runat="server" ControlToValidate=Tab1_WorkEmail ErrorMessage="Email Address format is invaid." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" />                       
                </td> 		    
		    </tr>
            <tr>
			    <td class="mainheadtxt" colspan="3">Profile Photo  <small>(Accepts jpg, .png, .gif up to 1MB. Recommended dimensions: 200px X 200px)</small></td>
			    
		    </tr>
 	        <tr>
			     <td class="mainheadtxt" colspan="3"><input id="Tab1_ProfilePhoto" type="file" TabIndex=3 class="textfield"  runat="server" size="50"></td>
			     
		    </tr>
	        <tr><td colspan="4">&nbsp;</td></tr>
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Save_Employee runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    
			</center>
			</td>	
            </tr>

            <tr><td colspan="4">&nbsp;</td></tr>	        
	    </table>
	    
 </asp:placeholder>
</td>
</tr>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
										
</master:content>

