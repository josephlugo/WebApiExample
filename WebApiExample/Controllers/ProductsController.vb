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
                                        .Id = 3,
                                        .Name = "DELL Monitor",
                                        .Category = "Hardware",
                                        .Price = 199.99
                                        },
                                        New Product() With {
                                        .Id = 4,
                                        .Name = "Keyboard",
                                        .Category = "Hardware",
                                        .Price = 14.99
                                        },
                                         New Product() With {
                                        .Id = 5,
                                        .Name = "NOC Monitor",
                                        .Category = "Hardware",
                                        .Price = 199.99
                                        }
                                    }
        ' GET example: http://localhost:63105/api/Products/GetAllProducts
        ''' <summary>
        ''' Get all registered products from the list.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetAllProducts() As IEnumerable(Of Product)
            Return products
        End Function

        ' GET example: http://localhost:63105/api/Products/GetFirstProduct/1
        ''' <summary>
        ''' Gets the first registered product under the specified ID parameter.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function GetFirstProduct(ByVal id As Integer) As IHttpActionResult


            Dim product As Product = products.FirstOrDefault(Function(p) p.Id = id)

            If IsNothing(product) Then
                Return NotFound()
            End If

            Return Ok(product)

        End Function

        ' GET example: http://localhost:63105/api/Products/GetProductsByPrice?price=199.99
        ''' <summary>
        ''' Gets all the registered products with the specified price.
        ''' </summary>
        ''' <param name="price"></param>
        ''' <returns></returns>
        Public Function GetProductsByPrice(ByVal price As Decimal) As IEnumerable(Of Product)
            Return products.Where(Function(p) p.Price = price)
        End Function

        ' GET example: http://localhost:63105/api/Products/GetAllProducts?category=Hardware&price=199.99
        ''' <summary>
        ''' Gets all the registered products under the same Price and Category.
        ''' </summary>
        ''' <param name="category"></param>
        ''' <param name="price"></param>
        ''' <returns></returns>
        Public Function GetAllProducts(ByVal category As String, ByVal price As Decimal) As IEnumerable(Of Product)
            Return products.Where(Function(p) p.Category = category And p.Price = price)
        End Function

    End Class
End Namespace