using BeehiveStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BeehiveStore.Models.Reposotories;
using System.Data.Entity;
using BeehiveStore.Helpers;
using System.Data.Entity.Infrastructure;

namespace BeehiveStore.Areas.StoreAdministrator.Controllers
{
    public class ProductController : Controller
    {
        // Reference to our Database
        private BeehiveContext _db = new BeehiveContext();

        private String formIDTemplate = "project-{0}-{1}";

        //
        // GET: /StoreAdministrator/Project/
        public ActionResult Index()
        {
            // Never use All
            // Should to make a pagination.
            IEnumerable<Product> products = _db.Products;

            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.formIDTemplate = formIDTemplate;

            // Create empty product
            Product product = new Product();
            SetProductViewBagForeignKeysDetails(product);

            return View(product);
        }

        /// <summary>
        /// Update project via ajax request.
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            // Post: http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(product).State = EntityState.Modified;
                    _db.SaveChanges();

                    var jsonData = new { HTTPCODE = 200 };
                    var jsonResult = JsonHelper.JsonResult(jsonData);

                    return jsonResult;
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            // Posts :
            // http://stackoverflow.com/questions/12112361/how-to-set-http-status-code-from-asp-net-mvc-3
            // http://stackoverflow.com/questions/499817/what-is-the-proper-way-to-send-an-http-404-response-from-an-asp-net-mvc-action
            Response.StatusCode = 403;
            var jsonErrors = ModelState.GenerateJsonErrors(formIDTemplate, product.ProductID);

            return jsonErrors;
        }

        /// <summary>
        /// Get All DropDown Collections
        /// </summary>
        /// <param name="product"></param>
        private void SetProductViewBagForeignKeysDetails(Product product)
        {
            SetProductViewBagCategories(product);
            SetProductViewBagStories(product);
        }

        /// <summary>
        /// Get Categories Collection and try to select one of them. 
        /// </summary>
        /// <param name="product"></param>
        private void SetProductViewBagCategories(Product product)
        {
            var categories = _db.Categories.GetCategoriesDropDownList();

            if (product.CategoryID == null)
            {
                ViewBag.CategoriesItems = new SelectList(categories, "ID", "Name");
            }
            else
            {
                ViewBag.CategoriesItems = new SelectList(categories, "ID", "Name", product.CategoryID);
            }
        }

        /// <summary>
        /// Get Stories Collection and try to select one of them. 
        /// </summary>
        /// <param name="product"></param>
        private void SetProductViewBagStories(Product product)
        {
            var stories = _db.Stories.GetStoriesDropDownList();

            if (product.StoreID == null)
            {
                ViewBag.StoriesItems = new SelectList(stories, "ID", "Name");
            }
            else
            {
                ViewBag.StoriesItems = new SelectList(stories, "ID", "Name", product.StoreID);
            }
        }
	}
}