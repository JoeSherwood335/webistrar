Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports <xmlns="urn:vgs:jc">
Namespace Model.ProgramOutcomes


    Public Class JCOutcome
        Implements iProgramOutcome


        'Developed ability to work independently at site.
        'Developed the ability to travel to work site independently.

        '

        Private _WorkIndependently As String
        Public Property WorkIndependently() As String
            Get
                Return _WorkIndependently
            End Get
            Set(ByVal value As String)
                _WorkIndependently = value
            End Set
        End Property


        Private _TravelIndependently As String
        Public Property TravelIndependently() As String
            Get
                Return _TravelIndependently
            End Get
            Set(ByVal value As String)
                _TravelIndependently = value
            End Set
        End Property


        ' Answers Improved,  Developed, Not Able 


        ' Dim _ImprovedWorkIndependently As String 'Improved in ability to work independently at site.
        'Dim _ImprovedTravelIndependently As String 'Developed the ability to travel to work site independently.

        'Improved in ability to travel to work site independently.
        'Not able to develop the ability to work independently at site. 
        'Not able to develop the ability to travel to work site independently.  
        'Did not participate in travel training.  
        'Did not participate in job coaching.  




        Private _CompletedBy As String
        Private _ed As String

 
        Public Function toXml(ByVal CompletedBy As String) As System.Xml.Linq.XElement Implements iProgramOutcome.toXml


            If String.IsNullOrEmpty(_CompletedBy) Then
                _CompletedBy = CompletedBy
            End If

            If String.IsNullOrEmpty(_ed) Then
                _ed = Date.Now.ToShortDateString
            End If

            Dim x = <ProgramOutcome xmlns="urn:vgs:jc" CompletedBy=<%= _CompletedBy %> type='jc' ed=<%= _ed %> version='1.0'>
                        <WorkIndependently><%= _WorkIndependently %></WorkIndependently>
                        <TravelIndependently><%= _TravelIndependently %></TravelIndependently>
                    </ProgramOutcome>


            Return x
        End Function

        Public Sub ReadXml(ByVal el As System.Xml.Linq.XElement) Implements iProgramOutcome.ReadXml
            _CompletedBy = el.@CompletedBy
            _ed = el.@ed


            Me.WorkIndependently = el.<WorkIndependently>.Value
            Me.TravelIndependently = el.<TravelIndependently>.Value


        End Sub
        'Public Shared Function GetSelectLists() As Dictionary(Of String, SelectList)


        Private ReadOnly Property WorkIndependentlyList() As List(Of SelectListItem)
            Get
                Dim WorkIndependentlyL As New List(Of SelectListItem)
                '       Dim TravelIndependentlyL As New List(Of SelectListItem)

                Dim WorkIndependentlyli As New SelectListItem
                WorkIndependentlyli.Text = "Person is able to Work Independently and is no longer needs Job Coaching services"
                WorkIndependentlyli.Value = "Developed"
                WorkIndependentlyL.Add(WorkIndependentlyli)

                Dim WorkIndependentlyli2 As New SelectListItem
                WorkIndependentlyli2.Text = "Has became more independent, but still requires onsite support"
                WorkIndependentlyli2.Value = "Improved"
                WorkIndependentlyL.Add(WorkIndependentlyli2)

                Dim WorkIndependentlyli3 As New SelectListItem
                WorkIndependentlyli3.Text = "Not able to Work Independently at site"
                WorkIndependentlyli3.Value = "NotAble"
                WorkIndependentlyL.Add(WorkIndependentlyli3)

                Dim WorkIndependentlyli4 As New SelectListItem
                WorkIndependentlyli4.Text = "Did not participate in Job Coaching"
                WorkIndependentlyli4.Value = "n/a"
                WorkIndependentlyL.Add(WorkIndependentlyli4)

                Return WorkIndependentlyL

            End Get
        End Property
        Private ReadOnly Property TravelIndependentlyList() As List(Of SelectListItem)
            Get
                Dim TravelIndependentlyL As New List(Of SelectListItem)

                Dim TravelIndependentlyli As New SelectListItem
                TravelIndependentlyli.Text = "Person is able to Travel Independently and is no longer needs Travel Training"
                TravelIndependentlyli.Value = "Developed"
                TravelIndependentlyL.Add(TravelIndependentlyli)

                Dim TravelIndependentlyli2 As New SelectListItem
                TravelIndependentlyli2.Text = "Has became more Independent, but still requires Travel Training"
                TravelIndependentlyli2.Value = "Improved"
                TravelIndependentlyL.Add(TravelIndependentlyli2)

                Dim TravelIndependentlyli3 As New SelectListItem
                TravelIndependentlyli3.Text = "Not able to Travel Independently to site"
                TravelIndependentlyli3.Value = "NotAble"
                TravelIndependentlyL.Add(TravelIndependentlyli3)

                Dim TravelIndependentlyli4 As New SelectListItem
                TravelIndependentlyli4.Text = "Did not participate in Travel Training"
                TravelIndependentlyli4.Value = "n/a"
                TravelIndependentlyL.Add(TravelIndependentlyli4)

                Return TravelIndependentlyL
            End Get
        End Property


        Function WorkIndependentlyListSelectList() As SelectList
            Dim ddlsl As SelectList

            ddlsl = New SelectList(WorkIndependentlyList.AsEnumerable, "Value", "Text")
            
            Return ddlsl
        End Function


        Function TravelIndependentlyListSelectList() As SelectList
            Dim ddlsl As SelectList

            ddlsl = New SelectList(TravelIndependentlyList.AsEnumerable, "Value", "Text")
            
            Return ddlsl
        End Function

        Function WorkIndependentlyListSelectList(ByVal SelectedValue As String) As SelectList
            Dim ddlsl As SelectList

            ddlsl = New SelectList(WorkIndependentlyList.AsEnumerable, "Value", "Text", SelectedValue)
            
            Return ddlsl
        End Function


        Function TravelIndependentlyListSelectList(ByVal SelectedValue As String) As SelectList
            Dim ddlsl As SelectList

            ddlsl = New SelectList(TravelIndependentlyList.AsEnumerable, "Value", "Text", SelectedValue)

            Return ddlsl
        End Function

        Public Function Body() As String Implements iProgramOutcome.Body
            'Dim score1 = AcceptingAuthority1 + Appearance1 + Attendance1 + OnTaskBehavior1 + Productivity1 + Punctuality1 + WorkQuality1
            'Dim score2 = AcceptingAuthority2 + Appearance2 + Attendance1 + OnTaskBehavior2 + Productivity2 + Punctuality2 + WorkQuality2

            Dim output = <div>
                             <p><strong>Work Independently</strong></p>
                             <p><%= (From a In WorkIndependentlyList Where a.Value = Me.WorkIndependently Select a.Text).SingleOrDefault %></p>
                             <p><strong>Travel Independently</strong></p>
                             <p><%= (From a In TravelIndependentlyList Where a.Value = TravelIndependently Select a.Text).SingleOrDefault %></p>
                             <p><strong>Completed by </strong><%= _CompletedBy %> on <%= _ed %></p>
                         </div>

            Return output.ToString

        End Function


        Function bodyxslt() As String
            Dim x As XElement = toXml("")
            Dim markup As XDocument = XDocument.Load(Myapp.LocalPath("waOutcome.xslt"))


            Dim newTree As XDocument = New XDocument

            Dim settings As New System.Xml.XmlWriterSettings

            settings.ConformanceLevel = System.Xml.ConformanceLevel.Fragment

            Dim si As New System.Text.StringBuilder

            'Using writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(si, settings) 'newTree.CreateWriter
            Using writer As System.Xml.XmlWriter = newTree.CreateWriter

                ' Load the style sheet.
                Dim xslt As System.Xml.Xsl.XslCompiledTransform = New System.Xml.Xsl.XslCompiledTransform()
                xslt.Load(markup.CreateReader())
                'writer.
                'writer.Settings.ConformanceLevel = System.Xml.ConformanceLevel.Fragment
                ' Execute the transform and output the results to a writer.
                xslt.Transform(x.CreateReader(), writer)
            End Using

            Return newTree.ToString

        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("JC", New With {.permilink = Permilink, .id = id}))
        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "Job Coaching"
        End Function
    End Class
End Namespace





'Function GetSelectList(ByVal SelectedValue? As Integer) As SelectList
'    Dim ddlsl As SelectList



'    Dim WorkIndependentlySL As New SelectList(WorkIndependentlyList.AsEnumerable, "Value", "Text", outcome.WorkIndependently)
'    'di("WorkIndependently") = WorkIndependentlySL
'    Dim TravelIndependentlySL As New SelectList(TravelIndependentlyList.AsEnumerable, "Value", "Text", outcome.TravelIndependently)
'    'di("TravelIndependently") = TravelIndependentlySL


'    If SelectedValue.HasValue Then
'        ddlsl = New SelectList(SelectListItems, "Value", "Text", SelectedValue)
'    Else
'        ddlsl = New SelectList(SelectListItems, "Value", "Text")
'    End If

'    Return ddlsl
'End Function


'Public Shared Function GetSelectList(ByVal outcome As Model.ProgramOutcomes.JCOutcome) As Dictionary(Of String, SelectList)
'    Dim di As New Dictionary(Of String, SelectList)


'    Dim WorkIndependentlyL As New List(Of SelectListItem)
'    Dim TravelIndependentlyL As New List(Of SelectListItem)



'    Dim WorkIndependentlyli As New SelectListItem
'    WorkIndependentlyli.Text = "Person is able to Work Independently by themselves and no longer needs coaching services"
'    WorkIndependentlyli.Value = "Developed"
'    WorkIndependentlyL.Add(WorkIndependentlyli)

'    Dim WorkIndependentlyli2 As New SelectListItem
'    WorkIndependentlyli2.Text = "Has become more independent, but still requires on site support"
'    WorkIndependentlyli2.Value = "Improved"
'    WorkIndependentlyL.Add(WorkIndependentlyli2)

'    Dim WorkIndependentlyli3 As New SelectListItem
'    WorkIndependentlyli3.Text = "Not able to work independently at site"
'    WorkIndependentlyli3.Value = "NotAble"
'    WorkIndependentlyL.Add(WorkIndependentlyli3)

'    Dim WorkIndependentlyli4 As New SelectListItem
'    WorkIndependentlyli4.Text = "Did not participate in job coaching"
'    WorkIndependentlyli4.Value = "n/a"
'    WorkIndependentlyL.Add(WorkIndependentlyli4)



'    Dim TravelIndependentlyli As New SelectListItem
'    TravelIndependentlyli.Text = "Person is able to Travel Independently and no longer needs Travel Training"
'    TravelIndependentlyli.Value = "Developed"
'    TravelIndependentlyL.Add(TravelIndependentlyli)

'    Dim TravelIndependentlyli2 As New SelectListItem
'    TravelIndependentlyli2.Text = "Has become more Independent, but still requires on Travel Training"
'    TravelIndependentlyli2.Value = "Improved"
'    TravelIndependentlyL.Add(TravelIndependentlyli2)

'    Dim TravelIndependentlyli3 As New SelectListItem
'    TravelIndependentlyli3.Text = "Not able to Travel Independently at site"
'    TravelIndependentlyli3.Value = "NotAble"
'    TravelIndependentlyL.Add(TravelIndependentlyli3)

'    Dim TravelIndependentlyli4 As New SelectListItem
'    TravelIndependentlyli4.Text = "Did not participate in Travel Training"
'    TravelIndependentlyli4.Value = "NotAble"
'    TravelIndependentlyL.Add(TravelIndependentlyli4)

'    Dim WorkIndependentlySL As New SelectList(WorkIndependentlyL.AsEnumerable, "Value", "Text", outcome.WorkIndependently)
'    di("WorkIndependently") = WorkIndependentlySL
'    Dim TravelIndependentlySL As New SelectList(TravelIndependentlyL.AsEnumerable, "Value", "Text", outcome.TravelIndependently)
'    di("TravelIndependently") = TravelIndependentlySL


'    Return di


'    'Dim s As String

'End Function


'Public Shared Function GetSelectLists(ByVal Name As String) As List(Of SelectListItem)
'    '  Dim di As New Dictionary(Of String, SelectList)
'    Dim di As New Dictionary(Of String, List(Of SelectListItem))


'    Dim WorkIndependentlyL As New List(Of SelectListItem)
'    Dim TravelIndependentlyL As New List(Of SelectListItem)



'    Dim WorkIndependentlyli As New SelectListItem
'    WorkIndependentlyli.Text = "Person is able to Work Independently by themselves and no longer needs coaching services"
'    WorkIndependentlyli.Value = "Developed"
'    WorkIndependentlyL.Add(WorkIndependentlyli)

'    Dim WorkIndependentlyli2 As New SelectListItem
'    WorkIndependentlyli2.Text = "Has become more independent, but still requires on site support"
'    WorkIndependentlyli2.Value = "Improved"
'    WorkIndependentlyL.Add(WorkIndependentlyli2)

'    Dim WorkIndependentlyli3 As New SelectListItem
'    WorkIndependentlyli3.Text = "Not able to work independently at site"
'    WorkIndependentlyli3.Value = "NotAble"
'    WorkIndependentlyL.Add(WorkIndependentlyli3)

'    Dim WorkIndependentlyli4 As New SelectListItem
'    WorkIndependentlyli4.Text = "Did not participate in job coaching"
'    WorkIndependentlyli4.Value = "n/a"
'    WorkIndependentlyL.Add(WorkIndependentlyli4)



'    Dim TravelIndependentlyli As New SelectListItem
'    TravelIndependentlyli.Text = "Person is able to Travel Independently and no longer needs Travel Training"
'    TravelIndependentlyli.Value = "Developed"
'    TravelIndependentlyL.Add(TravelIndependentlyli)

'    Dim TravelIndependentlyli2 As New SelectListItem
'    TravelIndependentlyli2.Text = "Has become more Independent, but still requires on Travel Training"
'    TravelIndependentlyli2.Value = "Improved"
'    TravelIndependentlyL.Add(TravelIndependentlyli2)

'    Dim TravelIndependentlyli3 As New SelectListItem
'    TravelIndependentlyli3.Text = "Not able to Travel Independently at site"
'    TravelIndependentlyli3.Value = "NotAble"
'    TravelIndependentlyL.Add(TravelIndependentlyli3)

'    Dim TravelIndependentlyli4 As New SelectListItem
'    TravelIndependentlyli4.Text = "Did not participate in Travel Training"
'    TravelIndependentlyli4.Value = "NotAble"
'    TravelIndependentlyL.Add(TravelIndependentlyli4)

'    'Dim WorkIndependentlySL As New SelectList(WorkIndependentlyL.AsEnumerable, "Value", "Text")
'    'di("WorkIndependently") = WorkIndependentlySL
'    'Dim TravelIndependentlySL As New SelectList(TravelIndependentlyL.AsEnumerable, "Value", "Text")
'    'di("TravelIndependently") = TravelIndependentlySL

'    '  Dim WorkIndependentlySL As New SelectList(WorkIndependentlyL.AsEnumerable, "Value", "Text", outcome.WorkIndependently)
'    di("WorkIndependently") = WorkIndependentlyL
'    'Dim TravelIndependentlySL As New SelectList(TravelIndependentlyL.AsEnumerable, "Value", "Text", outcome.TravelIndependently)
'    di("TravelIndependently") = TravelIndependentlyL


'    Return di(Name)


'    'Dim s As String

'End Function





