<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Fee)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            FeeId:
            <%= Html.Encode(Model.FeeId) %>
        </p>
        <p>
            FundingSourceId:
            <%=Html.Encode(Model.Main.FeeSchedualName)%>
        </p>
        <p>
            LocationId:
            <%=Html.Encode(Model.Location.LocationName)%>
        </p>
        <p>
            Product:
            <%=Html.Encode(Model.Product.GetServiceName)%>
        </p>
        <p>
            UnitPrice:
            <%= Html.Encode(String.Format("{0:F}", Model.UnitPrice)) %>
        </p>
        <p>
            UnitTypeId:
            <%=Html.Encode(Model.UnitType.UnitType)%>
        </p>
        
    </fieldset>
    
    
    <fieldset>
        <legend>Auto</legend>
        <p>
            Min Number of Units
            <%=Model.MinUnits%>
         </p>
         <p>   
            Min Units Type: Days            
        </p>
    
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.FeeId})%> |
        <%=Html.ActionLink("Delete", "Delete", New With {.id = Model.FeeId})%> |
       
    </p>

</asp:Content>

