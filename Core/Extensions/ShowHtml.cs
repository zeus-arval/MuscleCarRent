﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MuscleCarRentProject.Core.Extensions
{
    public static class ShowHtml
    {
        public static IHtmlContent Show<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e
        ) => Show(h, e, e);

        public static IHtmlContent Show<TModel, TResult1>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult1>> label,
            object value)
        {
            var labelStr = h.DisplayNameFor(label);
            return h.Show(labelStr, value.ToString());
        }
        public static IHtmlContent Show<TModel, TResult1, TResult2>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult1>> label,
            Expression<Func<TModel, TResult2>> value = null)
        {
            var labelStr = h.DisplayNameFor(label);
            var valueStr = (value is null)
                ? getValue(h, label)
                : getValue(h, value);
            return h.Show(labelStr, valueStr);
        }
        public static IHtmlContent Show<TModel>(
            this IHtmlHelper<TModel> h, string label, string value)
        {
            if (h == null) throw new ArgumentNullException(nameof(h));
            var s = htmlStrings(h, label, value);
            return new HtmlContentBuilder(s);
        }
        internal static List<object> htmlStrings<TModel>(
            IHtmlHelper<TModel> h, string label, string value)
        {
            return HtmlStrings(
                h.Raw(label),
                h.Raw(value)
                );
        }
        internal static string getValue<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var value = h.DisplayFor(e);
            var writer = new System.IO.StringWriter();
            value.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
        public static List<object> HtmlStrings(object label, object value)
        {
            return new()
            {
                new HtmlString("<dt class=\"col-sm-2\">"),
                label,
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                value,
                new HtmlString("</dd>")
            };
        }
    }
}