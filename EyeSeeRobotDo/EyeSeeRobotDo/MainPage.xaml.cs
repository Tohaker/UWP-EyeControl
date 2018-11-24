using Microsoft.Toolkit.Uwp.Input.GazeInteraction;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Timers;
using Windows.Devices.Input.Preview;
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

        private void DwellProgress(object sender, DwellProgressEventArgs e)
        {
            var target = sender as FrameworkElement;
            if (target == null) return;

            // Find out where to render the dwell indicator
            var targetPosition = target.TransformToVisual(_gazeMarker).TransformPoint(new Point(0, 0));
            var targetWidth = target.ActualWidth;
            var targetHeight = target.ActualHeight;

            // Set the size
            var maxRadius = Math.Min(targetWidth, targetHeight);
            var radius = Math.Min(maxRadius / 1.61803398875, 100);
            _dwell.Width = radius;
            _dwell.Height = radius;
            _dwellPosition.X = targetPosition.X + (targetWidth - _dwell.Width) / 2;
            _dwellPosition.Y = targetPosition.Y + (targetHeight - _dwell.Height) / 2;
            _dwellScale.CenterX = _dwell.Width / 2;
            _dwellScale.CenterY = _dwell.Height / 2;
            _dwellScale.ScaleX = 1.0f - e.Progress;
            _dwellScale.ScaleY = 1.0f - e.Progress;

            // Set the color and visibility of the indicator
            switch (e.State)
            {
                case DwellProgressState.Fixating:
                    _dwell.Visibility = Visibility.Visible;
                    _dwell.Fill = GazeInput.DwellFeedbackEnterBrush;
                    break;
                case DwellProgressState.Progressing:
                    _dwell.Visibility = Visibility.Visible;
                    _dwell.Fill = GazeInput.DwellFeedbackProgressBrush;
                    break;
                case DwellProgressState.Complete:
                    _dwell.Visibility = Visibility.Visible;
                    _dwell.Fill = GazeInput.DwellFeedbackCompleteBrush;
                    break;
                case DwellProgressState.Idle:
                    _dwell.Visibility = Visibility.Collapsed;
                    break;
            }

            // And tell the interaction library that you handled the event
            e.Handled = true;
        }

        private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ControlSelectionMenu.IsPaneOpen = !ControlSelectionMenu.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //if (ControlsFrame.CanGoBack) ControlsFrame.GoBack();
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
