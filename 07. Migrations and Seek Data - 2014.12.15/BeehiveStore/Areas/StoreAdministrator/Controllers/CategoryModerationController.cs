using BeehiveStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BeehiveStore.Areas.StoreAdministrator.Controllers
{
    public class CategoryModerationController : Controller
    {
        // Reference to our Database
        private BeehiveContext _db = new BeehiveContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Never use All
            // Should to make a pagination.
            IEnumerable<Category> categories = _db.Categories;

            return View(categories);
        }

        /// <summary>
        /// Load a form and try to create a new category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Create";

            return View("Form");
        }

        /// <summary>
        /// Try to Create to save Category information to our db
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            // Post: http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
            try
            {
                // Check our model is Valid
                if (ModelState.IsValid)
                {
                    // Add a new Category
                    _db.Categories.Add(category);

                    // Push Changes to Database
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View("Form", category);
        }

        /// <summary>
        /// Get information for Category by Category Id
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            ActionResult result = RenderCategoryViewById("Details", id);

            return result;
        }

        /// <summary>
        /// Get information for Category by Category Id
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit";

            ActionResult result = RenderCategoryViewById("Form", id);

            return result;
        }

        /// <summary>
        /// Update existing record information
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            ViewBag.Title = "Edit";

            // Post: http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
            try
            {
                // Check our model is Valid
                if (ModelState.IsValid)
                {
                    // Entity have a new versionAdd a new Category
                    _db.Entry(category).State = EntityState.Modified;

                    // Push Changes to Database
                    _db.SaveChanges();

                    return RedirectToAction("Details", category.CategoryID);
                }
            }
            catch (DbUpdateException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View("Form", category);
        }

        /// <summary>
        /// Render Partial view for Index and Details Actions
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public ActionResult DisplayCategoryInformation(Category category)
        {
            String path =
                "~/Areas/StoreAdministrator/Views/CategoryModeration/PartialViews/_DisplayCategoryInformationPartialView.cshtml";

            return PartialView(path, category);
        }

        /// <summary>
        /// Try to Get Category from Database and Display Information
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private ActionResult RenderCategoryViewById(String viewName, int? id)
        {
            if (id == null)
            {
                // We have invalid Get Param
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _db.Categories.Find(id);
            if (category == null)
            {
                return new HttpNotFoundResult();
            }

            return View(viewName, category);
        }
	}
}