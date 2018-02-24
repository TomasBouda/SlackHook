using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TomLabs.SlackHook
{
	/// <summary>
	/// Simple class that allows you to post messages to Slack channels
	/// </summary>
	public class SlackClient
	{
		private readonly Uri _uri;
		public string Url => _uri.AbsoluteUri;

		/// <summary>
		/// Initializes new instance of <see cref="SlackClient"/> using webhook url
		/// <para>For more information see https://api.slack.com/incoming-webhooks</para>
		/// </summary>
		/// <param name="url"></param>
		public SlackClient(string url)
		{
			_uri = new Uri(url);
		}

		/// <summary>
		/// Post <paramref name="message"/> to slack <paramref name="channel"/> asynchronously
		/// </summary>
		/// <param name="message">Message to send</param>
		/// <param name="username">Username that will be shown in slack</param>
		/// <param name="channel">Channel to post message into</param>
		/// <param name="iconEmoji">Icon that will be shown in slack e.g. :monkey_face:</param>
		/// <returns><c>true</c> if successfully posted</returns>
		public async Task<bool> PostMessageAsync(string message, string username = null, string channel = null, string iconEmoji = null)
		{
			using (WebClient client = new WebClient())
			{
				var response = await client.UploadValuesTaskAsync(_uri, "POST", PrepareData(message, username, channel, iconEmoji));

				return Encoding.UTF8.GetString(response) == "ok";
			}
		}

		/// <summary>
		/// Post <paramref name="message"/> to slack <paramref name="channel"/>
		/// </summary>
		/// <param name="message">Message to send</param>
		/// <param name="username">Username that will be shown in slack</param>
		/// <param name="channel">Channel to post message into</param>
		/// <param name="iconEmoji">Icon that will be shown in slack e.g. :monkey_face:</param>
		/// <returns><c>true</c> if successfully posted</returns>
		public bool PostMessage(string message, string username = null, string channel = null, string iconEmoji = null)
		{
			using (WebClient client = new WebClient())
			{
				var response = client.UploadValues(_uri, "POST", PrepareData(message, username, channel, iconEmoji));

				return Encoding.UTF8.GetString(response) == "ok";
			}
		}

		private NameValueCollection PrepareData(string message, string username = null, string channel = null, string iconEmoji = null)
		{
			NameValueCollection data = new NameValueCollection();
			data["payload"] = SlackPayload.Create(message, username, channel, iconEmoji).ToJson();

			return data;
		}
	}
}
