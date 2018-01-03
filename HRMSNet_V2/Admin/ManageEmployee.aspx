<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageEmployee.aspx.cs" Inherits="SchoolNet.ManageEmployee" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--   Search Box -->
 <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
    <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Employee Information Management</span></td>
	</tr>	
    
	<asp:PlaceHolder id=searchDataArea Runat="server">
<tr width="100%">
  <td>
  <div class="ManageEmpGrid">
  <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4"  GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnSorting="Grid_SortCommand" OnEditCommand="Grid_EditCommand">
                           
              <Columns>

                    <asp:TemplateColumn HeaderText="Employee ID" ItemStyle-Width="10%" SortExpression="Employee_ID">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage employee information"> <%# Eval("Employee_ID")%></asp:LinkButton>                                                                 
                                </ItemTemplate>
                    </asp:TemplateColumn>
                    
                    <asp:TemplateColumn HeaderText="Employee Name" ItemStyle-Width="18%" SortExpression="Name">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit"  CausesValidation="false" runat="server" ToolTip="Click to manage employee information"> <%# Eval("Name")%></asp:LinkButton>                                                                 
                                </ItemTemplate>
                    </asp:TemplateColumn>
                    
                    <asp:BoundColumn HeaderText="Job Title" DataField="Designation" SortExpression="Designation" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Supervisor" DataField="LineManager"  SortExpression="LineManager" ItemStyle-Width="15%"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Status" DataField="EmpStatusName" SortExpression="EmpStatusName" ItemStyle-Width="6%" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" SortExpression="DivisionName" ItemStyle-Width="12%" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Location" DataField="DivisionLocation" SortExpression="DivisionLocation" ItemStyle-Width="9%" ></asp:BoundColumn>                    
                    <asp:BoundColumn HeaderText="Department" DataField="DeptName" SortExpression="DeptName" ItemStyle-Width="15%"> </asp:BoundColumn>
                   


               </Columns>  
               
   
                <FooterStyle CssClass="EmpsFooter" />
                <SelectedItemStyle CssClass="EmpsSelectedItem" />
                <PagerStyle CssClass="EmpsPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="EmpsAltItem" />
                <ItemStyle CssClass="EmpsItem" />
                <HeaderStyle CssClass="EmpsHeader" />
</asp:DataGrid>
</br>
<center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>
</div>
</td>    
</tr>

</ASP:PlaceHolder>

    <tr>
		<td>
		    <table width="99%" border="0" class="Partgrayblock">
    	<tr class="PartWhite" align=center>
            <td valign="left" class="mainheadtxt">&nbsp;&nbsp;
                <a id="adv_search" href="#" runat="server"><IMG src="~/images/buttons/blue_adv_search.jpg" runat="server" alt="Advanced Search" title="Advanced Search" height="27" width="28" style="float:left;">
                <span style="text-decoration:underline;color:#FFF;float:left;margin:0;padding:5px 0 0 0;">Advanced Search</span></a>
            </td>
			<td  align="right" colspan="2" class="mainsearchtxt">
            Employee ID&nbsp;<asp:textbox id=empID cssclass="textfield" Maxlength="30" runat="server"></asp:textbox>
			</td>
			<td class="mainheadtxt" align=left>
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
                <asp:ImageButton id=Search runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_search.png" ToolTip="Search" alt="Search" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>&nbsp
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
			    <asp:ImageButton id=Reset runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_reset.png" ToolTip="Reset" alt="Reset" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>&nbsp;
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
                <asp:ImageButton id=Export runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_export2.png" ToolTip="Export" alt="Export" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>&nbsp;  
                <IMG src="~/images/buttons/separator.png" runat="server" alt= "" height="30" width="2" style="vertical-align:bottom;"/>&nbsp;                
            </td>
        </tr>	
		    <tr>
			    <td class="mainheadtxt">Employee Name</td>
			    <td class="mainheadtxt">Supervisor Name</td>
			    <td class="mainheadtxt">Employement Status</td>
                <td class="mainheadtxt"></td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=empName  cssclass="textfield" Maxlength="50" width="180px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=mgrName cssclass="textfield" Maxlength="50" width="180px" runat="server"></asp:textbox></td>
  			    <td class="mainheadtxt"><asp:dropdownlist id="empStatusDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
                <td class="mainheadtxt">&nbsp;</td>
		    </tr>

		    <tr>			   
			    <td class="mainheadtxt">Designation</td>
			    <td class="mainheadtxt">Business Unit</td>
			    <td class="mainheadtxt">Location/Country</td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="jobTitleDDList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="businessUnitDDList" AutoPostBack=true runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
			<tr><td colspan="4">&nbsp;</td></tr>

	    </table>
	   </td>						
	</tr>

</asp:PlaceHolder>

<!---  Data Content Area -->						

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="false">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Manage Employee Information</span></td>
</tr>
<tr>
  <td>
    <table width="99%" border="0" class="Partgrayblock">
       <tr>
	      <td valign="top" width="20%"> <asp:image id='profile' width="200" height="200" runat="server" /></td>
	      <td valign="top" width="2%">&nbsp;</td>
	     	      <td valign="top" width="38%" align="left">
	                    <table>
	                        <tr><td align="right"><span class="mainheadtxt3">Employee Name&nbsp;&nbsp;</span></td><td><asp:label id="lblEmployeeName" runat="server" cssclass="mainheadtxt2" /></td></tr>
                            <tr><td align="right"><span class="mainheadtxt3">Current Designation&nbsp;&nbsp;</span></td><td><asp:Label id="lblJobTitle" runat="server" cssclass="mainheadtxt2"></asp:Label></td></tr>	
                            <tr><td align="right"><span class="mainheadtxt3">Work Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblJobLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	
                            <tr><td align="right"><span class="mainheadtxt3">Business Unit&nbsp;&nbsp;</span></td><td><asp:Label id="lblDivision" runat="server" cssclass="mainheadtxt2" /></td></tr>	       
                            <tr><td align="right"><span class="mainheadtxt3">Business Unit Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblDivisionLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                                      
                            <tr><td align="right"><span class="mainheadtxt3">Work Phone&nbsp;&nbsp;</span></td><td><asp:Label id="lblWorkPhone" runat="server" cssclass="mainheadtxt2" ></asp:Label></td></tr>	    
                            <tr><td align="right"><span class="mainheadtxt3">Mobile Phone&nbsp;&nbsp;</span></td><td><asp:Label id="lblMobile" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                
                            <tr><td align="right"><span class="mainheadtxt3">Email Address&nbsp;&nbsp;</span></td><td><asp:Label id="lblEmailAddress" runat="server" cssclass="mainheadtxt2" /></td></tr>	
                            <tr><td align="right" colspan="2"><asp:Label id="keyField" runat="server" visible=false /></td></tr>	                                                                                                
                         </table>	                                                
	       </td>
	       <td valign="top" width="40%" align="left">
	                  <table>
	                     <tr><td align="right"><span class="mainheadtxt3">Supervisor Name&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisorName" runat="server" cssclass="mainheadtxt2" /></td></tr>                       
                         <tr><td align="right"><span class="mainheadtxt3">Designation&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_JobTitle" runat="server" cssclass="mainheadtxt2" /></td></tr>	                         
                         <tr><td align="right"><span class="mainheadtxt3">Work Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_JobLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	
                         <tr><td align="right"><span class="mainheadtxt3">Business Unit&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_Division" runat="server" cssclass="mainheadtxt2" /></td></tr>	       
                         <tr><td align="right"><span class="mainheadtxt3">Business Unit Location&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_DivisionLocation" runat="server" cssclass="mainheadtxt2" /></td></tr>	                                                                                          
	                     <tr><td align="right"><span class="mainheadtxt3">Work Phone&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisor_Phone" runat="server" cssclass="mainheadtxt2" /></td></tr>
	                     <tr><td align="right"><span class="mainheadtxt3">Email Address&nbsp;&nbsp;</span></td><td><asp:label id="lblSuperVisor_EmailAddress" runat="server" cssclass="mainheadtxt2" /></td></tr>
	                    </table>	                              
	      </td>				
		</tr>
     </table>
    </td>
</tr>
<tr width="100%">
  <td width="100%">
     <div id="nav">
           <ul>
             <li><asp:button id=tab1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Personal Information"></asp:button></li>
             <li><asp:button id=tab2 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Contact Information"></asp:button></li>
             <li><asp:button id=tab3 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Dependents Information"></asp:button></li>
             <li><asp:button id=tab4 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Emergency Contacts"></asp:button></li>       
             <li><asp:button id=tab5 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Job Details"></asp:button></li>
             <li><asp:button id=tab8 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Compensation"></asp:button></li>             
             <li><asp:button id=tab6 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Employee Organization"></asp:button></li>
             <li><asp:button id=tab7 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Employee E-Docket"></asp:button></li>
            </ul>  
     </div>
  </td>
</tr>  
<!--  Start:Tab 1--->
<tr><td width="100%">
 <asp:PlaceHolder id=GeneralInfoTab Runat="server" visible="false">	
		  <table width="99%" border="0" class="Partgrayblock">
             <tr><td colspan="4"><span class="maintitledesign">Personal Information</span></td></tr>   
		     <tr><td colspan="4">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt">Employee Name(First, Mid & Last Name)<font color="red">*</font></td>
			    <td class="mainheadtxt">Gender<font color="red">*</font></td>
			    <td class="mainheadtxt">Date of Birth<font color="red">*</font></td>
			    <td class="mainheadtxt">Age</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_FName   cssclass="textfield"   TabIndex=1 Maxlength="50" width="180px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_MidName cssclass="textfield"   TabIndex=2 width="40px"  Maxlength="15" runat="server" ></asp:textbox>
			                            <asp:textbox id=Tab1_LName   cssclass="textfield"   TabIndex=3 Maxlength="50" width="180px" runat="server" ></asp:textbox>
			    </td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_GenderType"  TabIndex=4 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_DOB  cssclass="textfield"   TabIndex=5 Maxlength="15" width="100px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Age  Enabled="false" cssclass="textfield"  TabIndex=6 Maxlength="10" width="50px" runat="server"></asp:textbox></td>
			    
		    </tr>
		     <tr>
                <td class="validationtxt">
                    <asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_FName  ErrorMessage="Employee First Name is required." />
                    <asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_LName  ErrorMessage="Employee Last Name is required." /></td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_GenderType display="dynamic" InitialValue="-1" ErrorMessage="Gender Type is required." /></td>
                <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_DOB  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>
                <td></td>
 		    </tr>
		    <tr>
			    <td class="mainheadtxt">Marital Status<font color="red">*</font></td>
			    <td class="mainheadtxt">Education<font color="red">*</font></td>
			    <td class="mainheadtxt">Citizenship</td>
			    <td class="mainheadtxt">Work Visa No</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_MaritalStatus" TabIndex=7 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Education"  TabIndex=8 AutoPostBack=false runat="server" Width="200px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Citizenship    TabIndex=9 cssclass="textfield"   Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_VisaNumber     TabIndex=10 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>
		    </tr>	
		     <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_MaritalStatus InitialValue="-1" ErrorMessage="Marital Status is required." /></td>                        
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Education InitialValue="-1" ErrorMessage="Education is required." /></td>                        
                <td></td>
                <td></td>
 		    </tr>
		    	    
		    <tr>
			    <td class="mainheadtxt">Visa Type</td>
			    <td class="mainheadtxt">Work Visa Issued Date</td>
			    <td class="mainheadtxt">Work Visa Expiry Date</td>
			    <td class="mainheadtxt">Visa Issuing Country</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_VisaType"  TabIndex=11 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_VisaIssueDate    TabIndex=12 cssclass="textfield" Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_VisaExpiryDate   TabIndex=13 cssclass="textfield"  Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_VisaCountryDDList" TabIndex=14 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>				    
		    </tr>	
		    <tr>
   		          <td>&nbsp;</td>
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_VisaIssueDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_VisaExpiryDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td>&nbsp;</td>
           </tr>
		    <tr>			    
			    <td class="mainheadtxt">Passport No</td>
			    <td class="mainheadtxt">Passport Issuing Country</td>
			    <td class="mainheadtxt">Passport Issue Date</td>
			    <td class="mainheadtxt">Passport Expiry Date</td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PassportNo  TabIndex=15 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_PassportCountryDDList" TabIndex=16 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>				    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PassportIssueDate TabIndex=17 cssclass="textfield"     Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PassportExpiryDate TabIndex=18 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
		    </tr>
		    <tr>
   		          <td>&nbsp;</td>
   		          <td>&nbsp;</td>
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_PassportIssueDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_PassportExpiryDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  		          
           </tr>		    	

		    <tr>			    
			    <td class="mainheadtxt">Labor Card No</td>
			    <td class="mainheadtxt">Labor Card Issuing Country</td>
			    <td class="mainheadtxt">Labor Card Issue Date</td>
			    <td class="mainheadtxt">Labor Card Expiry Date</td>
			    
		    </tr>
		    
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LaborCardNo  TabIndex=19 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_LaborCardCountryDDList" TabIndex=20 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>				    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LaborCardIssueDate TabIndex=21 cssclass="textfield"     Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LaborCardExpiryDate TabIndex=22 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
		    </tr>	
		    <tr>
   		          <td>&nbsp;</td>
   		          <td>&nbsp;</td>
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_LaborCardIssueDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_LaborCardExpiryDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
           </tr>	
		    <tr>
			    <td class="mainheadtxt">Business/Travel Number</td>
			    <td class="mainheadtxt">Visa Issued Date</td>
			    <td class="mainheadtxt">Visa Expiry Date</td>
			    <td class="mainheadtxt">Visa Issuing Country</td>
		    </tr>
 	        <tr>
 	            <td class="mainheadtxt"><asp:textbox id=Tab1_BVisaNumber     TabIndex=23 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_BVisaIssueDate    TabIndex=24 cssclass="textfield" Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_BVisaExpiryDate   TabIndex=25 cssclass="textfield"  Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_BVisaCountryDDList" TabIndex=26 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>				    
		    </tr>	
		    <tr>
   		          <td>&nbsp;</td>
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_BVisaIssueDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_BVisaExpiryDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td>&nbsp;</td>
           </tr>
           	    			    
           <tr>			    
			    <td class="mainheadtxt">Person  ID(Issued by Ministry of Labour/WPS)</td>
			    <td class="mainheadtxt" colspan="3">&nbsp;</td>    
		    </tr>
             <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PersonID TabIndex=27 cssclass="textfield"   Maxlength="14" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt" colspan="3">&nbsp;</td>
		    </tr>
		    <tr>
		          <td class="validationtxt"><asp:RegularExpressionValidator  ControlToValidate="Tab1_PersonID" ValidationExpression="\d+" Display="Dynamic" ErrorMessage="Please enter numbers only"  runat="server"/>
		          <td class="validationtxt" colspan="3">&nbsp;</td>
           </tr>		    			    
	<tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Personal_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab1_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		</tr>		    
           			        
	    </table>
	    
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab1 -->

<!---  Start:Tab 2 -->
<tr><td width="100%">
 <asp:PlaceHolder id=ContactInfoTab Runat="server" visible="false">
      
          <table width="99%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Contact Information</span></td></tr>   
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
			    <td class="mainheadtxt">Home Address<font color="red">*</font></td>
			    <td class="mainheadtxt">City<font color="red">*</font></td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HAddress1 cssclass="textfield" TabIndex=1 Maxlength="50" width="225px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab2_HAddress2 cssclass="textfield" TabIndex=2 Maxlength="50" width="225px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HCity  cssclass="textfield" TabIndex=3 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HState  cssclass="textfield" TabIndex=4 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_CountryDDList" TabIndex=5 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		    <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_HAddress1  ErrorMessage="Home Address is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_HCity  ErrorMessage="City is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab2_CountryDDList  InitialValue="-1" ErrorMessage="Country is reqired." /></td> 		    
		    </tr>
	        <tr>
			    <td class="mainheadtxt">Work Address<font color="red">*</font></td>
			    <td class="mainheadtxt">City<font color="red">*</font></td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WAddress1 cssclass="textfield" TabIndex=5 Maxlength="50" width="225px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab2_WAddress2 cssclass="textfield" TabIndex=6 Maxlength="50" width="225px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WCity cssclass="textfield" TabIndex=7  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WState  cssclass="textfield" TabIndex=8 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_WCountryDDList"  TabIndex=9 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		     <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_WAddress1  ErrorMessage="Work Address is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_WCity  ErrorMessage="Work City is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab2_WCountryDDList  InitialValue="-1" ErrorMessage="Country is reqired." /></td> 		    
		    </tr>

		    <tr>
			    <td class="mainheadtxt">Home Telephone<font color="red">*</font></td>
			    <td class="mainheadtxt">Work Telephone<font color="red">*</font></td>
			    <td class="mainheadtxt">Mobile</td>
			    <td class="mainheadtxt">Work Email<font color="red">*</font></td>
		    </tr>
		    <tr>		 
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HPhone  cssclass="textfield" TabIndex=10 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WPhone  cssclass="textfield" TabIndex=11 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_Mobile  cssclass="textfield" TabIndex=12 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WorkEmail cssclass="textfield" TabIndex=13  Maxlength="50" width="180px" runat="server"></asp:textbox></td>
		    </tr>
		     <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_HPhone  ErrorMessage="Home Phone is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_WPhone  ErrorMessage="Work Phone is required." /></td>                           
                <td class="validationtxt"></td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab2_WorkEmail ErrorMessage="Work Email Address is reqired." />
                                          <asp:RegularExpressionValidator runat="server" ControlToValidate=Tab2_WorkEmail ErrorMessage="Email Address format is invaid." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" />
                </td> 		    
		    </tr>
	<tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Contact_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab2_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		</tr>		
		    
	    </table>
	
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab2 -->

<!--   Start of Tab3 -->
<tr><td width="100%">
 <asp:PlaceHolder id="DependentTab" Runat="server" visible="false"> 
        <table width="99%" border="0" class="Partgrayblock">        
            <tr><td colspan="4"><span class="maintitledesign">Dependent Information</span></td></tr>   
            <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Relationship<font color="red">*</font></td>
			    <td class="mainheadtxt">Date Of Birth<font color="red">*</font></td>
			    <td class="mainheadtxt">Gender<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_Name  cssclass="textfield" TabIndex=1 Maxlength="50" width="180px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab3_RelationshipDDList  TabIndex=2 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_DOB  cssclass="textfield" TabIndex=3 Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab3_GenderType  TabIndex=4  AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		    <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab3_Name  Display="Dynamic" ErrorMessage="Dependent Name is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab3_RelationshipDDList Display="Dynamic" InitialValue="-1" ErrorMessage="Relationship is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab3_DOB  Display="Dynamic" ErrorMessage="Date of Birth is required." />
                		              <br /><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab3_DOB  Display="Dynamic" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." />
                </td>
                <td class="validationtxt"><asp:RequiredFieldValidator  runat=server ControlToValidate=Tab3_GenderType Display="Dynamic" InitialValue="-1" ErrorMessage="Gender Type is reqired." /></td> 		    
		    </tr>
		     	    
		    <tr>			    
			    <td class="mainheadtxt">Passport No</td>
			    <td class="mainheadtxt">Passport Issuing Country</td>
			    <td class="mainheadtxt">Passport Issue Date</td>
			    <td class="mainheadtxt">Passport Expiry Date</td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_PassportNo  cssclass="textfield" TabIndex=5         Maxlength="30" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab3_PassportCountryDDList TabIndex=6 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_PassportIssueDate    cssclass="textfield" TabIndex=7  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_PassportExpiryDate   cssclass="textfield" TabIndex=8  Maxlength="30" runat="server"></asp:textbox></td>	
		    </tr>
		   <tr>
   		          <td>&nbsp;</td>
   		          <td>&nbsp;</td>
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab3_PassportIssueDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab3_PassportExpiryDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  		          
           </tr>		    	

		    <tr>
			    <td class="mainheadtxt">Visa No</td>
			    <td class="mainheadtxt">Visa Type</td>
			    <td class="mainheadtxt">Visa Issue Date</td>
			    <td class="mainheadtxt">Visa Expiry Date</td>			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_VisaNumber     cssclass="textfield" TabIndex=9 Maxlength="30" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab3_VisaType  TabIndex=10 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_VisaIssueDate  cssclass="textfield" TabIndex=11 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_VisaExpiryDate cssclass="textfield" TabIndex=12 Maxlength="30" runat="server"></asp:textbox></td>		    
		    </tr>
		   <tr>   <td>&nbsp;</td>
   		          <td>&nbsp;</td>
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab3_VisaIssueDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		          <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab3_VisaExpiryDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  		          
           </tr>		    	
		    <tr>
			    <td class="mainheadtxt">Visa Issue Country</td>
			    <td class="mainheadtxt">&nbsp;</td>
			    <td class="mainheadtxt">&nbsp;</td>
			    <td class="mainheadtxt">&nbsp;</td>			    
		    </tr>
		    <tr>  
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab3_VisaIssueCountryID  TabIndex=13 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt">&nbsp;</td>
			    <td class="mainheadtxt">&nbsp;</td>
			    <td class="mainheadtxt">&nbsp;</td>			    
            </tr>
          	<tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=DP_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
                <asp:button id=DP_Cancel runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
                &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab3_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		    </tr>			    

             <tr>
                <td colspan="4" align=center><asp:label id="DPmessage" runat="server" visible=false /></td>
            </tr>

            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Datagrid for dependents -->
            <tr>
                <td colspan="4">
                        <asp:DataGrid ID="DPGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="dependentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="DPGrid_PageIndexChanged"   OnDeleteCommand="DPGrid_DeleteCommand" OnEditCommand="DPGrid_EditCommand">
                                       
                          <Columns>
                                <asp:BoundColumn HeaderText="Name" DataField="FullName" ItemStyle-Width="15%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Relationship" DataField="RelationshipName" ItemStyle-Width="15%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="DOB" DataField="DOB" ItemStyle-Width="12%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Gender" DataField="GenderName" ItemStyle-Width="10%" ></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Passport No" DataField="PassportNumber" ItemStyle-Width="15%"> </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Issue Country" DataField="CountryName" ItemStyle-Width="12%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Issue Date" DataField="PP_IssueDate" ItemStyle-Width="12%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Exp Date" DataField="PP_ExpiryDate" ItemStyle-Width="12%"></asp:BoundColumn>
                                <asp:BoundColumn Visible=false HeaderText="Visa_Number" DataField="Visa_Number" ItemStyle-Width="0%"></asp:BoundColumn>
                                <asp:BoundColumn Visible=false HeaderText="Visa_TypeID" DataField="Visa_TypeID" ItemStyle-Width="0%"></asp:BoundColumn>
                                <asp:BoundColumn Visible=false HeaderText="Visa_IssueDate" DataField="Visa_IssueDate" ItemStyle-Width="0%"></asp:BoundColumn>
                                <asp:BoundColumn Visible=false HeaderText="Visa_ExpiryDate" DataField="Visa_ExpiryDate" ItemStyle-Width="0%"></asp:BoundColumn>
                                <asp:BoundColumn Visible=false HeaderText="Visa_IssueCountryID" DataField="Visa_IssueCountryID" ItemStyle-Width="0%"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                    </ItemTemplate>
                               </asp:TemplateColumn>                    
                               <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                   <ItemTemplate> 
                                      <asp:LinkButton name="Delete" commandName="Delete" Text="Delete" CausesValidation="false" runat="server" OnClientClick="return confirm('Are you sure you want to delete the record?');" /> 
                                   </ItemTemplate>
                                </asp:TemplateColumn>                                
                           </Columns>     
                            <FooterStyle CssClass="DashGridFooter" />
                            <SelectedItemStyle CssClass="DashGridSelectedItem" />
                            <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                            <AlternatingItemStyle CssClass="DashGridAltItem" />
                            <ItemStyle CssClass="DashGridItem" />
                            <HeaderStyle CssClass="DashGridHeader" />
                        </asp:DataGrid>
                        <br/><center><asp:label id ="emptyRow2" value="" visible=false runat="server" /></center>          
                </td>
               </tr>           			    
        </table>
	
  </asp:placeholder>
</td>
</tr>
<!--  End of Tab3 -->

<!--  Start: Tab4 -->
<tr><td width="100%">
 <asp:PlaceHolder id="EmergencyContactTab" Runat="server" visible="false">
      <table width="99%" border="0" class="Partgrayblock">
            <!-- Add/Edit Emergency Contact details. -->
            <tr><td colspan="4"><span class="maintitledesign">Emergency Contacts</span></td></tr>           
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Relationship<font color="red">*</font></td>
			    <td class="mainheadtxt">Contact Priority<font color="red">*</font></td>
			    <td class="mainheadtxt"></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_Name cssclass="textfield" TabIndex=1 Maxlength="50" width="160px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab4_RelationshipDDList cssclass="textfield" TabIndex=2 AutoPostBack=false runat="server" Width="180px"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab4_ContactPrioirtyDDList" cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="180px"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"></td>
			</tr>
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_Name  ErrorMessage="Contact Name is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_RelationshipDDList InitialValue="-1" ErrorMessage="Relationship is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_ContactPrioirtyDDList InitialValue="-1"  ErrorMessage="Contact Priority is required." /></td>
                <td class="validationtxt">&nbsp;</td> 		    
		    </tr>
		    <tr>
			    <td class="mainheadtxt">Home Phone<font color="red">*</font></td>
			    <td class="mainheadtxt">Mobile Phone<font color="red">*</font></td>
			    <td class="mainheadtxt">Work Phone</td>
			    <td class="mainheadtxt">Email Address</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_HomePhone  cssclass="textfield" TabIndex=4   Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_MobilePhone cssclass="textfield" TabIndex=5  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_WorkPhone   cssclass="textfield" TabIndex=6  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_EmailAddress cssclass="textfield" TabIndex=7 Maxlength="50" runat="server" width="220px" ></asp:textbox></td>			    
		    </tr>
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_HomePhone    ErrorMessage="Home Phone is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_MobilePhone  ErrorMessage="Mobile Phone is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RegularExpressionValidator runat="server" ControlToValidate=Tab4_EmailAddress ErrorMessage="Email Address format is invaid." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" /></td> 		    
		    </tr>
	
          	<tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=EC_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
                <asp:button id=EC_Cancel runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
                &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab4_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		    </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="ECmessage" runat="server" visible=false /></td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Emergency Contact Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="ECGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="EContactID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="ECGrid_PageIndexChanged"  OnDeleteCommand="ECGrid_DeleteCommand" OnEditCommand="ECGrid_EditCommand">
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Contact Name" DataField="Contact_Name" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Relationship" DataField="RelationshipName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contact Priority" DataField="Contact_PriorityName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Home Phone" DataField="Home_Phone" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Mobile" DataField="Mobile" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Work Phone" DataField="WorkPhone" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Email" DataField="Email_Addr" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                    </ItemTemplate>
                            </asp:TemplateColumn>                    
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                   <ItemTemplate> 
                                      <asp:LinkButton name="Delete" commandName="Delete" Text="Delete" CausesValidation="false" runat="server" OnClientClick="return confirm('Are you sure you want to delete the record?');" /> 
                                   </ItemTemplate>
                            </asp:TemplateColumn>                                
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    </br>
                    <center><asp:label id ="emptyRow1" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	       
 </asp:placeholder>
</td>
</tr>

<!--  End of Tab 4 -->

<!--  Start: Tab 5 -->
<tr><td width="100%">
 <asp:PlaceHolder id="JobDetailsTab" Runat="server" visible="false">
        <table width="99%" border="0" class="Partgrayblock">
            <tr><td colspan="5"><span class="maintitledesign">Current Job Information</span></td></tr>
            <tr><td colspan="5">&nbsp;</td></tr>
 	        <tr>
			    <td class="mainheadtxt">Employee ID</td>
			    <td class="mainheadtxt">Peoplesoft Employee ID</td>			    
			    <td class="mainheadtxt">Job Title<font color="red">*</font></td>
			    <td class="mainheadtxt">Employment Status<font color="red">*</font></td>
			    <td class="mainheadtxt">Employment Category<font color="red">*</font></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_EmpID readonly="true"  cssclass="textfield" TabIndex=1 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_PSEmpID cssclass="textfield" TabIndex=2 Maxlength="30" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_DesignationDDList"  TabIndex=3 AutoPostBack=false runat="server" Width="180px" CssClass="textfield" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_EmpStatusDDList"  TabIndex=4 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_EmpCategoryDDList"  TabIndex=5  AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>		    
            <tr>
		        <td class="validationtxt">&nbsp;</td>  
		        <td>&nbsp;</td> 
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab5_DesignationDDList InitialValue=-1 ErrorMessage="Job Title is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab5_EmpStatusDDList   InitialValue=-1 ErrorMessage="Employment Status is required." /></td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab5_EmpCategoryDDList InitialValue=-1 ErrorMessage="Employment Category is required." /></td> 		    
		    </tr>
		    		    

		    <tr>
   			    <td class="mainheadtxt">Business Unit<font color="red">*</font></td>
			    <td class="mainheadtxt">Business Unit Location<font color="red">*</font></td>
			    <td class="mainheadtxt">Department<font color="red">*</font></td>
			    <td class="mainheadtxt">Supervisor Name</td>
		        <td class="mainheadtxt">Employee Work Location(City/Country)</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_DivisonDDList" cssclass="textfield" TabIndex=6 AutoPostBack=True onselectedindexchanged="Tab5_DivisonDDList_SelectedIndexChanged" runat="server" Width="180px"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_DivisionLocationDDList" cssclass="textfield" TabIndex=7 AutoPostBack=true runat="server" Width="150px" ></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_DepartmentDDList" cssclass="textfield" TabIndex=8 AutoPostBack=true runat="server" Width="150px" ></asp:dropdownlist></td>			    			    
   			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_SupervisorDDList" cssclass="textfield" TabIndex=9 AutoPostBack=false runat="server" Width="150px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox readonly = "true"  id=Tab5_City cssclass="textfield" TabIndex=10 Maxlength="30" runat="server"></asp:textbox>
			                            <asp:textbox readonly = "true"  id=Tab5_CountryName cssclass="textfield" TabIndex=10 Maxlength="30" runat="server"></asp:textbox></td>

		    </tr>
            <tr>
  		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab5_DivisonDDList   InitialValue=-1 ErrorMessage="Business Unit is required." /></td>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab5_DivisionLocationDDList   InitialValue=-1 ErrorMessage="Business Unit Location is required." /></td> 
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab5_DepartmentDDList InitialValue=-1 ErrorMessage="Department is required." /></td>                                           
                <td class="validationtxt" colspan="2">&nbsp;</td> 		    
		    </tr>
		    
		   <tr>
			    <td class="mainheadtxt">Hire/Transfer Date<font color="red">*</font></td>
			    <td class="mainheadtxt">Current Position End Date </td>			    
			    <td class="mainheadtxt">New Position Start Date</td>
			    <td class="mainheadtxt">Resigned Date</td>
			    <td class="mainheadtxt">Date Left/Relieved</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_HireDate cssclass="textfield" TabIndex=11  Maxlength="30" runat="server"></asp:textbox></td>	
                <td class="mainheadtxt"><asp:textbox id=Tab5_CRPositionEndDate  cssclass="textfield" TabIndex=12 Maxlength="30" runat="server"></asp:textbox></td>	
                <td class="mainheadtxt"><asp:textbox id=Tab5_NewPositionStartDate  cssclass="textfield" TabIndex=13 Maxlength="30" runat="server"></asp:textbox></td>			                    		    
			    <td class="mainheadtxt"><asp:textbox id=Tab5_ResignedDate cssclass="textfield" TabIndex=14 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_DateLeft  cssclass="textfield" TabIndex=15 Maxlength="30" runat="server"></asp:textbox></td>
		    </tr>
	        <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server Display="Dynamic" ControlToValidate=Tab5_HireDate ErrorMessage="Hire Date is required." />
		                                   <br /><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab5_HireDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." />
		        </td>   
		        <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab5_CRPositionEndDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
		        <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab5_NewPositionStartDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  		        
		        <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab5_ResignedDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  		        
		        <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab5_DateLeft  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  		          
		    </tr>	
		        
		   <tr> 
  			    <td class="mainheadtxt">Total Years of Service</td>
		        <td class="mainheadtxt">Years in Current Position</td>
			    <td class="mainheadtxt">Probation Period(Months)</td>
			    <td class="mainheadtxt">Probation End Date</td> 
			    <td class="mainheadtxt">Probation Completed?&nbsp;&nbsp;<asp:CheckBox ID="Tab5_ProbationCompletedCheckBox" TabIndex=16 runat="server" Text="" ></asp:CheckBox></td>			                              
			    
               
		    </tr>
		    <tr>	
		        <td class="mainheadtxt"><asp:textbox readonly="true" id=Tab5_TotalServiceYears  Maxlength="30" runat="server"></asp:textbox></td>			    		   
			    <td class="mainheadtxt"><asp:textbox readonly="true" id=Tab5_YearsinCurrentPosition  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_ProbabtionYears  cssclass="textfield" TabIndex=16 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_ProbationEndDate cssclass="textfield" TabIndex=17  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="validationtxt">&nbsp;</td>
		    </tr>		    
	        <tr>
		        <td class="validationtxt">&nbsp;</td>	
		        <td class="validationtxt">&nbsp;</td>   
		        <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab5_ProbationEndDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
   		        <td class="validationtxt">&nbsp;</td>                           
                <td class="validationtxt">&nbsp;</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt" colspan="2">Original Hire Date&nbsp;&nbsp;<asp:textbox id=Tab5_OriginalHireDate readonly="true" cssclass="textfield" TabIndex=18  Maxlength="30" runat="server"></asp:textbox></td>	
		        <td class="mainheadtxt" colspan="3">Supervisory Role&nbsp;&nbsp;<asp:CheckBox ID="Tab5_SupervisoryCheckBox" TabIndex=17 runat="server" Text="" ></asp:CheckBox></td>
		    </tr>
		    <tr><td colspan="5">&nbsp;</td></tr>	
            
            <tr class="PartButtons" align=center>
			<td  colspan="5">
			<center>
			    <asp:button id=Job_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab5_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		    </tr>	
                        
            <tr>
                   <td colspan="5" align=center><asp:label id="JobTab_message" runat="server" visible=false /></td>			
            </tr>                  	       
            <tr>
		        <td colspan="5"><hr /></td>
		    </tr>

         <!-- Employee Position Grid -->
             <tr>
                <td colspan="5">
                    <asp:DataGrid ID="EPGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="RowID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="EPGrid_PageIndexChanged"
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=mainheadtxt4 align="left">Employee Position History</td></tr></table>' CaptionAlign="Top">                                                                    
                      <Columns>
                            <asp:BoundColumn HeaderText="Designation Name" DataField="Designation" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Position Start Date" DataField="P_StartDate" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Position End Date" DataField="P_EndDate" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Supervisory Role" DataField="SupervisoryRole" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Current Position" DataField="Current_Position" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Note" DataField="SPLNote" ItemStyle-Width="16%"></asp:BoundColumn>
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
		        <td colspan="5"><hr /></td>
		    </tr>            
          <!-- Employee Transfer Grid -->
             <tr>
                <td colspan="5">
                    <asp:DataGrid ID="ETGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="ID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="ETGrid_PageIndexChanged"
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=mainheadtxt4 align="left">Employee Transfer History</td></tr></table>' CaptionAlign="Top">                                                                    
                      <Columns>
                            <asp:BoundColumn HeaderText="From" DataField="From" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="To" DataField="To" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Old Local ID" DataField="OldLocalID" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="New Local ID" DataField="NewLocalID" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Original Hire Date" DataField="OriginalHireDate" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Transfer Date" DataField="TransferDate" ItemStyle-Width="12%"></asp:BoundColumn>
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                </td>
            </tr>
	    </table>
	
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab 5 -->

<!--   Start : Tab 6 -->
<tr><td width="100%">
 <asp:PlaceHolder id="ManagementChainTab" Runat="server" visible="false">
        <table width="99%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Employee Management Chain</span></td></tr>
	        <tr>
	            <td colspan="4" class="mainheadtxt">
		          <asp:TreeView  ID="MyOrgTree" ExpandDepth="0"  PopulateNodesFromClient="true" cssclass="mainheadtxt" ShowLines="true"  ShowExpandCollapse="true"  runat="server" />
               </td> 
     		</tr>
            <tr><td colspan="4">&nbsp;</td></tr>     		
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab7_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		    </tr>	        
	    </table>  	                

 </asp:placeholder>
</td>
</tr>
<!-- Start: Tab 7 -->
<tr><td width="100%">
 <asp:PlaceHolder id="EmployeeDocumentsTab" Runat="server" visible="false">
  
        <table width="99%" border="0" class="Partgrayblock">
        <tr><td colspan="4"><span class="maintitledesign">Employee E-Docket</span></td></tr>
            <tr><td colspan="4">&nbsp;</td></tr>
             <tr>
			    <td class="mainheadtxt" colspan="2">Select the document to upload<small>(Maximum File Size:4MB)</small><font color="red">*</font></td>
			    <td class="mainheadtxt">Document Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Document Type<font color="red">*</font></td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt" colspan="2"><input id="Tab8_FileName" type="file" class="textfield" TabIndex=1 runat="server" size="50"></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab8_DocumentName  cssclass="textfield" TabIndex=2 Maxlength="100" width="200px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab8_DocumentType cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="220px"></asp:dropdownlist></td>
			  	    
		    </tr>	
           <tr>
		        <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab8_FileName ErrorMessage="Select the file to upload." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab8_DocumentName  ErrorMessage="Document Name is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab8_DocumentType InitialValue=-1 ErrorMessage="Document Type is required." /></td>               
            
		    </tr>		    
		    <tr>
		        <td class="mainheadtxt" colspan="4">Comments<asp:textbox id=Tab8_Comments  cssclass="textfield" TabIndex=4 size="100" Maxlength="100" runat="server"></asp:textbox></td>
		     </tr>
	 	    <tr><td colspan="4">&nbsp;</td></tr>
                      	<tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Doc_Upload runat="server" CausesValidation="True" CssClass="Button UploadButton" Text="Upload"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab6_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		    </tr>	
            <tr>
                <td colspan="4" align=center><asp:label id="docmessage" runat="server" visible=false /></td>
            </tr>    			
           <tr><td colspan="4"><hr /></td></tr>

            <tr>
                <td colspan="4">
                    <asp:DataGrid ID="DOCGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="DocumentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="DOCGrid_PageIndexChanged"                                  OnCancelCommand="DOCGrid_CancelCommand" OnDeleteCommand="DOCGrid_DeleteCommand" OnEditCommand="DOCGrid_EditCommand" OnUpdateCommand="DOCGrid_UpdateCommand">
                                   
                      <Columns>
                            <asp:TemplateColumn HeaderText="Document Name" ItemStyle-Width="35%">
                                
                                <ItemTemplate>
                                    <a id="A1" href='<%# "~/documents/" + Eval("DocumentName")%>' runat="server" target="_blank"><%# Eval("DocumentName")%></a> 
                                </ItemTemplate> 
                            </asp:TemplateColumn>
                
                            <asp:BoundColumn HeaderText="Document Type" DataField="DocumentTypeName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Comments" DataField="Doc_Comments" ItemStyle-Width="35%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Last Updated" DataField="Date_Updated" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                   <ItemTemplate> 
                                      <asp:LinkButton name="Delete" commandName="Delete" Text="Delete" CausesValidation="false" runat="server" OnClientClick="return confirm('Are you sure you want to delete the document?');" /> 
                                   </ItemTemplate>
                            </asp:TemplateColumn>                                                   
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br/>
                    <center><asp:label id ="emptyRow3" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>           				    	    
	     </table>
	   
 </asp:placeholder>
</td>
</tr>
<!---  End of Tab 7 -->
<!--   Start : Tab 8 -->
<tr><td width="100%">
 <asp:PlaceHolder id="CompensationTab" Runat="server" visible="false">
  
        <table width="99%" border="0" class="Partgrayblock">
        <tr><td colspan="4"><span class="maintitledesign">Current Year Compensation(YTD)</span></td></tr>
            <tr><td colspan="4" align=right class="validationtxt"><asp:label id="Tab8_lblCurrencyName" runat="server" /></td></tr>  	    
 	        <tr>
			    <td class="mainheadtxt">Total Earnings(YTD)</td>
			    <td class="mainheadtxt">LOP Deductions(YTD)</td>
			    <td class="mainheadtxt">Total Deductions(Includes LOP)(YTD)</td>
			    <td class="mainheadtxt">Net Pay(YTD)</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab8_EarningsYTD       disabled="true"   cssclass="textfield" TabIndex=1 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab8_LOPDeductYTD      disabled="true"   cssclass="textfield" TabIndex=2 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab8_OtherLOPDeductYTD disabled="true"   cssclass="textfield" TabIndex=3 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab8_NetEarningsYTD    disabled="true"   cssclass="textfield" TabIndex=4 Maxlength="30" runat="server"></asp:textbox></td>
		    </tr>		    
		    		    
            <tr><td colspan="4">&nbsp;</td></tr>

		    <tr>
			    <td class="mainheadtxt" colspan="2">End of Service Settlement:&nbsp;<asp:CheckBox ID="Tab8_EOSCheckBox1" runat="server" Text="" checked=false disabled="true"/></td>
			    <td class="mainheadtxt" colspan="2">&nbsp;</td>
		    </tr>
	        <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab8_Back runat="server" CausesValidation="false" CssClass="Button BackButton" Text="Back"></asp:button>
			</center>
			</td>
		    </tr>	<tr><td colspan="4"><hr/></td></tr>

          <!-- DataGrid to display employee's monthly paystub information -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="PayGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="Pay_MonthYear" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="PayGrid_PageIndexChanged"
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=mainheadtxt4 align="left">Monthly Payroll History</td></tr></table>' CaptionAlign="Top">                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Pay Period" DataField="Pay_MonthYear" ItemStyle-Width="9%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Total Earnings" DataField="Earnings" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LOP Deductions" visible=false  DataField="LOPDeductions" DataFormatString="{0:######.00}" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Total Deductions" DataField="OtherDeductions" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>    
                            <asp:BoundColumn HeaderText="Net Pay" DataField="NetPay" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>     
                            <asp:BoundColumn HeaderText="Total Days(PayCycle)" DataField="TotalDays_PayCycle" ItemStyle-Width="12%"></asp:BoundColumn>       
                            <asp:BoundColumn HeaderText="Total Days(Unpaid)" DataField="TotalDays_unpaid" ItemStyle-Width="12%"></asp:BoundColumn>                                                    
                            <asp:BoundColumn HeaderText="Net PayDays" DataField="NetPayDays" ItemStyle-Width="9%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" DataField="PayrollStatusName" ItemStyle-Width="10%"></asp:BoundColumn>
                            
                            <asp:TemplateColumn HeaderText="View Payslip" ItemStyle-Width="20%">
                               <ItemTemplate>
                                    <a href="javascript:Openpopup('../Payroll/Viewpaystub.aspx?empid=<%# Eval("empid")%>&PayMonthYear=<%# Eval("Pay_MonthYear") %>')">View Pay Slip</a>
                                </ItemTemplate>
                            </asp:TemplateColumn> 
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="Tab8_EmptRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr> 
   		    <tr><td colspan="4">&nbsp;</td></tr>	
	    </table>
	
 </asp:placeholder>
</td>
</tr>
<!--    End of Tab 8-->


</asp:PlaceHolder>
<!--- Common for all tabs --->

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			


</table>
	<!--   End of Data Area -->
										
</master:content>

