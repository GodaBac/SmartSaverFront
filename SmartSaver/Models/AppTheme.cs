using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSaver.Models
{
    public class AppTheme : ObservableObject
    {
        public ThemeManager.Themes ThemeId { get; set; }
        public string Title { get; set; }
        bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
}
