using JetBrains.Annotations;
using NFive.Discord.Shared;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Server.Controllers;
using NFive.SDK.Server.Events;
using NFive.SDK.Server.Rcon;
using NFive.SDK.Server.Rpc;

namespace NFive.Discord.Server
{
	[PublicAPI]
	public class DiscordController : ConfigurableController<Configuration>
	{
		public DiscordController(ILogger logger, IEventManager events, IRpcHandler rpc, IRconManager rcon, Configuration configuration) : base(logger, events, rpc, rcon, configuration)
		{
			this.Rpc.Event(DiscordEvents.GetConfig).On(e => e.Reply(this.Configuration));
		}
	}
}
