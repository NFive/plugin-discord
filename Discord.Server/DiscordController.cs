using JetBrains.Annotations;
using NFive.Discord.Shared;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Communications;
using NFive.SDK.Server.Controllers;

namespace NFive.Discord.Server
{
	[PublicAPI]
	public class DiscordController : ConfigurableController<Configuration>
	{
		public DiscordController(ILogger logger, Configuration configuration, ICommunicationManager comms) : base(logger, configuration)
		{
			comms.Event(DiscordEvents.Configuration).FromClients().OnRequest(e => e.Reply(this.Configuration));
		}
	}
}
