<%@ Page language="c#" AutoEventWireup="true" Inherits="SchoolNet.Division" CodeFile="Division.aspx.cs" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 
 <!--   Placeholder 1: Area to allow new add, edit and delete  --> 
 
 <ASP:PlaceHolder id="ManageCRUD" Runat="server">
   <tr width="100%">
		<td class="colheader"><center>Manage Business Unit Information</center></td>
 </tr>	
 <tr>
	<td>
     	<table width="100%" border="0" class="Partgrayblock">
     	<tr><td colspan="4">&nbsp;</td></tr>
		<tr>		    
			<td class="mainheadtxt">Business Unit Name<font color="red">*</font></td>
			<td class="mainheadtxt">Region<font color="red">*</font></td>
			<td class="mainheadtxt">Business Unit Head</td>
			<td class="mainheadtxt">Business Unit Code</td>
			<td class="mainheadtxt">Status</td>
			
		</tr>
		<tr>
			
			<td class="mainheadtxt"><asp:textbox id=DivisionName cssclass="textfield" Maxlength="50" width="160px" TabIndex=2 runat="server"></asp:textbox></td>
			<td class="mainheadtxt"><asp:dropdownlist id="RegionDDList" cssclass="textfield" TabIndex=1 AutoPostBack=false runat="server" Width="180px" ></asp:dropdownlist></td>
			<td class="mainheadtxt"><asp:dropdownlist id="SupervisorDDList" cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="180px" ></asp:dropdownlist></td>
   		    <td class="mainheadtxt"><asp:textbox id=GLCode  Maxlength="50" TabIndex=4 runat="server"></asp:textbox></td>
			<td class="mainheadtxt"><asp:RadioButton id="Radio1" Text="Active"  Checked="True" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;
			                        <asp:RadioButton id="Radio2" Text="InActive" GroupName="RadioGroup1" runat="server"/>

		</tr>	
		 <tr>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=DivisionName  ErrorMessage="Business Unit Name is required." /></td>   
   		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=RegionDDList InitialValue=-1 ErrorMessage="Region is  required." /></td>   
		        <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt">&nbsp;</td>
		 </tr>

		<tr><td colspan="5"><hr /></td></tr>		
    	<tr class="PartWhite" align=center>
			<td  colspan="5">
			<center><asp:button id=Tab1_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;<asp:button id=Tab1_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			</center>
			</td>
		</tr>	
		  <tr>
                <td colspan="5" align=center><asp:label id="Tab1_Message" runat="server" visible=false />
                                             <asp:Label id="Tab1_KeyField" runat="server" visible=false />
                </td>
          </tr>
	    </table>
	 </td>						
 </tr>

  <tr width="100%">
  <td>
  <asp:DataGrid ID="Grid" runat="server" Width="100%" PageSize="10" AllowPaging="True"  DataKeyField="DivisionID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" 
                OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnItemCommand="Grid_ItemCommand"  
                Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Business Unit List</td></tr></table>' CaptionAlign="Top">
                
                 <Columns>
                        <asp:BoundColumn HeaderText="Business Unit Name" DataField="DivisionName" ItemStyle-Width="18%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Region Name" DataField="RegionName" ItemStyle-Width="18%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Unit Head Name" DataField="DivisionHeadName" ItemStyle-Width="15%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Business Unit Code" DataField="GLCode"  ItemStyle-Width="14%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Status" DataField="Status"  ItemStyle-Width="8%"></asp:BoundColumn>  
                        <asp:TemplateColumn HeaderText="" ItemStyle-Width="15%">
                                <ItemTemplate>  
                                     <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server"  />                                                                  
                                     &nbsp;<asp:LinkButton name="Manage Location" commandName="Select" CausesValidation="false" Text="Manage Location" runat="server" />
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
</ASP:PlaceHolder>
<!--  Manage Division Location -->
 <ASP:PlaceHolder id="Managelocation" Runat="server" Visible=false>
   <tr width="100%">
		<td class="colheader"><center>Manage Business Unit Country Information</center></td>
 </tr>	
 <tr>
	<td>
     	<table width="100%" border="0" class="Partgrayblock">
     	<tr><td colspan="5">&nbsp;</td></tr>
		<tr>
			<td class="mainheadtxt">Business Unit Name (Read Only)</td>
			<td class="mainheadtxt">Country<font color="red">*</font></td>
			<td class="mainheadtxt">Country Head</td>
			<td class="mainheadtxt">Employer Unique ID</td>
		    <td class="mainheadtxt">Employer Reference Number</td>
		</tr>
		<tr>
			<td class="mainheadtxt"><asp:textbox id=Tab2_DivisionName ReadOnly=true  cssclass="textfield" Maxlength="50" width="160px" TabIndex=1 runat="server"></asp:textbox></td>
			                        <asp:Label id=Tab2_DivisionID runat=server Visible=false></asp:Label>
			<td class="mainheadtxt"><asp:dropdownlist id="Tab2_CountryList" cssclass="textfield" TabIndex=2 AutoPostBack=false runat="server" Width="150px" ></asp:dropdownlist></td>
   		    <td class="mainheadtxt"><asp:dropdownlist id="Tab2_SuperVisorList" cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="150px" ></asp:dropdownlist></td>
            <td class="mainheadtxt"><asp:textbox id=Tab2_EmployerID  Maxlength=13 cssclass="textfield"  width="150px" TabIndex=5 runat="server"></asp:textbox></td>
            <td class="mainheadtxt"><asp:textbox id=Tab2_EmployerRef  Maxlength=35 cssclass="textfield"  width="180px" TabIndex=6 runat="server"></asp:textbox></td>
		</tr>	
		 <tr>
		        <td class="validationtxt">&nbsp;</td>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab2_CountryList InitialValue=-1 ErrorMessage="Country Name is required." /></td>   
		        <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt"><asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="Tab2_EmployerID" ValidationExpression="\d+" Display="Dynamic" ErrorMessage="Please enter numbers only"  runat="server"/>
                <td class="validationtxt">&nbsp;</td>
		 </tr>
		<tr>
			<td class="mainheadtxt">Employer Banking Routing Code</td>
			<td class="mainheadtxt">Company Code</td>
			<td class="mainheadtxt">&nbsp;</td>
			<td class="mainheadtxt">&nbsp;</td>
		    <td class="mainheadtxt">&nbsp;</td>
		</tr>
		<tr>
            <td class="mainheadtxt"><asp:textbox id=Tab2_EmployerRoutingCode cssclass="textfield"  Maxlength=9  width="180px" TabIndex=7 runat="server"></asp:textbox></td>			                        
            <td class="mainheadtxt"><asp:textbox id=Tab2_GLCode  Maxlength=13 cssclass="textfield"  width="150px" TabIndex=8 runat="server"></asp:textbox></td>
            <td class="mainheadtxt">&nbsp;</td>
            <td class="mainheadtxt">&nbsp;</td>
            <td class="mainheadtxt">&nbsp;</td>
		</tr>	
		<tr>
            <td class="validationtxt"><asp:CompareValidator  ControlToValidate=Tab2_EmployerRoutingCode Type=Integer Display=Dynamic Operator="DataTypeCheck"  ErrorMessage="Please enter an integer value" runat="server"></asp:CompareValidator></td>		        
		    <td class="validationtxt">&nbsp;</td>
		    <td class="validationtxt">&nbsp;</td>
	        <td class="validationtxt">&nbsp;</td>
            <td class="validationtxt">&nbsp;</td>
		 </tr>

		<tr><td colspan="5"><hr /></td></tr>		
    	<tr class="PartWhite" align=center>
			<td  colspan="5">
			<center><asp:button id=Tab2_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;<asp:button id=Tab2_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			    &nbsp;&nbsp;&nbsp;<asp:button id=Tab2_Back runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Back to Business Unit"></asp:button>
			</center>
			</td>
		</tr>	
		 <tr><td colspan="5" align=center><asp:label id="Tab2_Message" runat="server" visible=false />
		                                  <asp:Label id="Tab2_KeyField" runat="server" visible=false />
		 </td></tr>
	    </table>
	 </td>						
 </tr>

  <tr width="100%">
  <td>
  <asp:DataGrid ID="LGrid" runat="server" Width="100%" PageSize="10" AllowPaging="True"  DataKeyField="LocationID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="LGrid_PageIndexChanged" 
                OnDeleteCommand="LGrid_DeleteCommand" OnEditCommand="LGrid_EditCommand" OnItemCommand="LGrid_ItemCommand"  
                Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Business Unit Country List</td></tr></table>' CaptionAlign="Top">
                
                 <Columns>
                        <asp:BoundColumn HeaderText="Business Unit Name" DataField="DivisionName" ItemStyle-Width="16%"></asp:BoundColumn>
                        <asp:BoundColumn Visible=false HeaderText="Division ID" DataField="DivisionID" ItemStyle-Width="0%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="15%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Country Head" DataField="LocationHeadName"  ItemStyle-Width="15%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Employer ID"  DataField="Employer_UniqueID"  ItemStyle-Width="13%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Employer Ref" visible=false DataField="Employer_RefNumber"  ItemStyle-Width="0%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Bank Routing Code"  DataField="Bank_RoutingCode"  ItemStyle-Width="12%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Company Code" visible=true DataField="GLCode"  ItemStyle-Width="0%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="CountryID" visible=false DataField="CountryID"  ItemStyle-Width="0%"></asp:BoundColumn>
                        
                        <asp:TemplateColumn HeaderText="" ItemStyle-Width="5%">
                              <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
                             </ItemTemplate>
                         </asp:TemplateColumn>                    
                         <asp:TemplateColumn HeaderText="" ItemStyle-Width="13%">
                             <ItemTemplate> 
                                      <asp:LinkButton name="Select" commandName="Select" Text="Manage Department" CausesValidation="false" runat="server"  /> 
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
</ASP:PlaceHolder>

<!--  Manage Division Location Department-->
 <ASP:PlaceHolder id="ManagelocationDept" Runat="server" Visible=false>
   <tr width="100%">
		<td class="colheader"><center>Manage Country Specific Department Information</center></td>
 </tr>	
 <tr>
	<td>
     	<table width="100%" border="0" class="Partgrayblock">
     	<tr><td colspan="5">&nbsp;</td></tr>
		<tr>
			<td class="mainheadtxt">Business Unit Name(Read Only)</td>
			<td class="mainheadtxt">Country(Read Only)</td>
			<td class="mainheadtxt">Department Name<font color="red">*</font></td>
			<td class="mainheadtxt">Department Head</td>
			<td class="mainheadtxt">Dept Code</td>
			
		</tr>
		<tr>
			<td class="mainheadtxt"><asp:textbox id=Tab3_DivisionName  ReadOnly=true cssclass="textfield" Maxlength="50" width="160px" TabIndex=1 runat="server"></asp:textbox>
			                        <asp:Label id="Tab3_DivisionID" runat="server" visible=false />
			                        <asp:Label id="Tab3_LocationID" runat="server" visible=false />
			</td>
			<td class="mainheadtxt"><asp:dropdownlist id="Tab3_CountryList" disabled= true cssclass="textfield" TabIndex=2 AutoPostBack=false runat="server" Width="160px" ></asp:dropdownlist></td>
   		    <td class="mainheadtxt"><asp:dropdownlist id="Tab3_DepartmentList" cssclass="textfield" TabIndex=3 AutoPostBack=false runat="server" Width="150px" ></asp:dropdownlist></td>
			<td class="mainheadtxt"><asp:dropdownlist id="Tab3_SuperVisorList" cssclass="textfield" TabIndex=4 AutoPostBack=false runat="server" Width="150px" ></asp:dropdownlist></td>
            <td class="mainheadtxt"><asp:textbox id=Tab3_GLCode  Maxlength="50" TabIndex=5 runat="server"></asp:textbox></td>			                        

		</tr>	
		 <tr>
		        <td class="validationtxt">&nbsp;</td>
		        <td class="validationtxt">&nbsp;</td>
		        <td class="validationtxt"><asp:RequiredFieldValidator runat=server ControlToValidate=Tab3_DepartmentList InitialValue=-1 ErrorMessage="Department Name is required." /></td>   
                <td class="validationtxt">&nbsp;</td>
                <td class="validationtxt">&nbsp;</td>
		 </tr>

		<tr><td colspan="5"><hr /></td></tr>		
    	<tr class="PartWhite" align=center>
			<td  colspan="5">
			<center><asp:button id=Tab3_Save runat="server" BorderStyle="Ridge" CausesValidation="True" CssClass="button" BorderWidth="1px" Text="Save"></asp:button>
			    &nbsp;&nbsp;&nbsp;<asp:button id=Tab3_Reset runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Reset"></asp:button>
			    &nbsp;&nbsp;&nbsp;<asp:button id=Tab3_Back runat="server" BorderStyle="Ridge" CausesValidation="false" CssClass="button" BorderWidth="1px" Text="Back to BU Location"></asp:button>
			</center>
			</td>
		</tr>	
		 <tr><td colspan="5" align=center><asp:label id="Tab3_Message" runat="server" visible=false /></td></tr>
	    </table>
	 </td>						
 </tr>

  <tr width="100%">
  <td>
  <asp:DataGrid ID="DGrid" runat="server" Width="100%" PageSize="10" AllowPaging="True"  DataKeyField="LocationID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" onpageindexchanging="DGrid_PageIndexChanged" 
                OnEditCommand="DGrid_EditCommand"  Caption='<table border="0" width="100%" cellpadding="0" cellspacing="0"><tr><td class=colheader>Business Unit/Country Specific Department List</td></tr></table>' CaptionAlign="Top">
                
                 <Columns>
                        <asp:BoundColumn HeaderText="Business Unit Name" DataField="DivisionName" ItemStyle-Width="25%"></asp:BoundColumn>
                        <asp:BoundColumn Visible=false HeaderText="Division ID" DataField="DivisionID" ItemStyle-Width="0%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Country Name" DataField="CountryName" ItemStyle-Width="18%"></asp:BoundColumn>
                        <asp:BoundColumn Visible=false HeaderText="Location ID" DataField="LocationID" ItemStyle-Width="0%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Department Name" DataField="DeptName"  ItemStyle-Width="18%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Department Head" DataField="LocationDeptHeadName"  ItemStyle-Width="18%"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Dept Code" DataField="GLCode"  ItemStyle-Width="13%"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="" ItemStyle-Width="8%">
                              <ItemTemplate> 
                                         <asp:LinkButton name="Edit" commandName="Edit" Text="Edit" CausesValidation="false" runat="server" /> 
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
</ASP:PlaceHolder>


					

</TABLE>
	<!--   End of Data Area -->
										
</master:content>

