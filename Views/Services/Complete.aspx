<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>
<%@ Import Namespace="r2kdoimvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Complete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Complete</h2>

<%  Dim dc As New R2kdoiMVC.R2kDoiMvcBillingDataContext%>
<% 


    Dim AmountBilled = Aggregate a In dc.BillingDetails _
            Where (a.Billing.BillingCycles.OrderByDescending(Function(b) b.ActionDate).Select(Function(f) f.Action.Name).FirstOrDefault = Myapp.ACCEPTED Or a.Billing.BillingCycles.OrderByDescending(Function(b) b.ActionDate).Select(Function(f) f.Action.Name).FirstOrDefault = Myapp.BILLED Or a.Billing.BillingCycles.OrderByDescending(Function(b) b.ActionDate).Select(Function(f) f.Action.Name).FirstOrDefault = Myapp.APPROVED) And a.ServiceId = Model.ServiceId _
            Into Sum(a.NumberOfUnits * a.UnitPrice)

    Dim UnitsBilled = Aggregate a In dc.BillingDetails _
    Where (a.Billing.BillingCycles.OrderByDescending(Function(b) b.ActionDate).Select(Function(f) f.Action.Name).FirstOrDefault = Myapp.ACCEPTED Or a.Billing.BillingCycles.OrderByDescending(Function(b) b.ActionDate).Select(Function(f) f.Action.Name).FirstOrDefault = Myapp.BILLED Or a.Billing.BillingCycles.OrderByDescending(Function(b) b.ActionDate).Select(Function(f) f.Action.Name).FirstOrDefault = Myapp.APPROVED) And a.ServiceId = Model.ServiceId _
    Into Sum(a.NumberOfUnits)

           
               
 %>


<%  Using Html.BeginForm()%>
                    
     <%=Html.ValidationSummary("Please Click Back and correct all errors")%>               
                    
    <table>
        <thead>
            <tr>
                <td></td>
                <th>Units</th>
                <th>Amount</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th>Authorized</th>
                <td><%=Model.NumberOfUnitesAuthorized%></td>
                <td><%=String.Format("{0:c}", Model.AmountAuthorized)%></td>
            </tr>
        </tbody>    
        <tfoot>
            <tr>
                <th>Billed</th>
                <td><%=UnitsBilled  %></td>
                <td><%=String.Format("{0:c}", AmountBilled)%></td>
            </tr>
        </tfoot>
    </table>                
                    
    <p>      
        <%If Not CType(ViewData("hide"), Boolean) Then%> 
            <input type="submit" value="Complete" /><%=ViewState("hide")%>
        <% End If%>
    </p>
<% End Using%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
