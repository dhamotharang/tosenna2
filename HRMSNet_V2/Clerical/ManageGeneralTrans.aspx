<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageGeneralTrans.aspx.cs" Inherits="SchoolNet.ManageGeneralTrans" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">

<!--    Edit Employee Data Area -->
<asp:PlaceHolder id=EditArea Runat="server" visible="true">
 <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Manage General Transactions Update</span></td>
</tr>

<tr width="100%">
  <td>
     <div id="nav">
           <ul>
             <li><asp:button id=tab1 runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Quick Entry (Labor,Visa & Passport)"></asp:button></li>
             <li><asp:button id=tab2 runat="server" BorderStyle="Ridge" CausesValidation="false" Visible="false"  CssClass="button" BorderWidth="1px" Text="Bulk Import(Labor,Visa & Passport)"></asp:button></li>
        
            </ul>  
     </div>
  </td>
</tr>
<!--   Tab1 :Enter Daily Transactions -->
<tr><td width="100%">
<asp:placeholder id="Tab1_Pane" runat="server" Visible=true>
     <table width="100%" border="0" class="Partgrayblock">
            <tr><td colspan="4"><span class="maintitledesign">Quick Data Entry(Labor Card, Visa,Passport Information)</span></td></tr>
            <tr><td colspan="4">&nbsp;</td></tr>
            
            <tr>
                <td class="mainheadtxt">Data Type<font color="red">*</font></td>
                <td class="mainheadtxt">Employee ID<font color="red">*</font></td>
			    <td class="mainheadtxt">Instrument No<font color="red">*</font></td>
			    <td class="mainheadtxt">Issue Date</td>
			</tr>
		    <tr>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_ImportDataTypeList" TabIndex=1 AutoPostBack=true onselectedindexchanged="Tab1_ImportDataTypeList_SelectedIndexChanged" runat="server" Width="180Px" CssClass="textfield"></asp:dropdownlist></td>
		        <td class="mainheadtxt"><asp:dropdownlist id="Tab1_EmployeeList" TabIndex=2 AutoPostBack=false runat="server" Width="220Px" CssClass="textfield"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_InstrumentNo cssclass="textfield" TabIndex=3 Maxlength="30"  runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_VisaIssueDate TabIndex=4  Maxlength="20" runat="server"  CssClass="textfield"></asp:textbox></td>
            </tr>
            <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ImportDataTypeList InitialValue=-1 ErrorMessage="Import Data Type is Required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_EmployeeList  InitialValue=-1 ErrorMessage="Employee Name is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat="server" ControlToValidate="Tab1_InstrumentNo" ErrorMessage="Instrument(Visa/PP/Labor Card) No is required." /></td>   
                <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab1_VisaIssueDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
                
		    </tr>
		    
            <tr>
			    <td class="mainheadtxt">Expiry Date</td>
			    <td class="mainheadtxt">Issuing Country</td>
			    <td class="mainheadtxt">Visa Type</td>
                <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
		        <td class="mainheadtxt"><asp:textbox id=Tab1_VisaExpiryDate  cssclass="textfield"  TabIndex=5 Maxlength="20" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_CountryList" TabIndex=6 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td> 
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_VisaType" TabIndex=7 AutoPostBack=false Visible = false runat="server" Width="160Px" CssClass="textfield"></asp:dropdownlist></td>                                 
                <td class="mainheadtxt">&nbsp;</td>
             </tr>
            <tr>
                <td class="validationtxt"><asp:RegularExpressionValidator  runat=server Display="Dynamic" ControlToValidate=Tab1_VisaExpiryDate  ValidationExpression="(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}" ErrorMessage="Date is required DD/MM/YYYY format." /></td>  
                <td class="validationtxt" colspan="3">&nbsp;</td>   
                             
		    </tr>
		    
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Tab1_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab1_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>
             <tr>
                <td colspan="7" align=center><asp:label id="Tab1_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab1_keyField" runat="server" visible=false />
                
                </td>
            </tr>
     
	     </table>
	 
  </asp:placeholder>
  </td>
 </tr>
 <!-- Tab 2: Benefits -->
<tr><td width="100%">
<asp:placeholder id="Tab2_Pane" runat="server" Visible=false>
    <table width="100%" border="0" class="Partgrayblock">
        <tr><td colspan="4"><span class="maintitledesign">Bulk Import(Labor Card,Visa,Passport Information)</span></td></tr>
            <tr> <td class="mainheadtxt" colspan="4" align=right >
		          <asp:HyperLink ID="TemplateDownloadLink" runat="server" visible=false></asp:HyperLink>
		    </td>
		    </tr> 
		    <tr><td colspan="4">&nbsp;</td></tr>         
            <tr>
               <td class="mainheadtxt" colspan="2">Select the excel(.xls) file to import<small>(Maximum File Size:4MB)</small><font color="red">*</font>
                <asp:FileUpload ID="fileuploadExcel" class="textfield" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;<span
                        onclick="return confirm('Are you sure to Import selected Excel?')">
                     </span> 
             </td> 
             <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=fileuploadExcel ErrorMessage="Please select the excel (.xls) file to import" /></td>            
		  </tr>
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=Import runat="server" CausesValidation="True" CssClass="Button SubmitButton" Text="Import"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Tab2_Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>
             <tr>
                <td colspan="4" align=center><asp:label id="Tab2_Message" runat="server" visible=false />&nbsp;
                                             <asp:Label id="Tab2_keyField" runat="server" visible=false />
                
                </td>
            </tr>
                    <!-- Exports Grid -->
             <tr> <td colspan="6" class="mainheadtxt" align=right><asp:button id=Export1 Visible=false runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Export Invalid Records"></asp:button></td></tr>
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Tab2Grid" class="Tabular2" runat="server" Width="100%" PageSize="10" AllowPaging="True" DataKeyField="Id" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnPageIndexChanged="Tab2Grid_PageIndexChanged"   
                    Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Bulk Import Details</td></tr></table>' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Employee ID" DataField="EmployeeID" ItemStyle-Width="12%"></asp:BoundColumn>  
                            <asp:BoundColumn HeaderText="Import Data Type" DataField="ImportDataType" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Instrument No" DataField="InstrumentNO" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Issue Date" DataField="Issue_Date"  ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Expiry Date" DataField="Expiry_Date" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Issuing Country" DataField="Issuing_Country" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Type" DataField="Visa_Type" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Error Description" DataField="Error_Description" ItemStyle-Width="19%"></asp:BoundColumn>                            
                      </Columns>     
                        <FooterStyle CssClass="DashGridFooter" />
                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                        <ItemStyle CssClass="DashGridItem" />                
                       <HeaderStyle CssClass="DashGridHeader" />
                   </asp:DataGrid>
         
                </td>
            </tr>
		    
	     </table> 
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





