using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace CloneProject.Control
{
    public class BaseWindow : Window
    {
        private AppWindow _appWindow;

        public int Width
        {
            get => _appWindow.Size.Width;
            set => _appWindow.Resize(new(value, Height));
        }

        public int Height
        {
            get => _appWindow.Size.Height;
            set => _appWindow.Resize(new(Width, value));
        }

        public AppWindowPresenterKind Presenter
        {
            get => _appWindow.Presenter.Kind;
            set => _appWindow.SetPresenter(value);
        }

        public string Icon
        {
            set
            {
                _appWindow.SetIcon(value);
            }
        }

        public BaseWindow()
        {
            _appWindow = GetAppWindowForCurrentWidow();

            InitTitleButton();
        }

        private void InitTitleButton()
        {
            _appWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            _appWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            _appWindow.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            _appWindow.TitleBar.ButtonHoverBackgroundColor = ColorHelper.FromArgb(51, 255, 255, 255);
            _appWindow.TitleBar.ButtonPressedBackgroundColor = ColorHelper.FromArgb(51, 255, 255, 255);

            _appWindow.TitleBar.ButtonForegroundColor = Colors.White;
            _appWindow.TitleBar.ButtonInactiveForegroundColor = Colors.White;
            _appWindow.TitleBar.ButtonHoverForegroundColor = Colors.White;
            _appWindow.TitleBar.ButtonPressedForegroundColor = Colors.White;
        }

        private AppWindow GetAppWindowForCurrentWidow()
        {
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var winId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(winId);
        }
    }
}
