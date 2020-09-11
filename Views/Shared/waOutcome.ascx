<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of R2kdoiMVC.Model.ProgramOutcomes.WaOutcome)" %>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>            
            <p>
                <label for="Attendance1">Attendance</label>
                <%=Html.DropDownList("Attendance1", CType(ViewData("Attendance"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Attendance1", "*") %>                
                <%=Html.DropDownList("Attendance2", CType(ViewData("Attendance22"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Attendance2", "*") %>
            </p>
            <p class="Description">Percent of total scheduled workdays present</p>
            <p>
                <label for="Punctuality1">Punctuality:</label>
                <%=Html.DropDownList("Punctuality1", CType(ViewData("Punctuality"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Punctuality1", "*") %>                
                <%=Html.DropDownList("Punctuality2", CType(ViewData("Punctuality22"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Punctuality2", "*") %>
            </p>
            <p class="Description">Percent of total scheduled workdays when the individual  was not more than 5 minutes late arriving for work or returning from lunch or breaks</p>
            <p>
                <label for="Productivity1">Productivity:</label>
                <%=Html.DropDownList("Productivity1", CType(ViewData("Productivity"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Productivity1", "*") %>                
                <%=Html.DropDownList("Productivity2", CType(ViewData("Productivity22"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Productivity2", "*") %>
            </p>
            <p class="Description">The rate of speed that work is completed in for a specific period of time</p>
            <p>
                <label for="WorkQuality1">WorkQuality:</label>                
                <%=Html.DropDownList("WorkQuality1", CType(ViewData("WorkQuality"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("WorkQuality1", "*") %>
                <%=Html.DropDownList("WorkQuality2", CType(ViewData("WorkQuality22"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("WorkQuality2", "*") %>                

            </p>
            <p class="Description">The ability to produce work that is correctly completed</p>
            <p>
                <label for="OnTaskBehavior1">OnTaskBehavior:</label>
                <%=Html.DropDownList("OnTaskBehavior1", CType(ViewData("OnTaskBehavior"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("OnTaskBehavior1", "*") %>
                <%=Html.DropDownList("OnTaskBehavior2", CType(ViewData("OnTaskBehavior22"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("OnTaskBehavior2", "*") %>
            </p>
            <p class="Description">The ability to consistently engage in activities that lead to completion of assigned work</p>
            <p>
                <label for="AcceptingAuthority1">AcceptingAuthority:</label>
                <%=Html.DropDownList("AcceptingAuthority1", CType(ViewData("Authority"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("AcceptingAuthority1", "*") %>   
                <%=Html.DropDownList("AcceptingAuthority2", CType(ViewData("Authority22"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("AcceptingAuthority2", "*") %>
            </p>
            <p class="Description">Willingness to listen and make an effort to comply with work place and rules</p>
            <p>
                <label for="Appearance1">Appearance:</label>
                <%=Html.DropDownList("Appearance1", CType(ViewData("Appearance"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Appearance1", "*") %>               
                <%=Html.DropDownList("Appearance2", CType(ViewData("Appearance22"), SelectList), "[not set]")%>
                <%= Html.ValidationMessage("Appearance2", "*") %>
            </p>
            <p class="Description">The practice of good personal hygiene, personal grooming, and wearing of appropriate attire for the assigned work setting</p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>



