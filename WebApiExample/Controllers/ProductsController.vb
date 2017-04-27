Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class ProductsController
        Inherits ApiController

        'Initializing an example list of products
        Dim products As Product() = {
        New Product() With {
        .Id = 1,
        .Name = "Tomatoe Sauce",
        .Category = "Groceries",
        .Price = 1
        },
        New Product() With {
        .Id = 2,
        .Name = "Ping pong table",
        .Category = "Toys",
        .Price = 8.75
        },
        New Product() With {
        .Id = 1,
        .Name = "Monitor",
        .Category = "Hardware",
        .Price = 199.99
    }
}
        ' GET: api/Products
        Public Function GetAllProducts() As IEnumerable(Of Product)
            Return products
        End Function


        Public Function GetFirstProduct(ByVal id As Integer) As IHttpActionResult

            Dim product As Product = products.FirstOrDefault(Function(p) p.Id = id)

            If IsNothing(product) Then
                Return NotFound()
            End If

            Return Ok(product)

        End Function

        Public Function GetAllProductsBySameID(ByVal id As Integer) As IEnumerable(Of Product)
            Return products.Where(Function(p) p.Id = id)
        End Function

    End Class
End Namespace