Imports System.Runtime.CompilerServices

Public Module CheckExtensions
    <Extension()> _
    Public Function CheckDetails(ByVal helper As HtmlHelper, ByVal check? As Boolean) As String

        If check.HasValue Then
            If check Then
                Return String.Format("<img src=""{0}/Content/imgs/checked.gif""/>", Myapp.GetServerPath)
            Else
                Return String.Format("<img src=""{0}/Content/imgs/un-checked.gif""/>", Myapp.GetServerPath)
            End If
        Else
            Return "<span class=""checkdetails"">I Don't Know</span>"
        End If

    End Function
End Module


Public Module LabelExtensions
    <Extension()> _
    Public Function Label(ByVal helper As HtmlHelper, ByVal target As String, ByVal text As String) As String
        Return String.Format("<label for='{0}'> {1}</label>", target, text)

    End Function
End Module


Public Module infoExtensions
    <Extension()> _
    Public Function ConsumerLink(ByVal helper As HtmlHelper, ByVal registrarNo As String) As String

        Dim db As New Repository

        Dim x = db.GetInfo(registrarNo)

        Return Myapp.ConsumerLink(x.Permilink, x.FirstName, x.LastName)

    End Function

    <Extension()> _
    Public Function ConsumerLink(ByVal helper As HtmlHelper, ByVal info As Model.Info) As String
        
        Return Myapp.ConsumerLink(info.Permilink, info.FirstName, info.LastName)

    End Function


    <Extension()> _
    Public Function ConsumerLink(ByVal helper As HtmlHelper, ByVal Permilink As String, ByVal FirstName As String, ByVal lastname As String) As String

        Return Myapp.ConsumerLink(Permilink, FirstName, lastname)

    End Function

    <Extension()> _
    Public Function ServiceColumnName(ByVal helper As HtmlHelper, ByVal ColumnName As String, ByVal ColumnAbbr As String, ByVal ServiceView As R2kdoiMVC.Model.Service.Statuses, ByVal Search As String, ByVal Sort As String, ByVal Page? As Integer) As String
        Dim serverpath As String = Myapp.GetServerPath
        Dim viewPath As String

        Select Case ServiceView
            Case Model.Service.Statuses.New
                viewPath = "NewServices"
            Case Model.Service.Statuses.Pending
                viewPath = "Pending"
            Case Model.Service.Statuses.InProgress
                viewPath = "InProgress"
            Case Model.Service.Statuses.Completed
                viewPath = "Completed"
            Case Else
        End Select


        Dim path As String

        If Page.HasValue Then
            path = Myapp.BuildUri.RouteUrl(New With {.controller = "Services", .action = viewPath, .Search = Search, .Sort = Sort})
        Else
            path = Myapp.BuildUri.RouteUrl(New With {.controller = "Services", .action = viewPath, .Search = Search, .Sort = Sort, .Page = Page.Value})
        End If
        Return String.Format("<a href='{0}{1}' class='showprintinline'><acronym title=""{2}"">{3}</acronym></a>", serverpath, path, ColumnName, ColumnAbbr)

        'Return String.Format("<a href='/R2kdoiMVC2/Consumer/{0}/'>{1} {2}</a>", info.Permilink, info.FirstName, info.LastName)

    End Function


    <Extension()> _
Public Function acronymColumnName(ByVal helper As HtmlHelper, ByVal ColumnName As String, ByVal ColumnAbbr As String, ByVal rootValues As Object) As String
        Dim serverpath As String = Myapp.GetServerPath


        Dim path As String

        path = Myapp.BuildUri.RouteUrl(rootValues)


        Return String.Format("<a href='{0}{1}' class='showprintinline'><acronym title=""{2}"">{3}</acronym></a>", serverpath, path, ColumnName, ColumnAbbr)

        'Return String.Format("<a href='/R2kdoiMVC2/Consumer/{0}/'>{1} {2}</a>", info.Permilink, info.FirstName, info.LastName)

    End Function

End Module