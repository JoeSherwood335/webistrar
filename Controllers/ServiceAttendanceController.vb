'Public Class ServiceAttendanceController
'    Inherits System.Web.Mvc.Controller

'    Private main As R2kdoiMVCDataContext

'    Sub New()

'        main = New R2kdoiMVCDataContext

'    End Sub

'    <Authorize()> _
'    Function Index(ByVal ServiceID As DateTime) As ActionResult

'        '  main.ServiceAttendances




'    End Function


'    <Authorize()> _
'    Function Program(ByVal ServiceID As Integer, ByVal Year As Integer, ByVal month As Integer, ByVal day As Integer) As ActionResult









'        Dim DateOfAttendance = DateTime.Parse(String.Format("{0}/{1}/{2}", month, day, Year))
'        Dim DateOfAttendanceEnd = DateTime.Parse(String.Format("{0}/{1}/{2} 23:59:59", month, day, Year))

'        Dim li = From a In Attendance.Infos _
'                 Select New AttendanceLineClass With { _
'                                  .name = String.Format("{0} {1}", a.FirstName, a.LastName), _
'                                  .rn = a.RegistrarNo, _
'                                  .start = (Aggregate b In Attendance.Attendances Where b.RegistrarNo = a.RegistrarNo And b.AttendanceTypeId = 1 And (b.Clock >= DateOfAttendance And b.Clock <= DateOfAttendanceEnd) Into Max(b.Clock)), _
'                                  .LunchOut = (Aggregate b In Attendance.Attendances Where b.RegistrarNo = a.RegistrarNo And b.AttendanceTypeId = 2 And (b.Clock >= DateOfAttendance And b.Clock <= DateOfAttendanceEnd) Into Max(b.Clock)), _
'                                  .LunchIn = (Aggregate b In Attendance.Attendances Where b.RegistrarNo = a.RegistrarNo And b.AttendanceTypeId = 3 And (b.Clock >= DateOfAttendance And b.Clock <= DateOfAttendanceEnd) Into Max(b.Clock)), _
'                                  .EndOfDay = (Aggregate b In Attendance.Attendances Where b.RegistrarNo = a.RegistrarNo And b.AttendanceTypeId = 4 And (b.Clock >= DateOfAttendance And b.Clock <= DateOfAttendanceEnd) Into Max(b.Clock)), _
'                                  .Instance = (From x In Attendance.ProgramInstances Where x.id = ServiceID Select x).Single _
'                                  }


'        Return View(li)

'    End Function

'    '
'    ' GET: /Attendances/Details/5

'    Function Details(ByVal id As Integer) As ActionResult
'        Return View()
'    End Function




'    Function Create(ByVal rn As Integer, ByVal id As Integer, ByVal Year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal atype As Integer) As ActionResult


'        Return View()
'    End Function

'    <AcceptVerbs(HttpVerbs.Post)> _
'    Function Create(ByVal rn As String, ByVal ServcieId As Integer, ByVal Year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal atype As Integer, ByVal collection As FormCollection) As ActionResult


'        Dim DateOfAttendance = DateTime.Parse(String.Format("{0}/{1}/{2}", month, day, Year))
'        Dim DateOfAttendanceEnd = DateTime.Parse(String.Format("{0}/{1}/{2} 23:59:59", month, day, Year))

'        Dim newAttendance = New Model.ServiceAttendance '.Attendance.Attendance





'        newAttendance.RegistrarNo = rn
'        newAttendance.ServiceId = ServcieId
'        newAttendance.InputedBy = Myapp.UserId
'        newAttendance.AttendanceTypeId = atype
'        newAttendance.Ed = Date.Now
'        newAttendance.SetDate(DateOfAttendance, collection("hour"), collection("min"), collection("half"))

'        main.ServiceAttendances.InsertOnSubmit(newAttendance)


'        If atype > 1 Then

'            Dim x = From a In main.ServiceAttendances _
'                    Where a.AttendanceTypeId < atype And a.RegistrarNo = rn And a.Clock >= DateOfAttendance And a.Clock < DateOfAttendanceEnd _
'                    Select a.Clock

'            If x.Count >= 1 Then

'                If x.First > newAttendance.Clock Then
'                    Throw New ServcieAttendanceLessThenPreviousException(newAttendance)
'                End If
'            End If

'        End If


'        main.SubmitChanges()


'        Return RedirectToAction("Details", "Services")
'    End Function
'    Function Edit(ByVal rn As Integer, ByVal id As Integer, ByVal Year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal atype As Integer) As ActionResult


'        Dim DateOfAttendance = DateTime.Parse(String.Format("{0}/{1}/{2}", month, day, Year))
'        Dim DateOfAttendanceEnd = DateTime.Parse(String.Format("{0}/{1}/{2} 23:59:59", month, day, Year))

'        Dim x = From a In Attendance.Attendances _
'                Where a.AttendanceTypeId = atype And a.Clock.Day = day And a.Clock.Month = month And a.Clock.Year = Year And a.ProgramInstanceId = id And a.RegistrarNo = rn _
'                Select a


'        If x.Count = 0 Then
'            Throw New RecordNotFoundException(id, "Attendance")
'        End If

'        Dim att = x.First


'        Select Case att.Clock.Hour
'            Case 0
'                ViewData("hour") = 12
'                ViewData("half") = "AM"
'            Case 1 To 11
'                ViewData("hour") = x.First.Clock.Hour
'                ViewData("half") = "AM"
'            Case 12
'                ViewData("hour") = x.First.Clock.Hour
'                ViewData("half") = "PM"
'            Case 13 To 23
'                ViewData("hour") = x.First.Clock.Hour - 12
'                ViewData("half") = "PM"
'        End Select

'        ViewData("min") = x.First.Clock.Minute

'        Select Case att.Clock.Minute
'            Case 0 To 9
'                ViewData("min") = "0" & CStr(att.Clock.Minute)
'            Case Else
'                ViewData("min") = att.Clock.Minute
'        End Select


'        Return View(x.First)
'    End Function

'    '
'    ' POST: /Attendances/Edit/5

'    <AcceptVerbs(HttpVerbs.Post)> _
'    Function Edit(ByVal rn As Integer, ByVal id As Integer, ByVal Year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal atype As Integer, ByVal collection As FormCollection) As ActionResult


'        Dim DateOfAttendance = DateTime.Parse(String.Format("{0}/{1}/{2}", month, day, Year))
'        Dim DateOfAttendanceEnd = DateTime.Parse(String.Format("{0}/{1}/{2} 23:59:59", month, day, Year))


'        Dim x = From a In Attendance.Attendances _
'                Where a.AttendanceTypeId = atype And a.Clock.Day = day And a.Clock.Month = month And a.Clock.Year = Year And a.ProgramInstanceId = id And a.RegistrarNo = rn _
'                Select a


'        If x.Count = 0 Then
'            Throw New RecordNotFoundException(id, "Attendance")
'        End If

'        Dim att = x.First



'        att.SetDate(DateOfAttendance, Collection("hour"), Collection("min"), Collection("half"))


'        If atype > 1 Then

'            Dim b = From a In Attendance.Attendances _
'                    Where a.AttendanceTypeId = atype - 1 And a.RegistrarNo = rn And a.Clock >= DateOfAttendance And a.Clock < DateOfAttendanceEnd _
'                    Select a.Clock

'            If b.Count >= 1 Then
'                If b.First > att.Clock Then
'                    Throw New AttendanceLessThenPreviousException(att)
'                End If
'            End If
'        End If


'        Attendance.SubmitChanges()

'        Return RedirectToAction("program", New With {.id = id, .year = Year, .month = month, .day = day})
'    End Function

'    <AcceptVerbs(HttpVerbs.Post)> _
'    Function Delete(ByVal id As Integer, ByVal Year As Integer, ByVal month As Integer, ByVal day As Integer)
'        Dim x = From a In Attendance.Attendances _
'                Where a.AttendanceId = id _
'                Select a

'        Dim pid = x.First.ProgramInstanceId
'        Attendance.Attendances.DeleteAllOnSubmit(x)


'        Attendance.SubmitChanges()
'        Return RedirectToAction("program", New With {.id = pid, .year = Year, .month = month, .day = day})
'    End Function


'End Class
