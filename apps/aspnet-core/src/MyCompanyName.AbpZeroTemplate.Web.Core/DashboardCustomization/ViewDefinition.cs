﻿namespace MyCompanyName.AbpZeroTemplate.Web.DashboardCustomization
{
    public class ViewDefinition
    {
        public ViewDefinition(
            string id,
            string viewFile,
            string javascriptFile = null,
            string cssFile = null)
        {
            Id = id;
            ViewFile = viewFile;
            JavascriptFile = javascriptFile;
            CssFile = cssFile;
        }

        public string Id { get; protected set; }

        public string ViewFile { get; protected set; }

        public string JavascriptFile { get; protected set; }

        public string CssFile { get; protected set; }
    }
}