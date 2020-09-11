<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="MvcPaging"%>

<%=""%>



    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Open", "Details", New With {.id = item.Id})%>
            </td>
            <td>
                <%=Html.Encode(item.Status)%>   
                        
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.statusDate))%>   
                        
            </td>
            <td>
                <%=Html.Encode(item.Username)%>           
            </td>
            <td>
                <%=Html.Encode(item.Id)%>           
            </td>
            <td>
                <%=R2kdoiMVC.Myapp.ConsumerLink(item.Permilink, item.FirstName, item.LastName)%>
           </td>
            <td>
                <acronym title="<%=Html.Encode(item.ProgramName)%>"><%=html.encode(item.ProgramAcronym)%></acronym> 
            </td>
            <td>
                <%= Html.Encode(item.CostCenter) %>
            </td>
            <td>
                <acronym title="<%=Html.Encode(item.FullName)%>"><%=Html.Encode(item.Acronym)%></acronym>
            </td>
            <td>
                <%= Html.Encode(item.AuthorizationNo) %>
            </td>
            <td>
              <%=Html.Encode(String.Format("{0:C}", item.AmountBilled))%>
            </td>

            <td>
                <%=Html.Encode(String.Format("{0:d}", item.StartDate))%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.EndDate))%>
            </td>
            <td>
                <%=Html.Encode(item.ProgramSupervisor)%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:d}", item.DateIssued))%>
            </td>

        </tr>
    
    <% Next%>
    
    
    
    

    