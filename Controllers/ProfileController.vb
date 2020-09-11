<Authorize()> _
<HandleError()> _
Public Class ProfileController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Profile/

    Private rs As Repository

    Sub New()
        rs = New Repository
    End Sub

    Function Index() As ActionResult
        ViewData("GroupOutput") = Groups()

        Return View(rs.getAllProfiles)
    End Function

    Function Groups() As String
        Dim sb As New System.Text.StringBuilder

        sb.AppendLine("Name, Action<br/>")
        Dim dc As New R2kdoiMVCDataContext
        Dim listofroles = Roles.GetAllRoles

        Dim listofSavedGroups = (From a In dc.Groups _
                                Select a.Groupname).ToArray

        Dim NewGroups = From a In listofroles Where Not listofSavedGroups.Contains(a) Select a

        For Each s In NewGroups
            Dim i As New Model.Group
            i.Groupname = s
            dc.Groups.InsertOnSubmit(i)
            dc.SubmitChanges()
            sb.AppendFormat("{0}, ADDED<br/>", s)
        Next

        Dim deletegroups = (From a In listofSavedGroups Where Not listofroles.Contains(a) Select a).ToArray

        For Each s In deletegroups
            Dim i As New Model.Group
            Dim d = From a In dc.Groups Where a.Groupname = s Select a
            Dim b = From a In dc.ProfileGroupContainers Where a.GroupId = d.First.GroupId Select a
            If b.Count > 0 Then
                dc.ProfileGroupContainers.DeleteAllOnSubmit(b)
                dc.SubmitChanges()
            End If
            If d.Count > 0 Then
                dc.Groups.DeleteOnSubmit(d.First)
                dc.SubmitChanges()
                sb.AppendFormat("{0}, Deleted<br/>", s)
            End If
        Next

        Return sb.ToString

    End Function

    Function Details(ByVal id As Integer) As ActionResult
        Return View(rs.getProfile(id))
    End Function
    Function myPermissions() As ActionResult

        Dim listofroles = Roles.GetAllRoles

        Dim rolesforuser As New List(Of String)

        For Each s In listofroles

            If Roles.IsUserInRole(Myapp.user(True), s) Then
                rolesforuser.Add(s)
            End If
        Next

        Return View(rolesforuser.ToArray)
    End Function
    <Authorize(Roles:="admin")> _
    Function Create() As ActionResult

        Return View()
    End Function
    <Authorize(Roles:="admin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal collection As FormCollection) As ActionResult
        'collection("groupa")
        Dim newProfile As New Model.profile

        newProfile.Name = collection("Name")

        rs.add(newProfile)

        rs.Save()

        Dim groupa() As String = collection("groups").Split(",")

        For Each s In groupa
            Dim p As New Model.ProfileGroupContainer

            p.ProfileId = newProfile.ProfileId

            Dim group As Model.Group = rs.getGroup(s)

            p.GroupId = group.GroupId

            rs.AddGroupToProfile(newProfile.ProfileId, group.GroupId)

        Next



        Return RedirectToAction("Details", New With {.id = newProfile.ProfileId})
    End Function
    <Authorize(Roles:="admin")> _
    Function Edit(ByVal ID As Integer) As ActionResult
        Dim x = rs.getProfile(ID)

        Return View(x)
    End Function
    <Authorize(Roles:="admin")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(ByVal ID As Integer, ByVal collection As FormCollection) As ActionResult
        'collection("groupa")
        Dim profile As Model.profile = rs.getProfile(ID)

        profile.Name = collection("Name")

        rs.Save()

        Dim groupa() As String = collection("groups").Split(",")


        For Each s In rs.getAllGroups.Where(Function(e) Not groupa.Contains(e.Groupname))

            rs.DeleteGroupFromProfile(profile.ProfileId, s)

        Next

        For Each s In rs.getAllGroups.Where(Function(e) groupa.Contains(e.Groupname))

            Dim p As New Model.ProfileGroupContainer

            p.ProfileId = profile.ProfileId

            Dim group As Model.Group = s ' rs.getGroup(s)

            p.GroupId = group.GroupId

            rs.AddGroupToProfile(p.ProfileId, group.GroupId)

        Next




        Return RedirectToAction("Details", New With {.id = profile.ProfileId})
    End Function
End Class
