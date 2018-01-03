<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="SchoolNet.Dashboard" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
<%@ Register Assembly="skmControls2" Namespace="skmControls2.GoogleChart" TagPrefix="cc1" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%"> 
 <asp:PlaceHolder id=DashBoardArea1 Runat="server" visible="true">
 
 <tr width="100%">
    <td colspan="3">
    <ASP:PlaceHolder id="EmpSearchBox" Runat="server">
        <table width="100%" border="0" class="Partgrayblock">
 	   	 <tr><td>&nbsp;</td>
		     <td class="mainheadtxt" align="right">Business Unit:&nbsp;<asp:dropdownlist id="businessUnitDDList" AutoPostBack=true onselectedindexchanged="businessUnitDDList_SelectedIndexChanged" runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist></td>
			 <td class="mainheadtxt" align="left">Location:&nbsp;<asp:dropdownlist id="DivisionLocationList" AutoPostBack=false runat="server" Width="180px" CssClass="textfield"></asp:dropdownlist>
			 &nbsp;&nbsp;
             <asp:ImageButton id=Search runat="server" CausesValidation="True" ImageUrl="~/images/buttons/blue_go.png" ToolTip="Go" alt="Go" height="30" width="30" style="vertical-align:middle;"></asp:ImageButton>
             </td>
		 </tr>				     
	    </table>
   </asp:PlaceHolder>
   </td>
 </tr> 
 
 <tr><td colspan="3">&nbsp;</td></tr> 
<tr>
    <td width="60%" valign="top">
        <div id="container">
         <div id="scrollable_content">
          <table width="100%">
             <tr class="HomeTitles"><td valign="top"><center>Current Month Payroll Status</center></td></tr>
             <tr>            
                 <td width="100%" valign="top">
                        <asp:DataGrid ID="Grid8" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="True" DataKeyField="DivisionName" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnItemDataBound="Grid8_ItemDataBound" OnPageIndexChanged="Grid8_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="20%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="YYYY-MM" DataField="Year-Month" ItemStyle-Width="8%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Company Code"  visible=false DataField="CompanyCode" ItemStyle-Width="0%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Emp Count" DataField="EmployeesCount" ItemStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="EOS Count" DataField="EOSCount" ItemStyle-Width="10%"></asp:BoundColumn>  
                                    <asp:BoundColumn HeaderText="Posted Amt" DataField="TotalPostedAmount" ItemStyle-Width="12%"></asp:BoundColumn> 
                                    <asp:BoundColumn HeaderText="Status" DataField="Status" ItemStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Run Date" visible=false DataField="RunDate" ItemStyle-Width="0%"></asp:BoundColumn>                                                                                                                                                                                                                           
                               </Columns>     
                                <FooterStyle CssClass="DashGridFooter" />
                                <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="DashGridAltItem" />
                                <ItemStyle CssClass="DashGridItem" />
                                <HeaderStyle CssClass="DashGridHeader" />
                        </asp:DataGrid>
                     </td>
                 </tr>
               </table> 
              </div>
             </div>
          </td>     
          <td width="40%" valign="top">
           <div id="container">
           <div id="scrollable_content">          
            <table width="100%">
             <tr class="HomeTitles"><td valign="top"><center>Payroll Status History</center></td></tr>
             <tr>            
                 <td width="100%" valign="top">
                        <asp:DataGrid ID="Grid9" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="True" DataKeyField="CompanyCode" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnItemDataBound="Grid9_ItemDataBound" OnPageIndexChanged="Grid9_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="YYYY-MM" DataField="Year-Month" ItemStyle-Width="15%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Business Unit" DataField="DivisionName" ItemStyle-Width="37%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Company Code" visible="false" DataField="CompanyCode" ItemStyle-Width="0%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Total Posted Amt" DataField="PostedAmount" ItemStyle-Width="28%"></asp:BoundColumn> 
                                    <asp:BoundColumn HeaderText="Payroll Status" DataField="Status" ItemStyle-Width="25%"></asp:BoundColumn>
                               </Columns>     
                                <FooterStyle CssClass="DashGridFooter" />
                                <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="DashGridAltItem" />
                                <ItemStyle CssClass="DashGridItem" />
                                <HeaderStyle CssClass="DashGridHeader" />
                        </asp:DataGrid>
                     </td>
                 </tr>
               </table> 
            </div>
          </div>               
        </td> 
                   
  </tr>
   <tr><td colspan="3">&nbsp;</td></tr>      
 
 
 <tr>
    <td colspan="3" width="100%">
        <table width="100%"><tr>
        <td width="50%" valign="top">
            <div><asp:Literal ID="FCLiteral1" runat="server" visible="true"></asp:Literal></div>
        </td>
        <td width="50%" valign="top">
            <div><asp:Literal ID="FCLiteral2" runat="server" visible="true"></asp:Literal></div>
        </td>
        </tr></table>
    </td>   
</tr>
<tr><td colspan="3">&nbsp;</td></tr> 
<tr>
    <td colspan="3">
        <table width="100%"><tr>
        <td width="65%" valign="top">
            <div><asp:Literal ID="FCLiteral3" runat="server" visible="true"></asp:Literal></div>
            
        </td>
        <td width="35%" valign="top">
            <div><asp:Literal ID="FCLiteral4" runat="server" visible="true"></asp:Literal></div>
        </td>
        </tr></table>
    </td>
</tr>
<tr><td colspan="3">&nbsp;</td></tr>
<tr>
    <td colspan="3" valign="top" width="100%">
       <table width="100%">
          <tr width="100%">
            <td width="33%" valign="top">
                  <div id="container">
                     <div id="scrollable_content">
                         <table border="0">
                             <tr class="HomeTitles"><td valign="top">Who is on Leave this week?</td></tr>
                             <tr>            
                              <td width="33%" valign="top">
                                <asp:DataGrid ID="Grid1" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="True" DataKeyField="LeaveRequestID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid1_PageIndexChanged">                        
                                      <Columns>
                                            <asp:BoundColumn HeaderText="Employee Name" DataField="EmployeeName" ItemStyle-Width="45%" SortExpression="Emp_Name"></asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Start Date" DataField="Leave_StartDate" ItemStyle-Width="15%" SortExpression="Leave_Date"></asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="End Date" DataField="Leave_EndDate" ItemStyle-Width="15%" SortExpression="Leave_Date"></asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Status" DataField="StatusName" ItemStyle-Width="15%"></asp:BoundColumn>
                                       </Columns>     
                                        <FooterStyle CssClass="DashGridFooter" />
                                        <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                        <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                        <AlternatingItemStyle CssClass="DashGridAltItem" />
                                        <ItemStyle CssClass="DashGridItem" />
                                        <HeaderStyle CssClass="DashGridHeader" />
                                </asp:DataGrid>
                             </td>
                            </tr>
                        </table> 
                      </div>
                    </div>  
               </td>      
  
             
              <td width="33%" valign="top">
                    <div id="container">
                    <div id="scrollable_content">
                    <table border="0">
                       <tr class="HomeTitles"><td valign="top">Expiring Probations Alert(Next 30 days)</td></tr>
                       <tr>            
                        <td width="33%" valign="top">
                            <asp:DataGrid ID="Grid7" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="true" DataKeyField="empid" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid7_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="Employee Name" DataField="EmployeeName" ItemStyle-Width="22%" SortExpression="Emp_Name"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Probation EndDate" DataField="ProbationEndDate" ItemStyle-Width="15%" SortExpression="Leave_Date"></asp:BoundColumn>
                                    
                               </Columns>     
                                <FooterStyle CssClass="DashGridFooter" />
                                <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="DashGridAltItem" />
                                <ItemStyle CssClass="DashGridItem" />
                                <HeaderStyle CssClass="DashGridHeader" />
                            </asp:DataGrid>
                        </td>
                       </tr>
                    </table> 
                    </div>
                    </div>  
              </td>

              
              
              <td width="33%" valign="top">
                  <div id="container">
                     <div id="scrollable_content">
                    <table border="0" width="100%">
                       <tr class="HomeTitles"><td valign="top">Labor Cards Expiry Alert(Next 6 Months) </td></tr>
                       <tr width="100%">            
                        <td  valign="top" >
                            <asp:DataGrid ID="Grid3" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="true" DataKeyField="EmpID" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid3_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="Employee Name" DataField="EmpName" ItemStyle-Width="40%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="LaborCard" DataField="LaborCardNo" ItemStyle-Width="25%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Expiry Date" DataField="ExpiryDate" ItemStyle-Width="25%"></asp:BoundColumn>
                               </Columns>     
                                <FooterStyle CssClass="DashGridFooter" />
                                <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="DashGridAltItem" />
                                <ItemStyle CssClass="DashGridItem" />
                                <HeaderStyle CssClass="DashGridHeader" />
                            </asp:DataGrid>
                        </td>
                       </tr>
                    </table> 
                    </div>
                </div>    
            </td>
        </tr>
  </table>
  </td>
</tr>
<tr><td colspan="3">&nbsp;</td></tr>
<tr>
     <td colspan="3" valign="top" width="100%">
      <table width="100%">
        <tr width="100%">
            <td valign="top" width="33%" >
                      <div id="container">
                       <div id="scrollable_content">     
                        <table border="0" width="100%">
                           <tr class="HomeTitles"><td valign="top">Visa Expiry Alert(Next 6 Months)</td></tr>
                           <tr>            
                            <td valign="top" width="100%">
                                <asp:DataGrid ID="Grid4" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="true" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid4_PageIndexChanged">                        
                                  <Columns>
                                        <asp:BoundColumn HeaderText="Employee Name" DataField="EmpName" ItemStyle-Width="35%"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Visa Number" DataField="VisaNo" ItemStyle-Width="25%"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Expiry Date" DataField="ExpiryDate" ItemStyle-Width="25%"></asp:BoundColumn>
                                        
                                   </Columns>     
                                    <FooterStyle CssClass="DashGridFooter" />
                                    <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                    <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                    <AlternatingItemStyle CssClass="DashGridAltItem" />
                                    <ItemStyle CssClass="DashGridItem" />
                                    <HeaderStyle CssClass="DashGridHeader" />
                                </asp:DataGrid>
                            </td>
                           </tr>
                        </table>
                       </div>  
                      </div>
            </td>
            <td valign="top" width="33%" >
                    <div id="container">
                    <div id="scrollable_content">
                    <table border="0">
                       <tr class="HomeTitles"><td valign="top">Passports Expiry Alert(Next 6 Months)</td></tr>
                       <tr>            
                        <td valign="top" width="33%">
                            <asp:DataGrid ID="Grid5" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid5_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="Employee Name" DataField="EmpName" ItemStyle-Width="35%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Passport No" DataField="PassportNo" ItemStyle-Width="25%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Expiry Date" DataField="ExpiryDate" ItemStyle-Width="22%"></asp:BoundColumn>
                                    
                               </Columns>     
                                <FooterStyle CssClass="DashGridFooter" />
                                <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="DashGridAltItem" />
                                <ItemStyle CssClass="DashGridItem" />
                                <HeaderStyle CssClass="DashGridHeader" />
                            </asp:DataGrid>
                        </td>
                       </tr>
                    </table> 
                    </div>
                  </div>        
           </td>
           <td valign="top" width="33%" >
                      <div id="container">
                       <div id="scrollable_content">     
                        <table border="0" width="100%">
                           <tr class="HomeTitles"><td valign="top">Business Visa Expiry Alert(Next 3 Months)</td></tr>
                           <tr>            
                            <td valign="top" width="100%">
                                <asp:DataGrid ID="Grid10" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="true" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid10_PageIndexChanged">                        
                                  <Columns>
                                        <asp:BoundColumn HeaderText="Employee Name" DataField="EmpName" ItemStyle-Width="35%"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="B. Visa No" DataField="VisaNo" ItemStyle-Width="25%"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Expiry Date" DataField="ExpiryDate" ItemStyle-Width="25%"></asp:BoundColumn>
                                        
                                   </Columns>     
                                    <FooterStyle CssClass="DashGridFooter" />
                                    <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                    <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                    <AlternatingItemStyle CssClass="DashGridAltItem" />
                                    <ItemStyle CssClass="DashGridItem" />
                                    <HeaderStyle CssClass="DashGridHeader" />
                                </asp:DataGrid>
                            </td>
                           </tr>
                        </table>
                       </div>  
                      </div>
            </td>           
             

      <!--
           <td valign="top" width="33%" >
                    <div id="container">
                    <div id="scrollable_content">
                    <table border="0">
                       <tr bgcolor=Azure><td class="mainheadtxt3" valign="top">Birth Days in this Week</td></tr>
                       <tr>            
                        <td valign="top" width="33%">
                            <asp:DataGrid ID="Grid6" Width="100%" runat="server" PageSize="10" AllowPaging="True" DataKeyField="EmpId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid5_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="Employee Name" DataField="EmployeeName" ItemStyle-Width="35%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Birth Date" DataField="DOB" ItemStyle-Width="25%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Service Years" DataField="ServiceYears" ItemStyle-Width="22%"></asp:BoundColumn>
                                    
                               </Columns>     
                                <FooterStyle CssClass="DashGridFooter" />
                                <SelectedItemStyle CssClass="DashGridSelectedItem" />
                                <PagerStyle CssClass="DashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="DashGridAltItem" />
                                <ItemStyle CssClass="DashGridItem" />
                                <HeaderStyle CssClass="DashGridHeader" />
                            </asp:DataGrid>
                        </td>
                       </tr>
                    </table> 
                    </div>
                  </div>        
           </td>
           -->
       </tr>
    </table>
   </td>  
</tr>
<tr><td colspan="3">&nbsp;</td></tr>
<tr>
    <td colspan="3" valign="top" width="100%">
      <table width="100%">
        <tr width="100%">
        <td width="33%" valign="top">
                    <div id="container">
                    <div id="scrollable_content">
                    <table border="0">
                       <tr class="HomeTitles"><td valign="top">Upcoming Holidays</td></tr>
                       <tr>            
                        <td width="33%" valign="top">
                            <asp:DataGrid ID="Grid2" CssClass="Tabular2" Width="100%" runat="server" PageSize="10" AllowPaging="true" DataKeyField="HolidayId" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid2_PageIndexChanged">                        
                              <Columns>
                                    <asp:BoundColumn HeaderText="Holiday Name" DataField="HolidayName" ItemStyle-Width="22%" SortExpression="Emp_Name"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Holiday Date" DataField="Holiday_Date" ItemStyle-Width="15%" SortExpression="Leave_Date"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Country" DataField="CountryName" ItemStyle-Width="8%" SortExpression="Country"></asp:BoundColumn>
                                    
                               </Columns>     
                                <FooterStyle CssClass="DashDashGridFooter" />
                                <SelectedItemStyle CssClass="DashDashGridSelectedItem" />
                                <PagerStyle CssClass="DashDashGridPagerItem" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="DashDashGridAltItem" />
                                <ItemStyle CssClass="DashDashGridItem" />
                                <HeaderStyle CssClass="DashDashGridHeader" />
                            </asp:DataGrid>
                        </td>
                       </tr>
                    </table> 
                    </div>
                    </div>  
              </td>
                      
       
            <td valign="top" width="33%" ></td>
            <td valign="top" width="33%" ></td>  
    </tr>
    </table>
   </td>              
</tr>


</ASP:PlaceHolder>
</table>
 </master:content>