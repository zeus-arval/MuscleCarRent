using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MuscleCarRentProject.Pages.Extensions
{
    public static class ShowHtml
    { 
        public static string Show<TVal, TRes> (TVal label, TRes value) => $"{label} {value}";

        public static TResult ShowFunction<TValue, TResult>(Func<TValue, TResult> func, TValue value)
        {
            return func(value);
        }

        public static TResult ShowExpression<TResult, TValue>(Expression<Func<TValue, TResult>> expression,
            TValue value)
        {
            var r = expression.Compile();
            return r.Invoke(value);
        }

        public static IHtmlContent Show<TModel, TResult>(
            this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TResult>> getMethod
            ) => Show(html, getMethod, getMethod);

        public static IHtmlContent Show<TModel, TResult1, TResult2>(
            this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TResult1>> getLabelMethod,
            Expression<Func<TModel, TResult2>> getValueMethod = null)
        {
            var labelStr = html.DisplayNameFor(getLabelMethod);
            var valueStr = (getValueMethod is null) 
                ? getValue(html, getLabelMethod) 
                : getValue(html, getValueMethod);
            return html.Show(labelStr, valueStr);
        }

        public static IHtmlContent Show<TModel>(this IHtmlHelper<TModel> html, string label, string value)
        {
            if (html == null) throw new ArgumentNullException(nameof(html));
            var s = htmlStrings(html, label, value);
            return new HtmlContentBuilder(s);
        }
         
        internal static List<object> htmlStrings<TModel>(IHtmlHelper<TModel> html, string label, string value)
        {
            return new List<object>
            {
                new HtmlString("<dt class=\"col-sm-2\">"),
                html.Raw(label),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.Raw(value),
                new HtmlString("</dd>")
            };
        }

        internal static string getValue<TModel, TResult>(IHtmlHelper<TModel> html,
            Expression<Func<TModel, TResult>> e)
        {
            var value = html.DisplayFor(e);
            var writer = new System.IO.StringWriter();
            value.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}
