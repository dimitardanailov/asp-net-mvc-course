using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BeehiveStore.Helpers
{
    public static class ModelStateHelper
    {
        /// <summary>
        /// Create JSON ContentResult with errors, formidtemplate and database id 
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="formIDTemplate"></param> This is connection between backend and front. Every component will have template id. 
        /// Example project-pmid-1234, project-client-1234. In this template must be project-{0}-{1}. 
        /// {1} will be used to replace and will be replace into front end with DatabaseID  
        /// <param name="DatabaseID"></param>
        /// <returns>JSON ContentResult</returns>
        public static ContentResult GenerateJsonErrors(this ModelStateDictionary modelState, String formIDTemplate, Int32 DatabaseID)
        {
            var errors = modelState.Errors();
            var responseData = new
            {
                Errros = errors,
                formIDTemplate = formIDTemplate,
                ID = DatabaseID
            };

            ContentResult jsonErrors = JsonHelper.JsonResult(responseData);

            return jsonErrors;
        }

        /// <summary>
        /// Create dictionary with Model State Errors.
        /// Result will be used for json response
        /// Post: http://stackoverflow.com/questions/2845852/asp-net-mvc-how-to-convert-modelstate-errors-to-json
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.ToDictionary(kvp => kvp.Key,
                    kvp => kvp.Value.Errors
                    .Select(e => e.ErrorMessage).ToArray())
                    .Where(m => m.Value.Count() > 0);
            }

            return null;
        }
    }
}