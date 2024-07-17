using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using Tools.Concrete.HelperClasses.WebUIHelpers;

namespace Tools.Concrete.HelperTools.WebUIHelpers.TagHelpers.Search
{
    public class FilterFormTagHelper :  FilterAttributes
    {
        [HtmlAttributeName("action")]
        public string Action { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            string action = Action;
            var innerContent = await output.GetChildContentAsync();
            var content = innerContent.GetContent();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<form ddddd action='" + action + "'>");
            stringBuilder.Append(content);
            stringBuilder.Append("</form>");
            output.Content.SetHtmlContent(stringBuilder.ToString());

          // base.ProcessAsync(context, output);
        }
    
    }
}
