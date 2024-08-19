using Microsoft.UI.Xaml;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebView2OverlayControlTest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            InitWebView();
        }

        private async void InitWebView()
        {
            await this.webView.EnsureCoreWebView2Async();

            this.webView.CoreWebView2.Settings.IsScriptEnabled = true;
            this.webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
        }
    }
}
