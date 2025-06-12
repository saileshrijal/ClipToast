using System.Windows;
using Application = System.Windows.Application;

namespace ClipToast;

public partial class App : Application
{
    private ClipboardMonitor? _clipboardMonitor;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Don’t open any window unless user clicks “Settings”
        SystemTray.Initialize();

        // Hide the main window
        ShutdownMode = ShutdownMode.OnExplicitShutdown;

        // Start clipboard monitor
        _clipboardMonitor = new ClipboardMonitor();
        _clipboardMonitor.ClipboardChanged += OnClipboardChanged;
    }

    private static void OnClipboardChanged(object? sender, string copiedText)
    {
        ToastNotification.Show("Copied to clipboard");
    }
}