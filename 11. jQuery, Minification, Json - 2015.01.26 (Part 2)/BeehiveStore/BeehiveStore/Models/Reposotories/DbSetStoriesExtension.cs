using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeehiveStore.Models.Reposotories
{
    public static class DbSetStoriesExtension
    {
        /// <summary>
        /// Get Stories List
        /// </summary>
        /// <param name="dbStories"></param>
        /// <returns>I will return Array with Categories</returns>
        public static Array GetStoriesDropDownList(this DbSet<Store> dbStories)
        {
            var stories = dbStories
                .OrderBy(s => s.Brand)
                .Select(s => new
                {
                    ID = s.StoreID,
                    Name = s.Brand
                })
                .ToArray();

            return stories;
        }
    }
}