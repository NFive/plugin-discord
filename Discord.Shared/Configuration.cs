using NFive.SDK.Core.Controllers;

namespace NFive.Discord.Shared
{
	public class Configuration : ControllerConfiguration
	{
		public string AppId { get; set; } = "520598603568250881";

		public string Description { get; set; } = "My server description";

		public ImageConfiguration Images { get; set; } = new ImageConfiguration
		{
			Large = new IconConfiguration
			{
				Asset = "logo",
				Text = "My Server"
			},
			Small = new IconConfiguration
			{
				Asset = "nfive",
				Text = "Server powered by NFive"
			},
		};

		public class ImageConfiguration
		{
			public IconConfiguration Large { get; set; }

			public IconConfiguration Small { get; set; }
		}

		public class IconConfiguration
		{
			public string Asset { get; set; }

			public string Text { get; set; }
		}
	}
}
