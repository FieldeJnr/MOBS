using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Linq;

namespace Mobs.Web
{
    public static class Helpers
    {
        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors = false)
        {
            if (htmlHelper.ViewData.ModelState.IsValid)
                return new MvcHtmlString(string.Empty);
            var output =  htmlHelper.ValidationSummary(excludePropertyErrors);
            return new MvcHtmlString($"<div class='alert alert-danger'><h5>There was an error:</h5>{output}</div>");
        }
    }
}