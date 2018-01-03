<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageDependents.aspx.cs" Inherits="SchoolNet.ManageDependents" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  
<!--   Start of Tab3 -->
<tr><td width="100%">
<asp:PlaceHolder id="DependentTab" Runat="server" visible="true">
     <fieldset><legend>Dependent Information</legend>
        <table width="100%" border="0" class="Partgrayblock">        
    
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
			    <td class="mainheadtxt">Visa Number</td>
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
          		    
            <tr align=center>
			     <td  valign="middle" colspan="4"><center><asp:button id=DP_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                              &nbsp;&nbsp;<asp:button id=DP_Cancel runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Cancel"></asp:button>
			                                              &nbsp;&nbsp;<asp:button id=Tab3_Back runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Back to Employee List"></asp:button>
			    </center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="DPmessage" runat="server" visible=false />
                                            <asp:Label id="keyField" runat="server" visible=false />
                </td>
            </tr>

            <tr><td colspan="4"><hr /></td></tr>
             
            <!-- Datagrid for dependents -->
            <tr>
                <td colspan="4">
                        <asp:DataGrid ID="DPGrid" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="dependentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="DPGrid_PageIndexChanged"                                      OnCancelCommand="DPGrid_CancelCommand" OnDeleteCommand="DPGrid_DeleteCommand" OnEditCommand="DPGrid_EditCommand" OnUpdateCommand="DPGrid_UpdateCommand">
                                       
                          <Columns>
                                <asp:BoundColumn HeaderText="Name" DataField="FullName" ItemStyle-Width="18%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Relationship" DataField="RelationshipName" ItemStyle-Width="12%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="DOB" DataField="DOB" ItemStyle-Width="10%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Gender" DataField="GenderName" ItemStyle-Width="12%" ></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Passport No" DataField="PassportNumber" ItemStyle-Width="12%"> </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Issue Country" DataField="CountryName" ItemStyle-Width="15%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Issue Date" DataField="PP_IssueDate" ItemStyle-Width="12%"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PP Exp Date" DataField="PP_ExpiryDate" ItemStyle-Width="12%"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="" ItemStyle-Width="5%">
                                   <ItemTemplate> 
                                      <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                    </ItemTemplate>
                                </asp:TemplateColumn>                    
                                <asp:TemplateColumn HeaderText="" ItemStyle-Width="5%">
                                   <ItemTemplate> 
                                       <asp:LinkButton name="Delete" commandName="Delete" Text="Delete" CausesValidation="false" runat="server" OnClientClick="return confirm('Are you sure you want to delete the record?');" /> 
                                   </ItemTemplate>
                                 </asp:TemplateColumn>                                
                           </Columns>     
                            <FooterStyle CssClass="GridFooter" />
                            <SelectedItemStyle CssClass="GridSelectedItem" />
                            <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                            <AlternatingItemStyle CssClass="GridAltItem" />
                            <ItemStyle CssClass="GridItem" />
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:DataGrid>
                        <br/><center><asp:label id ="emptyRow2" value="" visible=false runat="server" /></center>          
                </td>
               </tr>           			    
        </table>
	</fieldset>
  </asp:placeholder>
</td>
</tr>
<!--  End of Tab3 -->

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			

</table>
	<!--   End of Data Area -->
										
</master:content>


