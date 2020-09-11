Public Class ProductRepository
    Implements iProductRepository

    Private _db As R2kdoiMVCDataContext

    Sub New()

        _db = New R2kdoiMVCDataContext

    End Sub


    Public Sub Add(ByVal NewProduct As Model.Product) Implements iProductRepository.Add
        NewProduct.Discontinued = 0
        _db.Products.InsertOnSubmit(NewProduct)
    End Sub

    Public Function GetAllProducts() As System.Linq.IQueryable(Of Model.Product) Implements iProductRepository.GetAllProducts

        Return _db.Products.Where(Function(e) e.Discontinued = 0)
    End Function

    Public Function GetProduct(ByVal id As Long) As Model.Product Implements iProductRepository.GetProduct
        Return _db.Products.SingleOrDefault(Function(e) e.ProductId = id)

    End Function
    Public Function GetProductforList() As IEnumerable(Of Model.Product) Implements iProductRepository.GetProductforList
        'As System.Linq.ie(Of Model.Product) Implements iProductRepository.GetProductforList
        Return _db.GetProductsforList


    End Function

    Public Sub Save() Implements iProductRepository.Save
        _db.SubmitChanges()
    End Sub
End Class
