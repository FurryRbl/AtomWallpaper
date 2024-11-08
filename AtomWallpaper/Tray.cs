using System.Reflection;

namespace AtomWallpaper
{
	internal class Tray : IDisposable
	{
		private bool disposed = false;
		private readonly NotifyIcon trayIcon;
		private readonly ContextMenuStrip trayMenu;

		public Tray()
		{
			trayMenu = new ContextMenuStrip();
			trayMenu.Items.Add("关于", null, new EventHandler(OnAbout!));
			trayMenu.Items.Add("退出", null, new EventHandler(OnExit!));

			trayIcon = new NotifyIcon
			{
				Text = "托盘应用",
				Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
				ContextMenuStrip = trayMenu,
				Visible = true
			};
		}

		private void OnAbout(object sender, EventArgs e)
		{
			MessageBox.Show("消息", "标题", MessageBoxButtons.OK);
		}

		private void OnExit(object sender, EventArgs e)
		{
			Application.Exit();
		}

		void IDisposable.Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					trayIcon.Dispose();
					trayMenu.Dispose();
				}
				disposed = true;
			}
		}

		~Tray()
		{
			Dispose(false);
		}
	}
}
