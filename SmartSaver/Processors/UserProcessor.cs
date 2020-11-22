using SmartSaver.DTO.User.Input;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text;

namespace SmartSaver.Processors
{

    

    class UserProcessor
    {
        private static readonly HttpClient _client = new HttpClient();

        //public UserProcessor(HttpClient httpClient)
        //{
        //    _client = httpClient;
        //}

        public async Task<string> CreateNewUser(NewUserDTO data)
        {
            var json = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://194.5.157.98:88/api/User", httpContent);
            return response.ToString();
           
        }
    }
}
