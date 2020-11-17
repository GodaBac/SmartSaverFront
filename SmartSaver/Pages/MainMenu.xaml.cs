using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Xamarin.Forms;
using SmartSaver.Models;
using Xamarin.Forms.Xaml;

namespace SmartSaver.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem() { Title = "Main Page", Icon = "home.png", TargetType = typeof(MainPage)},
                new MainMenuItem() { Title = "Expenses", Icon = "expense.png", TargetType = typeof(PageOne) },
                new MainMenuItem() { Title = "Incomes", Icon = "incomes.png", TargetType = typeof(PageTwo) },
                new MainMenuItem() { Title = "Goals", Icon = "goals.png", TargetType = typeof(GoalsPage) },
                new MainMenuItem() { Title = "Budgets", Icon = "budgets.png", TargetType = typeof(BudgetsPage) }
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new MainPage());

            InitializeComponent();
        }

        // When a MenuItem is selected.
        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                if (item.Title.Equals("Main Page"))
                {
                    Detail = new NavigationPage(new MainPage());
                }
                else if (item.Title.Equals("Expenses"))
                {
                    Detail = new NavigationPage(new PageOne());
                }
                else if (item.Title.Equals("Incomes"))
                {
                    Detail = new NavigationPage(new PageTwo());
                }
                else if (item.Title.Equals("Goals"))
                {
                    Detail = new NavigationPage(new GoalsPage());
                }
                else if (item.Title.Equals("Budgets"))
                {
                    Detail = new NavigationPage(new BudgetsPage());
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}