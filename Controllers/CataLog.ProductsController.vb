Namespace Controllers

    Public Class ProductFormViewModel

        Private _Product As Model.Product

        Sub New(ByVal Product As Model.Product)
            _Product = Product
        End Sub

        Public Property Product() As Model.Product
            Get
                Return _Product
            End Get
            Set(ByVal value As Model.Product)
                _Product = value
            End Set
        End Property

        Public Function Parents() As SelectList
            Dim db As New R2kdoiMVCDataContext


            Return New SelectList((From x In db.Products Where x.ParentId Is Nothing And x.Discontinued = 0 Select x.ProductId, x.ProductName), "ProductId", "ProductName", Product.ParentId)



        End Function

    End Class


    <Authorize()> _
    Public Class ProductsController
        Inherits System.Web.Mvc.Controller

        Private _db As iProductRepository

        Sub New()
            _db = New ProductRepository

        End Sub

        Sub New(ByVal repository As iLocationsRepository)
            _db = repository
        End Sub

        '
        ' GET: /Product/

        Function Index() As ActionResult
            Return View(_db.GetProductforList.Where(Function(e) e.Discontinued = 0))
        End Function

        '
        ' GET: /Product/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Return View(_db.GetProduct(id))
        End Function

        '
        ' GET: /Product/Create
        <Authorize(Roles:="ProductAdmin")> _
        Function Create() As ActionResult

            Dim db As New R2kdoiMVCDataContext
            Dim b = From i In db.GetFullProductNames Where i.ParentId Is Nothing And i.Discontinued = 0 Order By i.ProductName Select i '.GetFullProductNames
            ViewData.Add("Parents", New SelectList(b, "ProductId", "ProductName")) ', product.ParentId.Value))
            Return View()
        End Function

        '
        ' POST: /Product/Create
        <Authorize(Roles:="ProductAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Create(ByVal NewProduct As Model.Product) As ActionResult
            'Try
            Dim x = From a In _db.GetAllProducts Where a.ProductName = NewProduct.ProductName And NewProduct.ParentId = a.ParentId

            If x.Count > 0 Then
                Throw New ProductAllReadyAddedException(NewProduct.ProductName)
            End If
            _db.Add(NewProduct)
            _db.Save()

            Return RedirectToAction("Index")
            'Catch ex As Exception
            '    Dim db As New R2kdoiMVCDataContext
            '    Dim b = From i In db.GetFullProductNames Where i.ParentId Is Nothing And i.Discontinued = 0 Order By i.ProductName Select i '.GetFullProductNames
            '    ViewData.Add("Parents", New SelectList(b, "ProductId", "ProductName")) ', product.ParentId.Value))
            '    Return View()
            'End Try
        End Function

        '
        ' GET: /Product/Edit/5
        <Authorize(Roles:="ProductAdmin")> _
        Function Edit(ByVal id As Integer) As ActionResult
            Dim db As New R2kdoiMVCDataContext

            Dim product As Model.Product = _db.GetProduct(id)


            Dim b = From i In db.GetFullProductNames Where i.ParentId Is Nothing And i.Discontinued = 0 Select i '.GetFullProductNames


            ViewData.Add("Parents", New SelectList(b, "ProductId", "ProductName", product.ParentId)) ', product.ParentId.Value))

            Return View(product)
        End Function

        '
        ' POST: /Product/Edit/5
        <Authorize(Roles:="ProductAdmin")> _
        <AcceptVerbs(HttpVerbs.Post)> _
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here
                Dim product As Model.Product = _db.GetProduct(id)

                UpdateModel(product)


                Dim x = From a In _db.GetAllProducts Where a.ProductName = product.ProductName And product.ParentId = a.ParentId

                If x.Count > 0 Then
                    Throw New ProductAllReadyAddedException(product.ProductName)
                End If

                _db.Save()


                Return RedirectToAction("Index")
            Catch ex As Exception
                Return View()
            End Try
        End Function
    End Class
End Namespace