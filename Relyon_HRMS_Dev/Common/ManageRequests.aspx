<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageRequests.aspx.cs" Inherits="SchoolNet.ManageRequests" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table  border="0" cellspacing="0" cellpadding="0" width=100% height="100%">
  <!--    Edit Employee Data Area -->
 <tr><td width="100%">
  <asp:PlaceHolder id=EditArea Runat="server" visible="true">
 <fieldset><Legend>Manage Requests</Legend>		
	  <table width="100%" border="0" class="Partgrayblock">    
		     <tr><td colspan="4">&nbsp;</td></tr>
		     <tr>
			    <td class="mainheadtxt">Select Request Type<font color="red">*</font></td>
			    <td class="mainheadtxt">Addressed To(Press CTRL and Select for multiple entries)<font color="red">*</font></td>   
			    <td class="mainheadtxt" align="right">Request Status</td>
			    <td>&nbsp;</td>
		     </tr>
		     <tr>
		        <td class="mainheadtxt" valign="top"><asp:dropdownlist id="Tab1_RequestType"  TabIndex=1 AutoPostBack=true onselectedindexchanged="Tab1_RequestType_SelectedIndexChanged" runat="server" Width="220px" CssClass="textfield"></asp:dropdownlist></td>		    	    		   
			    <td class="mainheadtxt"><asp:ListBox ID="Tab1_RequestImplType" TabIndex=2 runat="server" Width="220px" CssClass="textfield" AutoPostBack="false" SelectionMode="Multiple" ></asp:ListBox> </td>
			    <td class="mainheadtxt" valign="top" align="right"><asp:dropdownlist id="Tab1_RequestStatusType"  TabIndex=3 AutoPostBack=false runat="server" Width="180px" CssClass="textfield" Visible=false></asp:dropdownlist></td>		    	    		   
			    <td>&nbsp;</td>
		     </tr>
		     <tr>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_RequestType display="dynamic" InitialValue="-1" ErrorMessage="Request Type is required." /></td>
                <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_RequestImplType  ErrorMessage="Please select request implementor." /></td>              
                <td colspan="2">&nbsp;</td>
 		    </tr>
 		    <asp:placeholder id="EmployeeSelection" runat="server" Visible="false">
		         <tr>
			        <td class="mainheadtxt">Select the concerned employee</td>
			        <td colspan="3">&nbsp;</td>
		         </tr>
		         <tr>
		            <td class="mainheadtxt" valign="top"><asp:dropdownlist id="Tab1_NewHiresList"  TabIndex=4 AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>		    	    		   
			        <td class="validationtxt" colspan="3"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_NewHiresList display="dynamic" InitialValue="-1" ErrorMessage="Please select the concerned employee for this request." /></td>
		         </tr> 	
           </asp:placeholder>		     	    
              <tr>
		        <td class="mainheadtxt">Request Note(<small>Maximum of 2000 chars)<font color="red">*</font></small></td>   
	            <td class="mainheadtxt"><asp:textbox id=Tab1_Note TextMode=MultiLine Columns="5" Rows="12"  Width="450px" runat=server cssclass="textfield" TabIndex="3"></asp:textbox></td>
	            <td colspan="2"><asp:Label id="Tab1_keyField" runat="server" visible=false /> </td>
   		    </tr> 
		    		    
 	         <tr>
 	             <td class="validationtxt" colspan="2"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab1_Note display="dynamic"  ErrorMessage="Request Note is required." />
 	                                       <asp:RegularExpressionValidator  ControlToValidate="Tab1_Note" Text="Note should not exceed 2000 characters" ValidationExpression="^[\s\S]{0,2000}$" runat="server" />
 	             </td>    
 	             <td colspan="2">&nbsp;</td>        
			 </tr>	 
			 <tr> <td class="mainheadtxt" colspan="4" align=right ><asp:HyperLink ID="TemplateDownloadLink" runat="server" visible=false></asp:HyperLink></td></tr> 
   	        <tr><td colspan="4"><hr /></td></tr>
            <tr align=center>
			    <td  valign="middle" colspan="4"><center>   
			       <asp:button id=Send_Request  TabIndex = 4 runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Send Request"></asp:button>
			        &nbsp;&nbsp;&nbsp;<asp:button id=Cancel runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Cancel"></asp:button>
			</center>
			</td>
            </tr>
             
             <tr>
                <td colspan="4" align=center><asp:label id="Hmessage" runat="server" visible=false />                 
               </td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            
            
             <tr>
                <td colspan="4">
                    <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="5" AllowPaging="True" DataKeyField="RequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged"                                   OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnItemCommand="Grid_ItemCommand">
                                   
                      <Columns>
                            <asp:BoundColumn HeaderText="RequestType" DataField="RequestTypeName" ItemStyle-Width="22%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Request Subject" DataField="NewHireName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Requestor" DataField="RequestorName" ItemStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Request Sent To" DataField="Requestor_names" ItemStyle-Width="25%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="Request Note" DataField="Request_Comment" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="NewhireID" DataField="NewHireID" ItemStyle-Width="0%"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Request Status" DataField="StatusName" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn Visible=false HeaderText="Request Sent To" DataField="RequestImpl_Types" ItemStyle-Width="0%"></asp:BoundColumn>                            
                            
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="4%">
                                    <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                                    </ItemTemplate>
                            </asp:TemplateColumn>                    
                            <asp:TemplateColumn HeaderText="" ItemStyle-Width="4%">
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
 </asp:placeholder>
</td>
</tr>
<tr class="PartBrown" >
   <td width="100%" align=center><asp:label id="message" runat="server" visible=false /></td>			
</tr> 			
</table>
										
</master:content>

