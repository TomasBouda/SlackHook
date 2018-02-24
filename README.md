<img src="https://raw.githubusercontent.com/TomasBouda/SlackHook/master/icon.png" height="64">

# SlackHook [![NuGet](https://img.shields.io/nuget/v/TomLabs.SlackHook.svg)](https://www.nuget.org/packages/TomLabs.SlackHook/) [![Discord](https://img.shields.io/badge/chat-on%20discord-orange.svg)](https://discord.gg/AFa3SzV)
Simple library for sending messages into Slack channels using Webhook.

## Install via NuGet

```
Install-Package TomLabs.SlackHook -Version 1.0.0
```

## Usage
**Synchronous call**
```cs
using TomLabs.SlackHook;

var client = new SlackClient("https://hooks.slack.com/services/XXXXXXXXX/XXXXXXXXX/xxxxxxxxxxxxxxxxxxxxxxxx");
bool result = await client.PostMessage("<https://api.slack.com/incoming-webhooks|See more info> and message text", "Info", "general", ":thumbsup:");
```

**Asynchronous call**
```cs
using TomLabs.SlackHook;

var client = new SlackClient("https://hooks.slack.com/services/XXXXXXXXX/XXXXXXXXX/xxxxxxxxxxxxxxxxxxxxxxxx");
bool result = await client.PostMessageAsync("<https://api.slack.com/incoming-webhooks|See more info> and message text", "Info", "general", ":thumbsup:");
```
Results in:
<img src="http://image.ibb.co/kbJ98H/slackhook.png">

## You like it?
* Go to [discord](https://discord.gg/AFa3SzV) and tell me :relaxed: I'm always glad when I see that my work helps someone
* Feel free to contribute, post issue, :star: it...

## Credits
* Inspired by [jogleasonjr](https://gist.github.com/jogleasonjr/7121367)
* Icon is made by [htdfc](http://www.how-to-draw-funny-cartoons.com)
