using System.Windows;

namespace AtomWallpaper.Core.Wallpaper
{
	public partial class WallpaperWindow : Window
	{
		public WallpaperWindow()
		{
			InitializeComponent();

			// 加载网页
			WebBrowser.Load("https://www.google.com");
		}
	}
}
