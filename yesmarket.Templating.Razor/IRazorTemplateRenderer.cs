using System;
using RazorEngine.Templating;

namespace yesmarket.Templating.Razor
{
    public interface IRazorTemplateRenderer
    {
        string RenderTemplate(FullPathTemplateKey templateKey, object model);
        string RenderTemplate(FullPathTemplateKey templateKey, Type modelType, object model);
    }
}