using System;

namespace yesmarket.Templating.Razor
{
    public interface IRazorTemplateRenderer
    {
        string RenderTemplate(string templatePath, object model);
        string RenderTemplate(string templatePath, Type modelType, object model);
    }
}