#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	internal class TemplateRenderer
	{
		private readonly object _model;     // model object is kept generic but we force a kind of typing via constructors
		private readonly string _name;

		public TemplateRenderer(EmailIntroModel model)
		{
			_model = model;
			_name = "EmailIntroTemplate";
		}

		public TemplateRenderer(ReportModel model)
		{
			_model = model;
			_name = "ReportTemplate";
		}

		private string Render(string template)
		{
			var compile = Handlebars.Compile(template);
			var report = compile(_model);
			return report;
		}

		public string RenderPreset(TemplateFormat format = TemplateFormat.Text)
		{
			var template = GetTemplate(format);
			return this.Render(template);
		}

		public string RenderCustom(string template)
		{
			return this.Render(template);
		}

		private string GetTemplate(TemplateFormat format)
		{
			var resource = $"{this.GetType().Namespace}.{_name}.{format.ToString().ToLower()}";
			var assembly = Assembly.GetExecutingAssembly();

			using (var stream = assembly.GetManifestResourceStream(resource))
			{
				using (var reader = new StreamReader(stream ?? throw new InvalidOperationException($"resource not found: {resource}"), Encoding.UTF8))
				{
					var template = reader.ReadToEnd();
					return template;
				}
			}
		}
	}
}