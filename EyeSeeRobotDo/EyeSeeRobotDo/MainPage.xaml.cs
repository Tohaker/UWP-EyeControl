using Microsoft.Toolkit.Uwp.Input.GazeInteraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace EyeSeeRobotDo
{
    /// <summary>
    /// The Main Page that launches when the App opens.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;

            GazeInput.IsDeviceAvailableChanged += GazeInput_IsDeviceAvailableChanged;
            GazeInput_IsDeviceAvailableChanged(null, null);
        }

        private void GazeInput_IsDeviceAvailableChanged(object sender, object e)
        {
            DeviceAvailable.Text = GazeInput.IsDeviceAvailable ? "Eye tracker device available" : "No eye tracker device available";
        }

        private void OnStateChanged(object sender, StateChangedEventArgs ea)
        {
            Dwell.Text = ea.PointerState.ToString();
        }

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ControlSelectionMenu.IsPaneOpen = !ControlSelectionMenu.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (ControlsFrame.CanGoBack) ControlsFrame.GoBack();
        }

        private void SettingsPanelButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsPanel.IsPaneOpen = !SettingsPanel.IsPaneOpen;
        }

        private void ControlSelectionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 1;
        }
    }
}
