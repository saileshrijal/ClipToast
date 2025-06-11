using Application = System.Windows.Application; // resolve conflict

namespace ClipToast;

public static class SystemTray
{
    private static NotifyIcon? _notifyIcon;

    public static void Initialize()
    {
        _notifyIcon = new NotifyIcon
        {
            Icon = SystemIcons.Information,
            Visible = true,
            Text = "ClipToast"
        };

        // Use ContextMenuStrip instead of ContextMenu
        var contextMenu = new ContextMenuStrip();
        var exitItem = new ToolStripMenuItem("Exit");
        exitItem.Click += (_, _) => Application.Current.Shutdown();
        contextMenu.Items.Add(exitItem);

        _notifyIcon.ContextMenuStrip = contextMenu;
    }
}