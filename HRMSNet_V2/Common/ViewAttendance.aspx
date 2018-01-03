<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAttendance.aspx.cs" Inherits="SchoolNet.ViewAttendance" EnableEventValidation="false"%>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <tr><td class="colheader"><span class="maintitledesign">My Monthly Attendance</span></td></tr>
<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="true">

<tr><td width="100%">
       <table width="100%" border="0" class="Partgrayblock">
        <tr><td colspan="4">&nbsp;</td></tr>  
		    <tr>
  		    <td class="mainheadtxt">Select Attendance Month<font color="red">*</font></td>   
		    <td class="mainheadtxt" ><asp:textbox id=Attendance_Month cssclass="monthPicker" TabIndex=1 Maxlength="20" runat="server"></asp:textbox>		    
 		         		        &nbsp;&nbsp;
                <asp:ImageButton id=Attendance_Go runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_go.png" ToolTip="Go" alt="Go" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>
            <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Attendance_Month  ErrorMessage="Attendance Month is Required." /></td>   
		</tr>
        <tr><td colspan="4"><hr /></td></tr>  
        </table>
          
  </td>
</tr>

</asp:placeholder>
<!-- Payslip Print Area -->
<asp:placeholder id="ViewMonthlyAttendance" runat="server">  

<tr><td width="100%"> 
    
      <table width="100%" border="0" class="Partgrayblock">
                <tr><td>&nbsp;</td></tr>
             <tr width="100%">
                <td width="100%">
                    <asp:DataGrid ID="AttendanceGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="35" AllowPaging="True" DataKeyField="ID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">                                 
                        <Columns>
                            <asp:BoundColumn HeaderText="Date" DataField="EntryDate" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Name" DataField="ShiftName" ItemStyle-Width="20%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift Short" DataField="ShiftShort" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shift ID" DataField="ShiftID" Visible = false></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Worked Minutes" DataField="WorkedMins"  Visible = false></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Worked Hours" DataField="WorkedHrs" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OT Hours" DataField="OTHrs" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OT Hours" DataField="OTMins" Visible = false></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Status" DataField="AttendanceStatus" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Date Status ID" DataField="AttendanceStatusID" Visible = false></asp:BoundColumn>

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

<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
									
</master:content>




