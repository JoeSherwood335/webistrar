Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports <xmlns="urn:vgs:st">
Namespace Model.ProgramOutcomes

    Public Class StOutcome
        Implements iProgramOutcome



        Private _Goal As String
        Private _PracticeName As String
        Private _PracticeScore As Integer
        Private _MainName As String
        Private _MainScore As Integer
        Private _ProgramOutcome As Integer
        Private _CompletedBy As String
        Private _ed As String

        Public Property Goal() As String
            Get
                Return _Goal
            End Get
            Set(ByVal value As String)
                _Goal = value
            End Set
        End Property

        Public Property PracticeName() As String
            Get
                Return _PracticeName
            End Get
            Set(ByVal value As String)
                _PracticeName = value
            End Set
        End Property

        Public Property PracticeScore() As Integer
            Get
                Return _PracticeScore
            End Get
            Set(ByVal value As Integer)
                _PracticeScore = value
            End Set
        End Property

        Public Property MainName() As String
            Get
                Return _MainName
            End Get
            Set(ByVal value As String)
                _MainName = value
            End Set
        End Property

        Public Property MainScore() As Integer
            Get
                Return _MainScore
            End Get
            Set(ByVal value As Integer)
                _MainScore = value
            End Set
        End Property

        Public Property ProgramOutcome() As Integer
            Get
                Return _ProgramOutcome
            End Get
            Set(ByVal value As Integer)
                _ProgramOutcome = value
            End Set
        End Property

        Private _NoteId As Integer
        Public Property NoteId() As Integer
            Get
                Return _NoteId
            End Get
            Set(ByVal value As Integer)
                _NoteId = value
            End Set
        End Property


        Private _SatFor3rdPartyCert As String
        Public Property SatFor3rdPartyCert() As String
            Get
                Return _SatFor3rdPartyCert
            End Get
            Set(ByVal value As String)
                _SatFor3rdPartyCert = value
            End Set
        End Property



        Public Function toXml(ByVal Completedby As String) As XElement Implements iProgramOutcome.toXml


            Dim dc As New R2kdoiMVCDataContext

            If String.IsNullOrEmpty(_CompletedBy) Then
                _CompletedBy = Completedby
            End If

            If String.IsNullOrEmpty(_ed) Then
                _ed = Date.Now.ToShortDateString
            End If

            Dim We = <ProgramOutcome xmlns="urn:vgs:st" CompletedBy=<%= _CompletedBy %> type='st' ed=<%= Date.Now.ToShortDateString %> version='2.0'>
                         <Goal><%= Goal %></Goal>
                         <MainName><%= MainName %></MainName>
                         <MainScore><%= MainScore %></MainScore>
                         <PracticeName><%= PracticeName %></PracticeName>
                         <PracticeScore><%= PracticeScore %></PracticeScore>
                         <NoteId><%= NoteId %></NoteId>
                         <Satfor3rdParty><%= SatFor3rdPartyCert %></Satfor3rdParty>
                     </ProgramOutcome>

            Return We
        End Function



        Public Sub ReadXml(ByVal Element As XElement) Implements iProgramOutcome.ReadXml
            'ProgramOutcome = Element.<Outcome>.@id
            _CompletedBy = Element.@CompletedBy
            _ed = Element.@ed
            Goal = Element.<Goal>.Value
            MainName = Element.<MainName>.Value
            MainScore = Element.<MainScore>.Value
            PracticeName = Element.<PracticeName>.Value
            PracticeScore = Element.<PracticeScore>.Value
            NoteId = Element.<NoteId>.Value
            SatFor3rdPartyCert = Element.<Satfor3rdParty>.Value



        End Sub



        Public Shared Function GetSelectList(ByVal po? As Integer) As Dictionary(Of String, SelectList)
            Dim di As New Dictionary(Of String, SelectList)
            Dim db As New R2kdoiMVCDataContext

            If po.HasValue Then
                'di("PO") = New SelectList(db.ServiceOutcomes, "ServiceOutcomeId", "ServiceOutcomeName", po.Value)
            Else
                'di("PO") = New SelectList(db.ServiceOutcomes, "ServiceOutcomeId", "ServiceOutcomeName")
            End If

            Return di

        End Function


        Public Function Body() As String Implements iProgramOutcome.Body
            Dim output = <div>
                             <p><strong>Completed by </strong><%= _CompletedBy %> on <%= _ed %></p>
                             <p><strong>Practice Test Score </strong><%= PracticeScore %></p>
                             <p><strong>Main Test Score </strong><%= MainScore %></p>
                             <p><strong>Completed 3rd Party Certification</strong><%= SatFor3rdPartyCert %></p>
                         </div>

            Return output.ToString

        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("SkillsTraining", New With {.permilink = Permilink, .id = id}))

        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "Skills Traininig"

        End Function
    End Class





End Namespace

