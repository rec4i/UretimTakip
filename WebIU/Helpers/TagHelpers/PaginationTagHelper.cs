using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace WebIU.Helpers.TagHelpers
{
    public class PaginationTagHelper : TagHelper
    {
        [HtmlAttributeName("page-number")]
        public int Page { get; set; }
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("item-count")]
        public int ItemCount { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            int page = this.Page;
            int pageSize = this.PageSize;
            int itemCount = this.ItemCount;

            int totalPage = (itemCount / pageSize) + 2;

            output.TagName = "nav";


            StringBuilder paginatonButtons = new StringBuilder();
            //<div class='p-2 bd-highlight'>
            paginatonButtons.Append("<div class='d-flex justify-content-between bd-highlight mb-3'>");
            paginatonButtons.Append("<div class='p-2 bd-highlight'>");
            paginatonButtons.Append("" +
                " <div class=\"dropdown show\">" +
                "                            <a class=\"btn btn-secondary dropdown-toggle\" href=\"#\" role=\"button\" id=\"dropdownMenuLink\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">" +
                "                                Page Size" +
                "                            </a>" +
                "                            <div class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink\">" +
                "                                <a class=\"dropdown-item\" href=\"" + GetQueryString(page, 1) + "\">1</a>" +
                "                                <a class=\"dropdown-item\" href=\"" + GetQueryString(page, 10) + "\">10</a>" +
                "                                <a class=\"dropdown-item\" href=\"" + GetQueryString(page, 25) + "\">25</a>" +
                "                                <a class=\"dropdown-item\" href=\"" + GetQueryString(page, 50) + "\">50</a>" +
                "                                <a class=\"dropdown-item\" href=\"" + GetQueryString(page, 100) + "\">100</a>" +
                "                            </div>" +
                "                        </div>" +
                "");
            paginatonButtons.Append("</div>");
            paginatonButtons.Append("<div class='p-2 bd-highlight'>");
            paginatonButtons.Append("<ul class='pagination justify-content-end'>");

            if (page == 1)
            {
                paginatonButtons.Append("<li class='page-item disabled'>");
                paginatonButtons.Append("<span class='page-link'>Previous</span>");
                paginatonButtons.Append("</li>");
            }
            else
            {
                paginatonButtons.Append("<li class='page-item'>");
                paginatonButtons.Append(" <a class='page-link' href='" + GetQueryString(page - 1, pageSize) + "' tabindex='-1'>Previous</a>");
                paginatonButtons.Append("</li>");
            }
            if (totalPage < 1)
            {
                paginatonButtons.Append("<li class='page-item active'>");
                paginatonButtons.Append("<span class='page-link'>" + page + "</span>");
                paginatonButtons.Append("</li>");
            }
            else
            {
                if (page <= totalPage)
                {
                    if (page == 1)
                    {
                        paginatonButtons.Append("<li class='page-item active'>");
                        paginatonButtons.Append("<span  class='page-link'>" + (page) + "</span>");
                        paginatonButtons.Append("</li>");
                    }
                    else
                    {
                        paginatonButtons.Append("<li class='page-item'><a class='page-link' href='" + GetQueryString((page - 1), pageSize) + "'>" + (page - 1) + "</a></li>");

                        paginatonButtons.Append("<li class='page-item active'>");
                        paginatonButtons.Append("<span  class='page-link'>" + (page) + "</span>");
                        paginatonButtons.Append("</li>");
                    }
                    for (int i = 1; i < 5; i++)
                    {
                        if ((page + i) < totalPage)
                        {
                            paginatonButtons.Append("<li class='page-item'><a class='page-link' href='" + GetQueryString((page + i), pageSize) + "'>" + (page + i) + "</a></li>");
                        }
                    }

                }




            }


            if (totalPage > page)
            {
                paginatonButtons.Append("<li class='page-item disabled'>");
                paginatonButtons.Append("<span class='page-link'>Next</span>");
                paginatonButtons.Append("</li>");
            }
            else
            {
                paginatonButtons.Append("<li class='page-item'>");
                paginatonButtons.Append(" <a class='page-link' href='" + GetQueryString(page + 1, pageSize) + "' tabindex='-1'>Next</a>");
                paginatonButtons.Append("</li>");
            }



            paginatonButtons.Append("</ul>");
            paginatonButtons.Append("</div>");
            paginatonButtons.Append("</div>");

            output.Content.SetHtmlContent(paginatonButtons.ToString());

        }

        private string GetQueryString(int page, int pageSize)
        {
            return "?pagesize=" + pageSize.ToString() + "&pagenumber=" + page;
        }
    }
}
