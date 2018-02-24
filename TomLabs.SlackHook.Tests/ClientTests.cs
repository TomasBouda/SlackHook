using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TomLabs.SlackHook.Tests
{
	[TestClass]
	public class ClientTests
	{
		[TestMethod]
		public async Task TestPostAsync()
		{
			var client = new SlackClient("https://hooks.slack.com/services/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");
			var res = await client.PostMessageAsync("<https://api.slack.com/incoming-webhooks|See more info>", "Info", iconEmoji: ":thumbsup:");
			Assert.IsTrue(res);
		}
	}
}
