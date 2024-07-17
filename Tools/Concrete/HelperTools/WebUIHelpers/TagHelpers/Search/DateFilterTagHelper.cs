using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Tools.Concrete.HelperTools.WebUIHelpers.TagHelpers.Search
{
    public class DateFilterTagHelper : FilterFormTagHelper
    {
        [HtmlAttributeName("LabelString")]
        public string LabelString { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression Model { get; set; }

        [HtmlAttributeName("value")]
        public DateTime Value { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<label>" + LabelString + "</label>");
            string value = Convert.ToDateTime(Value).ToString("yyyy-MM-dd") == "0001-01-01" ? "" : Convert.ToDateTime(Value).ToString("yyyy-MM-dd");
            stringBuilder.Append("<input type='date' value='" + value + "' name='" + Model.Name + "' class='form-control' />");
            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}
