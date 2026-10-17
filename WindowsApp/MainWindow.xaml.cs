using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;

namespace NovaBrowser;

public partial class MainWindow : Window
{
    private const string HomeUrl = "https://www.bing.com";
    private const string CopilotUrl = "https://copilot.microsoft.com/";

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await Browser.EnsureCoreWebView2Async();
            Browser.CoreWebView2.NavigationStarting += (_, args) =>
            {
                AddressBox.Text = args.Uri;
                StatusText.Text = "Loading...";
            };
            Browser.CoreWebView2.NavigationCompleted += (_, args) =>
            {
                StatusText.Text = args.IsSuccess ? "Ready" : $"Navigation failed: {args.WebErrorStatus}";
            };
            Browser.Source = new Uri(HomeUrl);
        }
        catch (Exception exception)
        {
            StatusText.Text = $"Browser startup failed: {exception.Message}";
            MessageBox.Show(this,
                $"Nova Browser could not start its web engine.\n\n{exception.Message}\n\nInstall the Microsoft Edge WebView2 Runtime and try again.",
                "Nova Browser startup error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void NavigateFromAddress()
    {
        string input = AddressBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(input))
        {
            StatusText.Text = "Enter a web address or search phrase.";
            return;
        }

        Uri destination;
        if (Uri.TryCreate(input, UriKind.Absolute, out Uri? absoluteUri)
            && (absoluteUri.Scheme == Uri.UriSchemeHttp || absoluteUri.Scheme == Uri.UriSchemeHttps))
        {
            destination = absoluteUri;
        }
        else if (!input.Contains(' ') && input.Contains('.')
                 && Uri.TryCreate($"https://{input}", UriKind.Absolute, out Uri? webAddress))
        {
            destination = webAddress;
        }
        else
        {
            destination = new Uri($"https://www.bing.com/search?q={Uri.EscapeDataString(input)}");
        }

        Browser.Source = destination;
    }

    private void Go_Click(object sender, RoutedEventArgs e) => NavigateFromAddress();

    private void AddressBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            NavigateFromAddress();
            e.Handled = true;
        }
    }

    private void Back_Click(object sender, RoutedEventArgs e)
    {
        if (Browser.CoreWebView2?.CanGoBack == true) Browser.CoreWebView2.GoBack();
    }

    private void Forward_Click(object sender, RoutedEventArgs e)
    {
        if (Browser.CoreWebView2?.CanGoForward == true) Browser.CoreWebView2.GoForward();
    }

    private void Reload_Click(object sender, RoutedEventArgs e) => Browser.Reload();
    private void Home_Click(object sender, RoutedEventArgs e) => Browser.Source = new Uri(HomeUrl);

    private void OpenCopilot_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo(CopilotUrl) { UseShellExecute = true });
        }
        catch (Exception exception)
        {
            StatusText.Text = $"Could not open Copilot: {exception.Message}";
        }
    }
}
