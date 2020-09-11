Namespace Mail
    Public Class ServicesSendMail
        Implements iSendMail
        Private _service As Model.Service

        Sub New(ByVal Service As Model.Service)
            _service = Service
        End Sub

        Public ReadOnly Property Body() As Object Implements iSendMail.Body
            Get
                Dim Supervisor = Membership.GetUser(_service.Authorization.Referral.ProgramInstance.Supervisor.Username)

                Dim htmlXdocument = _
                            <service>
                                <program><%= _service.Authorization.Referral.ProgramInstance.Program.ProgramName %></program>
                                <product><%= If(_service.Product.ParentId.HasValue, _service.Product.Product.ProductName & " " & _service.Product.ProductName, _service.Product.ProductName) %></product>
                                <consumer><%= _service.Authorization.Referral.Info.GetFullName %></consumer>
                                <registrarNo><%= _service.Authorization.Referral.Info.RegistrarNo %></registrarNo>
                                <authorizationNo><%= _service.Authorization.AuthorizationNumber %></authorizationNo>
                                <fundingSource><%= _service.Authorization.FundingCounselor.FundingSource.Acronym %></fundingSource>
                                <fundingCounsler><%= _service.Authorization.FundingCounselor.FirstName + " " + _service.Authorization.FundingCounselor.LastName %></fundingCounsler>
                                <serviceName><%= _service.ServiceName %></serviceName>
                                <numberOfUnits><%= _service.NumberOfUnitesAuthorized %></numberOfUnits>
                                <unitType><%= _service.UnitType.UnitType %></unitType>
                                <schedualStartDate><%= _service.SchedualStartDate.ToShortDateString %></schedualStartDate>
                                <schedualEndDate><%= _service.SchedualEndDate.ToShortDateString %></schedualEndDate>
                                <AssignedBy><%= Myapp.user %></AssignedBy>
                                <link><%= Link %></link>
                            </service>


                Dim xsltXdocument As XDocument = XDocument.Load(HttpContext.Current.Server.MapPath("~/Messages/Service.xslt"))

                Dim newTree As XDocument = New XDocument()

                Using writer As System.Xml.XmlWriter = newTree.CreateWriter()
                    ' Load the style sheet.
                    Dim xslt As System.Xml.Xsl.XslCompiledTransform = New System.Xml.Xsl.XslCompiledTransform()
                    xslt.Load(xsltXdocument.CreateReader())

                    ' Execute the transform and output the results to a writer.
                    xslt.Transform(htmlXdocument.CreateReader(), writer)
                End Using

                Return newTree.ToString
            End Get
        End Property

        Public ReadOnly Property Link() As Object Implements iSendMail.Link
            Get
                Dim path As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Services", .action = "Details", .id = _service.ServiceId})
                Dim host As New UriBuilder(HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port)

                Return host.Uri.AbsoluteUri & path
            End Get
        End Property

        Public Sub Send() Implements iSendMail.Send
            Dim users = Membership.FindUsersByName(_service.RegisteredUser.Username)
            Dim email As String

            If users.Count = 0 Then
                email = "joesherwood@vgsjob.org"
            Else
                email = users.Item(_service.RegisteredUser.Username).Email

            End If

            Myapp.SendMail(email, Subject, Body)

        End Sub

        Public ReadOnly Property Subject() As Object Implements iSendMail.Subject
            Get
                Dim s As String = HttpContext.Current.Server.MapPath("~/Messages/ServiceSubject.txt")
                Return String.Format(Myapp.ReadText(s), _service.Authorization.Referral.Info.GetFullName)
            End Get
        End Property

        Public Overrides Function toString() As String Implements iSendMail.toString
            Return Subject & vbCrLf & vbCrLf & Body
        End Function
    End Class
End Namespace
