<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of Login.aspx.cs" Inherits="SchoolNet.Login"%>
<!DOCTYPE html> 
<HTML>
  <HEAD>
    <title>Relyon HRMS</title>
  	<link rel="stylesheet" type="text/css" href="CSS/loginstyle.css" runat="server" ></link>
    <script runat="server">

    </script>
</head>
<body>
<form id="form1" runat="server">
<div class="Wrapper">
<table cellspacing="0" cellpadding="1" id="login1" class="ContentArea">
    <tr><td align="left" align="center"><center><IMG height="80" src="images/ArkLogo2.jpg"  alt= "Ark HRMS" width="230"></center></td>
    </tr>
    <asp:PlaceHolder ID="Login_Pane"  runat="server">
	<tr>		
		<td><table cellpadding="0" border="0" width="510px" >
			<tr class="LoginTitle"><td align="center" colspan="2"><span>Login to Enterprise HRM Solutions</span></td></tr>
			<tr><td colspan="2">&nbsp;</td></tr>
			<tr>
				<td align="left" class="mainheadtxt" width="22%"><Label for="login_UserName">Email Address&nbsp;&nbsp;</label></td>
				<td align="left" class="mainheadtxt"><asp:textbox id=EmailAddress cssclass="textfield" TabIndex=1 Maxlength="50" width="220px" runat="server" ></asp:textbox></td>
			</tr>
			<tr><td>&nbsp;</td>
			    <td class="validationtxt" align="left">
			         <asp:requiredfieldvalidator id=Req_EmailAddress runat="server" Display="Dynamic" ControlToValidate="EmailAddress"  ErrorMessage="Please enter your email address"></asp:requiredfieldvalidator>
	                <br /> <asp:RegularExpressionValidator id=RegExp_EmailAddress runat="server" Display="Dynamic" ControlToValidate="EmailAddress"  ErrorMessage="Please enter a valid email address." ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                </td>
     	    </tr>
     	    <tr>
     	        <td align="left" class="mainheadtxt"><label for="login_Password">Password&nbsp;&nbsp;</label></td>
				<td align="left" class="mainheadtxt"><asp:textbox id=Login_Password TextMode="password" cssclass="textfield" TabIndex=2 Maxlength="15" width="220px" runat="server"></asp:textbox></td>
            </tr>
            <tr>
                <td>&nbsp;</td> 	
                <td class="validationtxt" align="left"><asp:requiredfieldvalidator ID="Requiredfieldvalidator1"  runat="server" Display="Dynamic" TabIndex=2  ControlToValidate="Login_Password" ErrorMessage="Please enter your password"></asp:requiredfieldvalidator></td>
            </tr>  
			<tr><td colspan="2">&nbsp;</td></tr>
			<tr><td colspan="2" align="left" class="mainheadtxt"><asp:checkbox id="login_RememberMe" cssclass="textfield" style="border: 0;" visible=false Text="Remember Me next time" runat="server" /></td></tr>
			<tr><td colspan="2"><center><asp:button id=LoginMe runat="server"  BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Login"></asp:button></center></td></tr>
		    <tr><td colspan="2">&nbsp;</td></tr>
		 </table>
		</td>
	</tr>
	</asp:PlaceHolder>
	<!--- Account Sign Up -->
	 <asp:PlaceHolder ID="Account_Signup" runat="server" Visible=false>	
		<tr>		
		    <td><table cellpadding="0" border="0" width="540px" >
			    <tr><td align="center" colspan="2" class="colheader"> New Employee Sign up</td></tr>
			    <tr><td colspan="2">&nbsp;</td></tr>
			    <tr>
				    <td align="left" class="mainheadtxt" width="28%"><Label for="Employee_Id">Employee ID&nbsp;&nbsp;</label></td>
				    <td align="left" class="mainheadtxt"><asp:textbox id=Signup_EmployeeID cssclass="textfield" TabIndex=1 Maxlength="20" Width="200px" runat="server" ></asp:textbox></td>
                </tr>
                <tr> <td>&nbsp;</td> 
                    <td class="validationtxt" align="left"><asp:requiredfieldvalidator ID="Requiredfieldvalidator2" runat="server" ControlToValidate="Signup_EmployeeID" ErrorMessage="Please Enter Your Employee ID"></asp:requiredfieldvalidator></td>
                
                </tr>       
	                                     
            
			    <tr>
				    <td align="left" class="mainheadtxt" width="22%"><Label for="login_UserName">Email Address&nbsp;&nbsp;</label></td>
				    <td align="left" class="mainheadtxt"><asp:textbox id=Signup_UserName cssclass="textfield" TabIndex=2 Maxlength="50" Width="200px" runat="server" ></asp:textbox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="validationtxt" align="left"><asp:requiredfieldvalidator  runat="server" ControlToValidate="Signup_UserName" Display="Dynamic" ErrorMessage="Please Enter Your Email Address"></asp:requiredfieldvalidator>
	                                       <br />   <asp:RegularExpressionValidator  runat="server" ControlToValidate="Signup_UserName"  Display="Dynamic" ErrorMessage="Please Enter Valid Email Address." ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                    </td>
     	        </tr>
     	         
     	        <tr>
     	            <td align="left" class="mainheadtxt"><label for="login_Password">Password&nbsp;&nbsp;</label></td>
				    <td align="left" class="mainheadtxt"><asp:textbox id=Signup_Password TextMode="password" cssclass="textfield" TabIndex=3 Maxlength="15" Width="200px" runat="server"></asp:textbox></td>
                 </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td class="validationtxt" align="left"><asp:requiredfieldvalidator  runat="server"  ControlToValidate="Signup_Password"  Display="Dynamic" ErrorMessage="Please Enter Your Password"></asp:requiredfieldvalidator>
                                                  <br />   <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  runat=server Display="Dynamic" ControlToValidate=Signup_Password  ValidationExpression="(?=^.{8,15}$)(?=.*\d)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ErrorMessage="Password length should be greater than 8 and less than 15 characters. Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]." />
                    </td>
                </tr> 
                
     	        <tr>
     	            <td align="left" class="mainheadtxt"><label for="login_Password">Confirm Password&nbsp;&nbsp;</label></td>
				    <td align="left" class="mainheadtxt"><asp:textbox id=Signup_ConfirmPassword TextMode="password" cssclass="textfield" TabIndex=4 Maxlength="15"  Width="200px" runat="server"></asp:textbox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="validationtxt" align="left"><asp:requiredfieldvalidator runat="server"  ControlToValidate="Signup_ConfirmPassword" Display="Dynamic" ErrorMessage="Please Enter Confirm Password"></asp:requiredfieldvalidator>
                                          <br />    <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Passwords do not match!"  Display="Dynamic" ControlToValidate="Signup_ConfirmPassword" ControlToCompare="Signup_Password"></asp:CompareValidator>
                    </td>
              </tr>              
			  
			  <tr><td colspan="2"><center><asp:button id="SignMeUp" runat="server"  BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Submit"></asp:button>
			                    &nbsp;&nbsp;&nbsp;<asp:button id=Cancel runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Cancel"></asp:button>
			                 </center></td>
		      </tr>
		      <tr><td colspan="2">&nbsp;</td></tr>
	       </table>
	    </td>
	    </tr>
	</asp:PlaceHolder>
   <!--- Forgot Password -->	
	<asp:PlaceHolder ID="Tab3_Pane" runat="server" Visible=false>	
	<tr>		
		<td>
		   <table cellpadding="0" border="0" width="510px" >
			    <tr><td align="center" colspan="3" class="colheader"> Forgot Password?</td></tr>
			    <tr><td colspan="2">&nbsp;</td></tr>
			    <tr><td align="right" class="mainheadtxt" width="25%"><Label for="Employee_Id">Email Address:&nbsp;&nbsp;</label></td>
				    <td align="left" class="mainheadtxt" ><asp:textbox id=Tab3_Emailaddress cssclass="textfield" TabIndex=1 Maxlength="50" Width="250px" runat="server" ></asp:textbox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="validationtxt" align="left"><asp:requiredfieldvalidator  runat="server" ControlToValidate="Tab3_Emailaddress" ErrorMessage="Please Enter Email Address"></asp:requiredfieldvalidator>
	                                   <br />   <asp:RegularExpressionValidator runat="server" ControlToValidate="Tab3_Emailaddress" Display="Dynamic" ErrorMessage="Please Enter Valid Email Address" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                    </td>
     	        </tr>
			    <tr><td colspan="2"><center><asp:button id="Tab3_Submit" runat="server"  BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Submit"></asp:button></center></td></tr>
     	   </table>
     	 </td>
     </tr>
     </asp:placeholder>   
     <!-- Change Password -->
     <asp:PlaceHolder id=ChangePassword Runat="server" visible="false">
     <tr><td>
	  <table cellpadding="0" border="0" width="630px" >    
		     <tr><td colspan="2" class="colheader">&nbsp;</td></tr>
		     <tr>
		        <td class="mainheadtxt" colspan="2" align="left">Your Current password has expired!.Please change it before logging into the system.<br /><br />
		        New Password can't be same as current password.Password length should be greater than 8 and less than 15 characters. Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]</td>  
		     </tr>
		     <tr><td colspan="2">&nbsp;</td></tr>
		     <tr>
			    <td align="left" class="mainheadtxt" width="25%">Current Password</td>
   			    <td align="left" class="mainheadtxt"><asp:textbox id="Tab1_password"   TextMode="Password"  TabIndex=1 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat=server ControlToValidate=Tab1_password  ErrorMessage="Current Password is Required." /></td>	    		 
             </tr>
             <tr><td colspan="2">&nbsp;</td></tr>
		     <tr>
			    <td align="left" class="mainheadtxt">New Password</td>
   			    <td align="left" class="mainheadtxt"><asp:textbox id="Tab1_NewPassword"   TextMode="Password"  TabIndex=2 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat=server ControlToValidate=Tab1_NewPassword  ErrorMessage="New Password is Required." /></td>	    		 
             </tr>
             <tr><td>&nbsp;</td>
                <td class="validationtxt"><asp:RegularExpressionValidator ID="RegularExpressionValidator2"  runat=server ControlToValidate=Tab1_NewPassword  ValidationExpression="(?=^.{8,15}$)(?=.*\d)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ErrorMessage="Password length should be greater than 8 and less than 15 characters. Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]." /></td>                        
		    </tr>
		    <tr>
			    <td align="left" class="mainheadtxt">Confirm New Password</td>
   			    <td align="left" class="mainheadtxt"><asp:textbox id="Tab1_ConfirmNewPassword"   TextMode="Password"  TabIndex=3 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat=server ControlToValidate=Tab1_ConfirmNewPassword  ErrorMessage="Confirm Password is Required." /></td>	    		 
            </tr>
             <tr><td>&nbsp;</td>
                <td class="validationtxt"><asp:CompareValidator ID="CompareValidator2"   runat="server" ErrorMessage="New and Confirm New Passwords do not match!"  ControlToValidate="Tab1_ConfirmNewPassword"  ControlToCompare="Tab1_NewPassword"></asp:CompareValidator></td>                        
		    </tr>
		    <tr><td colspan="2"><asp:Label id="Tab1_keyField" runat="server" visible=false /></td></tr>
    	    <tr align=center>
			    <td  valign="middle" colspan="2"><center><asp:button id=Change_Password TabIndex = 20 runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			        &nbsp;&nbsp;&nbsp;<asp:button id=Button1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Cancel"></asp:button>
			</center>
			</td>
            </tr>			        
	    </table>
	   </td>
     </tr>  
   </asp:placeholder>
 
     
       	    
	<tr><td><asp:label id=errorMessage Runat="server" Visible="false"></asp:label></td></tr>
    <tr><td class="colheader"><asp:HyperLink ID="HyperLink1" runat="server" Text="Click here to log in" NavigateUrl="login.aspx" />    
         <A Id="A3" href="Login.aspx?id=2" style="color: white;font-weight:bold;font-size:11pt"><b>Forgot Password?</b></A></td></tr>
</table>

 <p style="text-align:center;color:White;font-size:9pt">ARK HRMS Rel Version 2.1 Copyright © 2014 Shift2Net Solutions.All Rights Reserved.</p>
</div>
</form>
</body>
</HTML>





