using System;
using RazorEngine;
using RazorEngine.Templating;

namespace yesmarket.Templating.Razor
{
    public class DefaultRazorTemplateRenderer : IRazorTemplateRenderer
    {
        private readonly ITemplateManager _templateManager;

        public DefaultRazorTemplateRenderer(ITemplateManager templateManager)
        {
            _templateManager = templateManager;
        }

        public string RenderTemplate(string templatePath, object model)
        {
            return RenderTemplate(templatePath, null, model);
        }

        public string RenderTemplate(string templatePath, Type modelType, object model)
        {
            var key = new FullPathTemplateKey(null, templatePath, ResolveType.Layout, null);
            var templateSource = _templateManager.Resolve(key);
            var result = Engine.Razor.RunCompile(templateSource, key, modelType, model);
            return result;
        }
    }
}
