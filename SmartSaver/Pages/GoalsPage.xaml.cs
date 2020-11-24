using SmartSaver.DTO.Goal.Output;
using SmartSaver.Processors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        GoalProcessor gop;
        ObservableCollection<GoalDTO> goals;
        public ObservableCollection<GoalDTO> Goals { get { return goals; } }

        public GoalsPage()
        {
            InitializeComponent();
            gop = new GoalProcessor();
            goals = new ObservableCollection<GoalDTO>();
            GoalsList.ItemsSource = goals;
            GoalData();
            
        }

       public async void GoalData()
        {
            
            var _goals = await gop.GetGoals(App.ownerId);
            goals.Clear();
            foreach (var goal in _goals)
            {
                goals.Add(goal);
            }
        }
    }

   
}
