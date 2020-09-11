Public Class SherwoodController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Sherwood/

    Function Index() As ActionResult
        Return View()
    End Function

    Function InfoPathUpload(ByVal ReferralId As String) As ActionResult
        Dim db As New R2kdoiMVCDataContext

        Dim x = From a In db.Referrals Where a.ReferralId = ReferralId



        Return View(x.First)
    End Function

    Function Save(ByVal FullName As String, ByVal poID As String)

        'Dim f As IO.FileInfo = New IO.FileInfo(FileName)
        Dim _db As New R2kdoiMVCDataContext


        Dim t As New IO.StreamReader(FullName)

        Dim s As String = t.ReadToEnd

        '_db.AddInfopathtoProgramOutcome()
        s = s.Replace("encoding=""UTF-8""", "")
        _db.AddInfopathtoProgramOutcome(s, poID)



        Dim ReferralUID = (From a In _db.ProgramOutcomes Where a.PoId = poID Select a.ReferralId).Single

        Dim rusername = (From a In _db.ProgramOutcomes Where a.PoId = poID Select a.RegisteredUser.Username).Single
        t.Close()
        t.Dispose()
        t = Nothing

        Return RedirectToAction("InfoPathUpload", New With {.cm = rusername, .referralid = ReferralUID})


    End Function

End Class
