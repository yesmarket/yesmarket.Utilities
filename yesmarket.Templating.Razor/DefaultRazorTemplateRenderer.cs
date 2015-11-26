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

        public string RenderTemplate(FullPathTemplateKey templateKey, object model)
        {
            return RenderTemplate(templateKey, null, model);
        }

        public string RenderTemplate(FullPathTemplateKey templateKey, Type modelType, object model)
        {
            var templateSource = _templateManager.Resolve(templateKey);
            var result = Engine.Razor.RunCompile(templateSource, templateKey, modelType, model);
            return result;
        }
    }
}
