using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace RazorLight.Tests.Integrational
{
	public class BufferTruncationTests
	{
		private readonly ITestOutputHelper _testOutputHelper;

		public BufferTruncationTests(ITestOutputHelper testOutputHelper)
		{
			_testOutputHelper = testOutputHelper;
		}
		public class ViewModel
		{
			public string Name;
		}

		[Fact]
		public void EnsurePartialsDoNotTruncateReturnedView()
		{
			var engine = new RazorLightEngineBuilder()
				.UseEmbeddedResourcesProject(typeof(Root).Assembly)
				.UseMemoryCachingProvider()
				.Build();

			string result = engine.CompileRenderAsync("Assets.Embedded.IncludeAsyncViewModel.cshtml", new ViewModel { Name = "John Doe" }).Result;

			_testOutputHelper.WriteLine(result);
		}
	}
}
