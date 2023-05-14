using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Cryptography.X509Certificates;

namespace deepro.BookStore.Helper
{
    [HtmlTargetElement("big")]
    [HtmlTargetElement(Attributes = "big")]

    public class BIgTagHelpercs: TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h3";
            output.Attributes.RemoveAll("big");
            output.Attributes.SetAttribute("class", "h3");
        }
    }
}
