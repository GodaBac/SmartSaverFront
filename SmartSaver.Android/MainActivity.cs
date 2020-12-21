using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static SmartSaver.ThemeManager;

namespace SmartSaver.Droid
{
    [Activity(Label = "SmartSaver", Icon = "@mipmap/notsosmartIcon", Theme = "@style/lightAppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            var theme = ThemeManager.CurrentTheme();
            switch (theme)
            {
                case ThemeManager.Themes.Light:
                    {
                        SetTheme(Resource.Style.lightAppTheme);
                        break;
                    }
                case ThemeManager.Themes.Dark:
                    {
                        SetTheme(Resource.Style.darkAppTheme);
                        break;
                    }
                default:
                    SetTheme(Resource.Style.lightAppTheme);
                    break;
            }

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Instance = this;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

}