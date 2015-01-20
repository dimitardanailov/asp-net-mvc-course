## Asp.Net MVC - jQuery (19.01.2015)

## Спонсори
- http://beehive.bg
- http://www.158ltd.com/
- https://www.icn.bg
- http://www.microsoft.com/bg-bg/default.aspx

## Bundling and Minification
http://www.asp.net/mvc/overview/performance/bundling-and-minification

### How to add reference to System.Web.Optimization for MVC-3-converted-to-4 app
http://stackoverflow.com/questions/9475893/how-to-add-reference-to-system-web-optimization-for-mvc-3-converted-to-4-app

The Microsoft.Web.Optimization package is now obsolete. With the final release of ASP.NET (MVC) 4 
you should install the Microsoft ASP.NET Web Optimization Framework:

- Install the package from nuget:

```csharp
Install-Package Microsoft.AspNet.Web.Optimization
```

- Create and configure bundle(s) in App_Start\BundleConfig.cs:

```csharp
public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles) {
        bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
            "~/Scripts/Lib/jquery/jquery-{version}.js",
            "~/Scripts/Lib/jquery/jquery.*",
            "~/Scripts/Lib/jquery/jquery-ui-{version}.js")
        );

        bundles.Add(new ScriptBundle("~/Scripts/knockout").Include(
             "~/Scripts/Lib/knockout/knockout-{version}.js",
             "~/Scripts/Lib/knockout/knockout-deferred-updates.js")
        );
    }
}
```

- Call the RegisterBundles() function from Application_Start() in your global.asax.cs:

```csharp
using System.Web.Optimization;

protected void Application_Start() {
     ...
     BundleConfig.RegisterBundles(BundleTable.Bundles);
     ...
}
```

- In your view.cshtml include the Optimization namespace and render the bundle(s):

```csharp
@using System.Web.Optimization

@Scripts.Render("~/Scripts/jquery")
@Scripts.Render("~/Scripts/knockout")
```

## JavaScriptSerializer.MaxJsonLength Property
http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.maxjsonlength.aspx

```csharp
The maximum length of JSON strings. The default is 2097152 characters, which is equivalent to 4 MB of Unicode string data.
```

## jQuery

### jQuery Unobtrusive Ajax
- https://www.nuget.org/packages/Microsoft.jQuery.Unobtrusive.Ajax/3.2.2
- http://blogs.msdn.com/b/webdev/archive/2014/01/20/announcing-the-release-of-asp-net-mvc-5-1-asp-net-web-api-2-1-and-asp-net-web-pages-3-1.aspx
- http://www.asp.net/mvc/overview/releases/mvc51-release-notes#thisContext

- Install the package from nuget:

```csharp
Install-Package Microsoft.jQuery.Unobtrusive.Ajax -Version 3.2.2
```

- CallBack Functions for beforsend and error methods:

```javascript
$.extend(options, {
    type: element.getAttribute("data-ajax-method") || undefined,
    url: element.getAttribute("data-ajax-url") || undefined,
    cache: !!element.getAttribute("data-ajax-cache"),
    beforeSend: function (xhr) {
        var result;
        asyncOnBeforeSend(xhr, method);

        // Post fix: http://stackoverflow.com/questions/11250143/how-can-i-reference-a-clicked-actionlink-a-element-from-within-its-onbegin-fu
        result = getFunction(element.getAttribute("data-ajax-begin"), ["xhr"]).apply({
            xhr: this,
            element: element, options: options
        }, arguments);
        if (result !== false) {
            loading.show(duration);
        }
        return result;
        /*
        result = getFunction(element.getAttribute("data-ajax-begin"), ["xhr"]).apply(element, arguments);
        if (result !== false) {
            loading.show(duration);
        }
        return result;
        */
    },
    complete: function () {
        loading.hide(duration);
        getFunction(element.getAttribute("data-ajax-complete"), ["xhr", "status"]).apply(element, arguments);
    },
    success: function (data, status, xhr) {
        asyncOnSuccess(element, data, xhr.getResponseHeader("Content-Type") || "text/html");
        getFunction(element.getAttribute("data-ajax-success"), ["data", "status", "xhr"]).apply(element, arguments);
    },
    /*
    error: function () {
        getFunction(element.getAttribute("data-ajax-failure"), ["xhr", "status", "error"]).apply(element, arguments);
    }*/
    error: function () {
        loading.hide(duration);
        getFunction(element.getAttribute("data-ajax-failure"), ["xhr", "status"]).apply({
            xhr: this,
            element: element,
            options: options,
            response: errors
        }, arguments);
    }
});
```

### Ajax.BeginForm Helper
http://msdn.microsoft.com/en-us/library/system.web.mvc.ajax.ajaxoptions%28v=vs.118%29.aspx

```csharp
@using (Ajax.BeginForm("action", "controller",
new AjaxOptions()
{
    HttpMethod = "POST",
    OnBegin = "AjaxUpdateDataLoading($(this));",
    OnSuccess = "AjaxUpdateDateOnSuccess($(this))",
    OnFailure = "AjaxDisplayErrors($(this))"
},
new
{
    @id = "form-id",
    @data_attribute = "my attribute",
    @class = "class"
}))
{
	...
}
```
### LabelFor and DropDownListFor
- http://msdn.microsoft.com/en-us/library/ee407381%28v=vs.118%29.aspx
- http://msdn.microsoft.com/en-us/library/dd492948%28v=vs.118%29.aspx

```csharp
@{
    String labelSelectbox = String.Format("{0} *", "SelectBox field name");
    @Html.LabelFor(model => Model.ColumnName, labelSelectbox, new 
    { 
        @class = "myClass",
        @for =  Model.ColumnName
    })

    @Html.DropDownListFor(
        model => Model.ColumnName,
        (SelectList)ViewBag.Collections,
        String.Format("{0} {1}", "Default value", "Default label"),
        new
        {
            @class = "",
            @id =  ""
        }
    )

    @Html.ValidationMessageFor(model => Model.ColumnName)
}
```
