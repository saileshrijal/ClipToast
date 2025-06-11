using System.Windows;
using Application = System.Windows.Application;

namespace ClipToast;

public partial class ToastNotification
{
    public ToastNotification(string message)
    {
        InitializeComponent();
        ToastText.Text = message;

        Loaded += (_, _) =>
        {
            var screen = SystemParameters.WorkArea;
            Left = screen.Right - Width - 10;
            Top = screen.Bottom - Height - 10;
        };

        Task.Delay(1500).ContinueWith(_ =>
        {
            Dispatcher.Invoke(Close);
        });
    }

    public static void Show(string message)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            new ToastNotification(message).Show();
        });
    }
}