using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using Tools.Concrete.HelperClasses.WebUIHelpers;

namespace Tools.Concrete.HelperTools.WebUIHelpers.TagHelpers.Search
{
    public class SearcBarTagHelper : SearchAttributes
    {
        [HtmlAttributeName("filters")]
        public bool? Filters { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            int page = 1;
            int pageSize = 1;
            int itemCount = 1;
            string searchString = SearchString;
            var innerContent = await output.GetChildContentAsync();
            var content = innerContent.GetContent();

            StringBuilder searcBarStringBuilder = new StringBuilder();
            searcBarStringBuilder.Append("<div class='row'>");
            searcBarStringBuilder.Append("<div class='col-md-12'>");
            searcBarStringBuilder.Append("<div class='collapse' id='FiltersDiv'>");
            searcBarStringBuilder.Append("<div class='card card-body'>" + content);
            searcBarStringBuilder.Append("</div>");
            searcBarStringBuilder.Append("</div>");






            output.Content.SetHtmlContent(searcBarStringBuilder.ToString());

            // base.ProcessAsync(context, output);
        }

        private string GetQueryString(int page, int pageSize, string searchString)
        {
            return "?pagesize=" + pageSize.ToString() + "&pagenumber=" + page + "&searchstring=" + searchString;
        }
    }
}
