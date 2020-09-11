<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of R2kdoiMVC.Model.Program))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=""%>
    <h2>Index</h2>
    <script type="text/javascript" >

        $(document).ready(function() {

            $("#Locations").change(function() {
                $(this).parent('form').submit();
            });

        });
    
    </script>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>Acronym</th>
            <th>ProgramName</th>
            <th>ProgramOutcome</th>    
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.ProgramId})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.ProgramId})%>
            </td>
            <td>
                <%=Html.Encode(item.Acronym)%>
            </td>
            <td>
                <%= Html.Encode(item.ProgramName) %>
            </td>

        </tr>
    
    <% Next%>

    </table>

</asp:Content>

