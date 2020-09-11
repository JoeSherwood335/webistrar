Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iNotesRepository

    Property SelectList(ByVal Name As String) As SelectList

    Sub Save()

    Sub SelectListforCreate()

    Sub Add(ByRef newNote As Model.Note)

    Function GetNote(ByVal NoteId As Integer) As Model.Note

    Function GetAllNotes() As IQueryable(Of Model.Note)
    Function GetInfo(ByVal Permilink As String) As Model.Info

End Interface

Public Class NotesRepository
    Implements iNotesRepository

    Private _db As R2kdoiMVCDataContext
    Private _selectlist As Dictionary(Of String, SelectList)

    Sub New()
        _db = New R2kdoiMVCDataContext
        _selectlist = New Dictionary(Of String, SelectList)
    End Sub

    Public Sub Add(ByRef newNote As Model.Note) Implements iNotesRepository.Add
        newNote.InActive = False
        _db.Notes.InsertOnSubmit(newNote)
        _db.SubmitChanges()
    End Sub




    Public Function AddAttachment(ByVal NoteId As Integer, ByVal file As IO.FileInfo) As Boolean
   
        Dim buffer() As Byte

        Try
            Dim fs As New System.IO.FileStream(file.FullName, IO.FileMode.Open)
            Dim br As New IO.BinaryReader(fs)
            Dim total As Integer = file.Length
            buffer = br.ReadBytes(total)
            br.Close()
            fs.Close()
            fs.Dispose()


            Dim Linqbuffer As New System.Data.Linq.Binary(buffer)
            _db.AddAttachment(NoteId, file.Name, Linqbuffer, file.Extension.Replace(".", ""), "", total)
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try


    End Function

    Public Function GetInfo(ByVal permilink As String) As Model.Info Implements iNotesRepository.GetInfo
        Return _db.Infos.Single(Function(e) e.Permilink = permilink)

    End Function

    Public Function GetAllNotes() As System.Linq.IQueryable(Of Model.note) Implements iNotesRepository.GetAllNotes
        Return _db.Notes
    End Function

    Public Function GetNote(ByVal NoteId As Integer) As Model.note Implements iNotesRepository.GetNote

        Dim x = _db.Notes.Where(Function(e) e.NoteId = NoteId)

        If x.Count = 0 Then
            Throw New RecordNotFoundException(NoteId, "Notes")
        End If

        Return x.First
    End Function

    Public Function GetNoteByReferral(ByVal url) As String

    End Function


    Public Sub Save() Implements iNotesRepository.Save
        _db.SubmitChanges()
    End Sub

    Public Property SelectList(ByVal Name As String) As System.Web.Mvc.SelectList Implements iNotesRepository.SelectList
        Get
            Return _selectlist(Name)
        End Get
        Set(ByVal value As System.Web.Mvc.SelectList)
            _selectlist(Name) = value
        End Set
    End Property

    Public Sub SelectListforCreate() Implements iNotesRepository.SelectListforCreate

    End Sub
    Private Sub SelectListforEdit(ByVal note As Model.note)

    End Sub
End Class
