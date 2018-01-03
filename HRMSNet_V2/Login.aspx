<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="SchoolNet.Login"%>
<!DOCTYPE html> 
<HTML>
  <HEAD>
    <title>Relyon HRMS</title>
  	<link rel="stylesheet" type="text/css" href="CSS/loginstyle.css" runat="server" ></link>
    <script runat="server">

    </script>
    <style>
BODY
{
	Margin: 0px;
	padding: 0px;
	height: 100%;
	color: navy;
	background: url("Images/bg.jpg") repeat scroll 0 0 rgba(0, 0, 0, 0);
	font-family: Arial;
	margin-left:0px;
	margin-right:0px;
	margin-top:0px;
	margin-bottom:auto;	
	}
label
{
    float: left;
    margin:0;
    padding:0;
    font-size: 13px;
}
.Wrapper
{
    float: left;
    width: 100%;
}
input
{
    float: left;
}
.LoginNote {
    color: #949696;
    font-size:12px;
    margin: 3px 0;
}
.LoginNote span {
    color: #c33a1a;
    font-weight: bold;
}
.LoginArea .textfield {
    background: #ededed none repeat scroll 0 0;
    border: 1px solid #cccccc;
    padding: 5px;
    width: 220px;
}
.ProdBanner
{
    float:left;
    width:100%;
}
.TitleArea
{
    width:83%;
    float:left;
}
.TitleBar
{
    margin: 20px 7px 0 7px;
    padding: 0 25px;
    /*background-color: #0947AE;*/
    background: #e8f3f9 url("Images/menu_bg.jpg") repeat scroll 0;
    height: 35px;
}
.TitleBar span
{
    color:#FFF;
    font-size:13px;
    font-weight:bold;
    line-height:35px;
    padding:10px;
    background-color: #0947ae;
}
.LogoArea
{
    float:left;
    width:17%;
}    
.LogoArea Img
{
    float:left;
    width:100%;
    height:80px;
}    
.LoginHeading
{
     background: #e8f3f9 url("Images/login_banner_arrow.png") no-repeat scroll right 0;
    border-top: 5px solid #dde6eb;
    color: #124c8c;
    font-size: 14px;
    font-weight: bolder;
    height: 34px;
}
.Button1
{
    background: rgba(0, 0, 0, 0) url("Images/button_bg.png") no-repeat scroll 0;
    /*background-color: #e8f3f9;*/
    border: 0 none;
    color: #f8ffec;
    font-weight: bold;
    height: 36px;
    line-height: 24px;
    width: 80px;
    margin: 7px 10px;
}
.InnerWrapper
{
    float: left;
    background-color:#FFF;
    border: 3px solid #EFEFEF;
    width:99%;
}
.OuterWrapper
{   
    text-align: center;
    margin-top:0px; 
    margin-left: -125px; 
    position: absolute;
    top: 12%; left: 40%; 
    /*height:380px;*/
    background-color:#FFF;
    width:570px;
}
.ForgotArea li
{
    style:font-weight: bold; color:#357bb7; font-size:11px;
}
.ForgotArea li a
{
    style:font-weight: bold; color:#357bb7; font-size:12px;
}
.CopyrightArea
{
    background-color: #f2f6f7;
    float: left;
    padding: 0;
    width: 100%;
    text-align:center;
    color:#416287;
    font-size: 11px;
}
.ValidationArea
{
    height:21px;float:left; font-size:12px;color:#b02707;width:100%;
    line-height:15px;
}
    </style>
</head>
<body>
<form id="form1" runat="server">
<div class="OuterWrapper">
<div class="InnerWrapper">
    <div class="ProdBanner">
        <div class="TitleArea">
            <div class="TitleBar">
            <span class="ProdTitle">Welcome To Enterprise HRM Solutions</span>
            </div>
        </div>
        <div class="LogoArea">
            <IMG src="~/Images/Customer_Logo.png" runat=server  alt= "Ark HRMS">
        </div>
    </div>
    <asp:PlaceHolder ID="Login_Pane"  runat="server">
    <div class="Wrapper">
        <div class="LoginHeading">
            <span class="loginto">Login to Relyon HRMS Portal</span>
        </div>
        <div class="MainContent">
            <p class="LoginNote">(<span>CARE: </span>Your Username is  work email id. Your password is case sensitive.)</p>
            <div class="LoginArea">
                <label>Username*</label>
                <asp:textbox id=EmailAddress cssclass="textfield" TabIndex=1 Maxlength="50" width="220px" runat="server" ></asp:textbox>
                <div class="ValidationArea">
			        <asp:requiredfieldvalidator id=Req_EmailAddress runat="server" Display="Dynamic" ControlToValidate="EmailAddress"  ErrorMessage="Please enter your email address"></asp:requiredfieldvalidator>
                    <asp:RegularExpressionValidator id=RegExp_EmailAddress runat="server" Display="Dynamic" ControlToValidate="EmailAddress"  ErrorMessage="Please enter a valid email address." ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                </div>
                <label>Password*</label> 
                <asp:textbox id=Login_Password TextMode="password" cssclass="textfield" TabIndex=2 Maxlength="15" width="220px" runat="server"></asp:textbox>
                <div class="ValidationArea">
                    <asp:requiredfieldvalidator ID="Requiredfieldvalidator1"  runat="server" Display="Dynamic" TabIndex=2  ControlToValidate="Login_Password" ErrorMessage="Please enter your password"></asp:requiredfieldvalidator>
                <br />
                </div> 
                <asp:checkbox id="login_RememberMe" cssclass="textfield" style="border: 0;" visible=false Text="Remember Me next time" runat="server" />
                <asp:button id=LoginMe runat="server" CausesValidation="True" CssClass="Button1" Text="Login"></asp:button>
            </div>   
            <ul class="ForgotArea" style="float: left; line-height: 30px; margin: 30px 0 0 25px;list-style:none;">
                <li><a href="#">New User? Register here.</a></li>
                <li><a Id="A3"  href="Login.aspx?id=2">Forgot Login Password?</a></li>
            </ul>
        </div>
    </div>
    </asp:PlaceHolder>
    <!--- Forgot Password -->
    <asp:PlaceHolder ID="Tab3_Pane" runat="server" Visible=false>
    <div class="Wrapper">
        <div class="LoginHeading">
            <span class="loginto">Forgot Login Password?</span>
        </div>
        <div class="MainContent">
            <p class="LoginNote">(<span>CARE: </span>Your Username is  work email id.)</p>
            <div class="LoginArea">
                <label>Username*</label>
                <asp:textbox id=Tab3_Emailaddress cssclass="textfield" TabIndex=1 Maxlength="50" width="220px" runat="server" ></asp:textbox>
                <div class="ValidationArea">
			        <asp:requiredfieldvalidator runat="server" Display="Dynamic" ControlToValidate="Tab3_Emailaddress"  ErrorMessage="Please enter your email address"></asp:requiredfieldvalidator>
                    <asp:RegularExpressionValidator id=RegularExpressionValidator4 runat="server" Display="Dynamic" ControlToValidate="Tab3_Emailaddress"  ErrorMessage="Please enter a valid email address." ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                </div>
                <asp:button id="Tab3_Submit" runat="server" CausesValidation="True" CssClass="Button1" Text="Submit"></asp:button>
            </div>   
            <ul class="ForgotArea" style="float: left; line-height: 30px; margin: 30px 0 0 25px;list-style:none;">
                <li><asp:HyperLink ID="HyperLink1" runat="server" Text="Click here to Login" NavigateUrl="login.aspx" /></li>
            </ul>

        </div>
    </div>	
     </asp:placeholder>   
         <!-- Change Password -->
     <asp:PlaceHolder id=ChangePassword Runat="server" visible="false">
        <div class="Wrapper">
        <div class="LoginHeading">
            <span class="loginto">Change Login Password?</span>
        </div>
        <div class="MainContent">
            <p class="LoginNote">(<span>CARE: </span>Your Current password has expired! Please note the password setup rules.)</p>
            <ul class="ForgotArea" style="float: left; line-height: 15px; margin: 5px 0 0 5px;">
                <li style="text-align:left;color: #949696;">New Password can't be same as current password.</li>
                <li style="text-align:left;color: #949696;">Password length should be greater than 8 and less than 15 characters.</li>
                <li style="text-align:left;color: #949696;">Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]</li>
            </ul>
            <div class="LoginArea">
                <label>Current Password*</label>
                <asp:textbox id="Tab1_password"   TextMode="Password"  TabIndex=1 cssclass="textfield" Maxlength="15" runat="server"></asp:textbox>
                <div class="ValidationArea">
			        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat=server Display="Dynamic" ControlToValidate=Tab1_password  ErrorMessage="Current Password is Required." />

                </div>
                <label>New Password*</label>
                <asp:textbox id="Tab1_NewPassword"   TextMode="Password"  TabIndex=2 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox>
                <div class="ValidationArea">
			        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat=server Display="Dynamic" ControlToValidate=Tab1_NewPassword  ErrorMessage="New Password is Required." />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"  runat=server Display="Dynamic" ControlToValidate=Tab1_NewPassword  ValidationExpression="(?=^.{8,15}$)(?=.*\d)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ErrorMessage="Please set the password as per rules" />
                </div>
                <label>Confirm Password*</label>
                <asp:textbox id="Tab1_ConfirmNewPassword"   TextMode="Password"  TabIndex=3 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox>
                <div class="ValidationArea">
			        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat=server Display="Dynamic" ControlToValidate=Tab1_ConfirmNewPassword  ErrorMessage="Confirm Password is Required." />
                    <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ErrorMessage="New and Confirm New Passwords do not match!"  ControlToValidate="Tab1_ConfirmNewPassword"  ControlToCompare="Tab1_NewPassword"></asp:CompareValidator>
                </div>

                <asp:button id=Change_Password runat="server" CausesValidation="True" CssClass="Button1" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;
	            <asp:button id=Button1 runat="server" CausesValidation="false" CssClass="Button1" Text="Cancel"></asp:button>
                <div class="ValidationArea">
                    <asp:Label id="Tab1_keyField" runat="server" visible=false />
                </div>
            </div>   
            <ul class="ForgotArea" style="float: left; line-height: 30px; margin: 30px 0 0 25px;list-style:none;">
                <li><asp:HyperLink runat="server" Text="Click here to Login" NavigateUrl="login.aspx" /></li>
            </ul>

        </div>
    </div>	
  
   </asp:placeholder>
   <div class="ValidationArea"><asp:label id=errorMessage Runat="server" Visible="false"></asp:label></div>
    <div class="CopyrightArea"><p>ARK HRMS Rel Version 2.1 Copyright © 2014 Shift2Net Solutions.All Rights Reserved.</p></div>    
</div>

</div>




	
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
   	

  
     
       	    
    
</table>

 
</div>
</form>
</body>
</HTML>





