using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Clipboard = System.Windows.Clipboard;

namespace ClipToast;

public class ClipboardMonitor : IDisposable
{
    private readonly HwndSource _hwndSource;

    public event EventHandler<string>? ClipboardChanged;

    public ClipboardMonitor()
    {
        var hwnd = new WindowInteropHelper(new Window()).EnsureHandle();
        _hwndSource = HwndSource.FromHwnd(hwnd)!;
        _hwndSource.AddHook(WndProc);

        NativeMethods.AddClipboardFormatListener(_hwndSource.Handle);
    }

    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        const int wmClipboardupdate = 0x031D;

        if (msg != wmClipboardupdate) return IntPtr.Zero;
        
        if (Clipboard.ContainsText())
        {
            var text = Clipboard.GetText();
            ClipboardChanged?.Invoke(this, text);
        }
        handled = true;

        return IntPtr.Zero;
    }

    public void Dispose()
    {
        NativeMethods.RemoveClipboardFormatListener(_hwndSource.Handle);
        _hwndSource.RemoveHook(WndProc);
    }

    private static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
    }
}