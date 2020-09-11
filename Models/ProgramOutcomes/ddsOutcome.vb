Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports <xmlns="urn:vgs:dds">
Namespace Model.ProgramOutcomes
    Public Class ddsOutcome
        Implements iProgramOutcome

        Private _Permilink As String
        Private _id As Integer

        Private _CompletedBy As String
        Private _ed As String



        Private _NumberOfCommunityTrips As String
        Public Property CommunityTrips() As String
            Get
                Return _NumberOfCommunityTrips
            End Get
            Set(ByVal value As String)
                _NumberOfCommunityTrips = value
            End Set
        End Property



        Private _NumberOfNoneWorkRelatedActivities As String
        Public Property NumberOfNoneWorkRelatedActivities() As String
            Get
                Return _NumberOfNoneWorkRelatedActivities
            End Get
            Set(ByVal value As String)
                _NumberOfNoneWorkRelatedActivities = value
            End Set
        End Property




        Private _StartDateSpan As String
        Public Property StartDateSpan() As String
            Get
                Return _StartDateSpan
            End Get
            Set(ByVal value As String)
                _StartDateSpan = value
            End Set
        End Property


        Private _DateofAssessment As String
        Public Property DateOfAssessment() As String
            Get
                Return _DateofAssessment
            End Get
            Set(ByVal value As String)
                _DateofAssessment = value
            End Set
        End Property


        Private _NumberOfDaysScheduled As String
        Public Property NumberOfDaysScheduled() As String
            Get
                Return _NumberOfDaysScheduled
            End Get
            Set(ByVal value As String)
                _NumberOfDaysScheduled = value
            End Set
        End Property


        Private _NumberOfDaysAttended As String
        Public Property NumberOfDaysAttended() As String
            Get
                Return _NumberOfDaysAttended
            End Get
            Set(ByVal value As String)
                _NumberOfDaysAttended = value
            End Set
        End Property


        Private _AvgGoalScorefromFirstQuarter As String
        Public Property AvgGoalScoreFromFirstQuarter() As String
            Get
                Return _AvgGoalScorefromFirstQuarter
            End Get
            Set(ByVal value As String)
                _AvgGoalScorefromFirstQuarter = value
            End Set
        End Property


        Private _AvgGoalScorefromForthQuarter As String
        Public Property AvgGoalScorefromForthQuarter() As String
            Get
                Return _AvgGoalScorefromForthQuarter
            End Get
            Set(ByVal value As String)
                _AvgGoalScorefromForthQuarter = value
            End Set
        End Property




        Public Sub ReadXml(ByVal xmldata As XElement) Implements iProgramOutcome.ReadXml


            _CompletedBy = xmldata.@CompletedBy
            _ed = xmldata.@ed

            CommunityTrips = xmldata.<CommunityTrips>.Value
            NumberOfNoneWorkRelatedActivities = xmldata.<NumberOfNoneWorkRelatedActivities>.Value
            StartDateSpan = xmldata.<StartDateSpan>.Value
            DateOfAssessment = xmldata.<DateOfAssessment>.Value
            NumberOfDaysScheduled = xmldata.<NumberOfDaysScheduled>.Value
            NumberOfDaysAttended = xmldata.<NumberOfDaysAttended>.Value
            AvgGoalScoreFromFirstQuarter = xmldata.<AvgGoalScoreFromFirstQuarter>.Value
            AvgGoalScorefromForthQuarter = xmldata.<AvgGoalScorefromForthQuarter>.Value


       

        End Sub

        Public Function toXml(ByVal CompletedBy As String) As XElement Implements iProgramOutcome.toXml
            If String.IsNullOrEmpty(_CompletedBy) Then
                _CompletedBy = CompletedBy
            End If

            If String.IsNullOrEmpty(_ed) Then
                _ed = Date.Now.ToShortDateString
            End If

            Dim We = <ProgramOutcome xmlns="urn:vgs:dds" CompletedBy=<%= _CompletedBy %> type='dds' ed=<%= _ed %> version='1.0'>
                         <CommunityTrips text=<%= (From a In SelectListItems Where a.Value = CommunityTrips Select a.Text Take 1).Single %>><%= CommunityTrips %></CommunityTrips>
                         <NumberOfNoneWorkRelatedActivities text=<%= (From a In SelectListItems Where a.Value = NumberOfNoneWorkRelatedActivities Select a.Text Take 1).Single %>><%= NumberOfNoneWorkRelatedActivities %></NumberOfNoneWorkRelatedActivities>
                         <StartDateSpan><%= StartDateSpan %></StartDateSpan>
                         <DateOfAssessment><%= DateOfAssessment %></DateOfAssessment>
                         <NumberOfDaysScheduled><%= NumberOfDaysScheduled %></NumberOfDaysScheduled>
                         <NumberOfDaysAttended><%= NumberOfDaysAttended %></NumberOfDaysAttended>
                         <AvgGoalScoreFromFirstQuarter><%= AvgGoalScoreFromFirstQuarter %></AvgGoalScoreFromFirstQuarter>
                         <AvgGoalScorefromForthQuarter><%= AvgGoalScorefromForthQuarter %></AvgGoalScorefromForthQuarter>
                     </ProgramOutcome>

            Return We


        End Function






        ReadOnly Property SelectListItems() As List(Of SelectListItem)
            Get
                Dim ddL As New List(Of SelectListItem)

                Dim na As New SelectListItem With {.Value = -1, .Text = "N/A"}
                Dim none As New SelectListItem With {.Value = 0, .Text = "None"}
                Dim onetoten As New SelectListItem With {.Value = 1, .Text = "1 to 10"}
                Dim eleventotwenty As New SelectListItem With {.Value = 2, .Text = "11 to 20"}
                Dim twentyone As New SelectListItem With {.Value = 3, .Text = "21 to 30"}
                Dim thirtyone As New SelectListItem With {.Value = 4, .Text = "31 to 40"}
                Dim fortyone As New SelectListItem With {.Value = 5, .Text = "41 to 50"}
                Dim fivityone As New SelectListItem With {.Value = 6, .Text = "More than 50"}

                ddL.Add(na)
                ddL.Add(none)
                ddL.Add(onetoten)
                ddL.Add(eleventotwenty)
                ddL.Add(twentyone)
                ddL.Add(thirtyone)
                ddL.Add(fortyone)
                ddL.Add(fivityone)

                Return ddL

            End Get
        End Property

        Function GetSelectList(ByVal SelectedValue? As Integer) As SelectList
            Dim ddlsl As SelectList

            If SelectedValue.HasValue Then
                ddlsl = New SelectList(SelectListItems, "Value", "Text", SelectedValue)
            Else
                ddlsl = New SelectList(SelectListItems, "Value", "Text")
            End If

            Return ddlsl
        End Function


        Function BuildScript(ByVal name As String, ByVal s As String) As String
            Dim x As String = "<script type=""text/javascript"">$(""#{0}"" ).progressbar(""value"", {1});</script><div id=""{0}""></div>"
            Return String.Format(x, name, s)
        End Function


        Public Function Body() As String Implements iProgramOutcome.Body
            
            Dim output = <div>
                             <p><strong>Completed by </strong><%= _CompletedBy %> on <%= _ed %></p>
                             <p><strong>Number of Community Trips </strong><%= (From a In SelectListItems Where a.Value = CommunityTrips Select a.Text).Single %></p>
                             <p><strong>Number Of NoneWork Related Activities </strong><%= (From a In SelectListItems Where a.Value = NumberOfNoneWorkRelatedActivities Select a.Text).Single %></p>
                             <p><strong>Start Date Span </strong><%= StartDateSpan %></p>
                             <p><strong>Date Of Assessment </strong><%= DateOfAssessment %></p>
                             <p><strong>Number Of Days Scheduled </strong><%= NumberOfDaysScheduled %></p>
                             <p><strong>Number Of Days Attended </strong><%= NumberOfDaysAttended %></p>
                             <p><strong>Avg Goal Score From First Quarter </strong><%= AvgGoalScoreFromFirstQuarter %></p>
                             <p><strong>Avg Goal Score From Forth Quarter </strong><%= AvgGoalScorefromForthQuarter %></p>
                         </div>
            

            Return output.ToString

        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "DDS"
        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("DDS", New With {.permilink = Permilink, .id = id}))
        End Function
    End Class
End Namespace
