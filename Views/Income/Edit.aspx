<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Income)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Income</legend>
           <p>
                <label for="IncomeSourceId">IncomeSource:</label>
                <%=Model.IncomeSource.IncomeSource%>
           </p>
            
          <% If Model.IncomeSource.IncomeSource = "None" Then%>
                
                <p>
                    <%=Html.Hidden("IncomeSourceAmount")%>
                </p>
                <p>
                    <%=Html.Hidden("IncomeSourceAmountTypeId")%>
                </p>
            
                <p>This Consumer is reporting they have no income.</p>
            
          <% ElseIf Model.IncomeSource.IncomeSource = "Refused to be given" Then%>
          
            <p>
                <%=Html.Hidden("IncomeSourceAmount")%>
            </p>
            <p>
                <%=Html.Hidden("IncomeSourceAmountTypeId")%>
            </p>
            
            <p>Consumer refuses to divulge their income.</p>
                        
            <%else %>
            <p>
                <label for="IncomeSourceAmount">Amount:</label>
                <%= Html.TextBox("IncomeSourceAmount") %>
                <%= Html.ValidationMessage("IncomeSourceAmount", "*") %>
            </p>
            <p>
                <label for="IncomeSourceAmountTypeId">Type:</label>
                <%=Html.DropDownList("IncomeSourceAmountTypeId", Model.getAmmountType(Model.IncomeSourceAmountTypeId), "[Not Set]")%>
            </p>
            <%End if  %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

