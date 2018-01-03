<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GratuityRule.aspx.cs" Inherits="SchoolNet.GratuityRule" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="PayComponentTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>End of Service(EOS) Gratuity Rules</legend>
      <table width="100%" border="0" class="Partgrayblock">
         <!-- Benefits Grid -->
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
		         <td class="mainheadtxt">Business Unit<font color="red">*</font></td>
		        <td class="mainheadtxt">Country<font color="red">*</font></td>
			    <td class="mainheadtxt">Gratuity Type<font color="red">*</font></td>
			    <td class="mainheadtxt">Gratuity Expression</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_businessUnitDDList" TabIndex=1 AutoPostBack=true onselectedindexchanged="Tab1_businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_DivisionLocationList" runat="server" Width="150px" TabIndex=2 CssClass="textfield"></asp:dropdownlist></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_GratuityTypeDDList"  runat="server" Width="150px" TabIndex=3 CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_GratuityExpression readonly = true Width="230px" cssclass="textfield" TabIndex=4 Maxlength="2" runat="server"></asp:textbox></td>
			</tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_businessUnitDDList InitialValue=-1  ErrorMessage="Business Unit is required." /></td>   
	            <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DivisionLocationList InitialValue=-1  ErrorMessage="Location is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_GratuityTypeDDList InitialValue=-1 ErrorMessage="Gratuity Type is required." /></td>   
		        <td class="validationtxt"></td>                           
		    </tr>
		    
		    <tr>
		        <td class="mainheadtxt">Param 1(Days of Wage)</td>
		        <td class="mainheadtxt">Param 1(% of Wage)</td>
		        <td class="mainheadtxt">Param 2(Days of Wage)</td>
		        <td class="mainheadtxt">Param 2(% of Wage)</td>			    
  		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Param1Days cssclass="textfield" TabIndex=5 Maxlength="2" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Param1Percentage cssclass="textfield" TabIndex=6 Maxlength="2" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Param2Days cssclass="textfield" TabIndex=7 Maxlength="2" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Param2Percentage cssclass="textfield" TabIndex=8 Maxlength="3"  runat="server"></asp:textbox></td>			    			    
			    
		    </tr>
		    <tr>
	            <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_Param1Days Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		        <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_Param1Percentage Type=double Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter a valid value" runat="server"></asp:CompareValidator></td>   
		        <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_Param2Days Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
                <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_Param2Percentage Type=double Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter a valid value" runat="server"></asp:CompareValidator></td>   
		    </tr>
             <tr>
		        <td class="mainheadtxt" colspan="4">Maxmimum Wage Constraint(Years)</td>
  		    </tr>		    
		    <tr>
			    <td class="mainheadtxt" colspan="4"><asp:textbox id=Tab1_WageConstraint cssclass="textfield" TabIndex=9 Maxlength="2" runat="server"></asp:textbox></td>			    
            </tr>	
		    <tr>
	            <td class="validationtxt" colspan="4"><asp:CompareValidator  ControlToValidate=Tab1_WageConstraint Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		    </tr>
            	   	
	        <tr><td colspan="4"><hr /></td></tr>
            <tr  align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=EOS_Save runat="server" BorderStyle="Ridge" CausesValidation="True" TabIndex=8 CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                               &nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" TabIndex=9 CssClass="button" BorderWidth="1px" Text="Reset"></asp:button> 
			    </center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="LTmessage" runat="server" visible=false />
                                             <asp:Label id="Tab1_KeyField" runat="server" visible=false />
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
         
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="GratuityRuleId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"  OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" 
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>End of Service Gratuity Rules List</td></tr></table>' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="DivisionID" Visible=false DataField="DivisionID" ItemStyle-Width="0%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="13%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LocationID" Visible=false DataField="LocationID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="GratuityTypeID" Visible=false DataField="GratuityTypeID" ItemStyle-Width="0%"></asp:BoundColumn>                      
                            <asp:BoundColumn HeaderText="GratuityName" DataField="GratuityName" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Gratuity Expression" DataField="GratuityCalcExpression" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Param 1(Days)" DataField="Part1_Days" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Param 1(%)" DataField="Part1_Percentage" ItemStyle-Width="8%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Param 2(Days)" DataField="Part2_Days" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Param 2(%)" DataField="Part2_Percentage" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Max Wage Constraint(YR)" visible=false DataField="MaxYearWageConstraint" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server"  />                                                                  
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
         
                </td>
            </tr>
          
            <tr><td colspan="4"><hr /></td></tr>
            
           </table>   	 
	   </fieldset>
 </td>
</tr>
</asp:placeholder>
</table>								
</master:content>


