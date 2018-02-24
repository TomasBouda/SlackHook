using Newtonsoft.Json;

namespace TomLabs.SlackHook
{
	public class SlackPayload
	{
		[JsonProperty("text")]
		public string Message { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("channel")]
		public string Channel { get; set; }

		[JsonProperty("icon_emoji")]
		public string IconEmoji { get; set; }

		public SlackPayload(string message, string username = null, string channel = null, string iconEmoji = null)
		{
			Message = message;
			Username = username;
			Channel = channel;
			IconEmoji = iconEmoji;
		}

		public static SlackPayload Create(string message, string username = null, string channel = null, string iconEmoji = null)
		{
			return new SlackPayload(message, username, channel, iconEmoji);
		}

		public static string CreateLink(string url, string text)
		{
			return $"<{url}|{text}>";
		}

		public string ToJson()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
