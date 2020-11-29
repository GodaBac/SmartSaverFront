using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SmartSaver
{
    public static class Logger
    {
        public static void Log(string error)
        {
            try
            {
                using (StreamWriter sw = File.AppendText("logs.txt"))
                {
                    sw.WriteLine(string.Format("{0}:    {1}", DateTime.Now, error));
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("","Logger failed!", ":(");
            }
        }
    }
}
