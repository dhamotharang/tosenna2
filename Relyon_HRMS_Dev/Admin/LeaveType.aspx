<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveType.aspx.cs" Inherits="SchoolNet.LeaveType" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Leave Type Definition</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
		         <td class="mainheadtxt">Business Unit<font color="red">*</font></td>
		        <td class="mainheadtxt">Country<font color="red">*</font></td>
			    <td class="mainheadtxt">Leave Type<font color="red">*</font></td>
			    <td class="mainheadtxt">Pay Type</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_businessUnitDDList" TabIndex=1 AutoPostBack=true onselectedindexchanged="Tab1_businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_DivisionLocationList" runat="server" Width="150px" TabIndex=2 CssClass="textfield"></asp:dropdownlist></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_LeaveTypeDDList" runat="server" Width="150px" TabIndex=3 CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_Rb1_PayType1" runat="server" Text="Paid" Checked= 'true' value ="1" GroupName="LeavePayType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_Rb1_PayType2" runat="server" Text="Unpaid"  value = "0" GroupName="LeavePayType" AutoPostBack="false" />                                        
                                        <asp:Label id="Tab1_keyField" runat="server" visible=false />
			    </td>
			</tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_businessUnitDDList InitialValue=-1  ErrorMessage="Business Unit is required." /></td>   
	            <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DivisionLocationList InitialValue=-1  ErrorMessage="Location is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_LeaveTypeDDList InitialValue=-1 ErrorMessage="Leave Type is required." /></td>   
		        <td class="validationtxt"></td>                           
		    </tr>
		    
		    <tr>
		        <td class="mainheadtxt">Full Pay Days(Max)</td>
		        <td class="mainheadtxt">Partial Pay Days(Max)<small>(Applies to Maternity/Sick) </small></td>
		        <td class="mainheadtxt">Partial Pay %<small>(Applies to Maternity/Sick) </small></td>
		        <td class="mainheadtxt">Maximum Days Allowed</td>			    
  		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_MaxFullPayDays cssclass="textfield" TabIndex=4 Maxlength="2" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_MaxPartialPayDays cssclass="textfield" TabIndex=5 Maxlength="2" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PartialPayPercentage cssclass="textfield" TabIndex=6 Maxlength="2" width="40px" runat="server"></asp:textbox>&nbsp;% of Salary</td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_MaxDaysAllowed cssclass="textfield" TabIndex=7 Maxlength="3"  runat="server"></asp:textbox></td>			    
			    
			    
		    </tr>
		    <tr>
	            <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_MaxFullPayDays Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		        <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_MaxPartialPayDays Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		        <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_PartialPayPercentage Type=double Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter a valid value" runat="server"></asp:CompareValidator></td>   
                <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_MaxDaysAllowed Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		    </tr>
		   	
	        <tr><td colspan="4"><hr /></td></tr>
            <tr  align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=LeaveType_Save runat="server" BorderStyle="Ridge" CausesValidation="True" TabIndex=8 CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                               &nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" TabIndex=9 CssClass="button" BorderWidth="1px" Text="Reset"></asp:button> 
			    </center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="LTmessage" runat="server" visible=false /></td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Emergency Contact Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="7" AllowPaging="True" DataKeyField="LeaveTypeID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"  OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" 
                      Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Leave Types List</td></tr></table>' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="DivisionID" Visible=false DataField="DivisionID" ItemStyle-Width="0%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LocationID" Visible=false DataField="LocationID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Type Name" DataField="LeaveTypeName" ItemStyle-Width="14%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Type" DataField="LeavePayType" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Full Pay Days(Max)" DataField="MaxFullPayDays" ItemStyle-Width="14%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Partial Pay Days(Max)" DataField="MaxPartialPayDays" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Partial Pay %" DataField="PartialPayPercentage" ItemStyle-Width="11%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="MaxDaysAllowed"  DataField="MaxDaysAllowed" ItemStyle-Width="12%"></asp:BoundColumn>                            
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
                       <HeaderStyle CssClass="GridHeader"/>
                   </asp:DataGrid>
                    </br>
                    <center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	       </fieldset>
 </td>
</tr>
</asp:placeholder>
<!--  End of Tab 4 -->

</table>
	<!--   End of Data Area -->
										
</master:content>

