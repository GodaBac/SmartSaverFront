using SmartSaver.DTO.User.Output;
using SmartSaver.Models;
using SmartSaver.Processors;
using SmartSaver.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSaver.Models;

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
            usp = new UserProcessor();
            user = new ObservableCollection<User>();
            InitializeComponent();
            ThemeSelectionViewModel t = new ThemeSelectionViewModel();
        }

        private void LightClicked(object sender, EventArgs e)
        {
            ThemeSelectionViewModel t = new ThemeSelectionViewModel();
            AppTheme theme = new AppTheme(){ ThemeId = ThemeManager.Themes.Light, Title = "Light Theme" };
            t.ThemeChosen(theme);
        }
        private void DarkClicked(object sender, EventArgs e)
        {
            ThemeSelectionViewModel t = new ThemeSelectionViewModel();
            AppTheme theme = new AppTheme() { ThemeId = ThemeManager.Themes.Dark, Title = "Dark Theme" };
            t.ThemeChosen(theme);
        }
    }
}