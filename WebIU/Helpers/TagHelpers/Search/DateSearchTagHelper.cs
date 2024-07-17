using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebIU.Helpers.TagHelpers.Search
{
   
    public class DateSearchTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression ModelName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

        }
    }
}
