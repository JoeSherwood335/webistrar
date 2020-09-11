<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.FundingSource)" %>

    <p>
        <%=Html.ActionLink("Create New", "AssignFee", New With {.fsid = Model.FundingSourceId})%>
    </p>
    
    <table>
        <tr>
            <th />
            <th>
                Fee Schedual
            </th>
        </tr>
  
    <% For Each Fees In Model.AssignFeesContainers%>
        <tr>
            <td><%=Html.ActionLink("Delete", "DeAssignFee", New With {.fsid = Model.FundingSourceId, .feeid = Fees.FeeSchedualId})%> |</td>
            <td>
                <%=Html.Encode(Fees.Main.FeeSchedualName)%>
            </td>
        </tr>
    <% Next%>
    </table>


