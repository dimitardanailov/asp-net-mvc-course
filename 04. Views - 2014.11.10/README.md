## Asp.Net MVC - Views (10.11.2014)

## Спонсори
- http://beehive.bg
- http://www.158ltd.com/
- https://www.icn.bg
- http://www.microsoft.com/bg-bg/default.aspx

## Views

- Creating Views with Razor Syntax
- Using HTML Helpers
- Reusing Code in Views

## Razor

Example for Razor Syntax: 
- http://haacked.com/archive/2011/01/06/razor-syntax-quick-reference.aspx/
- http://www.asp.net/web-pages/overview/getting-started/introducing-razor-syntax-(c)

In Razor Syntax, the @ symbol has varios uses. You can:
- Use @ to identify server-side C# code
- Use @@ to render an @ symbol in an HTML page.
- Use @: to explicitly declare a line of text as content and not code.
- Use <text> to explicitly declare several lines of text as content and not code.

## Model reference

```csharp
@model IEnumerable<MyWebsite.Models.Product>
```

```csharp
@model AsianAbsoluteMVC.Models.Product
```

## HTML Helpers

- @Html.ActionLink
- @Html.RouteLink
- @Html.DisplayNameFor
- @Html.DisplayFor
- @Html.DropDownListFor
