Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Namespace Model.ProgramOutcomes



    Public Class dsOutcome
        Implements iProgramOutcome

        Private _CompletedBy As String
        Private _ed As String

        Public Enum months
            January = 1
            Feburary = 2
            March = 3
            April = 4
            May = 5
            June = 6
            July = 7
            Augest = 8
            September = 9
            October = 10
            November = 11
            December = 12
        End Enum

        Private _Month As Integer
        Public Property Month() As Integer
            Get
                Return _Month
            End Get
            Set(ByVal value As Integer)
                _Month = value
            End Set
        End Property


        Private _year As Int16
        Public Property Year() As Int16
            Get
                Return _year
            End Get
            Set(ByVal value As Int16)
                _year = value
            End Set
        End Property


        Private _AvgSuccessRate As Double
        Public Property AvgSuccessRate() As Double
            Get
                Return _AvgSuccessRate
            End Get
            Set(ByVal value As Double)
                _AvgSuccessRate = value
            End Set
        End Property

        Public Sub ReadXml(ByVal s As System.Xml.Linq.XElement) Implements iProgramOutcome.ReadXml
            Month = s.<Month>.Value
            Year = s.<year>.Value
            AvgSuccessRate = s.<AvgSuccessRate>.Value

            Me._CompletedBy = s.@CompletedBy


        End Sub



        Public Function toXml(ByVal CompletedBy As String) As System.Xml.Linq.XElement Implements iProgramOutcome.toXml

            _CompletedBy = CompletedBy
            _ed = Date.Now

            Dim We = <ProgramOutcome xmlns="urn:vgs:ds" CompletedBy=<%= CompletedBy %> type='ds' ed=<%= Date.Now.ToShortDateString %> version='1.0'>
                         <Month><%= Month %></Month>
                         <Year><%= Year %></Year>
                         <AvgSuccessRate><%= AvgSuccessRate %></AvgSuccessRate>
                     </ProgramOutcome>

            Return We
        End Function

        Public Shared Function GetMonthsSelectList() As SelectList
            Dim monthItems As Array = [Enum].GetValues(GetType(months))
            Dim items As List(Of SelectListItem) = New List(Of SelectListItem)(monthItems.Length)

            For Each a In monthItems
                Dim n1 As New SelectListItem
                With n1
                    .Text = [Enum].GetName(GetType(months), a)
                    .Value = CInt(a)
                End With
                items.Add(n1)
            Next

            Return New SelectList(items.AsEnumerable, "Value", "Text", Date.Now.Month)
        End Function




        Public Function Body() As String Implements iProgramOutcome.Body
            Dim output = <div>
                             <p><strong>Completed by </strong><%= _CompletedBy %> on <%= _ed %></p>
                             <p><strong>Month </strong><%= Month %><strong>Year </strong><%= Year %></p>
                             <p><strong>Avg Success Rate </strong><%= AvgSuccessRate %></p>


                         </div>

            Return output.ToString

        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("ds", New With {.permilink = Permilink, .id = id}))
        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "Development Services"
        End Function
    End Class
End Namespace