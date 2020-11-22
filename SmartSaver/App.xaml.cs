using System;
using Xamarin.Forms;
using SmartSaver.Pages;
using Xamarin.Forms.Xaml;
using SmartSaver.Processors;
using System.Threading.Tasks;
using SmartSaver.DTO.Expenses.Output;
using System.Collections.Generic;

namespace SmartSaver
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
        }

        private async Task myMethod()
        {
            ExpensesProcessor expensesProcessor = new ExpensesProcessor();
            List<ExpenseDTO> kazkas = await expensesProcessor.GetExpenses("26a39c6d-9709-44a3-8ce7-14e37dc4cfee", -1, -1);
        }
        protected override void OnStart()
        {
            _ = myMethod();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
