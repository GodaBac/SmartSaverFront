using SmartSaver.DTO.Expenses.Input;
using SmartSaver.DTO.User.Input;
using SmartSaver.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSaver.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private readonly UserProcessor userProcessor = new UserProcessor();
        private readonly ExpensesProcessor expensesProcessor = new ExpensesProcessor();
        private static readonly HttpClient _client = new HttpClient();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            NewExpenseDTO data = new NewExpenseDTO { expenseCategory = 3, expenseName = "ledai", moneyUsed = 333, ownerId = "26a39c6d-9709-44a3-8ce7-14e37dc4cfee", userId = "26a39c6d-9709-44a3-8ce7-14e37dc4cfee" };
            expensesProcessor.AddExpense(data);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}