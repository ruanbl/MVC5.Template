﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Template.Components.Extensions.Html;
using Template.Resources;
using Template.Tests.Helpers;
using Template.Tests.Objects.Components.Extensions.Html;

namespace Template.Tests.Tests.Components.Extensions.Html
{
    [TestFixture]
    public class LoginExtensionsTests
    {
        private Expression<Func<BootstrapModel, String>> expression;
        private HtmlHelper<BootstrapModel> html;

        [SetUp]
        public void SetUp()
        {
            html = new HtmlHelperMock<BootstrapModel>().HtmlHelper;
            expression = null;
        }

        #region Extensions method: LoginUsernameFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, String>> expression)

        [Test]
        public void LoginUsernameFor_FormsLoginUsernameFor()
        {
            expression = (model) => model.Required;

            var addon = new TagBuilder("span");
            addon.AddCssClass("input-group-addon");
            var icon = new TagBuilder("i");
            icon.AddCssClass("fa fa-user");

            addon.InnerHtml = icon.ToString();
            var attributes = new RouteValueDictionary();
            attributes["class"] = "form-control";
            attributes["placeholder"] = ResourceProvider.GetPropertyTitle(expression);
            
            var expected = String.Format("{0}{1}", addon, html.TextBoxFor(expression, attributes));
            var actual = html.LoginUsernameFor(expression).ToString();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Extensions method: LoginPasswordFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, String>> expression)

        [Test]
        public void LoginPasswordFor_FormsLoginPasswordFor()
        {
            expression = (model) => model.Required;

            var addon = new TagBuilder("span");
            addon.AddCssClass("input-group-addon lock-span");
            var icon = new TagBuilder("i");
            icon.AddCssClass("fa fa-lock");

            addon.InnerHtml = icon.ToString();
            var attributes = new RouteValueDictionary();
            attributes["class"] = "form-control";
            attributes["placeholder"] = ResourceProvider.GetPropertyTitle(expression);

            var expected = String.Format("{0}{1}", addon, html.PasswordFor(expression, attributes));
            var actual = html.LoginPasswordFor(expression).ToString();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Extensions method: LoginLanguageSelect<TModel>(this HtmlHelper<TModel> html)

        [Test]
        public void LoginLanguageSelect_FormsLoginLanguageSelect()
        {
            var addon = new TagBuilder("span");
            addon.AddCssClass("input-group-addon flag-span");
            var icon = new TagBuilder("i");
            icon.AddCssClass("fa fa-flag");
            var input = new TagBuilder("input");
            input.MergeAttribute("id", "TempLanguage");
            input.MergeAttribute("type", "text");
            input.AddCssClass("form-control");
            var select = new TagBuilder("select");
            select.MergeAttribute("id", "Language");

            addon.InnerHtml = icon.ToString();
            var languages = new Dictionary<String, String>()
            {
                { "en-GB", "English" },
                { "lt-LT", "Lietuvių" }
            };
            foreach (var language in languages)
            {
                var option = new TagBuilder("option");
                option.MergeAttribute("value", language.Key);
                option.InnerHtml = language.Value;
                select.InnerHtml += option.ToString();
            }

            var expected = String.Format("{0}{1}{2}", addon, input, select);
            var actual = html.LoginLanguageSelect().ToString();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Extensions method: LoginSubmit<TModel>(this HtmlHelper<TModel> html)

        [Test]
        public void LoginSubmit_FormsLoginSubmit()
        {
            var formActions = new TagBuilder("div");
            formActions.AddCssClass("login-form-actions");
            var submit = new TagBuilder("input");
            submit.AddCssClass("btn btn-block btn-primary btn-default");
            submit.MergeAttribute("value", Template.Resources.Shared.Resources.Login);
            submit.MergeAttribute("type", "submit");
            formActions.InnerHtml = submit.ToString();

            var expected = formActions.ToString();
            var actual = html.LoginSubmit().ToString();

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}