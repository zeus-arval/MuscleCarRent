﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuscleCarRentProject.Aids;

namespace MuscleCarRentProject.Core.Extensions
{
    public static class SelectHtml
    {
        public static IHtmlContent Select<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e,
            IEnumerable<SelectListItem> selectList, string optionLabel)
            => Select(h, e, e, selectList, optionLabel);

        public static IHtmlContent Select<TModel, TResult1, TResult2>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult1>> label,
            Expression<Func<TModel, TResult2>> value, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            var n = h.DisplayNameFor(label);
            return Select(h, value, selectList, optionLabel, n);
        }
        public static IHtmlContent Select<TModel, TResult>(this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e, IEnumerable<SelectListItem> selectList, string optionLabel, string displayName)
        {
            var s = htmlStrings(h, e, selectList, optionLabel, displayName);
            return new HtmlContentBuilder(s);
        }
        internal static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e, IEnumerable<SelectListItem> selectList, string optionLabel, string displayName)
        {
            var l = new List<object>();
            Safe.Run(() => {
                l.Add(new HtmlString("<dt class=\"col-sm-2\">"));
                l.Add(h.Raw(displayName));
                l.Add(new HtmlString("</dt>"));
                l.Add(new HtmlString("<dd class=\"col-sm-10\">"));
                l.Add(h.DropDownListFor(e, selectList, optionLabel, new { @class = "form-control" }));
                l.Add(h.ValidationMessageFor(e, "", new { @class = "text-danger" }));
                l.Add(new HtmlString("</dd>"));
            });
            return l;
        }
    }
}
