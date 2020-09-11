Public Class InfoPathResult
    Inherits ActionResult

    Private privateFileName As String

    Public Property FileName() As String

        Get

            Return privateFileName

        End Get

        Set(ByVal value As String)

            privateFileName = value

        End Set

    End Property

    Private _data As String

    Public Property Data() As String

        Get

            Return _data

        End Get

        Set(ByVal value As String)

            _data = value

        End Set

    End Property



    Public Overrides Sub ExecuteResult(ByVal context As ControllerContext)

        context.HttpContext.Response.Buffer = True

        context.HttpContext.Response.Clear()

        context.HttpContext.Response.AddHeader("content-disposition", "attachment; filename=" & FileName)

        context.HttpContext.Response.ContentType = "application/x-microsoft-InfoPathForm"

        'context.HttpContext.Response.WriteFile(context.HttpContext.Server.MapPath(Path))

        context.HttpContext.Response.Write(Data)

    End Sub
End Class
