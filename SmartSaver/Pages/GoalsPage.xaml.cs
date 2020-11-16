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
    public partial class GoalsPage : ContentPage
    {
        public GoalsPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public List<Goal> Goals { get => GoalData(); }

        private List<Goal> GoalData()
        {
            var tempList = new List<Goal>();
            tempList.Add(new Goal { GoalMoneyAllocated = "22.00$", GoalMoney = "100.00$" });
            tempList.Add(new Goal { GoalMoneyAllocated = "300.00$", GoalMoney = "350.00$" });
            tempList.Add(new Goal { GoalMoneyAllocated = "15.32$", GoalMoney = "400.00$" });

            return tempList;
        }
    }

    public class Goal
    {
        public string GoalMoney { get; set; }
        public string GoalMoneyAllocated { get; set; }
    }
}
