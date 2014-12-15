namespace BeehiveStore.Migrations
{
    using BeehiveStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeehiveStore.Models.BeehiveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BeehiveStore.Models.BeehiveContext";
        }

        protected override void Seed(BeehiveStore.Models.BeehiveContext context)
        {
            // Collecation with categories
            var categories = new List<Category>
            {
                new Category { Name = "Books", CreatedAt = DateTime.Parse("2010-09-01") },
                new Category { Name = "Albums", CreatedAt = DateTime.Parse("2010-09-01") },
                new Category { Name = "Art", CreatedAt = DateTime.Parse("2010-09-01") }
            };

            foreach (Category category in categories)
            {
                var databaseCategory = context.Categories.Where(
                    c => c.Name == category.Name).SingleOrDefault();
                if (databaseCategory == null)
                {
                    context.Categories.Add(category);
                }
            }
            context.SaveChanges();
        }
    }
}
