using OnlineShopping.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.UI.HTMLhelpers
{
    public static class PageHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageurl) {

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++) {

                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageurl(i));
                
                tag.InnerHtml = i.ToString();

                if (i == pageInfo.CurrentPage) {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());

        }
    }
}