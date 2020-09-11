Imports System.Configuration
Imports System.Net.Mail

<HandleError()> _
Public Class Myapp
    Friend Sub New()

    End Sub
    Private Shared Function _user(Optional ByVal Overwrite As Boolean = False) As String



        If Not String.IsNullOrEmpty(HttpContext.Current.Request.QueryString("cm")) And Overwrite = True Then


            Dim cm As String = HttpContext.Current.Request.QueryString("cm")
            'Dim un As String = HttpContext.Current.User.Identity.Name
            'Dim _db As New R2kdoiMVCDataContext

            'Dim x = _db.ChkSub(un, cm)

            Return cm

        Else
            Return HttpContext.Current.User.Identity.Name
        End If



    End Function


    Public Shared Function IsUserOverwrite() As Boolean
        If String.IsNullOrEmpty(HttpContext.Current.Request.QueryString("cm")) Then
            Return False

        End If

        Return True

    End Function


    Public Shared Function Now() As Date
        Return Date.Parse(String.Format("{0}/{1}/{2}", Date.Now.Month, Date.Now.Day, Date.Now.Year))
    End Function

    Public Shared Function Now(ByVal parse As DateTime) As Date
        Return Date.Parse(String.Format("{0}/{1}/{2}", parse.Month, parse.Day, parse.Year))
    End Function

    Public Shared Function CurrentUserInfo(Optional ByVal Overwrite As Boolean = False) As Model.RegisteredUser

        Dim _db As New R2kdoiMVCDataContext


        Dim x = _db.RegisteredUsers.Where(Function(e) e.Username = _user(Overwrite) And e.Active = True)


        If x.Count = 0 Then
            Throw New Exception("User Not Found")
        End If

        Return x.First

    End Function


    Public Shared Function GetUserInfo(ByVal Username As String) As Model.RegisteredUser

        Dim _db As New R2kdoiMVCDataContext


        Dim x = _db.RegisteredUsers.Where(Function(e) e.Username = Username And e.Active = True)


        If x.Count = 0 Then
            Throw New Exception("User Not Found")
        End If

        Return x.First

    End Function

    Public Shared Function GetUserInfo(ByVal userid As Integer) As Model.RegisteredUser

        Dim _db As New R2kdoiMVCDataContext

        Dim x = _db.RegisteredUsers.Where(Function(e) e.UserId = userid And e.Active = True)

        If x.Count = 0 Then
            Throw New Exception("User Not Found")
        End If

        Return x.First

    End Function

    Public Shared Function UserId(Optional ByVal Overwrite As Boolean = False) As Integer

        Dim _db As New R2kdoiMVCDataContext

        Dim x = GetUserInfo(_user(Overwrite))

        Return x.UserId

    End Function


    Public Shared Function User(Optional ByVal Overwrite As Boolean = False) As String

        Dim _db As New R2kdoiMVCDataContext

        Dim x = GetUserInfo(_user(Overwrite))

        Return x.Username

    End Function



    Public Shared Function GetPermilink(ByVal RegistrarNo As String) As String
        Dim _db As New R2kdoiMVCDataContext
        Dim x = From a In _db.Infos Where a.RegistrarNo = RegistrarNo Select a.Permilink Take 1

        Return x.First
    End Function

    Public Shared Function GetRegistrarNo(ByVal Permilink As String) As String
        Dim _db As New R2kdoiMVCDataContext

        Return _db.GetRegistrarNoFromPermilink(Permilink)

    End Function

    Public Shared Function GetSubordinates(ByVal Userid As Integer) As IEnumerable(Of Model.RegisteredUser)

        Dim db As New R2kdoiMVCDataContext

        Return db.GetSubordinates(Userid).OrderBy(Function(e) e.Username)

    End Function

    Public Shared Function GetBillingInfoFromAuthorization(ByVal AuthorizationId As Integer) As IEnumerable(Of Model.Billing.GetBillingInfoFromAuthorizationResult)

        Dim db As New R2kDoiMvcBillingDataContext

        Return db.GetBillingInfoFromAuthorization(id:=AuthorizationId)


    End Function

    Public Shared Function GetBillingStatus(ByVal BillingID As Integer) As String
        Dim db As New R2kDoiMvcBillingDataContext



        Return db.SP_GetBillingStatus(BillingID).First.status


    End Function

    Public Shared Function Number_of_Units(ByVal service As Model.Service) As Long

        Dim db As New R2kdoiMVCDataContext

        Dim ProductId As Integer = service.ProductId

        Dim LocationId As Integer = service.Authorization.Referral.ProgramInstance.LocationId

        Dim FundingSourceId As Integer = service.Authorization.FundingCounselor.FundingSourceId

        Dim x = (From a In db.AssignFeesContainers _
                Where a.FundingSourceId = FundingSourceId _
                Select a.FeeSchedualId).ToList

        Dim fe = (From b In db.Fees _
                 Where b.LocationId = LocationId And b.ProductId = ProductId And x.Contains(b.MainId) _
                 Select b Take 1).Single


        If fe.UnitTypeId = 2 Then




        ElseIf fe.UnitTypeId = 1 Then




        End If







    End Function

    Public Shared Function GetUnitType(ByVal AuthorizationID As Integer, ByVal ProductId As Integer) As Model.UnitType


        Dim db As New R2kdoiMVCDataContext

        Dim authorization = db.Authorizations.Single(Function(e) e.AuthorizationID = AuthorizationID)

        Dim unitPrices = From a In db.Fees _
                         Where a.LocationId = authorization.Referral.ProgramInstance.LocationId And a.ProductId = ProductId And (a.Main.AssignFeesContainers.Any(Function(e) e.FundingSourceId = authorization.FundingCounselor.FundingSourceId)) _
                         Select a.UnitType


        If unitPrices.Count = 0 Then
            Throw New Exception("Unit Price Not Found")
        End If

        Return unitPrices.First



    End Function

    Public Shared Function AddNote(ByVal RegistrarNo As String, ByVal Subject As String, ByVal Note As String)
        Return AddNote(RegistrarNo, Subject, Note, New IO.DirectoryInfo(Myapp.GetAttachmentTempPath))
    End Function
    Public Shared Function AddNote(ByVal RegistrarNo As String, ByVal Subject As String, ByVal Note As String, ByVal directory As IO.DirectoryInfo) As Integer
        Return AddNote(RegistrarNo, Subject, Note, HttpContext.Current.Request.UrlReferrer.AbsolutePath, directory)
    End Function
    Public Shared Function AddNote(ByVal RegistrarNo As String, ByVal Subject As String, ByVal Note As String, ByVal Link As String, ByVal directory As IO.DirectoryInfo) As Integer


        Dim _note As New Model.note

        _note.RegistrarNo = RegistrarNo
        _note.Subject = Subject


        _note.Note = Note

        _note.Link = Link
        _note.InputedBy = Myapp.UserId
        _note.ED = Date.Now
        _note.UD = Date.Now

        Return AddNote(_note, directory)
    End Function
    Public Shared Function AddNote(ByVal NewNote As Model.note, ByVal directory As IO.DirectoryInfo) As Integer
        Dim db As New R2kdoiMVCDataContext
        Dim noters As New NotesRepository
        noters.Add(NewNote)
        noters.Save()


        For Each f In directory.GetFiles()

            If noters.AddAttachment(NewNote.NoteId, f) Then
                Dim path = f.FullName

                System.IO.File.Delete(path)
            End If

        Next

        Return NewNote.NoteId
    End Function

    Public Shared Function GetAttachmentTempPath(Optional ByVal override As Boolean = False)



        'If Not System.IO.Directory.Exists(ConfigurationManager.AppSettings("AttachmentTempPath")) Then
        '    System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings("AttachmentTempPath"))
        'End If

        Dim PATH As String = String.Format(ConfigurationManager.AppSettings("AttachmentTempPath"), Myapp.User(override))

        If Not System.IO.Directory.Exists(PATH) Then
            System.IO.Directory.CreateDirectory(PATH)
        End If

        Return String.Format(String.Format(ConfigurationManager.AppSettings("AttachmentTempPath"), Myapp.User(override)))
    End Function


    Public Shared Function GetAttachmentTempPath(ByVal type As String, ByVal id As Integer)

        Dim root As String = GetAttachmentTempPath()

        Dim path As String = String.Format("{0}\{1}_{2}", root, type, id)

        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        Return path 'String.Format(ConfigurationManager.AppSettings("AttachmentTempPath"), Myapp.user)
    End Function

    Public Shared Function GetAttachmentTempPath(ByVal type As String, ByVal id As Integer, ByVal overright As Boolean)

        Dim root As String = GetAttachmentTempPath(overright)

        Dim path As String = String.Format("{0}\{1}_{2}", root, type, id)

        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        Return path 'String.Format(ConfigurationManager.AppSettings("AttachmentTempPath"), Myapp.user)
    End Function


    Public Const VOID As String = "Voided"
    Public Const BILLED As String = "Billed"
    Public Const ACCEPTED As String = "Accepted"
    Public Const ACCRUED As String = "Accrued"
    Public Const APPROVED As String = "Approved"

    Public Const VOIDID As Integer = 8
    Public Const BILLEDID As Integer = 5
    Public Const ACCEPTEDID As Integer = 7
    Public Const ACCRUEDID As Integer = 4
    Public Const APPROVEDID As Integer = 9

    Public Shared Function GetPoType(ByVal podata As XElement) As String
        Return podata.@type
    End Function

    Public Shared Function BuildUri() As UrlHelper
        Dim ctx = New HttpContextWrapper(HttpContext.Current)
        Dim helper As New UrlHelper(New RequestContext(ctx, RouteTable.Routes.GetRouteData(ctx)))

        Return helper

    End Function

    Public Shared Function ManualBill(ByVal service As Model.Service, ByVal NumberOfUnits As Decimal, ByVal UnitPrice As Decimal, ByVal ServiceStartDate As Date, ByVal ServiceEndDate As Date) As Model.Billing.Billing

        Dim dc As New R2kDoiMvcBillingDataContext
        Dim rep As New Repository

        If Not service.Authorization.ApproveById.HasValue Then
            Throw New AuthorizationNotApprovedException(service)
        End If

        If ServiceStartDate < service.SchedualStartDate Then
            Throw New ServiceStartDateLessThanSchedualStartDateException(service)
        End If

        If ServiceEndDate > service.SchedualEndDate Then
            Throw New ServiceEndDateGreaterThanSchedualEndDateException(service)
        End If

        If NumberOfUnits = 0 Then
            Throw New Exception("Number of Units Can't be zero.")
        End If

        Dim newBilling = dc.ManualBill(service.ServiceId, service.ProductId, NumberOfUnits, UnitPrice, ServiceStartDate, ServiceEndDate, Myapp.UserId)

        Return rep.GetBilling(newBilling)

    End Function

    Public Shared Function GetAMPM() As SelectList
        Dim am As New SelectListItem
        am.Value = "AM"
        am.Text = "AM"

        Dim pm As New SelectListItem
        pm.Value = "PM"
        pm.Text = "PM"


        Dim l As New List(Of SelectListItem)

        l.Add(am)
        l.Add(pm)

        Return New SelectList(l.AsEnumerable, "value", "text", am)


    End Function

    Public Shared Function getString(ByVal xdoc As XDocument) As String


        Dim ms As New IO.MemoryStream
        Dim settings As New System.Xml.XmlWriterSettings

        settings.Encoding = System.Text.Encoding.UTF8
        settings.ConformanceLevel = System.Xml.ConformanceLevel.Document
        settings.Indent = True

        Dim xmlwriter As System.Xml.XmlWriter = System.Xml.XmlTextWriter.Create(ms, settings)

        xdoc.Save(xmlwriter)
        xmlwriter.Flush()
        Dim sr As New IO.StreamReader(ms)
        ms.Seek(0, IO.SeekOrigin.Begin)
        Dim doctext As String = sr.ReadToEnd

        xmlwriter.Close()
        sr.Close()
        ms.Close()

        ms.Dispose()
        sr.Dispose()


        xmlwriter = Nothing
        ms = Nothing
        sr = Nothing


        Return doctext

    End Function

    Public Shared Sub SendMail(ByVal MailTo As String, ByVal Subject As String, ByVal Body As String)
        SendMail(New MailAddress(MailTo), Subject, Body)

    End Sub

    Public Shared Sub SendMail(ByVal MailTo As MailAddress, ByVal Subject As String, ByVal Body As String)
        Dim MailFrom As New MailAddress("Webistrar@vgsjob.org")

        Dim message As New MailMessage(MailFrom, MailTo)


        message.Subject = Subject


        message.IsBodyHtml = True

        message.Body = Body
        Dim client As New SmtpClient(ConfigurationSettings.AppSettings("SmtpServer"))

        client.Send(message)


    End Sub

    Public Shared Function ReadText(ByVal TextFilePath As String) As String
        Using ReadStream As System.IO.FileStream = System.IO.File.OpenRead(TextFilePath)
            Dim FileTextBuilder As New StringBuilder()
            Dim DataTransit As Byte() = New Byte(ReadStream.Length) {}
            Dim DataEncoding As New UTF8Encoding(True)
            While ReadStream.Read(DataTransit, 0, DataTransit.Length) > 0
                FileTextBuilder.Append(DataEncoding.GetString(DataTransit))
            End While
            ReadStream.Close()
            ReadStream.Dispose()
            DataTransit = Nothing

            Return FileTextBuilder.ToString()
        End Using
    End Function

    Public Shared Function GetServerPath()

        Dim sname = HttpContext.Current.Request.Url.Host
        Dim port = HttpContext.Current.Request.Url.Port
        Dim apppath = HttpContext.Current.Request.ApplicationPath
        apppath = IIf(apppath = "/", "", apppath)

        Dim sb As New StringBuilder

        sb.Append(HttpContext.Current.Request.Url.Scheme.ToString)
        sb.Append("://")
        sb.Append(sname)
        If Not HttpContext.Current.Request.Url.IsDefaultPort Then
            sb.AppendFormat(":{0}", port)
        End If

        sb.AppendFormat("{0}", apppath)

        Return sb.ToString
        'If port = 80 Or port = 443 Then
        '    Return String.Format("http://{0}{2}/", sname, port, apppath)
        'Else
        '    Return String.Format("http://{0}:{1}{2}/", sname, port, apppath)
        'End If

    End Function

    Public Shared Function GetDefaultPath(ByVal Permilink) As String
        Dim DefaultPath As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Info", .action = "Details", .Permilink = Permilink})
        Return DefaultPath

    End Function

    Public Shared Function ConsumerLink(ByVal Permilink As String, ByVal Name As String) As String
        Dim serverpath As String = Myapp.GetServerPath

        Dim conpath As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Info", .action = "Details", .Permilink = Permilink})

        Return String.Format("<a href='{0}{1}' class='showprintinline'>{2}</a>", serverpath, conpath, Name)

        
    End Function

    Public Shared Function ConsumerLink(ByVal Permilink As String, ByVal FirstName As String, ByVal lastname As String) As String

        Return ConsumerLink(Permilink, String.Format("{0} {1}", FirstName, lastname))

    End Function

    Public Shared Function ConsumerMISCLink(ByVal Permilink As String, ByVal FirstName As String, ByVal lastname As String) As String
        Dim serverpath As String = Myapp.GetServerPath
        Dim conpath As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Info", .action = "Misc", .Permilink = Permilink})

        Dim rs As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Info", .action = "Details", .Permilink = Permilink})


        Return String.Format("<a href='{0}{1}?rs={2}' class='showprintinline'>Return to Discripter</a>", serverpath, conpath, rs)

        'Return String.Format("<a href='/R2kdoiMVC2/Consumer/{0}/'>{1} {2}</a>", info.Permilink, info.FirstName, info.LastName)

    End Function

    Public Shared Function IsDebug() As Boolean

        If Myapp.Settings("IsDebug") = "Yes" Then
            Return True
        End If

        Return False
    End Function



    Public Shared Function Settings(ByVal Label As String) As String

        Return System.Configuration.ConfigurationManager.AppSettings(Label)
    End Function

    Public Shared Function HasAlert() As Boolean
        Dim db As New R2kdoiMVCDataContext


        If db.HasAlert(Myapp.UserId()) = 1 Then
            Return True
        Else
            Return False
        End If


    End Function

    Public Shared Function SetAlert(ByVal toid As Integer, ByVal subject As String, ByVal message As String, ByVal link As String) As Boolean
        Dim db As New R2kdoiMVCDataContext

        If db.SetAlert(Settings("AlertFromId"), toid, subject, message, link) = 1 Then
            Return True
        End If
    End Function

    Public Shared Function LocalPath() As String

        Return HttpContext.Current.Server.MapPath("\")
    End Function

    Public Shared Function LocalPath(ByVal Filename As String) As String

        Return HttpContext.Current.Server.MapPath("\") & Filename
    End Function

End Class

Public Class Repository

End Class

Public Class FileUploadJsonResult
    Inherits JsonResult

    Public Overrides Sub ExecuteResult(ByVal context As System.Web.Mvc.ControllerContext)

        Me.ContentType = "text/html"
        context.HttpContext.Response.Write("<textarea>")
        MyBase.ExecuteResult(context)
        context.HttpContext.Response.Write("</textarea>")

    End Sub
End Class


