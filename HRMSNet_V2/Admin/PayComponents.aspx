<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayComponents.aspx.cs" Inherits="SchoolNet.PayComponents" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
  <tr width="100%">
		<td class="colheader"><span class="maintitledesign">Define Pay and Allowance Components</span></td>
	</tr>	
 <asp:PlaceHolder id="PayComponentTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <table width="100%" border="0" class="Partgrayblock">
         <!-- Benefits Grid -->
            <tr><td colspan="4">&nbsp;</td></tr>
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="PayComponentID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"  OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" 
                    Caption='' CaptionAlign="Top">                                  
                      <Columns>
                            <asp:BoundColumn HeaderText="Benefit Component Name" DataField="PayComponentName" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Short Name" DataField="ShortName" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Pay Frequency" DataField="PayFrequency" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Account Code" DataField="AccountCode" ItemStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Description" DataField="AccountDescription" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Status" Visible=false DataField="Status" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Actions" ItemStyle-Width="10%">
                                <ItemTemplate> 
                                     <asp:ImageButton ImageUrl="~/images/buttons/blue_edit1.png" name="Edit" commandName="Edit" alt="Edit" ToolTip="Edit" CausesValidation="false" runat="server" height="28" width="28" />                                                                   
                                     &nbsp;&nbsp;
                                     <asp:ImageButton ImageUrl="~/images/buttons/blue_delete1.png" name="Delete" commandName="Delete" alt="Delete" ToolTip="Delete" CausesValidation="false" runat="server" height="28" width="28" OnClientClick="return confirm('Are you sure you want to delete the record?');" /> 
                                     
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
         
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>                         
		    
		    <tr>
			    <td class="mainheadtxt">Component Name&nbsp;<small>(Example: Basic Monthly Salary)</small><font color="red">*</font></td>
			    <td class="mainheadtxt">Short Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Pay Fequency</td>
			    <td class="mainheadtxt">Status</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_ComponentName cssclass="textfield" TabIndex=1 Maxlength="50" width="220px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"> <asp:textbox id=Tab1_ShortName cssclass="textfield" TabIndex=2 Maxlength="4" size="15" width="150px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_PayFrequencyList" TabIndex=3 AutoPostBack=false runat="server" Width="160Px" CssClass="textfield"></asp:dropdownlist></td>
                <td class="mainheadtxt"><asp:RadioButton id="Radio1" Text="Active"  Checked="True" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;
                                        <asp:RadioButton id="Radio2" Text="InActive" GroupName="RadioGroup1" runat="server"/>
             </td>	            			    
		   </tr>
		   
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ComponentName  ErrorMessage="Pay Component Name is required." /></td>  
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ShortName  ErrorMessage="Short Name (4 chars) is required." /></td>   		         
		        <td class="validationtxt"><asp:Label id="Tab1_KeyField" runat="server" visible=false /></td>                           
                <td class="validationtxt"></td>
		    </tr>
	        <tr>
			    <td class="mainheadtxt">Account Code</td>
			    <td class="mainheadtxt" colspan="2">Description</td>
			    <td class="mainheadtxt">&nbsp;</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_AccountCode cssclass="textfield" TabIndex=5 Maxlength="30"  runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" colspan="2"> <asp:textbox id=Tab1_Description cssclass="textfield" TabIndex=6 Maxlength="100" width="300px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt">&nbsp;</td>
		   </tr>		    
           <tr><td colspan="4">&nbsp;</td></tr>
		   	<tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=PayComp_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=Reset runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>
		    	
             <tr>
                <td colspan="4" align=center><asp:label id="LTmessage" runat="server" visible=false /></td>
            </tr>
            
           </table>   	 
	   
 </td>
</tr>
</asp:placeholder>
</table>								
</master:content>

