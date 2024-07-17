using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection;

namespace WebIU.Helpers.TagHelpers.Search
{
    public class FooTagHelper : TagHelper
    {
         
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var x = context;
            var content = output.GetChildContentAsync().Result.GetContent();

        }
    }
}
