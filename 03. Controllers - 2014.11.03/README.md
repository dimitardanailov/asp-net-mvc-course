## Asp.Net MVC - Controllers (27.10.2014)

## Спонсори
- http://beehive.bg
- http://www.158ltd.com/
- https://www.icn.bg
- http://www.microsoft.com/bg-bg/default.aspx

## Models

```csharp
public MyInstance()
{
	this.Clients = new List<Client>();
}
```

Install EnityFramework:
```
Tools -> Nuget Package Maganer -> Manage Nuget Packages for Solution ... -> (Online) EnityFramework
```

DbContext Class
```
A DbContext instance represents a combination of the Unit Of Work and 
Repository patterns such that it can be used to query from a database and group 
together changes that will then be written back to the store as a unit. 
DbContext is conceptually similar to ObjectContext.
```

## Controllers

- Responding to user Request

- Routes

Example:

```csharp
routes.MapRoute
(
	name: "Project",
	url: "project/show/{id}",
	defaults: new
	{
		controller = "Project",
		action = "Details"
	}
);
```

### Passing Data

1. Model
	- View(data)
	- Strongly typed, can be more flexible
	- More complex
2. ViewBag
	- Dynamic object for storing basic pieces of information
		- Alias for ViewData
	- Perfect for sending messages to the view
	- Only available for that action
		- Redirects cause the ViewBag to be emptied
3. TempData
	- Just like the ViewBag, but it’s also available on the next page

### Save information to Database

http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
