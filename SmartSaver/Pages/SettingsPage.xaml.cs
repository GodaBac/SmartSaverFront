using SmartSaver.DTO.User.Output;
using SmartSaver.Processors;
using SmartSaver.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSaver.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        UserProcessor usp;
        ObservableCollection<User> user;
        public delegate void NotifyParentDelegate();

        public SettingsPage()
        {
            InitializeComponent();
            usp = new UserProcessor();
            user = new ObservableCollection<User>();
        }

        void ThemeChanged(object sender, EventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if(mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                if(e.Equals(false))
                {
                    mergedDictionaries.Add(new LightTheme());
                    sw.On = true;
                }
                else
                {
                    mergedDictionaries.Add(new DarkTheme());
                    sw.On = false;
                }
            }
        }
        void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            Theme theme = (Theme)picker.SelectedItem;

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case Theme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case Theme.Light:
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }

    }
}