Imports System.Net.Http.Headers
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()

        'Changed the default calling behavior introducing {action} in the string calling pattern
        'This way the Web API methods can be called separately as on this example:
        'http://localhost:63105/api/Products/GetAllProductsBySameID/1

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{action}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )

        'Get JSON format
        config.Formatters.Add(New BrowserJsonFormatter())

        'Get HTML format
        'config.Formatters.JsonFormatter.SupportedMediaTypes.Add(New MediaTypeHeaderValue("text/html"))

        'To generate Web API documentation:
        '1. Open Nuget Package Manager, look up for "Microsoft.AspNet.WebApi.HelpPage.VB" And install it.
        '2. Build the solution. This will add a new Areas folder in the project.
        '3. Go to Areas/HelpPage/App_Start -> HelpPageConfig.vb file.
        '4. Look up for the line "config.SetDocumentationProvider(New XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")))" and uncomment it.
        '5. Change the MapPath to: "~/bin/WebApiProjectName.xml".
        '6. Add comments to the desired functions at the Web API project controller.
        '7. Go to Areas/Views/Help -> Index.vbhtml to change the content of the Web API documentation main page.
        '8. On Project Properties -> Compile tab, review that "Generate XML documentation file" option is checked.
        '9. Build the solution and run it.
        '10. Access to the auto-generated Web API website documentation at: http://yourmachine/Help
        'More info at: https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages

    End Sub
End Module
