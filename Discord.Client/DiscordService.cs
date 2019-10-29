using System;
using System.Threading.Tasks;
using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.Discord.Shared;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Communications;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;

namespace NFive.Discord.Client
{
	[PublicAPI]
	public class DiscordService : Service
	{
		private Configuration config;

		public DiscordService(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlay, User user) : base(logger, ticks, comms, commands, overlay, user) { }

		public override async Task Started()
		{
			this.config = await this.Comms.Event(DiscordEvents.Configuration).ToServer().Request<Configuration>();

			this.Ticks.On(OnTick);
		}

		private async Task OnTick()
		{
			this.Logger.Debug("Setting Discord presence");

			API.SetDiscordAppId(this.config.AppId);
			API.SetRichPresence(this.config.Description);
			API.SetDiscordRichPresenceAsset(this.config.Images.Large.Asset);
			API.SetDiscordRichPresenceAssetText(this.config.Images.Large.Text);
			API.SetDiscordRichPresenceAssetSmall(this.config.Images.Small.Asset);
			API.SetDiscordRichPresenceAssetSmallText(this.config.Images.Small.Text);

			await Delay(TimeSpan.FromMinutes(1));
		}
	}
}
