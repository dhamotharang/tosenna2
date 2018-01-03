<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageEContacts.aspx.cs" Inherits="SchoolNet.ManageEContacts" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
 <tr><td class="colheader"><span class="maintitledesign">Emergency Contacts</span></td></tr>
 <tr><td width="100%">
 <asp:PlaceHolder id="EmergencyContactTab" Runat="server" visible="true">
    
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Emergency Contact details. -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Contact Name<font color="red">*</font></td>
			    <td class="mainheadtxt">Relationship<font color="red">*</font></td>
			    <td class="mainheadtxt">Contact Priority<font color="red">*</font></td>
			    <td class="mainheadtxt"></td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_Name cssclass="textfield" TabIndex=1 Maxlength="50" width="160px" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:dropdownlist id=Tab4_RelationshipDDList cssclass="textfield" TabIndex=2 AutoPostBack=false runat="server" Width="200px"></asp:dropdownlist></td>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab4_ContactPrioirtyDDList" cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="200px"></asp:dropdownlist></td>			    
			    <td class="mainheadtxt"></td>
			</tr>
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_Name  ErrorMessage="Contact Name is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_RelationshipDDList InitialValue="-1" ErrorMessage="Relationship is required." /></td>                           
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_ContactPrioirtyDDList InitialValue="-1"  ErrorMessage="Contact Priority is required." /></td>
                <td class="validationtxt">&nbsp;</td> 		    
		    </tr>
		    <tr>
			    <td class="mainheadtxt">Home Phone<font color="red">*</font></td>
			    <td class="mainheadtxt">Mobile Phone<font color="red">*</font></td>
			    <td class="mainheadtxt">Work Phone</td>
			    <td class="mainheadtxt">Email Address</td>
		    </tr>
		    <tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_HomePhone  cssclass="textfield" TabIndex=4   Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_MobilePhone cssclass="textfield" TabIndex=5  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_WorkPhone   cssclass="textfield" TabIndex=6  Maxlength="30" runat="server"></asp:textbox></td>
			    <td class="mainheadtxt"><asp:textbox id=Tab4_EmailAddress cssclass="textfield" TabIndex=7 Maxlength="50" width="200px"  runat="server"></asp:textbox></td>			    
		    </tr>
            <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_HomePhone    ErrorMessage="Home Phone is required." /></td>   
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab4_MobilePhone  ErrorMessage="Mobile Phone is required." /></td>                           
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RegularExpressionValidator runat="server" ControlToValidate=Tab4_EmailAddress ErrorMessage="Email Address format is invaid." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" /></td> 		    
		    </tr>
	
            <tr class="PartButtons" align=center>
			<td  colspan="4">
			<center>
			    <asp:button id=EC_Save runat="server" CausesValidation="True" CssClass="Button SaveButton" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;
			    <asp:button id=EC_Cancel runat="server" CausesValidation="false" CssClass="Button ResetButton" Text="Reset"></asp:button>
			</center>
			</td>
            </tr>
             <tr>
                <td colspan="4" align=center><asp:label id="ECmessage" runat="server" visible=false />
                                             <asp:Label id="keyField" runat="server" visible=false />
                </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            <!-- Emergency Contact Grid -->
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="ECGrid" CssClass="Tabular2" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="EContactID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="ECGrid_PageIndexChanged" OnDeleteCommand="ECGrid_DeleteCommand" OnEditCommand="ECGrid_EditCommand">
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Contact Name" DataField="Contact_Name" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Relationship" DataField="RelationshipName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Contact Priority" DataField="Contact_PriorityName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Home Phone" DataField="Home_Phone" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Mobile" DataField="Mobile" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Work Phone" DataField="WorkPhone" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Email" DataField="Email_Addr" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                <ItemTemplate> 
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                 </ItemTemplate>
                             </asp:TemplateColumn>                    
                             <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                                 <ItemTemplate> 
                                    <asp:LinkButton name="Delete" commandName="Delete" Text="Delete" CausesValidation="false" runat="server" OnClientClick="return confirm('Are you sure you want to delete the record?');" /> 
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
                    </br>
                    <center><asp:label id ="emptyRow1" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	       
 </asp:placeholder>
</td>
</tr>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
	<!--   End of Data Area -->
										
</master:content>


