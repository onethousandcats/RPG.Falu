﻿using System.Web;
using System.Web.Optimization;

namespace RPG.Falu.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/responsive-tables.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/summernote.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/chosen.jquery.js",
                      "~/Scripts/chart.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-reset.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/responsive-tables.css",
                      "~/Content/font-awesome.css",
                      "~/Content/summernote.css",
                      "~/Content/chosen.css",
                      "~/Content/site.css"));
        }
    }
}