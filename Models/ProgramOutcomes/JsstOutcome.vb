Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports <xmlns="urn:vgs:jsst">
Namespace Model.ProgramOutcomes
    Public Class JsstOutcome
        Implements iProgramOutcome

        Private _Permilink As String
        Private _id As Integer

        Private _FollowingInstructions As Integer
        Private _JobSearchTechniques As Integer
        Private _TransferrableSkills As Integer
        Private _Assignment As Integer
        Private _Application As Integer
        Private _Resume As Integer
        Private _CoverLetter As Integer
        Private _Interviewing As Integer
        Private _Etiquette As Integer

        Private _CompletedBy As String
        Private _ed As String

        Public Property Following() As Integer
            Get
                Return _FollowingInstructions
            End Get
            Set(ByVal value As Integer)
                _FollowingInstructions = value
            End Set
        End Property

        Public Property JobSearch() As Integer
            Get
                Return _JobSearchTechniques
            End Get
            Set(ByVal value As Integer)
                _JobSearchTechniques = value
            End Set
        End Property

        Public Property TransferrableSkills() As Integer
            Get
                Return _TransferrableSkills
            End Get
            Set(ByVal value As Integer)
                _TransferrableSkills = value
            End Set
        End Property




        Public Property Assignments() As Integer
            Get
                Return _Assignment
            End Get
            Set(ByVal value As Integer)
                _Assignment = value
            End Set
        End Property

        Public Property Applications() As Integer
            Get
                Return _Application
            End Get
            Set(ByVal value As Integer)
                _Application = value
            End Set
        End Property

        Public Property Resumes() As Integer
            Get
                Return _Resume
            End Get
            Set(ByVal value As Integer)
                _Resume = value
            End Set
        End Property

        Public Property CoverLetter() As Integer
            Get
                Return _CoverLetter
            End Get
            Set(ByVal value As Integer)
                _CoverLetter = value
            End Set
        End Property

        Public Property Interviewing() As Integer
            Get
                Return _Interviewing
            End Get
            Set(ByVal value As Integer)
                _Interviewing = value
            End Set
        End Property

        Public Property Etiquette() As Integer
            Get
                Return _Etiquette
            End Get
            Set(ByVal value As Integer)
                _Etiquette = value
            End Set
        End Property

        Public Sub ReadXml(ByVal xmldata As XElement) Implements iProgramOutcome.ReadXml


            _CompletedBy = xmldata.@CompletedBy
            _ed = xmldata.@ed
            Me.Following = xmldata.<FollowInstructions>.Value
            Me.JobSearch = xmldata.<JobSearchTechniques>.Value
            Me.TransferrableSkills = xmldata.<TransferrableSkills>.Value
            Me.Assignments = xmldata.<Assignment>.Value
            Me.Applications = xmldata.<Application>.Value
            Me.Resumes = xmldata.<Resume>.Value
            Me.CoverLetter = xmldata.<CoverLetter>.Value
            Me.Interviewing = xmldata.<Interviewing>.Value
            Me.Etiquette = xmldata.<Etiquette>.Value

        End Sub
        Public Function toXml(ByVal CompletedBy As String) As XElement Implements iProgramOutcome.toXml
            Dim x = <ProgramOutcome xmlns="urn:vgs:jsst" CompletedBy=<%= CompletedBy %> type='js' ed=<%= Date.Now.ToShortDateString %> version='1.0'>
                        <FollowInstructions><%= _FollowingInstructions %></FollowInstructions>
                        <JobSearchTechniques><%= _JobSearchTechniques %></JobSearchTechniques>
                        <TransferrableSkills><%= _TransferrableSkills %></TransferrableSkills>
                        <Assignment><%= _Assignment %></Assignment>
                        <Application><%= _Application %></Application>
                        <Resume><%= _Resume %></Resume>
                        <CoverLetter><%= _CoverLetter %></CoverLetter>
                        <Interviewing><%= _Interviewing %></Interviewing>
                        <Etiquette><%= _Etiquette %></Etiquette>
                    </ProgramOutcome>




            Return x
        End Function






        'Public Function toHtml(ByVal permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.toHtml

        '    Dim edit = 

        '    Dim header = <h3><a href="#"></a></h3>

        '    _Permilink = permilink
        '    _id = iid


        '    Dim s = header.ToString & output.ToString

        '    Return s

        'End Function

        ReadOnly Property SelectListItems() As List(Of SelectListItem)
            Get
                Dim ddL As New List(Of SelectListItem)

                Dim ns As New SelectListItem With {.Value = 0, .Text = "Not Selected"}
                Dim ua As New SelectListItem With {.Value = 1, .Text = "Unacceptable"}
                Dim ni As New SelectListItem With {.Value = 2, .Text = "Needs Much To Improve"}
                Dim nsi As New SelectListItem With {.Value = 3, .Text = "Needs Some Improvement"}
                Dim ac As New SelectListItem With {.Value = 4, .Text = "Adequate For Competition"}
                Dim os As New SelectListItem With {.Value = 5, .Text = "Outstanding"}

                ddL.Add(ns)
                ddL.Add(ua)
                ddL.Add(ni)
                ddL.Add(nsi)
                ddL.Add(ac)
                ddL.Add(os)

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
                             <p><strong>Following Instructions </strong><span><%= (From a In SelectListItems Where a.Value = Following Select a.Text).Single %></span></p>
                             <p><strong>Job Search </strong><span><%= (From a In SelectListItems Where a.Value = JobSearch Select a.Text).Single %></span></p>
                             <p><strong>Transferrable Skills </strong><span><%= (From a In SelectListItems Where a.Value = TransferrableSkills Select a.Text).Single %></span></p>
                             <p><strong>Assignments </strong><span><%= (From a In SelectListItems Where a.Value = Assignments Select a.Text).Single %></span></p>
                             <p><strong>Applications </strong><span><%= (From a In SelectListItems Where a.Value = Applications Select a.Text).Single %></span></p>
                             <p><strong>Resumes </strong><span><%= (From a In SelectListItems Where a.Value = Resumes Select a.Text).Single %></span></p>
                             <p><strong>CoverLetter </strong><span><%= (From a In SelectListItems Where a.Value = CoverLetter Select a.Text).Single %></span></p>
                             <p><strong>Interviewing </strong><span><%= (From a In SelectListItems Where a.Value = Interviewing Select a.Text).Single %></span></p>
                             <p><strong>Etiquette </strong><span><%= (From a In SelectListItems Where a.Value = Etiquette Select a.Text).Single %></span></p>
                         </div>

            Return output.ToString

        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "JSST"
        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("jsst", New With {.permilink = Permilink, .id = id}))
        End Function
    End Class
End Namespace
