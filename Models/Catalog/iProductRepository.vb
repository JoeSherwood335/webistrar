Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iProductRepository



    ''' <summary>
    ''' Returns All Product from model
    ''' </summary>
    Function GetAllProducts() As IQueryable(Of Model.Product)

    ''' <summary>
    ''' Returns One Product from Model
    ''' </summary>
    Function GetProduct(ByVal id As Long) As Model.Product

    Function GetProductforList() As IEnumerable(Of Model.Product)
    ''' <summary>
    ''' Do i really need to explain this
    ''' </summary>
    Sub Save()

    ''' <summary>
    ''' Add Product Source
    ''' </summary>
    ''' <param name="newProduct"></param>
    Sub Add(ByVal newProduct As Model.Product)




End Interface


