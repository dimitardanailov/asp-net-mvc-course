using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BeehiveStore.Helpers
{
    public class JsonHelper
    {
        /// <summary>
        /// Generate JSON object with MaxJsonLength equal to Int32.MaxValue
        /// Posts:
        /// http://stackoverflow.com/questions/1151987/can-i-set-an-unlimited-length-for-maxjsonlength-in-web-config
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns>ContentResultJson</returns>
        public static ContentResult JsonResult(object jsonData)
        {
            var serializer = new JavaScriptSerializer();

            // For simplicity just use Int32's max value.
            // You could always read the value from the config section mentioned above.
            serializer.MaxJsonLength = Int32.MaxValue;

            var jsonResult = new ContentResult
            {
                Content = serializer.Serialize(jsonData),
                ContentType = "application/json"
            };

            return jsonResult;
        }

        /// <summary>
        /// Use JsonResult method to generate.
        /// This Object store Error Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ContentResult GenerateJsonError(String message)
        {
            var error = new { ErrorMessage = message };
            ContentResult jsonErrors = JsonHelper.JsonResult(error);

            return jsonErrors;
        }

        /// <summary>
        /// Use JsonResult method to generate.
        /// This Object store Error Message and Asp.Net Database Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dbError"></param>
        /// <returns></returns>
        public static ContentResult GenerateJsonError(String message, String dbError)
        {
            var error = new { ErrorMessage = message, dbError = dbError };
            ContentResult jsonErrors = JsonHelper.JsonResult(error);

            return jsonErrors;
        }
    }
}