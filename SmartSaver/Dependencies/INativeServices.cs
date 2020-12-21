using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSaver.Dependencies
{
    public interface INativeServices
    {
        void OnThemeChanged(ThemeManager.Themes theme);
    }
}
