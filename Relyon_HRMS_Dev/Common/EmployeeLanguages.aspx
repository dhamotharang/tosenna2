<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeLanguages.aspx.cs" Inherits="SchoolNet.EmployeeLanguages" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="CertificationTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>Add/Update Employee Language Skills</legend>
      <table width="100%" border="0" class="Partgrayblock">
            <!-- Add/Edit Leave Type -->
                    
		    <tr><td colspan="4">&nbsp;</td></tr>
		    <tr>
			    <td class="mainheadtxt">Select Language<font color="red">*</font></td>			    
			    <td class="mainheadtxt">Speaking Level<font color="red">*</font></td>
	            <td class="mainheadtxt">Reading Level<font color="red">*</font></td>		    			    
	            <td class="mainheadtxt">Writing Level<font color="red">*</font></td>		    			    
     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_Languagelist"  TabIndex=1 CssClass="textfield" runat="server" width="150px" ></asp:dropdownlist></td>   			    
			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_SpeakLevel"  TabIndex=2 CssClass="textfield" runat="server" width="150px" ></asp:dropdownlist></td>   			    
   			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_ReadLevel"  TabIndex=3 CssClass="textfield" runat="server" width="150px" ></asp:dropdownlist></td>  
  			    <td class="mainheadtxt"><asp:dropdownlist id="Tab1_WriteLevel"  TabIndex=4 CssClass="textfield" runat="server" width="150px" ></asp:dropdownlist></td>   			     			    

			</tr>
            <tr><td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Languagelist InitialValue=-1 ErrorMessage="Language is required." /></td>   
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_SpeakLevel InitialValue=-1 ErrorMessage="Speaking Level is required." /></td>
   			    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_ReadLevel InitialValue=-1 ErrorMessage="Reading Level is required." /></td>
   			    <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_WriteLevel InitialValue=-1 ErrorMessage="Writing Level is required." /></td>
             </tr>               
   	
   	    <tr>
			    <td class="mainheadtxt">Last Assessed</td>			    
			    <td class="mainheadtxt"><asp:Label id="Tab1_keyField" runat="server" visible=false /></td>
	            <td class="mainheadtxt">&nbsp</td>		    			    
	            <td class="mainheadtxt">&nbsp;</td>		    			    
     		</tr>
			
			<tr>
			    <td class="mainheadtxt"><asp:textbox id=Tab1_LastAssessed  TabIndex=5  CssClass="textfield"  Maxlength="15"  runat="server"></asp:textbox></td>
			    <td class="mainheadtxt" colspan="3">&nbsp</td>

			</tr>
	        <tr><td colspan="4"><hr /></td></tr>
	        
            <tr  align=center>
			    <td  valign="middle" colspan="4"><center><asp:button id=EmpLang_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			                                    &nbsp;&nbsp;&nbsp;<asp:button id=Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button></center></td>
            </tr>	
             <tr>
                <td colspan="4" align=center><asp:label id="Hmessage" runat="server" visible=false />                 
               </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="RowId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" >
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="Language" DataField="LanguageName" ItemStyle-Width="30%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Speaking" DataField="SpeakingLevel" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Reading" DataField="ReadingLevel" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Writing" DataField="WritingLevel" ItemStyle-Width="18%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Last Assessed" DataField="Last_Assessed" ItemStyle-Width="22%"></asp:BoundColumn>
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
                        <FooterStyle CssClass="GridFooter" />
                        <SelectedItemStyle CssClass="GridSelectedItem" />
                        <PagerStyle CssClass="GridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAltItem" />
                        <ItemStyle CssClass="GridItem" />
                        <HeaderStyle CssClass="GridHeader" />
                    </asp:DataGrid>
                    <br /><center><asp:label id ="emptyRow" value="" visible=false runat="server" /></center>           
           
                </td>
            </tr>
	       </table>   	 
	       </fieldset>
 </td>
</tr>
</asp:placeholder>
<!--  End of Tab 4 -->

</table>
	<!--   End of Data Area -->
										
</master:content>




