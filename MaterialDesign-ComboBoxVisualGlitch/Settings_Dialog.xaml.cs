// Author: Andy Bond
// Date:   12/20/2016

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace MaterialDesign_ComboBoxVisualGlitch
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings_Dialog : UserControl
    {

        #region Private Variables

        // List of Settings Pages
        private List<NavigationListBoxItem> settings_pages = new List<NavigationListBoxItem>();

        // Settings Pages to be DataBound
        public List<NavigationListBoxItem> Settings_Pages{ get { return settings_pages; } }

        // Save the Original Values of Settings when Dialog is Created
        // These will be checked against when the dialog closes to see if changes occurred
        private bool original_theme = Properties.Settings.Default.Palette_IsDark;
        private string original_primary = Properties.Settings.Default.Palette_PrimaryColor;
        private string original_accent = Properties.Settings.Default.Palette_AccentColor;
        private string original_filetype = Properties.Settings.Default.FileTypeSelection;

        #endregion

        #region Constructor

        // Constructor
        public Settings_Dialog()
        {
            InitializeComponent();

            // Create and Add Settings Pages
            NavigationListBoxItem color_palette = new NavigationListBoxItem("Color Palette", "Palette", new Settings_ColorPalette(), 0, false);
            NavigationListBoxItem report_settings = new NavigationListBoxItem("Report Settings", "ClipboardText", new Settings_ReportSettings(), 1, false);
            Settings_Pages.Add(color_palette);
            Settings_Pages.Add(report_settings);

            // Set up Size
            Width = Application.Current.MainWindow.ActualWidth * .5;
            Height = Application.Current.MainWindow.ActualHeight * .5;

            Settings_LB.SelectedIndex = 0;
        }

        #endregion

        #region Helper Functions

        // Function to Check if Settings have Changed
        // Sets a CommandParameter for use when Dialog Closes (much like a DialogResult)
        private void CheckSettingsChanged()
        {
            // Check if Any Settings has Changed
            bool theme_changed = original_theme != Properties.Settings.Default.Palette_IsDark;
            bool primary_changed = original_primary != Properties.Settings.Default.Palette_PrimaryColor;
            bool accent_changed = original_accent != Properties.Settings.Default.Palette_AccentColor;
            bool filetype_changed = original_filetype != Properties.Settings.Default.FileTypeSelection;

            bool settings_changed = theme_changed || primary_changed || accent_changed || filetype_changed;

            // If a Setting has Changed, Set Parameter to Settings_Change, otherwise set Settings_NoChange
            Done_BTN.CommandParameter = (settings_changed) ? "Settings_Change" : "Settings_NoChange";
        }

        #endregion

        #region Events

        // Material Design Required This (So I added it)
        // Speeds up content switching
        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
        }

        #endregion

        #region Buttons

        // Occurs when Done_BTN is clicked
        private void Done_BTN_Click(object sender, RoutedEventArgs e)
        {
            CheckSettingsChanged();
        }

        #endregion

    }
}
