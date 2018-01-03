<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="SchoolNet.AddEmployee" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--    Edit Employee Data Area -->
 <tr><td width="100%">
  <asp:PlaceHolder id=EditArea Runat="server" visible="true">
	  <table width="100%" border="0"><tr><td class="colheader" colspan="5"><span class="maintitledesign">Add New Employee Information<span></td></tr>
      </table>
	  <table width="99%" border="0" class="Partgrayblock">    
             <tr><td colspan="5">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt" colspan="2">Employee Name(Saluation,First Name,Mid Initial & Last Name)<font color="red">*</font></td>
			    <td class="mainheadtxt">Date of Birth<font color="red">*</font></td>
			    <td class="mainheadtxt">Gender Type<font color="red">*</font></td>
			    <td class="mainheadtxt">Marital Status<font color="red">*</font></td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt" colspan="2">
			                            <asp:dropdownlist id="Tab1_SaluationType"  TabIndex=1 AutoPostBack=false runat="server" Width="70px" CssClass="textfield"></asp:dropdownlist>
			                            <asp:textbox id=Tab1_FName   cssclass="textfield"   TabIndex=2 Maxlength="50" width="180px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_MidName cssclass="textfield"   TabIndex=3 width="40px"  Maxlength="15" runat="server" ></asp:textbox>
			                            <asp:textbox id=Tab1_LName   cssclass="textfield"   TabIndex=4 Maxlength="50" width="180px" runat="server" ></asp:textbox>
			    </td> 
			    <td class="mainheadtxt"><asp:textbox id=Tab1_DOB  cssclass="textfield"   TabIndex=5 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_GenderType"  TabIndex=6 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>		    	    
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_MaritalStatus" TabIndex=7 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>
		     <tr>
                <td class="validationtxt">
                    <asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_FName  ErrorMessage="Employee First Name is required." />
                    <asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_LName  ErrorMessage="Employee Last Name is required." /></td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_SaluationType display="dynamic" InitialValue="-1" ErrorMessage="Salutation Type is required." /></td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DOB  display="dynamic" ErrorMessage="DOB is required." />
                                        <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" display="dynamic"  ErrorMessage="Please enter date in dd/mm/yyyy format" ControlToValidate="Tab1_DOB" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}"> </asp:RegularExpressionValidator>
                
                </td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_GenderType display="dynamic" InitialValue="-1" ErrorMessage="Gender Type is required." /></td>
                  <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_MaritalStatus display="dynamic" InitialValue="-1" ErrorMessage="Marital Status is Required." /></td>                        
 		    </tr>
		    <tr>
			    <td class="mainheadtxt">Hire Date<font color="red">*</font></td>
			    <td class="mainheadtxt">Employee ID(Auto Assign)</td>
			    <td class="mainheadtxt">Peoplesoft Employee ID<font color="red">*</font></td>
			    <td class="mainheadtxt">Employee Category<font color="red">*</font></td>
			    <td class="mainheadtxt">Employement Status<font color="red">*</font></td>
		    </tr>
 	        <tr>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HireDate    TabIndex=8 cssclass="textfield"   Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_EmployeeID  disabled=true TabIndex=9 cssclass="textfield"   Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PSEmployeeID   TabIndex=10 cssclass="textfield"   Maxlength="30" runat="server" ></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_EmpCategory" TabIndex=10 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
  			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_EmpStatus" TabIndex=11 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>	
		     <tr>              
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_HireDate   display="dynamic" ErrorMessage="Hire Date is Required." />
                                 <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" display="dynamic"  ErrorMessage="Please enter date in dd/mm/yyyy format" ControlToValidate="Tab1_HireDate" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}"> </asp:RegularExpressionValidator>
                 </td>                        
                <td class="validationtxt">&nbsp;</td>                                 
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_PSEmployeeID display="dynamic" ErrorMessage="Peoplesoft Employee ID is Required." /></td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EmpStatus InitialValue="-1" ErrorMessage="Employement Status is Required." /></td>                        
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EmpCategory display="dynamic" InitialValue="-1" ErrorMessage="Employee Category is Required." /></td>                                        
 		    </tr>
 		    
		    <tr>
		    	<td class="mainheadtxt">Business Unit<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit Location<font color="red">*</font></td>
			    <td class="mainheadtxt">Department<font color="red">*</font></td>
			    <td class="mainheadtxt">Supervisor<font color="red">*</font></td>
	    	    <td class="mainheadtxt">Designation<font color="red">*</font></td>
			    
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Division" TabIndex=12 AutoPostBack=true onselectedindexchanged="Tab1_Division_SelectedIndexChanged" runat="server" Width="200px" CssClass="textfield"></asp:dropdownlist></td> 	        
 	            <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Location" TabIndex=13 AutoPostBack=false runat="server" Width="190px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Department" TabIndex=14 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td> 
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Supervisor" TabIndex=15 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td> 	            			    	            
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Designation" TabIndex=16 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>	
		     <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Division InitialValue="-1" ErrorMessage="Business Unit is Required." /></td>    
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Location InitialValue="-1" ErrorMessage="Location is Required." /></td>                                                            
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Department InitialValue="-1" ErrorMessage="Department is Required." /></td>  
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Supervisor InitialValue="-1"  ErrorMessage="Supervisior is Required." /></td>                                                              
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Designation InitialValue="-1"  ErrorMessage="Designation is Required." /></td>                                        

 		    </tr>
            <tr>
			    <td class="mainheadtxt" colspan="2">Home Address<font color="red">*</font></td>
			    <td class="mainheadtxt">City<font color="red">*</font></td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt" colspan="2"><asp:textbox id=Tab1_HAddress1 cssclass="textfield" TabIndex=17 Maxlength="50" width="225px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_HAddress2 cssclass="textfield" TabIndex=18 Maxlength="50" width="225px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HCity  cssclass="textfield" TabIndex=19 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HState  cssclass="textfield" TabIndex=20 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_CountryDDList" TabIndex=21 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		    <tr>
		        <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_HAddress1  ErrorMessage="Home Address is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_HCity  ErrorMessage="City is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab1_CountryDDList  InitialValue="-1" ErrorMessage="Country is reqired." /></td> 		    
		    </tr>
	        <tr>
			    <td class="mainheadtxt" colspan="2">Work Address<font color="red">*</font></td>
			    <td class="mainheadtxt">City<font color="red">*</font></td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt" colspan="2"><asp:textbox id=Tab1_WAddress1 cssclass="textfield" TabIndex=22 Maxlength="50" width="225px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_WAddress2 cssclass="textfield" TabIndex=23 Maxlength="50" width="225px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WCity cssclass="textfield" TabIndex=24  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WState  cssclass="textfield" TabIndex=25 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_WCountryDDList"  TabIndex=26 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		     <tr>
		        <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WAddress1  ErrorMessage="Work Address is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WCity  ErrorMessage="Work City is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab1_WCountryDDList  InitialValue="-1" ErrorMessage="Country is reqired." /></td> 		    
		    </tr>

		    <tr>
			    <td class="mainheadtxt">Home Telephone<font color="red">*</font></td>
			    <td class="mainheadtxt">Work Telephone<font color="red">*</font></td>
			    <td class="mainheadtxt">Mobile</td>
			    <td class="mainheadtxt">Work Email<font color="red">*</font></td>
			    <td class="mainheadtxt">Education<font color="red">*</font></td>
		    </tr>
		    <tr>		 
			    <td class="mainheadtxt"><asp:textbox id=Tab1_HPhone  cssclass="textfield" TabIndex=27 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WPhone  cssclass="textfield" TabIndex=28 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Mobile  cssclass="textfield" TabIndex=29 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_WorkEmail cssclass="textfield" TabIndex=30  Maxlength="50" width="180px" runat="server"></asp:textbox></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Education" TabIndex=31 AutoPostBack=false runat="server" Width="190px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>
		     <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_HPhone  ErrorMessage="Home Phone is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WPhone  ErrorMessage="Work Phone is required." /></td>                           
                <td class="validationtxt"></td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab1_WorkEmail ErrorMessage="Work Email Address is reqired." />
                                          <asp:RegularExpressionValidator runat="server" ControlToValidate=Tab1_WorkEmail ErrorMessage="Email Address format is invaid." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" />
                </td> 
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Education InitialValue="-1" ErrorMessage="Education is Required." /></td>                        		    
		    </tr>
 		    		    
		    <tr>
			    <td class="mainheadtxt">Probation Period(Months)</td>
			    <td class="mainheadtxt">&nbsp;</td>
			    <td class="mainheadtxt" colspan="3">Photo profile <small>(Accepts jpg, .png, .gif up to 1MB. Recommended Size:200px X 200px)</small></td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Probation   cssclass="textfield"   TabIndex=31 Maxlength="10" width="120px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt">&nbsp;</td>
			    <td class="mainheadtxt" colspan="3"><input id="Tab1_ProfilePhoto" type="file" TabIndex=32 class="textfield" width="180px" runat="server" size="50"></td>			    
		    </tr>	
		     <tr>
		        <td class="validationtxt" colspan="2">
		                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"  ControlToValidate="Tab1_Probation" ErrorMessage="Value must be a whole number" />
		     
		        </td>
		        <td class="validationtxt" colspan="3"></td>
		     </tr>
 		    
 		     		    
		        <tr>
			        <td class="mainheadtxt">HR System User Name<br />(<small>Work Email address recommended)</small><font color="red">*</font></td>
			        <td class="mainheadtxt">Access Level<font color="red">*</font></td>
			        <td class="mainheadtxt">Temp Password<font color="red">*</font></td>
			        <td class="mainheadtxt">Confirm Password<font color="red">*</font></td>
			        <td class="mainheadtxt">Account Status</td>
		        </tr>
 	            <tr>
			        <td class="mainheadtxt"><asp:textbox id=Tab1_UserName      TabIndex=33 cssclass="textfield" Maxlength="50" width="180px" runat="server" ></asp:textbox></td>
			        <td class="mainheadtxt"><asp:dropdownlist id=Tab1_AccessLevel    TabIndex=34 AutoPostBack=false runat="server" Width="190px" CssClass="textfield" ></asp:dropdownlist></td>			        
			        <td class="mainheadtxt"><asp:textbox id=Tab1_password   TextMode="Password"  TabIndex=35 cssclass="textfield" Maxlength="15" runat="server" ></asp:textbox></td>
			        <td class="mainheadtxt"><asp:textbox id=Tab1_ConfirmPassword TextMode="Password"  TabIndex=36 cssclass="textfield"  Maxlength="15" runat="server" ></asp:textbox></td>
			        <td class="mainheadtxt"><asp:RadioButton ID="RadioButton1" runat="server" Text="Enabled" value ="1" Checked=true GroupName="AccountStatus" AutoPostBack="false" />  
                                            &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text="Disabled"  value = "0" GroupName="AccountStatus" AutoPostBack="false" /> 
                                            
			        </td>
		        </tr>	
	            <tr>
	                <td class="validationtxt"><asp:RequiredFieldValidator runat=server Display="Dynamic" ControlToValidate=Tab1_UserName ErrorMessage="User Name is required." /> 
	                                            <asp:RegularExpressionValidator id=RegExp_EmailAddress runat="server" Display="Dynamic" ControlToValidate="Tab1_UserName"  ErrorMessage="Please enter a valid email address." ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator></td>
	                                                                  		    
                    <td class="validationtxt"><asp:RequiredFieldValidator runat=server Display="Dynamic" ControlToValidate=Tab1_AccessLevel InitialValue=-1 ErrorMessage="Access Level is required." />                        
                    <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_password  ValidationExpression="(?=^.{8,15}$)(?=.*\d)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ErrorMessage="Password length should be greater than 8 and less than 15 characters. Password should contain at least one digit [0-9], one alphabet [A-Z] [a-z] and one special character such as [@#&*!]." /> </td>                        
                    <td class="validationtxt"><asp:CompareValidator      runat="server" ErrorMessage="Passwords do not match!"  ControlToValidate="Tab1_ConfirmPassword"  ControlToCompare="Tab1_password"></asp:CompareValidator></td>
                    <td class="validationtxt"></td>
 		        </tr>
 	   		 	   		    
    	    <tr><td colspan="5">&nbsp;</td></tr>
            	
            <tr class="PartButtons" align=center>
			<td  colspan="5">
			<center>
			    <asp:button id=Save_Employee runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
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

