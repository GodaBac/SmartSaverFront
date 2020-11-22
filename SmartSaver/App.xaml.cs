using System;
using Xamarin.Forms;
using SmartSaver.Pages;
using Xamarin.Forms.Xaml;

namespace SmartSaver
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
