using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMenu.Models;

namespace RestaurantMenu.Helpers
{
    public static class PageLinksC 
    {
        public static IHtmlContent PageLinks(this IHtmlHelper<TableViewModel> html, PageInfo pageInfo, DishSortState sortState,
            Func<int,  DishSortState, string> pageUrl)
        {
            string result;
            using (StringWriter writer = new StringWriter())
            {
                for (int i = 1; i <= pageInfo.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i, sortState));
                    tag.InnerHtml.Append(i.ToString());
                    if (i == pageInfo.PageNumber)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    tag.WriteTo(writer, HtmlEncoder.Default);
                }

                result = writer.ToString();
            }

            return new HtmlString(result);
        }
    }
}