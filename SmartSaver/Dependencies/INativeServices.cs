using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSaver.Dependencies
{
    interface INativeServices
    {
        void OnThemeChanged(ThemeManager.Themes theme);
    }
}
