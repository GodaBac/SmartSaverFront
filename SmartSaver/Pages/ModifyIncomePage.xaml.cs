using SmartSaver.DTO.Income.Input;
using SmartSaver.DTO.Income.Output;
using SmartSaver.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SmartSaver.Pages.AddIncomePage;
using static SmartSaver.Pages.PageTwo;

namespace SmartSaver.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyIncomePage : ContentPage
    {
        IncomeProcessor inc = new IncomeProcessor();
        public event NotifyParentDelegate NotifyParentEvent;

        public ModifyIncomePage(IncomeDTO selectedItem)
        {
            InitializeComponent();
            this.modMoneirecieved.Text = (selectedItem.Moneyrecieved).ToString();
            this.modIncomename.Text = selectedItem.Incomename;

        }


        public async void ModifyButton_Clicked(object sender, EventArgs args)
        {


            if (string.IsNullOrEmpty(modMoneirecieved.Text) == false)
            {
                if (string.IsNullOrEmpty(modIncomename.Text) == false)
                {
                    var result = await inc.ModifyIncome(new NewIncomeDTO
                    {
                        userId = App.user.Userid,
                        ownerId = App.ownerId,
                        incomeName = modIncomename.Text,
                        moneyReceived = float.Parse(modMoneirecieved.Text),

                    });
                    await DisplayAlert("", "IncomeModified", "Ok");
                    NotifyParent();

                    //Application.Current.MainPage.Navigation.PopModalAsync();

                }
            }
            else
            {
                await DisplayAlert("", "Expense info must be filled in!", "Ok");
            }

        }

        public void CancelButton_Clicked(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }



        public void NotifyParent()
        {
            if (NotifyParentEvent != null)
            {
                //Raise Event. All the listeners of this event will get a call.
                NotifyParentEvent();
            }
        }
    }
}


