using System.Windows.Media;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;

namespace ClipToast;

public static class ToastSettings
{
    public static FontFamily FontFamily { get; set; } = new("Segoe UI");
    public static double FontSize { get; set; } = 14;
    public static Color FontColor { get; set; } = Colors.Black;
    public static Color BackgroundColor { get; set; } = Color.FromRgb(240, 244, 255); // Light blue
    public static Color BorderColor { get; set; } = Color.FromRgb(51, 153, 255); // Blue
}