Namespace Model.Attendance
    Partial Class Attendance



        Function GetDate() As DateTime

            Return Myapp.Now(Me.Clock)
        End Function

        Function SetDate(ByVal theDate As DateTime, ByVal hour As Integer, ByVal min As Integer, ByVal half As String) As DateTime

            Dim sDate = String.Format("{0}/{1}/{2} {3}:{4}:00 {5}", theDate.Month, theDate.Day, theDate.Year, hour, min, half)
            Me.Clock = DateTime.Parse(sDate)

        End Function


    End Class
End Namespace

Namespace Model
    Partial Class ServiceAttendance




        Function GetDate() As DateTime

            Return Myapp.Now(Me.Clock)
        End Function

        Function SetDate(ByVal theDate As DateTime, ByVal hour As Integer, ByVal min As Integer, ByVal half As String) As DateTime

            Dim sDate = String.Format("{0}/{1}/{2} {3}:{4}:00 {5}", theDate.Month, theDate.Day, theDate.Year, hour, min, half)
            Me.Clock = DateTime.Parse(sDate)

        End Function



    End Class
End Namespace