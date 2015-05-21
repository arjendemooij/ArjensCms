using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Cms.Views
{
    public static class HtmlEditExtensions
    {
        public static MvcHtmlString EditRowFor<TModel, TValue>(this HtmlHelper<TModel> html,
                                                               Expression<Func<TModel, TValue>> expression)
        {
            string resultString = string.Format("<div>{0}</div><div>{1}{2}</div>", html.LabelFor(expression),
                                                html.EditorFor(expression), html.ValidationMessageFor(expression));
            return MvcHtmlString.Create(resultString);
        }

    }
}