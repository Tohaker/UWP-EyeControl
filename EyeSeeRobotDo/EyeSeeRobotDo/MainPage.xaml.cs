using Microsoft.Toolkit.Uwp.Input.GazeInteraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        private GazeElement gazeButtonControl;

        public MainPage()
        {
            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;
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

        }
    }
}
