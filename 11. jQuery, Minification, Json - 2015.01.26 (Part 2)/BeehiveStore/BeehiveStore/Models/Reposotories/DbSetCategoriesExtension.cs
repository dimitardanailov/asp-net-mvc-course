using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeehiveStore.Models.Reposotories
{
    public static class DbSetCategoriesExtension
    {
        /// <summary>
        /// Get Categories List
        /// </summary>
        /// <param name="dbCategories"></param>
        /// <returns></returns>
        public static Array GetCategoriesDropDownList(this DbSet<Category> dbCategories)
        {
            var categories = dbCategories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    ID = c.CategoryID,
                    Name = c.Name
                })
                .ToArray();

            return categories;
        }
    }
}