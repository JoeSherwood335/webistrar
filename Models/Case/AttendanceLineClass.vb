Public Class AttendanceLineClass
    Sub New()

    End Sub


    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property


    Private _rn As String
    Public Property rn() As String
        Get
            Return _rn
        End Get
        Set(ByVal value As String)
            _rn = value
        End Set
    End Property


    Private _start As DateTime?
    Public Property start() As DateTime?
        Get
            Return _start
        End Get
        Set(ByVal value As DateTime?)
            _start = value
        End Set
    End Property


    Private _LunchOut As DateTime?
    Public Property LunchOut() As DateTime?
        Get
            Return _LunchOut
        End Get
        Set(ByVal value As DateTime?)
            _LunchOut = value
        End Set
    End Property

    Private _LunchIn As DateTime?
    Public Property LunchIn() As DateTime?
        Get
            Return _LunchIn
        End Get
        Set(ByVal value As DateTime?)
            _LunchIn = value
        End Set
    End Property


    Private _endOfDay As DateTime?
    Public Property EndOfDay() As DateTime?
        Get
            Return _endOfDay
        End Get
        Set(ByVal value As DateTime?)
            _endOfDay = value
        End Set
    End Property


    Private _program As Model.Attendance.ProgramInstance
    Public Property Instance() As Model.Attendance.ProgramInstance
        Get
            Return _program
        End Get
        Set(ByVal value As Model.Attendance.ProgramInstance)
            _program = value
        End Set
    End Property


    Private _Absent As String
    Public Property IsAbsent() As String
        Get
            Return _Absent
        End Get
        Set(ByVal value As String)
            _Absent = value
        End Set
    End Property

    Private _AbsentType As String
    Public Property AbsentType() As String
        Get
            Return _AbsentType
        End Get
        Set(ByVal value As String)
            _AbsentType = value
        End Set
    End Property



End Class
