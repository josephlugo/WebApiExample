Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()

        'Changed the default calling behavior introducing {action} in the string calling pattern. 
        'This way the Web API methods can be called separately as on this example:
        'http://localhost:63105/api/Products/GetAllProductsBySameID/1

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{action}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
