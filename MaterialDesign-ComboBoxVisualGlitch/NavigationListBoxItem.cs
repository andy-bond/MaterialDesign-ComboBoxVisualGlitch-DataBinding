// Author:  Andy Bond
// Date:    1/18/2017

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MaterialDesign_ComboBoxVisualGlitch
{
    public class NavigationListBoxItem : INotifyPropertyChanged
    {

        #region Private Variables

        private string _name;
        private string _icon;
        private object _content;
        private int _index;
        private bool _subitem;

        #endregion

        #region Constructors

        // Default Constructor
        public NavigationListBoxItem(string name, string icon, object content, int index, bool subitem)
        {
            Name = name;
            Icon = icon;
            Content = content;
            IsSubItem = subitem;
            Index = index;
        }

        #endregion

        #region Public Properties

        // Name Property
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        // Icon Property (Material Design PackIcon Kind)
        public string Icon
        {
            get { return _icon; }
            set
            {
                if (_icon == value) return;
                _icon = value;
                OnPropertyChanged();
            }
        }

        // Content Property (Page Content to Load)
        public object Content
        {
            get { return _content; }
            set
            {
                if (_content == value) return;
                _content = value;
                OnPropertyChanged();
            }
        }

        // Index to Appear in ListBox or Favorites Bar
        public int Index
        {
            get { return _index; }
            set
            {
                if (_index == value) return;
                _index = value;
                OnPropertyChanged();
            }
        }

        // IsSubItem Boolean (Changes Margin Thickness)
        public bool IsSubItem
        {
            get { return _subitem; }
            set
            {
                if (_subitem == value) return;
                _subitem = value;
                OnPropertyChanged();
            }
        }

        // ItemMargin Property (If SubItem, Change Thickness)
        public Thickness ItemMargin
        {
            get
            {
                return (IsSubItem) ? new Thickness(24, 0, 8, 0) : new Thickness(8, 0, 8, 0);
            }
        }

        #endregion

        #region Property Changed Required Items

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
