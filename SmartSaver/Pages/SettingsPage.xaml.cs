using SmartSaver.DTO.User.Output;
using SmartSaver.Models;
using SmartSaver.Processors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartSaver.Dependencies;

namespace SmartSaver.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        UserProcessor usp;
        ObservableCollection<User> user;
        public delegate void NotifyParentDelegate();
        ObservableObject ree = new ObservableObject();

        public SettingsPage()
        {
            usp = new UserProcessor();
            user = new ObservableCollection<User>();

            Themes = new List<AppTheme>()
            {
                new AppTheme() { ThemeId = ThemeManager.Themes.Light, Title = "Light Theme"},
                new AppTheme() { ThemeId = ThemeManager.Themes.Dark, Title = "Dark Theme"},
            };
            var selectedTheme = Themes.FirstOrDefault(x => x.ThemeId == ThemeManager.CurrentTheme());
            selectedTheme.IsSelected = true;

            InitializeComponent();
        }
        List<AppTheme> _themes;
        public List<AppTheme> Themes
        {
            get { return _themes; }
            set { ree.SetProperty(ref _themes, value); }
        }

        AppTheme _selectedTheme;
        public AppTheme SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                ree.SetProperty(ref _selectedTheme, value);
                if (value != null) { OnThemeSelected(value); }
            }
        }

        /// <summary>
        /// Invokes when you select any Theme from the ListView
        /// </summary>
        /// <param name="selectedTheme"></param>
        private void OnThemeSelected(AppTheme selectedTheme)
        {
            foreach (var t in Themes)
            {
                t.IsSelected = t.ThemeId == selectedTheme.ThemeId;
            }
            ThemeManager.ChangeTheme(selectedTheme.ThemeId);

            //For Android we need some Platform specific twicks for Android Toolbar. 
            //Apply this platform specific change by invoking following DependencyService
            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.UWP)
            {
                DependencyService.Get<INativeServices>().OnThemeChanged(selectedTheme.ThemeId);
            }
        }
    }
}