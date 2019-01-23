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
			// Send configuration when requested
			this.Rpc.Event(DiscordEvents.Configuration).On(e => e.Reply(this.Configuration));
		}

		public override void Reload(Configuration configuration)
		{
			// Update local configuration
			base.Reload(configuration);

			// Send out new configuration
			this.Rpc.Event(DiscordEvents.Configuration).Trigger(this.Configuration);
		}
	}
}
