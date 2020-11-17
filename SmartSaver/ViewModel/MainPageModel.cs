using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSaver.ViewModel
{
    class MainPageModel
    {
        public string DefaultColor
        {
            get
            {
                return App.Settings.DefaultColor;
            }
        }
    }
}
