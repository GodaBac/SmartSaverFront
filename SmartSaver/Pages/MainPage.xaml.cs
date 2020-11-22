using SmartSaver.DTO.Expenses.Output;
using SmartSaver.Processors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SmartSaver.Pages
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ExpensesProcessor exp = new ExpensesProcessor();
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            ExpenseData();
        }

        public List<ExpenseDTO> Expenses { get; set; }


        private async void ExpenseData()
        {
            Expenses = await exp.GetExpenses("26a39c6d-9709-44a3-8ce7-14e37dc4cfee", -1, -1);           
        }
    }

}
