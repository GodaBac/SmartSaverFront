using SmartSaver.DTO.Expenses.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSaver.Pages
{
    [DesignTimeVisible(false)]
    public partial class PageOne : ContentPage
    {
        public PageOne()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public List<ExpenseDTO> Expenses { get => ExpenseData(); }

        private List<ExpenseDTO> ExpenseData()
        {
            return new List<ExpenseDTO>();
        }

    }
}