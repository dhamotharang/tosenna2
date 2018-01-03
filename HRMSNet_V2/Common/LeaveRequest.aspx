<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveRequest.aspx.cs" Inherits="SchoolNet.LeaveRequest" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%"> 
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr><td class="colheader"><span class="maintitledesign">Employee Leave Request</span></td></tr>
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Leave Start Date<font color="red">*</font></td>
			     <td class="mainheadtxt">Leave End Date<font color="red">*</font></td>
			    <td class="mainheadtxt">Leave Type<font color="red">*</font></td>
			    <td class="mainheadtxt">Comments</td>
			</tr>
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_StartDate  TabIndex=1 CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_EndDate    TabIndex=2 CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
			    <td class="mainheadtxt"> <asp:dropdownlist id="Tab1_LeaveTypeList" TabIndex=3 CssClass="textfield" runat="server" Width="180px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Comments  TabIndex=4 CssClass="textfield" Maxlength="50" width="180px" runat="server"></asp:textbox></td>	    			    			
			</tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_StartDate  ErrorMessage="Leave Start Date is required." />
                                        <br /><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_StartDate  Display="static" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." />
                </td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EndDate  ErrorMessage="Leave End Date is required." />
                                        <br /><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_EndDate  Display="Dynamic" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." />
                </td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_LeaveTypeList InitialValue=-1 ErrorMessage="Leave Type is required." /></td>   
   			    <td class="validationtxt">&nbsp;</td>
             </tr> 
             <!-- This is needed to check only for partial days-->              
   	       <asp:placeholder id="Partialday" runat="server" visible=true> 
   	           <tr>         
   	                <td class="mainheadtxt" colspan="4" align=left>Choose Day Type:&nbsp;<asp:RadioButton ID="Tab1_DayRB1" TabIndex=5 runat="server" Text="Full Day" Checked= 'true' value ="1" GroupName="DayType" AutoPostBack="false" />  
                                            &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab1_DayRB2" runat="server" Text="Half Day"  value = "0" GroupName="DayType" AutoPostBack="false" /> 
                                            &nbsp;<small>(Please note that this day type applies only to single day leave. Multiple days are always counted as full day option)</small>
                     </td>
   	            </tr>
		  </asp:placeholder>
		  
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=LeaveRequest_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
                <asp:button id=Reset runat="server" CausesValidation="True" CssClass="Button ResetButton" Text="Reset"></asp:button>
			    
			</center>
			</td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="Hmessage" runat="server" visible=false />&nbsp;<asp:Label id="Tab1_keyField" runat="server" visible=false /></td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="12" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Leave Start Date" DataField="Leave_StartDate" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave End Date" DataField="Leave_EndDate" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Days Requested" DataField="DaysRequested" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Type" DataField="LeavePayType" ItemStyle-Width="10%"></asp:BoundColumn>  
                            <asp:BoundColumn HeaderText="Emp Comment" visible=false DataField="Comments" ItemStyle-Width="0%"></asp:BoundColumn>                                                      
                            <asp:BoundColumn HeaderText="Approver Comment" DataField="Approver_Comments" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="10%">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server"  />                                                                  
                                     &nbsp;<asp:LinkButton name="Delete" commandName="Delete" Text="Delete"  CausesValidation="false" runat="server" />
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
                    <br /><center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	      
 </td>
</tr>
</asp:placeholder>
</table>								
</master:content>


