using NFive.SDK.Core.Controllers;

namespace NFive.Discord.Shared
{
	public class Configuration : ControllerConfiguration
	{
		public string AppId { get; set; } = "520598603568250881";

		public string Description { get; set; } = "My server description";

		public IconConfiguration Large { get; set; } = new IconConfiguration
		{
			Logo = "logo",
			Text = "My Server"
		};

		public IconConfiguration Small { get; set; } = new IconConfiguration
		{
			Logo = "nfive",
			Text = "Server powered by NFive"
		};

		public class IconConfiguration
		{
			public string Logo { get; set; }

			public string Text { get; set; }
		}
	}
}
