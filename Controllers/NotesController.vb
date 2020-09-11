<Authorize()> _
<HandleError()> _
Public Class NotesController
    Inherits System.Web.Mvc.Controller

    Private _db As NotesRepository


    Sub New()
        _db = New NotesRepository
    End Sub

    ''
    '' GET: /Notes/
    '<Authorize(Roles:="NotesView")> _
    'Function Index(ByVal Permilink As String) As ActionResult


    '    Dim notes = _db.GetInfo(Permilink)






    '    Return View(notes)
    'End Function



    ' GET: /Notes/
    <Authorize(Roles:="NotesView")> _
    Function Index(ByVal Permilink As String) As ActionResult

        Dim userinfo = _db.GetInfo(Permilink)
        ViewData("LastName") = userinfo.LastName
        ViewData("FirstName") = userinfo.FirstName
        ViewData("Permilink") = userinfo.Permilink
        ViewData("Consumer") = userinfo



        Return View(userinfo.Notes)
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    <Authorize(Roles:="NotesView")> _
    Function Index(ByVal Permilink As String, ByVal collection As FormCollection) As ActionResult
        Dim userinfo = _db.GetInfo(Permilink)
        ViewData("Permilink") = userinfo.Permilink
        ViewData("Consumer") = userinfo

        Dim notes As System.Linq.IQueryable(Of Model.note) = _db.GetAllNotes.Where(Function(e) e.Info.Permilink = Permilink)

        Dim ShowOnlyMine As String = collection("ShowOnlyMine").Replace("true,false", "true")

        If ShowOnlyMine = "true" Then
            notes = notes.Where(Function(e) e.InputedBy = Myapp.UserId)
        End If

        Return View(notes)
    End Function

    '
    ' GET: /Notes/Details/5
    <Authorize(Roles:="NotesView")> _
    Function Details(ByVal id As Integer) As ActionResult
        Return View(_db.GetNote(id))
    End Function

    '
    ' GET: /Notes/Create
    <Authorize(Roles:="NotesCreate")> _
    Function Create(ByVal Permilink As String, ByVal title As String) As ActionResult
        Dim link As String
        Dim note As Model.note
        If Request.UrlReferrer Is Nothing Then
            link = Myapp.GetDefaultPath(Permilink)
        Else
            link = Request.UrlReferrer.AbsolutePath
        End If

        'Dim notes = From a In _db.GetAllNotes _
        '            Where a.Link = link And a.status = Model.note.Statuses.Draft _
        '            Select a

        'If notes.Count = 1 Then
        '    note = notes.First
        'Else
        '    note = New Model.note
        '    note.status = Model.note.Statuses.Draft

        'End If

        ViewData("Link") = link

        If String.IsNullOrEmpty(title) Then
            ViewData("Subject") = "General"
        Else
            ViewData("Subject") = title
        End If

        Dim d As New System.IO.DirectoryInfo(Myapp.GetAttachmentTempPath)

        Dim x = <ul id="filelist">
                    <%= From a In d.GetFiles _
                        Select <li><%= System.IO.Path.GetFileName(a.FullName) %></li> %>
                </ul>

        ViewData("filelist") = x.ToString

        Return View()
    End Function

    '
    ' POST: /Notes/Create
    <Authorize(Roles:="NotesCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal Permilink As String, ByVal title As String, ByVal nnote As Model.note) As ActionResult


        nnote.RegistrarNo = Myapp.GetRegistrarNo(Permilink)

        nnote.InputedBy = Myapp.UserId

        nnote.ED = Date.Now

        nnote.UD = Date.Now

        If Not Trim(nnote.Note) = String.Empty Then


            _db.Add(nnote)


            For Each f In System.IO.Directory.GetFiles(Myapp.GetAttachmentTempPath)
                Dim fi As New IO.FileInfo(f)

                If _db.AddAttachment(nnote.NoteId, fi) Then

                    fi = Nothing
                    System.IO.File.Delete(f)
                End If

            Next

        End If

        Return Redirect(nnote.Link)
    End Function

    <Authorize(Roles:="NotesInActive")> _
    Function Inactive(ByVal permilink As String, ByVal id As Integer) As ActionResult
        Dim x = _db.GetNote(id)
        Return View(x)
    End Function

    <Authorize(Roles:="NotesInActive")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Inactive(ByVal permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here

            Dim x = _db.GetNote(id)

            x.UD = Date.Now

            x.InActive = True
            _db.Save()

            Return RedirectToAction("Index", New With {.permilink = permilink})
        Catch

            Return View()
        End Try
    End Function


    Function SubjectList(ByVal value As String) As SelectList

        Dim subject As New List(Of String)

        subject.Add("General")
        
        If Not subject.Contains(value) Then
            subject.Insert(0, value)
        Else
            subject.Remove(value)
            subject.Insert(0, value)
        End If

        Return New SelectList(subject)

    End Function
    <Authorize(Roles:="NotesCreate")> _
    Function AjaxUpload(ByVal file As HttpPostedFileBase)

        Dim f As New FileUploadJsonResult

        Dim newpath As String = String.Format("{0}\{1}", Myapp.GetAttachmentTempPath, System.IO.Path.GetFileName(file.FileName))

        file.SaveAs(newpath)

        f.Data = New With {.fname = System.IO.Path.GetFileName(file.FileName), .filename = String.Format("<li>{0}</li>", System.IO.Path.GetFileName(file.FileName)), .message = String.Format("{0} uploaded successfully", System.IO.Path.GetFileName(file.FileName))}

        Return f
    End Function

    <HandleError()> _
    <Authorize(Roles:="NotesView")> _
    Function GetAttachments(ByVal id As Integer, ByVal filename As String) As FileContentResult

        Dim note = _db.GetNote(id)


        Dim files = note.Attachments.Where(Function(e) e.FileName = filename)

        If files.Count = 0 Then
            Throw New IO.FileNotFoundException(filename:=filename, message:="Not Found")
        End If

        Return File(files.First.metadata.ToArray, files.First.mimtype, files.First.FileName)
    End Function


    Function PurgeBuffer()

        Dim r As String
        Try
            For Each f In System.IO.Directory.GetFiles(Myapp.GetAttachmentTempPath)
                System.IO.File.Delete(f)

            Next
            r = Myapp.GetAttachmentTempPath
        Catch ex As Exception
            r = ex.Message
        End Try
        Return r


    End Function

    Function BrowserClose() As JsonResult
        Dim re = New With {.result = PurgeBuffer()}


        Dim jr As New JsonResult
        jr.Data = re

        Return jr

    End Function
End Class
