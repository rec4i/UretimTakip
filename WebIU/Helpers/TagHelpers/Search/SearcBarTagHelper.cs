using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace WebIU.Helpers.TagHelpers.Search
{
    public class SearcBarTagHelper : SearchAttributes
    {


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            int page = Page;
            int pageSize = PageSize;
            int itemCount = ItemCount;
            string searchString = SearchString;

            StringBuilder searcBarStringBuilder = new StringBuilder();
            var content = output.GetChildContentAsync().Result.GetContent();
            searcBarStringBuilder.Append("<div class='row'>");
            searcBarStringBuilder.Append("<div class='col-md-9'></div>");
            searcBarStringBuilder.Append("<div class='col-md-3'>");
            searcBarStringBuilder.Append("<form action='Index'>");
            searcBarStringBuilder.Append("<input type='hidden' id='pagesize' name='pagesize' value='" + pageSize + "'>");
            searcBarStringBuilder.Append("<input type='hidden' id='pagenumber' name='pagenumber' value='" + page + "'>");
            searcBarStringBuilder.Append("<div class='input-group'>");
            searcBarStringBuilder.Append("<input class='form-control form-control' name='searchstring' value='" + searchString + "' type='search' placeholder='Type your keywords'>");
            searcBarStringBuilder.Append("<div class='input-group-append'>");
            searcBarStringBuilder.Append("<button type='submit' class='btn btn btn-default'>");
            searcBarStringBuilder.Append("<i class='fa fa-search'></i>");
            searcBarStringBuilder.Append("</button>");
            searcBarStringBuilder.Append("<button onclick='return false;' class='btn btn btn-default' data-toggle='collapse' data-target='#Filters' aria-expanded='false' aria-controls='Filters' >");
            searcBarStringBuilder.Append("<i class='nav-icon fas fa-table'></i> Filters");
            searcBarStringBuilder.Append("</button>");
            searcBarStringBuilder.Append("</div>");
            searcBarStringBuilder.Append("</div>");
            searcBarStringBuilder.Append("</div>");
            searcBarStringBuilder.Append("</div>" + content);




            output.Content.SetHtmlContent(searcBarStringBuilder.ToString());

        }

        private string GetQueryString(int page, int pageSize, string searchString)
        {
            return "?pagesize=" + pageSize.ToString() + "&pagenumber=" + page + "&searchstring=" + searchString;
        }
    }
}
