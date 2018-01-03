<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyOrganization.aspx.cs" Inherits="SchoolNet.MyOrganization" %>
<%@ Register TagPrefix="Master" Namespace="PresentationManager.Web.UI.MasterPages" Assembly="PresentationManager.Web.UI.MasterPages" %>
 <master:content id="formData" runat="server" height="100%" width="100%">
 <table border="0" cellspacing="0" cellpadding="0" height="100%" width="100%">
 <asp:PlaceHolder id="MyOrgTab" Runat="server" visible="true">
 <tr><td width="100%"> 
    <fieldset><legend>My Organization</legend>
      <table width="100%" border="0" class="Partgrayblock">
                    
		    <tr>
		       <td colspan="3" class="mainheadtxt">
		            <asp:TreeView  ID="MyOrgTree" ExpandDepth="0"  PopulateNodesFromClient="true" cssclass="mainheadtxt" ShowLines="true"  ShowExpandCollapse="true"  runat="server" />
  
               </td> 
     		</tr>
            <tr><td colspan="3">&nbsp;</td></tr>
	       	        
	    </table>   	 
	  </fieldset>
 </td>
</tr>
</asp:placeholder>
</table>							
</master:content>





