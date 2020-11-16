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
    public partial class BudgetsPage : ContentPage
    {
        public BudgetsPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<Budget> Budgets { get => BudgetData(); }

        private List<Budget> BudgetData()
        {
            var tempList = new List<Budget>();
            tempList.Add(new Budget { Category = "Food", BudgetMoney = "100.00$" });
            tempList.Add(new Budget { Category = "Gas", BudgetMoney = "50.00$" });
            tempList.Add(new Budget { Category = "Clothes", BudgetMoney = "200.00$" });
            tempList.Add(new Budget { Category = "Leisure", BudgetMoney = "150.00$" });

            return tempList;
        }
    }

    public class Budget
    {
        public string Category { get; set; }
        public string BudgetMoney { get; set; }
    }
}
