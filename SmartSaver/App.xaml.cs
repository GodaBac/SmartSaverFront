using System;
using Xamarin.Forms;
using SmartSaver.Pages;
using Xamarin.Forms.Xaml;
using SmartSaver.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace SmartSaver
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainMenu();
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

        private static Settings settings;

        public static Settings Settings
        {
            get
            {
                if (settings == null)
                    LoadSettings();

                return settings;
            }
        }

        private static void LoadSettings()
        {
#if RELEASE
            var settingsResourceStream = Assembly.GetAssembly(typeof(AppSettings)).GetManifestResourceStream("AppSettingsPoC.Configuration.appsettings.release.json");
#else
            var settingsResourceStream = Assembly.GetAssembly(typeof(Settings)).GetManifestResourceStream("AppSettingsPoC.Configuration.appsettings.debug.json");
#endif
            if (settingsResourceStream == null)
                return;

            using (var streamReader = new StreamReader(settingsResourceStream))
            {
                var jsonString = streamReader.ReadToEnd();
                settings = JsonConvert.DeserializeObject<Settings>(jsonString);
            }
        }
    }
}
