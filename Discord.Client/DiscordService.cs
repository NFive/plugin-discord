using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.Discord.Shared;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Rpc;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using System;
using System.Threading.Tasks;

namespace NFive.Discord.Client
{
	[PublicAPI]
	public class DiscordService : Service
	{
		private Configuration config;

		public DiscordService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, ICommandManager commands, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, commands, overlay, user) { }

		public override async Task Started()
		{
			// Request server configuration
			this.config = await this.Rpc.Event(DiscordEvents.Configuration).Request<Configuration>();

			this.Logger.Debug("Configuration loaded");

			// Update local configuration on server configuration change
			this.Rpc.Event(DiscordEvents.Configuration).On<Configuration>((e, c) => this.config = c);

			// Attach a tick handler
			this.Ticks.Attach(async () =>
			{
				this.Logger.Debug("Setting Discord presence");

				API.SetDiscordAppId(this.config.AppId);
				API.SetRichPresence(this.config.Description);
				API.SetDiscordRichPresenceAsset(this.config.Large.Logo);
				API.SetDiscordRichPresenceAssetText(this.config.Large.Text);
				API.SetDiscordRichPresenceAssetSmall(this.config.Small.Logo);
				API.SetDiscordRichPresenceAssetSmallText(this.config.Small.Text);

				await Delay(TimeSpan.FromMinutes(1));
			});
		}
	}
}
