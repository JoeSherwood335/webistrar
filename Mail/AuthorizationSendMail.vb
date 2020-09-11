Namespace Mail
    Public Class AuthorizationSendMail
        Implements iSendMail

        Private _authorization As Model.Authorization

        Sub New(ByVal authorization As Model.Authorization)

            _authorization = authorization
        End Sub

        Public ReadOnly Property Authorzation() As Model.Authorization
            Get
                Return _authorization
            End Get
        End Property

        Public Sub Send() Implements iSendMail.Send
            Dim ProgramSupervisorName As String = Authorzation.Referral.ProgramInstance.Supervisor.Username


            Dim users = Membership.FindUsersByName(ProgramSupervisorName)
            Dim email As String

            If users.Count = 0 Then
                email = "joesherwood@vgsjob.org"
            Else
                email = users.Item(ProgramSupervisorName).Email
            End If

            Myapp.SendMail(email, Subject, Body)

        End Sub

        Public Overrides Function toString() As String Implements iSendMail.toString

            Return Subject & vbCrLf & vbCrLf & Body
        End Function

        Public ReadOnly Property Body() As Object Implements iSendMail.Body
            Get

                Dim Supervisor = Membership.GetUser(Authorzation.Referral.ProgramInstance.Supervisor.Username)

                Dim htmlXdocument = _
                            <authorization>
                                <program><%= Authorzation.Referral.ProgramInstance.Program.ProgramName %></program>
                                <authorizationNo><%= Authorzation.AuthorizationNumber %></authorizationNo>
                                <fundingSource><%= Authorzation.FundingCounselor.FundingSource.Acronym %></fundingSource>
                                <fundingCounsler><%= Authorzation.FundingCounselor.FirstName + " " + Authorzation.FundingCounselor.LastName %></fundingCounsler>
                                <%= From a In Authorzation.Services _
                                    Select <service><serviceName><%= a.ServiceName %></serviceName><numberOfUnits><%= a.NumberOfUnitesAuthorized %></numberOfUnits><unitType><%= a.UnitType.UnitType %></unitType><schedualStartDate><%= a.SchedualStartDate.ToShortDateString %></schedualStartDate><schedualEndDate><%= a.SchedualEndDate.ToShortDateString %></schedualEndDate></service> %>
                                <link><%= Link %></link>
                            </authorization>


                Dim xsltXdocument As XDocument = XDocument.Load(HttpContext.Current.Server.MapPath("~/Messages/Authorization.xslt"))

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

        Public ReadOnly Property Subject() As Object Implements iSendMail.Subject
            Get

                Dim s As String = HttpContext.Current.Server.MapPath("~/Messages/AuthorizationSubject.txt")
                Return String.Format(Myapp.ReadText(s), Authorzation.AuthorizationNumber, Authorzation.FundingCounselor.FundingSource.Acronym)

            End Get
        End Property

        Public ReadOnly Property Link() As Object Implements iSendMail.Link
            Get
                Dim path As String = Myapp.BuildUri.RouteUrl(New With {.controller = "Authorizations", .action = "Approve", .id = Authorzation.AuthorizationID})
                Dim host As New UriBuilder(HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port)

                Return host.Uri.AbsoluteUri & path
            End Get
        End Property
    End Class
End Namespace
