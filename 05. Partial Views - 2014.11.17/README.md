## Asp.Net MVC - Partial Views (17.11.2014)

## Спонсори
- http://beehive.bg
- http://www.158ltd.com/
- https://www.icn.bg
- http://www.microsoft.com/bg-bg/default.aspx

## Partial Views

- If you load partial view without parameters
```csharp
@Html.Partial("~/Views/Home/HomePageTabs/_AboutUsPartial.cshtml")
```

- If you want to pass paramethers to Partial view
```csharp
@{
    Html.RenderAction("Action", "Controller", new { 
        paramKey1 = paramValue1,
        paramKey2 = paramValue2
    });
}
```

Controller:

```csharp
String path =
    "~/Areas/StoreAdministrator/Views/CategoryModeration/PartialViews/_DisplayCategoryInformationPartialView.cshtml";

return PartialView(path);
```

### Screencast
Youtube: 
