Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports <xmlns="urn:vgs:we">
Namespace Model.ProgramOutcomes


    Public Class WeOutcome
        Implements iProgramOutcome



        Private _WasVocationalGoalDetermined As Boolean
        Private _Goal As String
        Private _note As String
        Private _GoalAccepted As Boolean
        Private _CompletedBy As String
        Private _ed As String
        ''' <summary>
        ''' Was Goal Determined
        ''' </summary>
        ''' <value>Boolean</value>
        Public Property WasVocationalGoalDetermined() As Boolean
            Get
                Return _WasVocationalGoalDetermined
            End Get
            Set(ByVal value As Boolean)
                _WasVocationalGoalDetermined = value
            End Set
        End Property

        Public Property Goal() As String
            Get
                If String.IsNullOrEmpty(_Goal) Then
                    Return ""
                Else
                    Return _Goal
                End If
            End Get
            Set(ByVal value As String)
                _Goal = value
            End Set
        End Property

        Public Property GoalAccepted() As Boolean
            Get
                Return _GoalAccepted
            End Get
            Set(ByVal value As Boolean)
                _GoalAccepted = value
            End Set
        End Property




        Public Sub readXml(ByVal element As System.Xml.Linq.XElement) Implements iProgramOutcome.ReadXml
            _CompletedBy = element.@CompletedBy
            _ed = element.@ed
            Me.WasVocationalGoalDetermined = If(Not String.IsNullOrEmpty(element.<WasVocationalGoalDetermined>.Value), CBool(element.<WasVocationalGoalDetermined>.Value), False)
            Me.Goal = element.<Goal>.Value
            Me.GoalAccepted = If(Not String.IsNullOrEmpty(element.<GoalAccepted>.Value), CBool(element.<GoalAccepted>.Value), False)


            'element.cr

        End Sub

        Public Function toXml(ByVal CompletedBy As String) As System.Xml.Linq.XElement Implements iProgramOutcome.toXml
            If String.IsNullOrEmpty(_CompletedBy) Then
                _CompletedBy = CompletedBy
            End If

            If String.IsNullOrEmpty(_ed) Then
                _ed = Date.Now.ToShortDateString
            End If

            Dim We = <ProgramOutcome xmlns="urn:vgs:we" CompletedBy=<%= _CompletedBy %> type='we' ed=<%= _ed %> version='1.0'>
                         <WasVocationalGoalDetermined><%= _WasVocationalGoalDetermined %></WasVocationalGoalDetermined>
                         <Goal><%= _Goal %></Goal>
                         <GoalAccepted><%= _GoalAccepted %></GoalAccepted>
                     </ProgramOutcome>

            Return We

        End Function




        Public Function Body() As String Implements iProgramOutcome.Body
            Dim output = <div>
                             <p><strong>Completed by </strong><%= _CompletedBy %> on <%= _ed %></p>
                             <p><strong>Goal </strong><%= Goal.Replace(vbCrLf, "<br />") %></p>
                             <p><strong>Goal Accepted</strong><%= _GoalAccepted %></p>

                         </div>

            Return output.ToString


        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("WorkEval", New With {.permilink = Permilink, .id = id}))
        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "Evaluation"

        End Function
    End Class

End Namespace
