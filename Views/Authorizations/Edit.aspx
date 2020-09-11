<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Authorizations.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Authorization)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Authorization <%=Html.Encode(Model.AuthorizationNumber)%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
    <script type="text/javascript" >
        $(document).ready(function() {
            $.ajaxSetup({ cache: false })
            $('#ReferralSourceId').change(function() {
                //alert("rs Change");
                $.getJSON('/Referral/getcounslers/' + $("#ReferralSourceId > option:selected").attr("value"), function(data) {
                    var items = '<option value="0">[Not Set]</option>'
                    $.each(data, function(i, counsler) {
                        items += '<option value="' + counsler.ReferringCounselorId + '">' + counsler.DisplayName + '</option>'
                    });
                    $('#FundingCounslerId').html(items);
                });
            });
            $('#AuthorizationDate').datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>
    <h2>Edit Authorization</h2>

    <% Using Html.BeginForm() %>
        <%=Html.ActionLink("Back to Authorizations", "Details", New With {.id = Model.AuthorizationID})%>
            <p>
               <input type="submit" value="Save" />
            </p>
            <fieldset>
                <legend>Source</legend>
                <p>
                    <label for="ReferralSourceId">Funding Source:</label>
                    <%=Html.DropDownList("ReferralSourceId", Model.getReferalSources(Model.FundingCounslerId), "[Not Set]")%>
                    <%=Html.ValidationMessage("ReferralSourceId", "*")%>
                </p>
                <p>
                    <label for="ReferingCounslerId">Counsler:</label>
                    <%=Html.DropDownList("FundingCounslerId", Model.getReferringCounslers, "[Not Set]")%><a id="newC" href="#" >New</a>
                    <%=Html.ValidationMessage("FundingCounslerId", "*")%>
                </p>
            </fieldset> 

            <fieldset>
            <legend>Details</legend>

            <p>
                <label for="AuthorizationNumber">Authorization Number</label>
                <%= Html.TextBox("AuthorizationNumber") %>
                <%= Html.ValidationMessage("AuthorizationNumber", "*") %>
            </p>
            <p>
                <label for="AuthorizationDate">Authorization Date</label>
                <%= Html.TextBox("AuthorizationDate") %>
                <%= Html.ValidationMessage("AuthorizationDate", "*") %>
            </p>

        </fieldset>
        <fieldset>
            <legend>Services</legend>
            <%=Html.ActionLink("Add Service", "AddDetail", New With {.id = Model.AuthorizationID})%>
            <%=Html.ActionLink("Add Services", "AddDetails", New With {.id = Model.AuthorizationID})%>
            
            <br /><br />
            <% Html.RenderPartial("AuthorizationDetails")%>
        </fieldset>
        
        <%=Html.ActionLink("Back to Authorizations", "Details", New With {.id = Model.AuthorizationID})%>
                    <p>
               <input type="submit" value="Save" />
            </p>
        
    <% End Using %>


    
</asp:Content>

