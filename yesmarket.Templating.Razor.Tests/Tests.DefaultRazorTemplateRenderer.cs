using System;
using System.Collections.Generic;
using System.IO;
using NSubstitute;
using RazorEngine.Templating;
using SharpTestsEx;
using Xunit;

namespace yesmarket.Templating.Razor.Tests
{
    public class DefaultRazorTemplateRendererTests
    {
        [Fact]
        public void RenderTemplate_ValidRazorTemplate_ResultCorrectlyRendered()
        {
            var templateManager = new ResolvePathTemplateManager(new[] {Path.Combine(Environment.CurrentDirectory, "Templates")});
            var sut = new DefaultRazorTemplateRenderer(templateManager);

            var str = Guid.NewGuid().ToString();
            var result = sut.RenderTemplate(Path.Combine(Environment.CurrentDirectory, @"Templates\test.cshtml"), new {Test = str});

            result.Should().Contain(str);
        }
    }
}
