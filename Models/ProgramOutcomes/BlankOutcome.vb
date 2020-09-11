Imports <xmlns="urn:vgs:wa">

Namespace Model.ProgramOutcomes
    Public Class blankOutcome
        Implements iProgramOutcome


        Dim element As System.Xml.Linq.XElement


        Public Sub ReadXml(ByVal s As System.Xml.Linq.XElement) Implements iProgramOutcome.ReadXml
            element = s
        End Sub




        Public Function toXml(ByVal CompletedBy As String) As System.Xml.Linq.XElement Implements iProgramOutcome.toXml
            Return element
        End Function

        Public Function Body() As String Implements iProgramOutcome.Body
            Dim completedby = element.@CompletedBy
            Dim ed = element.@ed

            Dim output = <div>
                             <p><strong>Completed by </strong><%= completedby %> on <%= ed %></p>
                             <%= From a In element.Elements Select <p><strong><%= a.Name.LocalName & " " %></strong><%= a.Value %></p> %>

                         </div>
            Return output.ToString

        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return ""
        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return element.@type
        End Function
    End Class
End Namespace