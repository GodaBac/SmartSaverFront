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
    public partial class PageTwo : ContentPage
    {
        public PageTwo()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<Income> Incomes { get => IncomeData(); }

        private List<Income> IncomeData()
        {
            var tempList = new List<Income>();
            tempList.Add(new Income { Amount = "22.00$", Date = "2020.11.01" });
            tempList.Add(new Income { Amount = "300.00$", Date = "2020.11.02" });
            tempList.Add(new Income { Amount = "15.32$", Date = "2020.11.03" });
            tempList.Add(new Income { Amount = "12.20$", Date = "2020.11.04" });
            tempList.Add(new Income { Amount = "17.13$", Date = "2020.11.05" });
            tempList.Add(new Income { Amount = "23.23$", Date = "2020.11.05" });

            return tempList;
        }
    }

    public class Income
    {
        public string Amount { get; set; }
        public string Date { get; set; }
    }
}
