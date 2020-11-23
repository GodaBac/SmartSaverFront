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
            int daysToShow = (DateTime.Now - datepicker.Date).Days;
            var _expenses = await exp.GetExpenses(App.ownerId, daysToShow, -1);
            expenses.Clear();
            foreach(var expense in _expenses)
            {
                expenses.Add(expense);
            }
        }

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var now = DateTime.Now;
            var smf = DateTime.Now - datepicker.Date;
            var _expenses = await exp.GetExpenses(App.ownerId, smf.Days, -1);
            expenses.Clear();
            foreach(var expense in _expenses)
            {
                expenses.Add(expense);
            }
        }
    }
}