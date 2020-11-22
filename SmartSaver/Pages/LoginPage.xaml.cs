using SmartSaver.DTO.User.Output;
using SmartSaver.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSaver.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly UserProcessor userProcessor = new UserProcessor();
        public LoginPage()
        {
            InitializeComponent();
        }

        async void loginClick (object sender, EventArgs args)
        {
            User user = await userProcessor.UserLogin(email.Text, password.Text);
            if (user != null)
            {
                App.Current.MainPage = new PageOne(user);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new RegisterPage();
        }
    }
}