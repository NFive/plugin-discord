using NFive.SDK.Core.Controllers;

namespace NFive.Discord.Shared
{
	public class Configuration : ControllerConfiguration
	{
		public string AppId { get; set; } = "520598603568250881";
		public string Description { get; set; } = "My server description";
		public string Logo { get; set; } = "logo";
		public string Text { get; set; } = "My Server";
		public string LogoSmall { get; set; } = "nfive";
		public string TextSmall { get; set; } = "Server powered by NFive";
	}
}
