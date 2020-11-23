using SmartSaver.DTO.Expenses.Output;
﻿using SmartSaver.DTO.User.Output;
using SmartSaver.Processors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        User user;
        ExpensesProcessor exp;
        ObservableCollection<ExpenseDTO> expenses;
        public ObservableCollection<ExpenseDTO> Expenses { get { return expenses; } }
        public PageOne()
        {
            InitializeComponent();
            exp = new ExpensesProcessor();
            expenses = new ObservableCollection<ExpenseDTO>();
            ExpensesList.ItemsSource = expenses;
            ExpenseData();
        }


        private async void ExpenseData()
        {
            var _expenses = await exp.GetExpenses("26a39c6d-9709-44a3-8ce7-14e37dc4cfee", -1, -1);
            expenses.Clear();
            foreach(var expense in _expenses)
            {
                expenses.Add(expense);
            }
        }



        public async void AddButton_Clicked(object sender, EventArgs args)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new AddExpensePage()));
        }


    }
}