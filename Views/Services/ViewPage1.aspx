<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Service)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewPage1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewPage1</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            ServiceId:
            <%= Html.Encode(Model.ServiceId) %>
        </p>
        <p>
            AuthorizationId:
            <%= Html.Encode(Model.AuthorizationId) %>
        </p>
        <p>
            ServiceTypeId:
            <%= Html.Encode(Model.ServiceTypeId) %>
        </p>
        <p>
            NumberOfUnitesAuthorized:
            <%= Html.Encode(String.Format("{0:F}", Model.NumberOfUnitesAuthorized)) %>
        </p>
        <p>
            AmountAuthorized:
            <%= Html.Encode(String.Format("{0:F}", Model.AmountAuthorized)) %>
        </p>
        <p>
            ProductId:
            <%= Html.Encode(Model.ProductId) %>
        </p>
        <p>
            NumberOfUnits:
            <%= Html.Encode(String.Format("{0:F}", Model.NumberOfUnits)) %>
        </p>
        <p>
            UnitTypeId:
            <%= Html.Encode(Model.UnitTypeId) %>
        </p>
        <p>
            AssignedTo:
            <%= Html.Encode(Model.AssignedTo) %>
        </p>
        <p>
            CostCenter:
            <%= Html.Encode(Model.CostCenter) %>
        </p>
        <p>
            ServiceStartDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ServiceStartDate)) %>
        </p>
        <p>
            ServiceEndDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ServiceEndDate)) %>
        </p>
        <p>
            SchedualStartDate:
            <%= Html.Encode(String.Format("{0:g}", Model.SchedualStartDate)) %>
        </p>
        <p>
            SchedualEndDate:
            <%= Html.Encode(String.Format("{0:g}", Model.SchedualEndDate)) %>
        </p>
        <p>
            ServiceOutcomeId:
            <%= Html.Encode(Model.ServiceOutcomeId) %>
        </p>
        <p>
            InputedBy:
            <%= Html.Encode(Model.InputedBy) %>
        </p>
        <p>
            ed:
            <%= Html.Encode(String.Format("{0:g}", Model.ed)) %>
        </p>
        <p>
            ud:
            <%= Html.Encode(String.Format("{0:g}", Model.ud)) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.ServiceId})%> |
        
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

