using System.IO;
using CefSharp;
using CefSharp.Wpf;

namespace AtomWallpaper.Core.Wallpaper
{
	internal static class Loader
	{
		internal static void Load(string WallpaperPath)
		{
			if (Cef.IsInitialized != true)
			{
				CefSettings setting =
					new()
					{
						Locale = "zh-CN", // 设置语言环境为简体中文
						CachePath = Path.Combine(Directory.GetCurrentDirectory(), ".data", "web"), // 设置数据存储位置
					};

				Cef.Initialize(setting);
			}

			// 显示壁纸窗口
			WallpaperWindow wallpaperWindow = new();
			wallpaperWindow.Show();
		}
	}
}
