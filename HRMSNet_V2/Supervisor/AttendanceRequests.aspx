<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceRequests.aspx.cs" Inherits="SchoolNet.AttendanceRequests" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Attendance Requests Inbox</span></td>
	</tr>	 
<!--   End of Tab2 -->
<!--   Tab3 :Pending Leave Requests for Approval -->
<tr><td width="100%"> 
   <asp:PlaceHolder id="Tab3_Pane" Runat="server" visible="true">
    
      <table width="100%" border="0" class="Partgrayblock">              
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
        	    <td class="mainheadtxt">Punch Date</td>
		        <td class="mainheadtxt">Punch In Time</td>
			    <td class="mainheadtxt">Punch Out Time</td>
			    <td class="mainheadtxt">Reason Catagory</td>
			</tr>
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PunchingDate disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_PunchInTime   disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
                <td class="mainheadtxt"><asp:textbox id=Tab1_PunchOutTime   disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_ReasonTypeList" disabled=true  CssClass="textfield" runat="server" Width="180px" ></asp:dropdownlist></td>
			</tr>
            <tr><td colspan="4">&nbsp;</td></tr>
   	        <tr>
   	            <td class="mainheadtxt">Employee Name</td>
   	            <td class="mainheadtxt">Required Approval </td>
   	            <td class="mainheadtxt">Approver Comments</td>
                <td class="mainheadtxt">Request Log</td>
   	        </tr>
   	        <tr>
   	            <td class="mainheadtxt"><asp:textbox id=Tab3_EmpName  disabled="true"  CssClass="textfield" Maxlength="50"  width="200px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab3_ApprRB1" TabIndex=2 runat="server" Text="Approved" Checked= 'true' value ="1" GroupName="ApprovalType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab3_ApprRB2" runat="server" Text="Rejected"  value = "0" GroupName="ApprovalType" AutoPostBack="false" /> 
                </td>
                <td class="mainheadtxt"><asp:textbox id=Tab3_ApproverComments  TabIndex=3 CssClass="textfield" Maxlength="50" width="200px" runat="server"></asp:textbox></td>	    			    			
                <td class="mainheadtxt"><div id="Tab1_Request_Log" runat="server" clientidmode=static></div></td>
		    </tr>	
	        <tr><td colspan="4">&nbsp;</td></tr>
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab3_Approve runat="server" CausesValidation="True" CssClass="Button SubmitButton" Text="Submit"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab3_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>
		 
             <tr>
                <td colspan="4" align=center><asp:label id="Tab3_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab3_keyField" runat="server" visible=false />
                
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!--  Grid -->
             <tr width="100%">
                <td colspan="4">
                    <asp:DataGrid ID="ALGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="15" AllowPaging="True" DataKeyField="ID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="ALGrid_PageIndexChanged" 
                                   OnEditCommand="ALGrid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee Name" DataField="Emp_Name" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Punch Date" DataField="PunchingDate" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Punch In" DataField="PunchInTime" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Punch Out" DataField="PunchOutTime" ItemStyle-Width="10%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Reason Catagory" DataField="ActionTypeName" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Request Log" DataField="RequestLog" ItemStyle-Width="30%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Select" commandName="Edit" CausesValidation="false" Text="Select" runat="server" />
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
                    <br /><center><asp:label id ="Tab3_EmptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	       
    </asp:placeholder>
</td>
</tr>
<!--   End of Tab2 -->


<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			


</table>
	<!--   End of Data Area -->
										
</master:content>

