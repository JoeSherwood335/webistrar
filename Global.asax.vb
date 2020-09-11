' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults

        routes.MapRoute( _
            "InfoIndex", _
            "Consumer/Index", _
             New With {.controller = "Info", .action = "Index"} _
        )


        'routes.MapRoute( _
        '    "contact", _
        '    "Consumer/{permilink}/contacts", _
        '    New With {.controller = "Contact", .action = "Index"} _
        ')

        'routes.MapRoute( _
        '    "Authorizations", _
        '    "Consumer/{permilink}/Authorizations/{action}/{id}", _
        '    New With {.controller = "Authorizations", .action = "Index", .id = ""} _
        ')




        routes.MapRoute( _
            "Placement", _
            "Consumer/{permilink}/Placements/{action}/{id}", _
            New With {.controller = "Placements", .action = "Index", .id = ""} _
        )

        routes.MapRoute( _
            "Attendances", _
            "Attendances/{action}/{id}/{year}/{month}/{day}", _
            New With {.controller = "Attendances", .action = "Index", .id = "", .year = "", .month = "", .day = ""} _
        )

        routes.MapRoute( _
            "Notes", _
            "Consumer/{permilink}/Notes/{action}/{id}", _
            New With {.controller = "Notes", .action = "Index", .id = ""} _
        )

        routes.MapRoute( _
            "Referral", _
            "Consumer/{permilink}/Referral/{action}/{id}/{filename}", _
            New With {.controller = "Referral", .action = "Index", .id = "", .filename = ""} _
        )


        routes.MapRoute( _
            "Contact", _
            "Consumer/{permilink}/Contact/{action}/{id}", _
            New With {.controller = "Contact", .action = "Index", .id = ""} _
        )
        routes.MapRoute( _
            "Address", _
            "Consumer/{permilink}/Address/{action}/{id}", _
            New With {.controller = "Address", .action = "Index", .id = ""} _
        )
        routes.MapRoute( _
            "Disability", _
            "Consumer/{permilink}/Disability/{action}/{id}", _
            New With {.controller = "Disability", .action = "Index", .id = ""} _
        )

        routes.MapRoute( _
            "IncomeSources", _
            "Consumer/{permilink}/Income/{action}/{id}", _
            New With {.controller = "Income", .action = "Index", .id = ""} _
        )


        'exp consumer/firstname-lastname-registrarno/action
        routes.MapRoute( _
            "Needs", _
            "Consumer/{permilink}/Needs/{action}", _
            New With {.controller = "SpecialNeeds", .action = "Index"} _
        )



        'exp consumer/firstname-lastname-registrarno/action
        routes.MapRoute( _
            "info", _
            "Consumer/{permilink}/{action}", _
            New With {.controller = "Info", .action = "Details"} _
        )




        routes.MapRoute( _
            "FundingSource_ReferingCounsler", _
            "fundingsource/{Acronym}/Counsler/{action}/{id}", _
            New With {.controller = "ReferringCounslers", .action = "Index", .id = ""} _
        )

        routes.MapRoute( _
            "fundingsource", _
            "fundingsource/{Acronym}/{action}", _
            New With {.controller = "fundingsource", .action = "Details"} _
        )


        '
        routes.MapRoute( _
            "Services", _
            "Services/{action}/{id}", _
            New With {.controller = "Services", .action = "InProgress", .id = ""} _
        )
        routes.MapRoute( _
            "Authorizations", _
            "Authorizations/{action}/{id}", _
            New With {.controller = "Authorizations", .action = "NewAuthorizations", .id = ""} _
        )




        routes.MapRoute( _
          "Default", _
          "{controller}/{action}/{id}", _
          New With {.controller = "Services", .action = "Index", .id = ""} _
      )
        '  routes.MapRoute( _
        '    "Default", _
        '    "{controller}/{action}/{id}", _
        '    New With {.controller = "Info", .action = "Index", .id = ""} _
        ')
           

        'routes.MapRoute( _
        '   "disability", _
        '    "info/{registrarno}/{controller}", _
        '    New With {.controller = "Info", .action = "Details", .id = "000001"} _
        ')
    End Sub

    Sub Application_Start()
        RegisterRoutes(RouteTable.Routes)
        Application("userlist") = New Dictionary(Of String, DateTime)

    End Sub

    Sub session_start()
        Dim joe As New Object

    End Sub


    Sub session_end()
        Dim joe As New Object

    End Sub



    Public Sub Session_OnStart()
        Application.Lock()
        ' Application("UsersOnline") = CInt(Application("UsersOnline")) + 1


        Application.UnLock()
    End Sub

    Public Sub Session_OnEnd()
        Application.Lock()
        ' Application("UsersOnline") = CInt(Application("UsersOnline")) - 1
        ' Dim d As Dictionary(Of String, DateTime) = Application("userlist")

        ' d.Remove(Myapp.user)
        Application.UnLock()
    End Sub



    Private Sub MvcApplication_AuthenticateRequest(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AuthenticateRequest
        Dim joe As New Object
        'If Me.User.Identity.IsAuthenticated Then

    End Sub
End Class
