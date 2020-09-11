<Authorize()> _
<HandleError()> _
Public Class RegisteredUsersController
    Inherits System.Web.Mvc.Controller

    Private _dc As New R2kdoiMVCDataContext


    '
    ' GET: /RegisteredUsers/
    <Authorize(Roles:="RegisteredUsersView")> _
    Function Index() As ActionResult
        Dim x = _dc.RegisteredUsers.Where(Function(e) e.Active = True).OrderBy(Function(e) e.Username)



        Return View(x)
    End Function

    '
    ' GET: /RegisteredUsers/Details/5
    <Authorize(Roles:="RegisteredUsersView")> _
    Function Details(ByVal id As Integer) As ActionResult
        Dim x = _dc.RegisteredUsers.Single(Function(e) e.UserId = id)

        Return View(x)
    End Function

    '
    ' GET: /RegisteredUsers/Create
    <Authorize(Roles:="RegisteredUsersCreate")> _
    Function Create() As ActionResult

        Return View()
    End Function

    '
    ' POST: /RegisteredUsers/Create
    <Authorize(Roles:="RegisteredUsersCreate")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal newUser As Model.RegisteredUser) As ActionResult
        Try

            newUser.Active = True
            _dc.RegisteredUsers.InsertOnSubmit(newUser)

            _dc.SubmitChanges()

            ' TODO: Add insert logic here
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /RegisteredUsers/Edit/5
    <Authorize(Roles:="RegisteredUsersEdit")> _
    Function Edit(ByVal id As Integer) As ActionResult
        Dim x = _dc.RegisteredUsers.Single(Function(e) e.UserId = id)

        Return View(x)
    End Function

    '
    ' POST: /RegisteredUsers/Edit/5
    <Authorize(Roles:="RegisteredUsersEdit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add update logic here
            Dim x = _dc.RegisteredUsers.Single(Function(e) e.UserId = id)

            UpdateModel(x)

            _dc.SubmitChanges()

            Return RedirectToAction("Index")
        Catch

            Return View()
        End Try
    End Function



    <Authorize(Roles:="ActiveUsers")> _
    Function ActiveUsers() As ActionResult
        Dim x = Membership.GetAllUsers
        Dim y = x.Item("")



        Return View(x)
    End Function

End Class
