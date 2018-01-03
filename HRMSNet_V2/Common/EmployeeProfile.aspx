<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeProfile.aspx.cs" Inherits="SchoolNet.EmployeeProfile" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
<!--    Employee Profile -->
<asp:PlaceHolder id=EditArea Runat="server" visible="true">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">My Employment Information</span></td>
</tr>
<tr>
  <td>
    <table width="100%" border="0" class="Partgrayblock">
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
                         <tr><td align="right"><span class="mainheadtxt3">Designation&nbsp;&nbsp;</span></td><td><asp:Label id="lblSuperVisor_JobTitle" runat="server" cssclass="mainheadtxt2"></asp:Label></td></tr>	
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
  <td>
     <div id="nav">
           <ul>
             <li><asp:button id=tab1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Personal Information"></asp:button></li>
             <li><asp:button id=tab2 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Contact Information"></asp:button></li>
             <li><asp:button id=tab3 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Dependent Information"></asp:button></li>
             <li><asp:button id=tab4 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Emergency Contact"></asp:button></li>       
             <li><asp:button id=tab5 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Job Details"></asp:button></li>
             <li><asp:button id=tab6 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Compensation"></asp:button></li>
             <li><asp:button id=tab7 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Leave Balance"></asp:button></li>
             <li><asp:button id=tab8 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="My Organization"></asp:button></li>
            </ul>  
     </div>
  </td>
</tr>  
<!--  Start:Tab 1--->
<tr><td width="100%">
 <asp:PlaceHolder id=GeneralInfoTab Runat="server" visible="false">
  
		  <table width="100%" border="0" class="Partgrayblock">   
            <tr><td colspan="4"><span class="maintitledesign">Personal Information</span></td></tr> 
		     <tr><td colspan="4">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt">Employee Name(First, Mid & Last Name)</td>
			    <td class="mainheadtxt">Gender</td>
			    <td class="mainheadtxt">Date of Birth</td>
			    <td class="mainheadtxt">Age</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_FName   disabled="true" cssclass="textfield"   TabIndex=1 Maxlength="50" width="180px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab1_MidName disabled="true" cssclass="textfield"   TabIndex=2 width="40px"  Maxlength="15" runat="server" ></asp:textbox>
			                            <asp:textbox id=Tab1_LName   disabled="true" cssclass="textfield"   TabIndex=3 Maxlength="50" width="180px" runat="server" ></asp:textbox>
			    </td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_GenderType" disabled="true" TabIndex=4 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_DOB  disabled="true" cssclass="textfield"    TabIndex=5 Maxlength="15" width="100px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Age  disabled="True" cssclass="textfield"    TabIndex=6 Maxlength="10" width="50px" runat="server"></asp:textbox></td>
			    
		    </tr>
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Marital Status</td>
			    <td class="mainheadtxt">Education</td>
			    <td class="mainheadtxt">CitizenShip</td>
			    <td class="mainheadtxt">Visa Number</td>
		    </tr>
		     <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_MaritalStatus" disabled="true" TabIndex=7 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Education"  disabled="true" TabIndex=8 AutoPostBack=false runat="server" Width="200px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Citizenship    disabled="true" TabIndex=9 cssclass="textfield"   Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_VisaNumber    disabled="true" TabIndex=10 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>
		    </tr>	
	    	<tr><td colspan="4">&nbsp;</td></tr>    
		    <tr>
			    <td class="mainheadtxt">Visa Type</td>
			    <td class="mainheadtxt">Visa Issued Date</td>
			    <td class="mainheadtxt">Visa Expiry Date</td>
			    <td class="mainheadtxt">Visa Issuing Country</td>
		    </tr>
 	        <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_VisaType" disabled="true" TabIndex=11 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_VisaIssueDate   disabled="true" TabIndex=12 cssclass="textfield" Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_VisaExpiryDate  disabled="true" TabIndex=13 cssclass="textfield"  Maxlength="30" runat="server" ></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_VisaCountryDDList" disabled="true" TabIndex=14 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>				    
		    </tr>	
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>			    
			    <td class="mainheadtxt">Passport No</td>
			    <td class="mainheadtxt">Passport Issuing Country</td>
			    <td class="mainheadtxt">Passport Issue Date</td>
			    <td class="mainheadtxt">Passport Expiry Date</td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PassportNo  disabled="true" TabIndex=15 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_PassportCountryDDList" disabled="true" TabIndex=16 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>				    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PassportIssueDate disabled="true" TabIndex=17 cssclass="textfield"     Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PassportExpiryDate disabled="true" TabIndex=18 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
		    </tr>	
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>			    
			    <td class="mainheadtxt">Labor Card No</td>
			    <td class="mainheadtxt">Labor Card Issuing Country</td>
			    <td class="mainheadtxt">Labor Card Issue Date</td>
			    <td class="mainheadtxt">Labor Card Expiry Date</td>
			    
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LaborCardNo disabled="true" TabIndex=19 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_LaborCardCountryDDList" disabled="true" TabIndex=20 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>				    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LaborCardIssueDate disabled="true" TabIndex=21 cssclass="textfield"     Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LaborCardExpiryDate disabled="true" TabIndex=22 cssclass="textfield"   Maxlength="30" runat="server"></asp:textbox></td>	
		    </tr>	
		    <tr><td colspan="4">&nbsp;</td></tr>		    
                 
	    </table>
	    
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab1 -->

<!---  Start:Tab 2 -->
<tr><td width="100%">
 <asp:PlaceHolder id=ContactInfoTab Runat="server" visible="false">
      
          <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Contact Information</span></td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
			    <td class="mainheadtxt">Home Address</td>
			    <td class="mainheadtxt">City</td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HAddress1 disabled="true" cssclass="textfield" TabIndex=1 Maxlength="50" width="180px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab2_HAddress2 disabled="true" cssclass="textfield" TabIndex=2 Maxlength="50" width="180px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HCity  disabled="true" cssclass="textfield" TabIndex=3 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HState disabled="true" cssclass="textfield" TabIndex=4 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_CountryDDList" disabled="true" TabIndex=5 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
   		    <tr><td colspan="4">&nbsp;</td></tr>
	        <tr>
			    <td class="mainheadtxt">Work Address</td>
			    <td class="mainheadtxt">City</td>
			    <td class="mainheadtxt">State/Province</td>
			    <td class="mainheadtxt">Country</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WAddress1 disabled="true" cssclass="textfield" TabIndex=5 Maxlength="50" width="180px" runat="server"></asp:textbox>
			                            <asp:textbox id=Tab2_WAddress2 disabled="true" cssclass="textfield" TabIndex=6 Maxlength="50" width="180px" runat="server" ></asp:textbox>
			                            
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WCity disabled="true" cssclass="textfield" TabIndex=7  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WState disabled="true" cssclass="textfield" TabIndex=8 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_WCountryDDList" disabled="true" TabIndex=9 AutoPostBack=false runat="server" Width="150px" CssClass="textfield"></asp:dropdownlist></td>
			    
		    </tr>
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Home Telephone</td>
			    <td class="mainheadtxt">Work Telephone</td>
			    <td class="mainheadtxt">Mobile</td>
			    <td class="mainheadtxt">Work Email</td>
		    </tr>
		    <tr>		 
			    <td class="mainheadtxt"><asp:textbox id=Tab2_HPhone disabled="true" cssclass="textfield" TabIndex=10 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WPhone disabled="true"  cssclass="textfield" TabIndex=11 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_Mobile  disabled="true" cssclass="textfield" TabIndex=12 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_WorkEmail disabled="true" cssclass="textfield" TabIndex=13  Maxlength="50" width="200px" runat="server"></asp:textbox></td>
		    </tr>

  		    <tr><td colspan="4">&nbsp;</td></tr>
		    
	    </table>
  
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab2 -->

<!--   Start of Tab3 -->
<tr><td width="100%">
 <asp:PlaceHolder id="DependentTab" Runat="server" visible="false">
     
        <table width="100%" border="0" class="Partgrayblock">      
            <!-- Datagrid for dependents -->
            <tr><td colspan="4"><span class="maintitledesign">Dependents Information</span></td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
                <td colspan="4">
                        <asp:DataGrid ID="DPGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="dependentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="DPGrid_PageIndexChanged">                                       
                          <Columns>
                                <asp:BoundColumn HeaderText="Name" DataField="FullName" ItemStyle-Width="17%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Relationship" DataField="RelationshipName" ItemStyle-Width="10%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="DOB" DataField="DOB" ItemStyle-Width="10%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Gender" DataField="GenderName" ItemStyle-Width="12%" ></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Passport No" DataField="PassportNumber" ItemStyle-Width="12%"> </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Issue Country" DataField="CountryName" ItemStyle-Width="13%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Issue Date" DataField="PP_IssueDate" ItemStyle-Width="15%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Exp Date" DataField="PP_ExpiryDate" ItemStyle-Width="15%"></asp:BoundColumn>
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
    
      <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Emergency Contacts</span></td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>
            <!-- Emergency Contact Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="ECGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="EContactID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="ECGrid_PageIndexChanged">                               
                      <Columns>
                            <asp:BoundColumn HeaderText="Contact Name" DataField="Contact_Name" ItemStyle-Width="17%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Relationship" DataField="RelationshipName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contact Priority" DataField="Contact_PriorityName" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Home Phone" DataField="Home_Phone" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Mobile" DataField="Mobile" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Work Phone" DataField="WorkPhone" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Email" DataField="Email_Addr" ItemStyle-Width="23%"></asp:BoundColumn>
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
  
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Job Information</span></td></tr>     
            <tr><td colspan="4">&nbsp;</td></tr>
 	        <tr>
			    <td class="mainheadtxt">Employee ID</td>
			    <td class="mainheadtxt">Job Title</td>
			    <td class="mainheadtxt">Employment Status</td>
			    <td class="mainheadtxt">Employment Category</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_EmpID disabled="true" cssclass="textfield" TabIndex=1 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_DesignationDDList" disabled=true TabIndex=2 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_EmpStatusDDList"  disabled=true TabIndex=3 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_EmpCategoryDDList" disabled=true TabIndex=4  AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		    </tr>	
		    <tr><td colspan="4">&nbsp;</td></tr>	    

		    <tr>
			    <td class="mainheadtxt">Supervisor Name</td>
			    <td class="mainheadtxt">Department</td>
			    <td class="mainheadtxt">Business Divison</td>
			     <td class="mainheadtxt">Work Location(City/Country)</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_SupervisorDDList" disabled=true cssclass="textfield" TabIndex=5 AutoPostBack=true runat="server" Width="180px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_DepartmentDDList" disabled=true cssclass="textfield" TabIndex=6 AutoPostBack=true runat="server" Width="200px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab5_DivisonDDList" disabled=true cssclass="textfield" TabIndex=7 AutoPostBack=true runat="server" Width="220px"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox disabled = "true"  id=Tab5_City cssclass="textfield" TabIndex=8 Maxlength="30" runat="server"></asp:textbox>
			                            <asp:textbox disabled = "true"  id=Tab5_CountryName cssclass="textfield" TabIndex=9 Maxlength="30" runat="server"></asp:textbox></td>

		    </tr>
   		    <tr><td colspan="4">&nbsp;</td></tr>   
		   <tr>
			    <td class="mainheadtxt">Hire Date</td>
			    <td class="mainheadtxt">Original Hire Date</td>
			    <td class="mainheadtxt">Resigned Date</td>
			    <td class="mainheadtxt">Date Left/Relieved</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_HireDate disabled=true cssclass="textfield" TabIndex=10  Maxlength="30" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:textbox id=Tab5_OriginalHDate disabled=true cssclass="textfield" TabIndex=11 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_ResignedDate disabled=true  cssclass="textfield" TabIndex=12 Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab5_DateLeft  disabled=true cssclass="textfield" TabIndex=13 Maxlength="30" runat="server"></asp:textbox></td>
		    </tr>
   		    <tr><td colspan="4">&nbsp;</td></tr>   
		   <tr>
			    <td class="mainheadtxt">Total Years of Service</td>
			    <td class="mainheadtxt">Years in Current Position</td>
			    <td class="mainheadtxt">Probabtion Period(Months)</td>
			     <td class="mainheadtxt">Probation End Date</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox disabled="true" id=Tab5_TotalServiceYears  cssclass="textfield" TabIndex=14  Maxlength="10" width="60px" runat="server"></asp:textbox></td>	
			    <td class="mainheadtxt"><asp:textbox disabled="true" id=Tab5_YearsinCurrentPosition  cssclass="textfield" TabIndex=15 Maxlength="10" width="60px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox disabled=true id=Tab5_ProbabtionYears   cssclass="textfield" TabIndex=16 Maxlength="10" width="60px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox disabled=true id=Tab5_ProbationEndDate  cssclass="textfield" TabIndex=16 Maxlength="30"  runat="server"></asp:textbox></td></td>
		    </tr>	
		    <tr>
		    	<td class="mainheadtxt">Probation Completed?&nbsp;&nbsp;<asp:CheckBox ID="Tab5_ProbationCompletedCheckBox" disabled="true" TabIndex=17 runat="server" Text="" ></asp:CheckBox></td>			                              
			    <td class="mainheadtxt">Supervisory Role&nbsp;&nbsp;<asp:CheckBox ID="Tab5_SupervisoryCheckBox" disabled="true" TabIndex=18 runat="server" Text="" ></asp:CheckBox></td>
		        <td class="mainheadtxt"></td>
		        <td class="mainheadtxt"></td>
            </tr>
	    
	 	    <tr>
		        <td colspan="4">&nbsp;</td>
		    </tr>

    <!-- Employee Position Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="EPGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="RowID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="EPGrid_PageIndexChanged"
                       Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class="HomeTitles">Employee Position History</td></tr></table>' CaptionAlign="Top">                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Designation Name" DataField="Designation" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Position Start Date" DataField="P_StartDate" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Position End Date" DataField="P_EndDate" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Supervisory Role" DataField="SupervisoryRole" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Current Position" DataField="Current_Position" ItemStyle-Width="23%"></asp:BoundColumn>
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
          <tr><td colspan="4">&nbsp;</td></tr>
	    </table>
	
  
 </asp:placeholder>
</td>
</tr>
<!--   End of Tab 5 -->

<!--   Start : Tab 6 -->
<tr><td width="100%">
 <asp:PlaceHolder id="CompensationTab" Runat="server" visible="false">
  
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Current Year Compensation(YTD)</span></td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr><td colspan="4" align=right class="validationtxt"><asp:label id="Tab6_lblCurrencyName" runat="server" /></td></tr>  	    
            
            <!-- Benefits Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="BTGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=HomeTitles>My Monthly Compensation/Benefit Details</td></tr></table>' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Benefit Component Name" DataField="PayComponentName" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Frequency" DataField="PayFrequency" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Comment" Visible=true DataField="ChangeReason" ItemStyle-Width="25%"></asp:BoundColumn>
                           
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
            <tr><td colspan="4">&nbsp;</td></tr>
            <!-- Deductions Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="DedGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="DeductionID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class="HomeTitles">My Standard/Reoccuring Monthly Deduction Details</td></tr></table>' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="PayComponentID" Visible=false DataField="PayComponentID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Deduction Comp.Name" DataField="PayComponentName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Ded\Adv Amt" DataField="Advance_DedAmount" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Repay Months" DataField="RepaymentMonths" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Repay Start" DataField="Repayment_StartMonthYear" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Repay End" DataField="Repayment_EndMonthYear" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Repay Amt(M)" DataField="MonthlyRepayment_Amt" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Repay Complete" DataField="Repayment_Complete"  ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Months Paid" DataField="MonthsPaid"  ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Active" Visible=false DataField="Active" ItemStyle-Width="0%"></asp:BoundColumn>
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
            <tr><td colspan="4">&nbsp;</td></tr>
            
 	        <tr>
			    <td class="mainheadtxt">Current Year Total Earnings(YTD)</td>
			    <td class="mainheadtxt">Current Year Unpaid Leave Deductions(YTD)</td>
			    <td class="mainheadtxt">Current Year Other Deductions(YTD)</td>
			    <td class="mainheadtxt">Current Year Net Pay(YTD)</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab6_EarningsYTD       disabled="true"   cssclass="textfield" TabIndex=1 Maxlength="50" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab6_LOPDeductYTD      disabled="true"   cssclass="textfield" TabIndex=2 Maxlength="50" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab6_OtherLOPDeductYTD disabled="true"   cssclass="textfield" TabIndex=3 Maxlength="50" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab6_NetEarningsYTD    disabled="true"   cssclass="textfield" TabIndex=4 Maxlength="50" runat="server"></asp:textbox></td>
		    </tr>		    
		    		    
            <tr><td colspan="4">&nbsp;</td></tr>

		    <tr>
			    <td class="mainheadtxt" colspan="2">End of Service Settlement:&nbsp;<asp:CheckBox ID="Tab6_EOSCheckBox1" disabled = "true" runat="server" Text="" checked=false /></td>
			    <td class="mainheadtxt" colspan="2">&nbsp;</td>
		    </tr>
		    <tr><td colspan="4">&nbsp;</td></tr>

          <!-- DataGrid to display employee's monthly paystub information -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="PayGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="Pay_MonthYear" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="PayGrid_PageIndexChanged"
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class="HomeTitles">Monthly Payroll History</td></tr></table>' CaptionAlign="Top">                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Pay Period" DataField="Pay_MonthYear" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Total Earnings" DataField="Earnings" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LOP Deductions" DataField="LOPDeductions" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Other Deductions" DataField="OtherDeductions" DataFormatString="{0:######.00}" ItemStyle-Width="14%"></asp:BoundColumn>    
                            <asp:BoundColumn HeaderText="Net Pay" DataField="NetPay" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>     
                            <asp:BoundColumn HeaderText="Total Days(PayCycle)" DataField="TotalDays_PayCycle" ItemStyle-Width="14%"></asp:BoundColumn>       
                            <asp:BoundColumn HeaderText="Total Days(Unpaid)" DataField="TotalDays_unpaid" ItemStyle-Width="14%"></asp:BoundColumn>                                                    
                            <asp:BoundColumn HeaderText="Net PayDays" DataField="NetPayDays" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" DataField="PayrollStatusName" ItemStyle-Width="16%"></asp:BoundColumn>
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="Tab6_EmptRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr> 
   		  
   		  
   		  
   		    <tr><td colspan="4">&nbsp;</td></tr>	
	    </table>
	
 </asp:placeholder>
</td>
</tr>
<!--    End of Tab 6-->

<!--    Start: Tab 7 -->
<tr><td width="100%">
 <asp:PlaceHolder id="OtherBenefitsTab" Runat="server" visible="false">
  
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Leave Balance</span></td></tr> 
            <tr><td colspan="4">&nbsp;</td></tr>
              <!-- DataGrid to display employee's annual leave entitlements -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="EGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="EntitlementID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="EGrid_PageIndexChanged">                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Annual Entitled(Days)" DataField="Annual_Entitlement" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Current Balance(Days)" DataField="Annual_Balance" ItemStyle-Width="16%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LM Approval" DataField="LineMgr_Approval" ItemStyle-Width="16%"></asp:BoundColumn>    
                            <asp:BoundColumn HeaderText="Dept Head Approval" DataField="Dept_Approval" ItemStyle-Width="16%"></asp:BoundColumn>                                                    
                            <asp:BoundColumn HeaderText="Current Leave period" DataField="LeavePeriodName" ItemStyle-Width="18%"></asp:BoundColumn>
                       </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />
                        <HeaderStyle CssClass="DashGridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="Tab1_EmptRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr> 
       	    <tr><td colspan="4">&nbsp;</td></tr>
   
	     </table>
	</fieldset>
 </asp:placeholder>
</td>
</tr>
<!---  End of Tab 7 -->
<!--   Start : Tab 8 -->
<tr><td width="100%">
 <asp:PlaceHolder id="ManagementChainTab" Runat="server" visible="false">
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Employee Management Chain</span></td></tr> 
            
	        <tr>
	            <td colspan="4" class="mainheadtxt">
		          <asp:TreeView  ID="MyOrgTree" ExpandDepth="0"  PopulateNodesFromClient="true" cssclass="mainheadtxt" ShowLines="true"  ShowExpandCollapse="true"  runat="server" />
               </td> 
     		</tr>
            <tr><td colspan="4">&nbsp;</td></tr>     		
       	        
	    </table>  	                
 </asp:placeholder>
</td>
</tr>

<!---  End of Tab 8 -->


<!--- Common for all tabs --->

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</asp:PlaceHolder>

</table>
	<!--   End of Data Area -->
										
</master:content>

