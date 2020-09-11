Imports <xmlns="urn:vgs:pd">

Namespace Model.ProgramOutcomes
    Public Class PdOutcome
        Implements iProgramOutcome

        'Private _JobGoal As String
        'Private _NumberOfInterviews As Integer
        'Private _NumberOfJobCoachingHours As Integer
        'Private _NumberOfJobRententionHours As Integer
        'Private _JobGoal1 As String
        'Private _JobGoal2 As String
        'Private _JobGoal3 As String
        Private _ed As String
        Private _Completedby As String

        Private _NumberOfInterviews As Integer
        Public Property NumberOfInterviews() As Integer
            Get
                Return _NumberOfInterviews
            End Get
            Set(ByVal value As Integer)
                _NumberOfInterviews = value
            End Set
        End Property


        Private _NumberOfJobCoachingHours As Integer
        Public Property NumberOfJobCoachingHours() As Integer
            Get
                Return _NumberOfJobCoachingHours
            End Get
            Set(ByVal value As Integer)
                _NumberOfJobCoachingHours = value
            End Set
        End Property


        Private _NumberOfJobRententionHours As Integer
        Public Property NumberOfJobRententionHours() As Integer
            Get
                Return _NumberOfJobRententionHours
            End Get
            Set(ByVal value As Integer)
                _NumberOfJobRententionHours = value
            End Set
        End Property

        Private _JobGoal1 As String
        Public Property JobGoal1() As String
            Get
                Return _JobGoal1
            End Get
            Set(ByVal value As String)
                _JobGoal1 = value
            End Set
        End Property
        Private _JobGoal2 As String
        Public Property JobGoal2() As String
            Get
                Return _JobGoal2
            End Get
            Set(ByVal value As String)
                _JobGoal2 = value
            End Set
        End Property
        Private _JobGoal3 As String
        Public Property JobGoal3() As String
            Get
                Return _JobGoal3
            End Get
            Set(ByVal value As String)
                _JobGoal3 = value
            End Set
        End Property
        'Private _NumberOfInterviews As Integer
        'Private _NumberOfJobCoachingHours As Integer
        'Private _NumberOfJobRententionHours As Integer
        'Private _JobGoal1 As String
        'Private _JobGoal2 As String
        'Private _JobGoal3 As String

        Public Function toXml(ByVal CompletedBy As String) As System.Xml.Linq.XElement Implements iProgramOutcome.toXml
            If String.IsNullOrEmpty(_Completedby) Then
                _Completedby = CompletedBy
            End If

            If String.IsNullOrEmpty(_ed) Then
                _ed = Date.Now.ToShortDateString
            End If

            Dim We = <ProgramOutcome xmlns="urn:vgs:pd" CompletedBy=<%= _Completedby %> type='pd' ed=<%= _ed %> version='1.0'>
                         <NumberOfInterviews><%= NumberOfInterviews %></NumberOfInterviews>
                         <NumberOfJobCoachingHours><%= NumberOfJobCoachingHours %></NumberOfJobCoachingHours>
                         <NumberOfJobRententionHours><%= NumberOfJobRententionHours %></NumberOfJobRententionHours>
                         <JobGoal1><%= JobGoal1 %></JobGoal1>
                         <JobGoal2><%= JobGoal2 %></JobGoal2>
                         <JobGoal3><%= JobGoal3 %></JobGoal3>
                     </ProgramOutcome>


            Return We

        End Function

        Public Sub ReadXml(ByVal s As System.Xml.Linq.XElement) Implements iProgramOutcome.ReadXml

            _Completedby = s.@CompletedBy
            _ed = s.@ed

            Me.NumberOfInterviews = s.<NumberOfInterviews>.Value
            Me.NumberOfJobCoachingHours = s.<NumberOfJobCoachingHours>.Value
            Me.NumberOfJobRententionHours = s.<NumberOfJobRententionHours>.Value
            Me.JobGoal1 = s.<JobGoal1>.Value
            Me.JobGoal2 = s.<JobGoal2>.Value
            Me.JobGoal3 = s.<JobGoal3>.Value

        End Sub

        Public Function Body() As String Implements iProgramOutcome.Body
            Dim output = <div>
                             <p><strong>Completed by </strong><%= _Completedby %> on <%= _ed %></p>
                             <p><strong>Job Goal1</strong><%= JobGoal1 %></p>
                             <p><strong>Job Goal2</strong><%= JobGoal2 %></p>
                             <p><strong>Job Goal3</strong><%= JobGoal3 %></p>
                             <p><strong>Number Of Interviews</strong><%= NumberOfInterviews %></p>
                             <p><strong>Number Of JobCoaching Hours</strong><%= NumberOfJobCoachingHours %></p>
                             <p><strong>Number Of JobRentention Hours</strong><%= NumberOfJobRententionHours %></p>

                         </div>

            Return output.ToString

        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "Placement"
        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("pd", New With {.permilink = Permilink, .id = id}))
        End Function
    End Class
End Namespace

