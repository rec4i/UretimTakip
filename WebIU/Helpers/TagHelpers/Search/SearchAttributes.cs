using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebIU.Helpers.TagHelpers.Search
{
    public class SearchAttributes : TagHelper
    {
        [HtmlAttributeName("searchString")]
        public string? SearchString { get; set; }
        [HtmlAttributeName("page-number")]
        public int Page { get; set; }
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("item-count")]
        public int ItemCount { get; set; }
    }
}