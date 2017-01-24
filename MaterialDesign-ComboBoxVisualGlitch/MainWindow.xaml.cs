// Author:  Andy Bond
// Date:    1/3/17

using MahApps.Metro.Controls;
using System.Windows;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using System.Threading;

namespace MaterialDesign_ComboBoxVisualGlitch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        #region Private Variables

        // Version Number
        public string Version_Number { get { return "Version 1.0"; } }

        #endregion

        #region Constructor

        // Constructor
        public MainWindow()
        {
            InitializeComponent();

            #region Initialize Settings

            // Initialize Palette
            new PaletteHelper().SetLightDark(Properties.Settings.Default.Palette_IsDark);
            new PaletteHelper().ReplacePrimaryColor(Properties.Settings.Default.Palette_PrimaryColor);
            new PaletteHelper().ReplaceAccentColor(Properties.Settings.Default.Palette_AccentColor);

            #endregion

        }

        #endregion

        #region Helper Functions

        // Send a message to the Snackbar
        private void EnqueueSnackBarMessage(string message)
        {
            Task.Factory.StartNew(() => MainSnackbar.MessageQueue.Enqueue(message), new CancellationToken(false), TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        #region Events

        // When MainWindowDialogHost's Dialog is closing
        private void MainWindowDialogHost_DialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            // If there is no parameter
            if (eventArgs.Parameter == null)
            {
                return;
            }

            // Get the Parameter as a String
            string parameter = (string)eventArgs.Parameter;

            if (parameter == "Settings_Change")
            {
                EnqueueSnackBarMessage("Settings Saved");
            }
        }

        #endregion

        #region Buttons

        // Occurs when Settings_BTN is clicked
        private void Settings_BTN_Click(object sender, RoutedEventArgs e)
        {
            // Set the DialogContent
            MainWindowDialogHost.DialogContent = new Settings_Dialog();

            // Open the Dialog
            MainWindowDialogHost.IsOpen = true;
        }

        #endregion

    }

}