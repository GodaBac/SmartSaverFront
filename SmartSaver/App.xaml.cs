using System;
using Xamarin.Forms;
using SmartSaver.Pages;
using Xamarin.Forms.Xaml;
using SmartSaver.Processors;
using SmartSaver.DTO.User.Input;
using SmartSaver.DTO.User.Output;

namespace SmartSaver
{
    public partial class App : Application
    {
        public static User user { get; set; }

        private readonly UserProcessor userProcessor = new UserProcessor();
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
