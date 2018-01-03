<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingLeaveRequests.aspx.cs" Inherits="SchoolNet.PendingLeaveRequests" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Leave Requests Inbox</span></td>
	</tr>	 
<!--   End of Tab2 -->
<!--   Tab3 :Pending Leave Requests for Approval -->
<tr><td width="100%"> 
   <asp:PlaceHolder id="Tab3_Pane" Runat="server" visible="true">
    
      <table width="100%" border="0" class="Partgrayblock">              
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
        	    <td class="mainheadtxt">Leave Start Date</td>
		        <td class="mainheadtxt">Leave End Date</td>
			    <td class="mainheadtxt">Leave Type</td>
			    <td class="mainheadtxt">Employee's Comment</td>
			</tr>

			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_StartDate disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_EndDate   disabled="true"  CssClass="textfield" Maxlength="10" runat="server"></asp:textbox></td>		
			    <td class="mainheadtxt"> <asp:dropdownlist id="Tab3_LeaveTypeList" disabled=true  CssClass="textfield" runat="server" Width="180px" ></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab3_Comments  disabled="true"  CssClass="textfield" Maxlength="100" width="250px" runat="server"></asp:textbox></td>	    			    			
			</tr>

            <tr><td colspan="4">&nbsp;</td></tr>
   	        <tr>
   	            <td class="mainheadtxt">Employee Name</td>
   	            <td class="mainheadtxt">Leave Pay Type</td>
   	            <td class="mainheadtxt">Required Approval </td>
   	            <td class="mainheadtxt">Approver's Comment</td>
   	        </tr>
   	        <tr>
   	            <td class="mainheadtxt"><asp:textbox id=Tab3_EmpName  disabled="true"  CssClass="textfield" Maxlength="50"  width="200px" runat="server"></asp:textbox></td>
                                        
			    <td class="mainheadtxt"> <asp:RadioButton ID="Tab3_Rb1_PayType1" runat="server" TabIndex=1 Text="Paid" Checked= 'true' value ="1" GroupName="LeavePayType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab3_Rb1_PayType2" runat="server" Text="Unpaid"  value = "0" GroupName="LeavePayType" AutoPostBack="false" />                                        
			    </td>
			    <td class="mainheadtxt"><asp:RadioButton ID="Tab3_ApprRB1" TabIndex=2 runat="server" Text="Approved" Checked= 'true' value ="1" GroupName="ApprovalType" AutoPostBack="false" />  
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="Tab3_ApprRB2" runat="server" Text="Rejected"  value = "0" GroupName="ApprovalType" AutoPostBack="false" /> 
                 </td>

                <td class="mainheadtxt"><asp:textbox id=Tab3_ApproverComments  TabIndex=3 CssClass="textfield" Maxlength="100" width="250px" runat="server"></asp:textbox></td>	    			    			
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
                    <asp:DataGrid ID="ALGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="15" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="ALGrid_PageIndexChanged"                                    OnEditCommand="ALGrid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee Name" DataField="Emp_Name" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Start Date" DataField="Leave_StartDate" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave End Date" DataField="Leave_EndDate" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Days Requested" DataField="DaysRequested" ItemStyle-Width="15%"></asp:BoundColumn>                            
                            <asp:BoundColumn HeaderText="Leave Type" DataField="LeaveTypeName" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Leave Pay Type" DataField="LeavePayType" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="Comments" DataField="Comments" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="Approver Comments" DataField="Comments" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="15%"></asp:BoundColumn>
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

