<HandleError()> _
<Authorize()> _
Public Class IncomeController
    Inherits System.Web.Mvc.Controller


    Dim _db As Repository

    Sub New()
        _db = New Repository
    End Sub
    '
    ' GET: /IncomeSources/

    Function Index(ByVal Permilink As String) As ActionResult
        'Dim IncomeSources = From a In _db.GetAllIncomeSources _
        '                    Select a.IncomeSourceId, a.IncomeSource, Amount = Aggregate b In a.Incomes Where b.Info.Permilink = Permilink Into Sum(CType(b.IncomeSourceAmount, Decimal?))

        'Dim reg = _db.getInfoByPermilink(Permilink).RegistrarNo


        Dim IncomeSources = From a In _db.GetAllIncomeSources _
                            Select New rIncomeSources With {.Registrarno = Permilink, .IncomeSourceId = a.IncomeSourceId, .IncomeSource = a.IncomeSource, .Amount = Aggregate b In a.Incomes Where b.Info.Permilink = Permilink Into Sum(CType(b.IncomeSourceAmount, Decimal?))}


        Return View(IncomeSources)

    End Function


    '
    ' GET: /IncomeSources/Edit/5
    <Authorize(Roles:="IncomeSourcesCreateEdit")> _
    Function Edit(ByVal Permilink As String, ByVal id As Integer) As ActionResult
        Dim x = Aggregate a In _db.getInfoByPermilink(Permilink).Incomes _
                 Where a.IncomeSourceId = id _
                 Into Count()


        Dim b As Integer = 2

        If x = 0 Then
            Dim newincome As New Model.Income


            newincome.RegistrarNo = Myapp.GetRegistrarNo(Permilink)
            newincome.IncomeSourceId = id
            newincome.IncomeSourceAmountTypeId = b
            newincome.InputedBy = Myapp.UserId
            newincome.ed = Date.Now
            newincome.ud = Date.Now

            _db.add(newincome)

            Return View(newincome)
        Else
            Dim income = _db.GetIncome(Permilink, id)

            Return View(income)
        End If


        ' _db.Refresh(_db.GetInfoByPermilink(Permilink).Incomes)



    End Function

    '
    ' POST: /IncomeSources/Edit/5
    <Authorize(Roles:="IncomeSourcesCreateEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal Permilink As String, ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        'Dim x = (From a In _db.getInfoByPermilink(Permilink).Incomes _
        ' Where a.IncomeSourceId = id _
        ' Select a).Single()
        Dim x = _db.GetIncome(Permilink, id)


        Try
            ' TODO: Add update logic here

            UpdateModel(x)
            x.ud = Now

            _db.Save()




            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function
    <Authorize(Roles:="IncomeSourcesCreateEdit")> _
    Function Remove(ByVal Permilink As String, ByVal id As Integer) As ActionResult
        Dim x = _db.GetIncome(Permilink, id)
        _db.Delete(x)

        Return RedirectToAction("Index")
    End Function


End Class


Public Class rIncomeSources

    Public IncomeSourceId As Integer
    Public IncomeSource As String
    Public Amount As Decimal?
    Public Type As String
    Public Registrarno As String
End Class
