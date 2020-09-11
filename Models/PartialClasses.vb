Namespace Model

    Partial Class Fee
        Function GetServiceName()
            Try
                Dim db As New R2kdoiMVCDataContext
                Dim Parent_Value As String = ""
                Dim Child_Value As String = ""
                If Me.Product.ParentId.HasValue Then
                    Parent_Value = (From a In db.Products Where a.ProductId = Me.Product.ParentId.Value Select a.ProductName).First
                    Child_Value = Product.ProductName
                    Return String.Format("{0} {1}", Parent_Value, Child_Value)
                Else
                    Return Product.ProductName
                End If


                'Dim x = (From b In db.Products Where b.ParentId = (From a In db.Products Where a.ProductId = Me.ProductId Select a.ParentId).First _
                '        Select b.ProductName).First



            Catch
                Return ""
            End Try

        End Function


    End Class
    Partial Class Product
        Function GetServiceName() As String
            Dim db As New R2kdoiMVCDataContext
            If ParentId.HasValue Then
                Return String.Format("{0} {1}", (From j In db.Products Where j.ProductId = ParentId Select j.ProductName).FirstOrDefault, ProductName)
            Else
                Return ProductName

            End If
        End Function

    End Class

    Public Class CreateAndEnrollNewConsumers
        Sub New()

        End Sub


        Private _ssn As String
        Public Property SSN() As String
            Get
                Return _ssn
            End Get
            Set(ByVal value As String)
                _ssn = value
            End Set
        End Property




    End Class


    Public Class CasesView


        Private _ProgramName As String
        Public Property ProgramName() As String
            Get
                Return _ProgramName
            End Get
            Set(ByVal value As String)
                _ProgramName = value
            End Set
        End Property


        Private _ReferralId As String
        Public Property ReferralId() As String
            Get
                Return _ReferralId
            End Get
            Set(ByVal value As String)
                _ReferralId = value
            End Set
        End Property


        Private _firstname As String
        Public Property FirstName() As String
            Get
                Return _firstname
            End Get
            Set(ByVal value As String)
                _firstname = value
            End Set
        End Property


        Private _LastName As String
        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property



        Private _RegistrarNo As String
        Public Property RegistrarNo() As String
            Get
                Return _RegistrarNo
            End Get
            Set(ByVal value As String)
                _RegistrarNo = value
            End Set
        End Property



    End Class


    Public Class TranspherClass


        Dim _r2kdoi As Repository
        Sub New()



            _r2kdoi = New Repository
        End Sub
        Private _RegistrarNo As String
        Public Property RegistrarNo() As String
            Get
                Return _RegistrarNo
            End Get
            Set(ByVal value As String)
                _RegistrarNo = value
            End Set
        End Property



        Private _CurrentCounsler As String
        Public Property CurrentCounsler() As String
            Get
                Return _CurrentCounsler
            End Get
            Set(ByVal value As String)
                _CurrentCounsler = value
            End Set
        End Property


        Private _NewCounsler As String
        Public Property NewCounsler() As String
            Get
                Return _NewCounsler
            End Get
            Set(ByVal value As String)
                _NewCounsler = value
            End Set
        End Property

        Public Shared Function GetNewCounslers() As SelectList
            Dim dc As R2kdoiMVCDataContext

            dc = New R2kdoiMVCDataContext
            Dim Users = From user In dc.GetSubordinates(Myapp.UserId)

            Return New SelectList(Users, "UserId", "Username")
        End Function



        Function Link()


            Return _r2kdoi.GetInfo(RegistrarNo).Link
        End Function

    End Class



End Namespace


Partial Public Class R2kdoiMVCDataContext

    Public Function GetFullProductNames() As IEnumerable(Of Model.Product)
        Return ExecuteQuery(Of Model.Product)("Catalog.GetFullProductNames")
    End Function

    Public Function GetProductsforList() As IEnumerable(Of Model.Product)
        Return ExecuteQuery(Of Model.Product)("Catalog.GetProductHierarchical")
    End Function

    'Public Function GetInProgressAuthorizations() As IEnumerable(Of Model.Authorization)
    '    Return ExecuteQuery(Of Model.Authorization)("[Case].GetInProgressAuthorizations")
    'End Function


    'Public Function GetCompleteAuthorizations() As IEnumerable(Of Model.Authorization)
    '    Return ExecuteQuery(Of Model.Authorization)("[Case].GetCompleteAuthorizations")
    'End Function
    'Public Function GetNewAuthorizations() As IEnumerable(Of Model.Authorization)
    '    Return ExecuteQuery(Of Model.Authorization)("[Case].GetNewAuthorizations")
    'End Function

    Public Function GetRegistrarNoFromPermilink(ByVal permilink As String) As String
        'Return ExecuteQuery(Of String)("

        Return Me.Infos.Where(Function(e) e.Permilink = permilink).Select(Function(e) e.RegistrarNo).First



    End Function
End Class