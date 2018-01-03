<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TAShiftMaster.aspx.cs" Inherits="SchoolNet.TAShiftMaster" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
  <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Manage Shifts</span></td>
	</tr>	
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
		         <td class="mainheadtxt">Business Unit<font color="red">*</font></td>
		        <td class="mainheadtxt">Country<font color="red">*</font></td>
			    <td class="mainheadtxt">Shift Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Shift Short Name</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_businessUnitDDList" TabIndex=1 AutoPostBack=true onselectedindexchanged="Tab1_businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_DivisionLocationList" runat="server" Width="150px" TabIndex=2 CssClass="textfield"></asp:dropdownlist></td>
                <td class="mainheadtxt"><asp:textbox id=ShiftName cssclass="textfield" Maxlength="50" width="160px" TabIndex=3 runat="server"></asp:textbox>
                                        <asp:Label id="Tab1_keyField" runat="server" visible=false />
                </td>
                <td class="mainheadtxt"><asp:textbox id=ShiftCode  Maxlength="50" cssclass="textfield" TabIndex=4 runat="server"></asp:textbox></td>
			</tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_businessUnitDDList InitialValue=-1  ErrorMessage="Business Unit is required." /></td>   
	            <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_DivisionLocationList InitialValue=-1  ErrorMessage="Location is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=ShiftName  ErrorMessage="Shift Name is required." /></td>   
		        <td class="validationtxt">&nbsp;</td>                           
		    </tr>
		    
		    <tr>
		        <td class="mainheadtxt">In Time<font color="red">*</font></td>
		        <td class="mainheadtxt">Out Time<font color="red">*</font></td>
		        <td class="mainheadtxt">Late Coming Allowed<font color="red">*</font></td>
		        <td class="mainheadtxt">Early Going Allowed<font color="red">*</font></td>			    
  		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_ShiftInTime cssclass="textfield" TabIndex=5 Maxlength="2" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_ShiftOutTime cssclass="textfield" TabIndex=6 Maxlength="2" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab1_LateAllowed1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="LateAllowed" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_LateAllowed2" runat="server" Text="No"  value = "0" GroupName="LateAllowed" AutoPostBack="false" />                                        
			    </td>	    
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_EarlyAllowed1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="EarlyAllowed" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_EarlyAllowed2" runat="server" Text="No"  value = "0" GroupName="EarlyAllowed" AutoPostBack="false" />                                        
			    </td>    
		    </tr>
		    <tr>
	            <td class="validationtxt">&nbsp;</td>   
		        <td class="validationtxt">&nbsp;</td>   
		        <td class="validationtxt">&nbsp;</td>   
                <td class="validationtxt">&nbsp;</td>   
		    </tr>

            <tr>
		        <td class="mainheadtxt">Lunch Allowed<font color="red">*</font></td>
		        <td class="mainheadtxt">Fixed Lunch Minutes</td>
		        <td class="mainheadtxt">Break Allowed<font color="red">*</font></td>
		        <td class="mainheadtxt">Fixed Break Minutes</td>			    
  		    </tr>
		    <tr>
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_LunchAllowed1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="LunchAllowed" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_LunchAllowed2" runat="server" Text="No"  value = "0" GroupName="LunchAllowed" AutoPostBack="false" />                                        
			    </td>
                <td class="mainheadtxt"><asp:textbox id=Tab1_FixedLunchMins cssclass="textfield" TabIndex=5 Maxlength="6" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_BreakAllowed1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="BreakAllowed" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_BreakAllowed2" runat="server" Text="No"  value = "0" GroupName="BreakAllowed" AutoPostBack="false" />                                        
			    </td>
                <td class="mainheadtxt"><asp:textbox id=Tab1_FixedBreakMins cssclass="textfield" TabIndex=7 Maxlength="6"  runat="server"></asp:textbox></td>			    
		    </tr>
		    <tr>
	            <td class="validationtxt">&nbsp;</td>   
		        <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_FixedLunchMins Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		        <td class="validationtxt">&nbsp;</td>   
                <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_FixedBreakMins Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		    </tr>
            
            
            <tr>
		        <td class="mainheadtxt">Fixed Full-Day Minutes<font color="red">*</font></td>
		        <td class="mainheadtxt">Fixed Half-Day Minutes<font color="red">*</font></td>
		        <td class="mainheadtxt">OT Allowed<font color="red">*</font></td>
		        <td class="mainheadtxt">OT Offset</td>			    
  		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_FixedFullDayMins cssclass="textfield" TabIndex=4 Maxlength="6" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"><asp:textbox id=Tab1_FixedHalfDayMins cssclass="textfield" TabIndex=5 Maxlength="6" runat="server"></asp:textbox></td>			    
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_OTAllowed1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="OTAllowed" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_OTAllowed2" runat="server" Text="No"  value = "0" GroupName="OTAllowed" AutoPostBack="false" />                                        
			    </td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_OTOffset cssclass="textfield" TabIndex=7 Maxlength="3"  runat="server"></asp:textbox></td>			    
			    
			    
		    </tr>
		    <tr>
	            <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_FixedFullDayMins Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		        <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_FixedHalfDayMins Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		        <td class="validationtxt">&nbsp;</td>   
                <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_OTOffset Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>   
		    </tr>
            
            <tr>
                <td class="mainheadtxt">Grace Period</td>	
                <td class="mainheadtxt">Set As Default</td>
		        <td class="mainheadtxt">Ends Next Day</td>    		    
                <td class="mainheadtxt">&nbsp;</td>			    
  		    </tr>
		    <tr>
            	<td class="mainheadtxt"><asp:textbox id=Tab1_GracePeriod cssclass="textfield" Maxlength="6" runat="server"></asp:textbox></td>
                <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_IsDefault1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="SetasDefault" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_IsDefault2" runat="server" Text="No"  value = "0" GroupName="SetasDefault" AutoPostBack="false" />                                        
			    </td>
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab1_EndsNextDay1" runat="server" Text="Yes" Checked= 'true' value ="1" GroupName="EndsNextDay" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_EndsNextDay2" runat="server" Text="No"  value = "0" GroupName="EndsNextDay" AutoPostBack="false" />                                        
			    </td>
                <td class="mainheadtxt">&nbsp;</td>	
		    </tr>
            
            <tr>
            	<td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab1_GracePeriod Type=Integer Display=static Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>
                <td class="mainheadtxt">&nbsp;</td>	
                <td class="mainheadtxt">&nbsp;</td>	
                <td class="mainheadtxt">&nbsp;</td>	
		    </tr>

		   	<tr class="PartButtons" align=center>
			    <td  colspan="4">
			    <center>
			        <asp:button id=LeaveType_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			        &nbsp;&nbsp;&nbsp;
			        <asp:button id=Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			    </center>
			    </td>
            </tr>
            <tr>
                <td colspan="4" align=center><asp:label id="LTmessage" runat="server" visible=false /></td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Emergency Contact Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="ShiftID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"  OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" 
                      Caption='' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="DivisionID" Visible=false DataField="DivisionID" ItemStyle-Width="0%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="LocationID" Visible=false DataField="LocationID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Name" DataField="ShiftName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Code" Visible=false DataField="ShiftShortName" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="In Time" DataField="InTime" ItemStyle-Width="7%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Out Time" DataField="OutTime" ItemStyle-Width="7%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Late Allowed" DataField="LateAllowed" ItemStyle-Width="5%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Early Allowed" DataField="EarlyAllowed" ItemStyle-Width="5%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Ends Next Day"  DataField="EndsNextDay" ItemStyle-Width="5%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Lunch Allowed" DataField="Lunch_Allowed" ItemStyle-Width="5%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Break Allowed" DataField="BreakAllowed" ItemStyle-Width="5%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Fixed Lunch Minutes" Visible=false DataField="LunchMinsFixed" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Fixed Break Minutes" Visible=false DataField="BreakMinsFixed" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Full Day Minutes" DataField="FullDayMinutes" ItemStyle-Width="6%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Half Day Minutes" DataField="HalfDayMinutes" ItemStyle-Width="6%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OT Allowed" DataField="OTAllowed" ItemStyle-Width="4%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OT Offset" Visible=false DataField="OTOffset" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Grace Period" Visible=false DataField="GracePeriod" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Set as Default" DataField="SetDefault" ItemStyle-Width="4%"></asp:BoundColumn>
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

