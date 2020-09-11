<Authorize()> _
<HandleError()> _
Public Class SpecialNeedsController
    Inherits System.Web.Mvc.Controller


    Dim _db As Repository

    Sub New()
        _db = New Repository
    End Sub


    '
    ' GET: /SpecialNeeds/

    Function Index(ByVal Permilink As String) As ActionResult

        'Dim IncomeSources = From a In _db.GetAllIncomeSources _
        '                    Select a.IncomeSourceId, a.IncomeSource, Amount = Aggregate b In a.Incomes Where b.Info.Permilink = Permilink Into Sum(CType(b.IncomeSourceAmount, Decimal?))
        Dim Consumer As Model.Info = _db.getInfoByPermilink(Permilink)


        Dim SpecialNeedlist = From a In _db.getSpecialNeedlist _
                              Where (a.Enabled = True) _
                                 Select New rSpecialNeeds With {.SpecialNeed = a.SpecialNeedName, .SpecialNeedId = a.SpecialNeedId, .NumberOfSN = Aggregate b In a.SpecialNeedsContainers Where b.Info.Permilink = Permilink Into Count(CType(b.SpecialNeedId, Decimal?))}

        ViewData("rs") = Myapp.ConsumerMISCLink(Permilink, Consumer.FirstName, Consumer.LastName)

        Return View(SpecialNeedlist)
    End Function





    <AcceptVerbs(HttpVerbs.Post)> _
    Function Index(ByVal Permilink As String, ByVal collection As FormCollection) As ActionResult
        Dim Consumer As Model.Info = _db.getInfoByPermilink(Permilink)

        ' profile.Name = Collection("Name")

        ' rs.Save()

        Dim groupa() As String = collection("groups").Split(",")


        For Each s In _db.getSpecialNeedlist.Where(Function(e) Not groupa.Contains(e.SpecialNeedName))

            _db.DeleteNeedToConsumer(Consumer.RegistrarNo, s.SpecialNeedId)

        Next

        For Each s In _db.getSpecialNeedlist.Where(Function(e) groupa.Contains(e.SpecialNeedName))

            'Dim p As New Model.SpecialNeedsContainer

            'p.RegistrarNo = Consumer.RegistrarNo

            'Dim group As Model.SpecialNeed = s ' rs.getGroup(s)

            'p.GroupId = s.SpecialNeedId

            _db.AddNeedToConsumer(Consumer.RegistrarNo, s.SpecialNeedId)

        Next

        Dim SpecialNeedlist = From a In _db.getSpecialNeedlist _
                              Where a.Enabled = True _
                              Select New rSpecialNeeds With {.SpecialNeed = a.SpecialNeedName, .SpecialNeedId = a.SpecialNeedId, .NumberOfSN = Aggregate b In a.SpecialNeedsContainers Where b.Info.Permilink = Permilink Into Count(CType(b.SpecialNeedId, Decimal?))}

        ViewData("rs") = Myapp.ConsumerMISCLink(Permilink, Consumer.FirstName, Consumer.LastName)

        ' Return View(SpecialNeedlist)
        Return RedirectToAction("Misc", New With {.controller = "Info", .Permilink = Permilink})

    End Function






    Function Create(ByVal Permilink As String) As ActionResult
        ViewData("Permilink") = Permilink

        Return View()
    End Function


    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal Permilink As String, ByVal newSN As Model.SpecialNeed) As ActionResult
        ViewData("Permilink") = Permilink


        Dim sp = From a In _db.getSpecialNeedlist Where a.SpecialNeedName = newSN.SpecialNeedName

        If sp.Count > 0 Then
            Throw New Exception(String.Format("{0} allready exist", newSN.SpecialNeedName))
        End If

        newSN.Enabled = True

        _db.add(newSN)

        Dim RegistrarNo = _db.getInfoByPermilink(Permilink).RegistrarNo

        _db.AddNeedToConsumer(RegistrarNo, newSN.SpecialNeedId)

        Return RedirectToAction("Index", New With {.Permilink = Permilink})
    End Function

End Class

Public Class rSpecialNeeds
    Public SpecialNeedId As Integer
    Public NumberOfSN As Integer
    Public SpecialNeed As String

End Class
