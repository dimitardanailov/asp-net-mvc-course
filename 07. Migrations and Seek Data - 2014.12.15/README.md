## Asp.Net MVC - Partial Views (17.11.2014)

## Спонсори
- http://beehive.bg
- http://www.158ltd.com/
- https://www.icn.bg
- http://www.microsoft.com/bg-bg/default.aspx

## Microsoft Virtual Academy (What’s New in ASP.NET 5 Jump Start)

http://www.microsoftvirtualacademy.com/

## CRUD

- Update record 
```csharp
_db.Entry(project).State = EntityState.Modified;
_db.SaveChanges();
```

## Migrations and Seek Data

http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application

```
Tools -> NuGet Package Manager -> Package Manager Console
```

```csharp
enable-migrations
add-migration InitialCreate
update-database // Update Database via our Migrations
```

- Add Column
```csharp
AddColumn("TableName", "FieldName", c => c.Int(nullable: true)); // Field type will be Integer
DropColumn("TableName", "FieldName");
```

- Add Foreign Key
```csharp
AddForeignKey("TableName", "FieldName", "ExternalTable", "ID");
DropForeignKey("TableName", "FieldName", "ExternalTable");
```

- Add Index
```csharp
CreateIndex("TableName", "FieldName");
DropIndex("TableName", "FieldName");
```
- Create Table
```csharp
CreateTable(
	"dbo.Doctypes",
	c => new 
	{
		DocTypeID = c.Int(nullable: false, identity: true),
		Doctype = c.String(nullable: false, maxLength: 255),
		Description = c.String(nullable: true, storeType: "ntext")
	})
	.PrimaryKey(t => t.DocTypeID);
DropTable("dbo.Doctypes");
```

### Screencast
Youtube: 
