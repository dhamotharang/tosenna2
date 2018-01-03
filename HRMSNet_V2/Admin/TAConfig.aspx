<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TAConfig.aspx.cs" Inherits="SchoolNet.TAConfig" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
  <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Time & Attendance Configuration</span></td>
	</tr>	
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
		         <td class="mainheadtxt">Business Unit<font color="red">*</font></td>
		        <td class="mainheadtxt">Country<font color="red">*</font></td>
			    <td class="mainheadtxt">Employee Edit Access<font color="red">*</font></td>
			    <td class="mainheadtxt">Employee Delete Access</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_businessUnitDDList" TabIndex=1 AutoPostBack=true onselectedindexchanged="Tab1_businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_DivisionLocationList" runat="server" Width="150px" TabIndex=2 CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_EmpEditAccess1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="EmpEditAccess" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_EmpEditAccess2" runat="server" Text="No"  value = "0" GroupName="EmpEditAccess" AutoPostBack="false" />                                        
                                        <asp:Label id="Tab1_keyField" runat="server" visible=false />
			    </td>
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_EmpDelAccess1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="EmpDelAccess" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_EmpDelAccess2" runat="server" Text="No"  value = "0" GroupName="EmpDelAccess" AutoPostBack="false" />                                        
			    </td>
			</tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_businessUnitDDList InitialValue=-1  ErrorMessage="Business Unit is required." /></td>   
	            <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DivisionLocationList InitialValue=-1  ErrorMessage="Location is required." /></td>   
		        <td class="validationtxt"></td>   
		        <td class="validationtxt"></td>                           
		    </tr>
		    
		    <tr>
		        <td class="mainheadtxt">Supervisor Modify Access</td>
		        <td class="mainheadtxt">Lunch Allowed</td>
		        <td class="mainheadtxt">OT Allowed</td>
		        <td class="mainheadtxt">Maximum OT Allowed <small>(minutes per day)</small></td>			    
  		    </tr>
		    <tr>
                <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_SupervisorAccess1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="SupEditAccess" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_SupervisorAccess2" runat="server" Text="No"  value = "0" GroupName="SupEditAccess" AutoPostBack="false" />                                        
                                        
			    </td>
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_LunchAllowed1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="LunchAllowed" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_LunchAllowed2" runat="server" Text="No"  value = "0" GroupName="LunchAllowed" AutoPostBack="false" />                                        
                                        
			    </td>
                <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_OTAllowed1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="OTAllowed" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_OTAllowed2" runat="server" Text="No"  value = "0" GroupName="OTAllowed" AutoPostBack="false" />                                        
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_MaxOTMinsAllowed cssclass="textfield" TabIndex=7 Maxlength="6"  runat="server"></asp:textbox></td>			    
			    
			    
		    </tr>
		    <tr>
	            <td class="validationtxt"></td>   
		        <td class="validationtxt"></td>   
		        <td class="validationtxt"></td>   
                <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_MaxOTMinsAllowed Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		    </tr>
		   	<tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=TAConfig_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=TAConfig_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>
             <tr>
                <td colspan="4" align=center><asp:label id="LTmessage" runat="server" visible=false /></td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="TAConfig_ID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"  OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" 
                      Caption='' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="DivisionID" Visible=false DataField="DivisionID" ItemStyle-Width="0%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LocationID" Visible=false DataField="LocationID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Employee Edit Access" DataField="Emp_EditAllowed" ItemStyle-Width="14%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Employee Delete Access" DataField="Emp_DelAllowed" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Supervisor Edit Access" DataField="Sup_EditDelAllowed" ItemStyle-Width="14%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Lunch Allowed" DataField="Lunch_Allowed" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OT Allowed" DataField="OT_Allowed" ItemStyle-Width="11%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Maximum OT Allowed (mins)"  DataField="MaxDaysAllowed" ItemStyle-Width="12%"></asp:BoundColumn>                            
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     
                                     <asp:ImageButton ImageUrl="~/images/buttons/blue_edit1.png" name="Edit" commandName="Edit" alt="Edit" ToolTip="Edit" CausesValidation="false" runat="server" height="28" width="28" />                                                                    
                                </ItemTemplate>
                            </asp:TemplateColumn>
                      </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />                
                       <HeaderStyle CssClass="DashGridHeader"/>
                   </asp:DataGrid>
                    </br>
                    <center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	       
 </td>
</tr>
</asp:placeholder>
<!--  End of Tab 4 -->

</table>
	<!--   End of Data Area -->
										
</master:content>

