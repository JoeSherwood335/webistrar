Namespace Model
    Public Class Accruel

        Private _ServiceId As Integer
        Sub New(ByVal ServiceID As Integer)
            _ServiceId = ServiceID
        End Sub


        Private _hide As Boolean = False


        Property Hide() As Boolean
            Get
                Return _hide
            End Get
            Set(ByVal value As Boolean)
                _hide = value
            End Set
        End Property


        Public ReadOnly Property Service() As Model.Service
            Get

                Dim r As New Repository


                Return r.GetService(_ServiceId)
                'Dim dc As New R2kdoiMVCDataContext

                'Dim s = From a In dc.Services _
                '        Where a.ServiceId = _ServiceId _
                '        Select a

                'If s.Count = 0 Then
                '    Throw New RecordNotFoundException(_ServiceId, "Service")
                'End If

                'Return s.First

            End Get
        End Property



        Private _NumberOfUnits As Double
        Public Property NumberOfUnits() As Double
            Get
                Return _NumberOfUnits
            End Get
            Set(ByVal value As Double)
                _NumberOfUnits = value
            End Set
        End Property



        Private _ServiceEndDate As DateTime
        Public Property ServiceEndDate() As DateTime
            Get
                Return _ServiceEndDate
            End Get
            Set(ByVal value As DateTime)
                _ServiceEndDate = value
            End Set
        End Property



        Private _NumberOfUnitsBilled As Double
        Public Property NumberOfUnitsBilled() As Double
            Get
                Return _NumberOfUnitsBilled
            End Get
            Set(ByVal value As Double)
                _NumberOfUnitsBilled = value
            End Set
        End Property


        Private _Permilink As String
        Public Property Permilink() As String
            Get
                Return _Permilink
            End Get
            Set(ByVal value As String)
                _Permilink = value
            End Set
        End Property




    End Class



    Public Class Complete
        Sub New()

        End Sub

        Private _ServiceId As Integer
        Public Property ServiceId() As Integer
            Get
                Return _ServiceId
            End Get
            Set(ByVal value As Integer)
                _ServiceId = value
            End Set
        End Property

        Private _AmmountBilled As Double
        Public Property AmountBilled() As Double
            Get
                Return _AmmountBilled
            End Get
            Set(ByVal value As Double)
                _AmmountBilled = value
            End Set
        End Property

        Private _AmmountAuthorized As Double
        Public Property AmountAuthorized() As Double
            Get
                Return _AmmountAuthorized
            End Get
            Set(ByVal value As Double)
                _AmmountAuthorized = value
            End Set
        End Property

        Private _unitsbilled As Decimal
        Public Property UnitsBilled() As Decimal
            Get
                Return _unitsbilled
            End Get
            Set(ByVal value As Decimal)
                _unitsbilled = value
            End Set
        End Property


        Private _unitsAuthorized As Decimal
        Public Property UnitsAuthorized() As Decimal
            Get
                Return _unitsAuthorized
            End Get
            Set(ByVal value As Decimal)
                _unitsAuthorized = value
            End Set
        End Property


    End Class
End Namespace