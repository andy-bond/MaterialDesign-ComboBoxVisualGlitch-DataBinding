// Author: Andy Bond
// Date:   12/9/2016

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace MaterialDesign_ComboBoxVisualGlitch
{
    /// <summary>
    /// Interaction logic for ColorPalette.xaml
    /// </summary>
    public partial class Settings_ColorPalette : UserControl
    {

        #region Private Variables

        // Get all of the swatches
        public IEnumerable<Swatch> Swatches = new SwatchesProvider().Swatches;

        #endregion

        #region Constructor

        // Default Constructor
        // Set up Item Control and Toggle Button
        public Settings_ColorPalette()
        {
            InitializeComponent();

            // Set the Item Source for the lists of colors
            PrimaryColors.ItemsSource = Swatches;
            AccentColors.ItemsSource = Swatches;

            // Set the state that the Toggle Button should be in
            LightDark_ToggleBTN.IsChecked = (Properties.Settings.Default.Palette_IsDark);
        }

        #endregion

        #region Buttons

        // Toggle Light/Dark
        // This will have no effect on the Dialog Card
        private void LightDark_ToggleBTN_Click(object sender, RoutedEventArgs e)
        {
            // Get the current state of the toggle button
            bool toggle_button_value = (bool)LightDark_ToggleBTN.IsChecked;

            // Set the Theme
            new PaletteHelper().SetLightDark(toggle_button_value);

            // Save the settings
            Properties.Settings.Default.Palette_IsDark = toggle_button_value;
            Properties.Settings.Default.Save();
        }

        // Apply Primary Color
        private void ApplyPrimaryColor(object sender, RoutedEventArgs e)
        {
            // Get the selected color
            Swatch selected_swatch = (Swatch)(sender as Button).DataContext;

            // Set the Color
            new PaletteHelper().ReplacePrimaryColor(selected_swatch);

            // Save the settings
            Properties.Settings.Default.Palette_PrimaryColor = selected_swatch.Name;
            Properties.Settings.Default.Save();
        }

        // Apply Accent Color
        private void ApplyAccentColor(object sender, RoutedEventArgs e)
        {
            // Get the selected color
            Swatch selected_swatch = (Swatch)(sender as Button).DataContext;

            // Set the Color
            new PaletteHelper().ReplaceAccentColor(selected_swatch);

            // Save the settings
            Properties.Settings.Default.Palette_AccentColor = selected_swatch.Name;
            Properties.Settings.Default.Save();
        }

        #endregion

    }
}
