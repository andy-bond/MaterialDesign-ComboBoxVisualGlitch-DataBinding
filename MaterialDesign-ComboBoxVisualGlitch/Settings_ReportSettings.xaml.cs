// Author:  Andy Bond
// Date:    1/3/17

using System.Windows.Controls;
using System.Collections.Generic;

namespace MaterialDesign_ComboBoxVisualGlitch
{
    /// <summary>
    /// Interaction logic for Settings_ReportSettings.xaml
    /// </summary>
    public partial class Settings_ReportSettings : UserControl
    {

        #region Constructor

        // Constructor
        public Settings_ReportSettings()
        {
            InitializeComponent();

            // Initialize ComboBox
            ImageTextItem excel = new ImageTextItem("FileExcel", "Microsoft Excel Spreadsheet", "XLS");
            ImageTextItem word = new ImageTextItem("FileWord", "Microsoft Word Document", "DOC");
            ImageTextItem pdf = new ImageTextItem("FilePdf", "Portable Document Format", "PDF");

            List<ImageTextItem> items = new List<ImageTextItem>() { excel, word, pdf };

            FileType_CB.ItemsSource = items;

            int index = -1;
            int count = 0;
            // Initialize FileType ComboBox Selection
            foreach (ImageTextItem cbi in FileType_CB.Items)
            {
                if (cbi.name == Properties.Settings.Default.FileTypeSelection)
                {
                    index = count;
                    break;
                }
                count++;
            }

            FileType_CB.SelectedIndex = index;
        }

        #endregion

        #region Events

        // Occurs when Selection Changes in FileType ComboBox
        private void FileType_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FileType_CB.SelectedItem != null)
            {
                Properties.Settings.Default.FileTypeSelection = ((ImageTextItem)FileType_CB.SelectedItem).name;
                Properties.Settings.Default.Save();
            }
        }

        #endregion

    }

    public class ImageTextItem
    {
        public string name;
        public string image;
        public string text;

        public ImageTextItem(string i, string t, string n)
        {
            image = i;
            text = t;
            name = n;
        }

        public string Text
        {
            get { return text; }
        }

        public string Image
        {
            get { return image; }
        }
    }
}
