using System.IO;

namespace AtomWallpaper
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length <= 0)
			{
				MessageBox.Show("请给定壁纸文件夹参数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(1);
			}

			string WallpaperPath = Path.GetFullPath(args[0]);
			if (!Directory.Exists(WallpaperPath))
			{
				MessageBox.Show("壁纸目录不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(2);
			}
			else if (!File.Exists(Path.Combine(WallpaperPath, "index.html")))
			{
				MessageBox.Show("在壁纸目录内找不到“index.html”文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(2);
			}

			Thread trayThread =
				new(() =>
				{
					var tray = new Tray(); // 创建托盘图标
					Core.Wallpaper.Loader.Load(WallpaperPath); // 加载壁纸
					Application.Run();
				});
			trayThread.SetApartmentState(ApartmentState.STA);
			trayThread.Start();
		}
	}
}
