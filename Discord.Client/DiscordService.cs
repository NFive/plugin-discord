using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.Discord.Shared;
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
		public DiscordService(ILogger logger, ITickManager ticks, IEventManager events, IRpcHandler rpc, OverlayManager overlay, User user) : base(logger, ticks, events, rpc, overlay, user) { }

		public override async Task Started()
		{
			var config = await this.Rpc.Event(DiscordEvents.GetConfig).Request<Configuration>();

			this.Logger.Debug("Configuration loaded");

			this.Ticks.Attach(async () =>
			{
				this.Logger.Debug("Setting Discord presence");

				API.SetDiscordAppId(config.AppId);
				API.SetRichPresence(config.Description);
				API.SetDiscordRichPresenceAsset(config.Logo);
				API.SetDiscordRichPresenceAssetText(config.Text);
				API.SetDiscordRichPresenceAssetSmall(config.LogoSmall);
				API.SetDiscordRichPresenceAssetSmallText(config.TextSmall);

				await this.Delay(TimeSpan.FromMinutes(1));
			});
		}
	}
}
