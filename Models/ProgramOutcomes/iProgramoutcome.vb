Namespace Model.ProgramOutcomes


    Public Interface iProgramOutcome


        Function toXml(ByVal CompletedBy As String) As XElement
        Sub ReadXml(ByVal s As XElement)

        Function Title() As String
        Function Body() As String
        Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String

    End Interface
End Namespace