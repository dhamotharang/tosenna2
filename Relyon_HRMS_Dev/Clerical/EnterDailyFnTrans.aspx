<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnterDailyFnTrans.aspx.cs" Inherits="SchoolNet.EnterDailyFnTrans" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="true">
 <tr width="100%">
		<td class="colheader"><blink>Manage Current Pay Period Adhoc Financial Transactions</blink></td>
</tr>
<tr width="100%">
  <td>
     <div id="nav">
           <ul>
             <li><asp:button id=tab1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Quick Entry(Financial Transactions) "></asp:button></li>
             <li><asp:button id=tab2 runat="server" BorderStyle="Ridge" CausesValidation="false" visible=true CssClass="button" BorderWidth="1px" Text="Bulk Import(Financial Transactions)"></asp:button></li>
        
            </ul>  
     </div>
  </td>
</tr>
<tr width="100%"><td>&nbsp;</td></tr>

<!--   Tab1 :Enter Daily Transactions -->
<tr><td width="100%">
<asp:placeholder id="Tab1_Pane" runat="server" Visible=true>
    <fieldset ><legend>Enter Current Month Payroll Related Finance Transactions(Only non-reoccuring/adhoc type)</legend>
        <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4">&nbsp;</td></tr>
            
            <tr>
                <td class="mainheadtxt">Employee Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Pay Component Type<font color="red">*</font></td>
			    <td class="mainheadtxt">Component Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Amount<font color="red">*</font></td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab2_EmployeeList" TabIndex=2 AutoPostBack=false runat="server" Width="220Px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_PayComponentTypeList" TabIndex=2 runat="server" Width="220Px" CssClass="textfield" AutoPostBack=True onselectedindexchanged="Tab2_PayComponentTypeList_SelectedIndexChanged"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_PayComponentList" TabIndex=2 AutoPostBack=false runat="server" Width="220Px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab2_Amount cssclass="textfield" TabIndex=6 Maxlength="30"  runat="server"></asp:textbox></td>
                   
                 
             </tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_EmployeeList InitialValue=-1 ErrorMessage="Employee Name is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_PayComponentTypeList InitialValue=-1 ErrorMessage="Pay Component Type is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_PayComponentList InitialValue=-1 ErrorMessage="Pay Component is required." /></td>   
                <td class="validationtxt"><asp:CompareValidator runat="server" ControlToValidate="Tab2_Amount" Operator="DataTypeCheck" Type="Double" ErrorMessage="Value must be a number" /></td>
		    </tr>
		    <tr><td colspan="4"><hr /></td></tr>
            <tr  align=center>
			    <td  valign="middle" colspan="4">
			                <center><asp:button id=Tab2_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                &nbsp;&nbsp;&nbsp;<asp:button id=Tab2_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="Tab2_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab2_keyField" runat="server" visible=false />
                
                </td>
            </tr>
            <tr> <td colspan="4" class="mainheadtxt" align=right><asp:button id=Export Visible=false runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export Current Payroll Related Transaction"></asp:button></td></tr>
            
            
                        <!-- Benefits Grid -->
             <tr>
                <td colspan="6">
                    <asp:DataGrid ID="Tab2Grid"  runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Tab2Grid_PageIndexChanged"  OnDeleteCommand="Tab2Grid_DeleteCommand" OnEditCommand="Tab2Grid_EditCommand" 
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Current Month Payroll Related Finance Transactions Since Last Payroll Run Date</td></tr></table>' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="PayComponentTypeID" Visible=false DataField="PayComponentTypeID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="PayComponentID" Visible=false DataField="PayComponentID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="EmpID" Visible=false DataField="EmpID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Employee Name" DataField="EmployeeName" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Component Type" DataField="PayComponentTypeName" ItemStyle-Width="23%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Component Name" DataField="PayComponentName" ItemStyle-Width="23%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server"  />                                                                  
                                     &nbsp;&nbsp;<asp:LinkButton name="Delete" commandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this record');" Text="Delete" runat="server" />
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


	     </table>
	 </fieldset>
  </asp:placeholder>
  </td>
 </tr>
 <!-- Tab 2: Benefits -->
<tr><td width="100%">
<asp:placeholder id="Tab2_Pane" runat="server" Visible=false>
    <fieldset ><legend>Import Payroll Related Financial Transactions</legend>
        <table width="100%" border="0" class="Partgrayblock">
            <tr> <td class="mainheadtxt" colspan="4" align=right >
		          <asp:HyperLink ID="TemplateDownloadLink" runat="server" visible=false></asp:HyperLink>
		    </td>
		    </tr> 
		    <tr><td colspan="4">&nbsp;</td></tr>         
            <tr>
               <td class="mainheadtxt" colspan="2">Select the excel file to import<small>(Maximum File Size:4MB)</small><font color="red">*</font>
                <asp:FileUpload ID="fileuploadExcel" class="textfield" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;<span
                        onclick="return confirm('Are you sure to Import selected Excel?')">
                     </span> 
             </td> 
             <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=fileuploadExcel ErrorMessage="Please select the excel (.xls) file to import" /></td>            
		  </tr>
         
          
		    <tr><td colspan="4"><hr /></td></tr>
		
            <tr  align=center>
              
			    <td  valign="middle" colspan="4">
			                <center><asp:button id=Import runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                &nbsp;&nbsp;&nbsp;<asp:button id=Tab1_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="Tab1_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab1_keyField" runat="server" visible=false />
                
                </td>
            
            <tr><td colspan="4"><hr /></td></tr>
                    <!-- Benefits Grid -->
             <tr> <td colspan="6" class="mainheadtxt" align=right><asp:button id=Export1 Visible=false runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export Invalid Records"></asp:button></td></tr>
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Tab1Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="RowId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Tab1Grid_PageIndexChanged"   
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Employee Pay Components List</td></tr></table>' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee ID" DataField="PSEmployeeID" ItemStyle-Width="15%"></asp:BoundColumn>  
                            <asp:BoundColumn HeaderText="Benefit Component Name" DataField="ComponentCode" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Amount" DataField="Amount" DataFormatString="{0:######.00}" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Error Description" DataField="Error_Description" ItemStyle-Width="25%"></asp:BoundColumn>
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
		    
	     </table>
	 </fieldset>
  </asp:placeholder>
  </td>
 </tr>
<!--   End of Tab2 -->


</asp:placeholder>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" Visible=false /></td>			
</tr> 			
</table>										
</master:content>



