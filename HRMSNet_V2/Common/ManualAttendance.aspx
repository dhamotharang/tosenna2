<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManualAttendance.aspx.cs" Inherits="SchoolNet.ManualAttendance" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%"> 
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <tr><td class="colheader"><span class="maintitledesign">Manual Attendance Submission</span></td></tr>
 <asp:PlaceHolder id="LeaveTypeTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Punching Date<font color="red">*</font></td>
			     <td class="mainheadtxt">Punch In Time<font color="red">*</font></td>
			    <td class="mainheadtxt">Punch Out Time<font color="red">*</font></td>
			    <td class="mainheadtxt">Reason Catagory</td>
			</tr>
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PunchingDate  TabIndex=1 CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PunchInTime    TabIndex=2 CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
                <td class="mainheadtxt"><asp:textbox id=Tab1_PunchOutTime    TabIndex=2 CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
			    <td class="mainheadtxt"> <asp:dropdownlist id="Tab1_ReasonTypeList" TabIndex=3 CssClass="textfield" runat="server" Width="180px" ></asp:dropdownlist></td>
			    
			</tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_PunchingDate  ErrorMessage="Punching Date is required." />
                                        <br /><asp:RegularExpressionValidator  runat=server ControlToValidate=Tab1_PunchingDate  Display="static" ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." />
                </td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_PunchInTime  ErrorMessage="Punch-in Time is required." />                
                </td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_PunchOutTime  ErrorMessage="Punch-out Time is required." />                
                </td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ReasonTypeList InitialValue=-1 ErrorMessage="Reason Catagory is required." /></td>   
   			    
             </tr> 
               
		    <tr>
			    <td class="mainheadtxt">Comments<font color="red">*</font></td>
			    <td class="mainheadtxt">Request Log</td>		
                <td class="mainheadtxt">&nbsp;</td>		
			    <td class="mainheadtxt">&nbsp;</td>
                 
			    
			</tr>
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_Comments  TabIndex=4 CssClass="textfield" Maxlength="50" width="180px" runat="server"></asp:textbox></td>
			    <td Colspan=3 class="mainheadtxt"><div id="Tab1_Request_Log" runat="server"></div></td>
			</tr>
          
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=ManualPunch_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
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
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="12" AllowPaging="True" DataKeyField="ID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" 
                                  OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Punch Date" DataField="PunchingDate" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Punch In Time" DataField="PunchInTime" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Punch Out Time" DataField="PunchOutTime" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Reason Catagory" DataField="ActionTypeName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Request Log" DataField="RequestLog" ItemStyle-Width="40%"></asp:BoundColumn>                                                      
                            <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="StatusID" Visible= false DataField="Status" ItemStyle-Width="10%"></asp:BoundColumn>
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


