using Plugin.Settings;
using SmartSaver.Themes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartSaver
{
    public class ThemeManager
    {
        public enum Themes
        {
            Light,
            Dark
        }

        /// <summary>
        /// Changes the theme of the app.
        /// Add additional switch cases for more themes you add to the app.
        /// This also updates the local key storage value for the selected theme.
        /// </summary>
        /// <param name="theme"></param>
        public static void ChangeTheme(Themes theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                //Update local key value with the new theme you select.
                CrossSettings.Current.AddOrUpdateValue("SelectedTheme", (int)theme);

                switch (theme)
                {
                    case Themes.Light:
                        {
                            mergedDictionaries.Add(new LightTheme());
                            break;
                        }
                    case Themes.Dark:
                        {
                            mergedDictionaries.Add(new DarkTheme());
                            break;
                        }
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }

        public static void LoadTheme()
        {
            Themes currentTheme = CurrentTheme();
            ChangeTheme(currentTheme);
        }

        public static Themes CurrentTheme()
        {
            return (Themes)CrossSettings.Current.GetValueOrDefault("SelectedTheme", (int)Themes.Light);
        }
    }
}
