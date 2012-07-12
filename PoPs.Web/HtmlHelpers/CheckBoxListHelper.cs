using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace PoPs.Web.HtmlHelpers
{
    public static class CheckBoxListHelper
    {
        public static MvcHtmlString CheckBoxListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TEnum>>> expression, string ulClass = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var unobtrusiveValidationAttributes = htmlHelper.GetUnobtrusiveValidationAttributes(metadata.PropertyName, metadata);

            var html = new TagBuilder("ul");
            if (!String.IsNullOrEmpty(ulClass))
                html.MergeAttribute("class", ulClass);

            string innerhtml = "";
            var model = metadata.Model as IEnumerable<TEnum>;
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {

                bool ischecked = (model == null) ? false : model.Any(x => x.ToString() == item.ToString());

                var liBuilder = new TagBuilder("li");

                var inputBuilder = new TagBuilder("input");
                inputBuilder.MergeAttribute("type", "checkbox");
                inputBuilder.MergeAttribute("name", metadata.PropertyName, true);
                inputBuilder.MergeAttribute("id", item.ToString(), true);
                inputBuilder.MergeAttribute("value", item.ToString(), true);
                inputBuilder.MergeAttributes(unobtrusiveValidationAttributes);
                if (ischecked)
                {
                    inputBuilder.MergeAttribute("checked", "'checked'");
                }

                liBuilder.InnerHtml = inputBuilder.ToString() + htmlHelper.Label(metadata.PropertyName + "." + item, Enum.GetName(typeof(TEnum), item).ToString());
                innerhtml = innerhtml + liBuilder;

            }
            html.InnerHtml = innerhtml;
            return new MvcHtmlString(html.ToString());


        }

    }
}