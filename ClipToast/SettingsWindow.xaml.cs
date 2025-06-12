using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;

namespace ClipToast;

public partial class SettingsWindow : Window
{
    public SettingsWindow()
    {
        InitializeComponent();

        // Load available fonts
        FontComboBox.ItemsSource = Fonts.SystemFontFamilies;
        FontComboBox.SelectedItem = ToastSettings.FontFamily;
        FontSizeSlider.Value = ToastSettings.FontSize;

        FontColorBtn.Click += (_, _) => ToastSettings.FontColor = ChooseColor(ToastSettings.FontColor);
        BgColorBtn.Click += (_, _) => ToastSettings.BackgroundColor = ChooseColor(ToastSettings.BackgroundColor);
        BorderColorBtn.Click += (_, _) => ToastSettings.BorderColor = ChooseColor(ToastSettings.BorderColor);
    }

    private Color ChooseColor(Color defaultColor)
    {
        var dlg = new System.Windows.Forms.ColorDialog
        {
            Color = System.Drawing.Color.FromArgb(defaultColor.A, defaultColor.R, defaultColor.G, defaultColor.B)
        };

        if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            return Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B);
        }

        return defaultColor;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (FontComboBox.SelectedItem is FontFamily selectedFont)
        {
            ToastSettings.FontFamily = selectedFont;
        }

        ToastSettings.FontSize = FontSizeSlider.Value;

        Close();
    }
}