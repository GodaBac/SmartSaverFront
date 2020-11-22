using SmartSaver.DTO.User.Input;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text;
using SmartSaver.DTO.User.Output;

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
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<User> UserLogin(string userEmail, string userPassword)
        {
            string url = string.Format("http://194.5.157.98:88/api/User?email={0}&password={1}", userEmail, userPassword);
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                User user = JsonConvert.DeserializeObject<User>(responseBody);
                return user;
            }
            else return null;
        }

        public async Task<bool> ModifyUser(ModifyUserDTO data)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, "http://194.5.157.98:88/api/User/ModifyUser");
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(message);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            string url = string.Format("http://194.5.157.98:88/api/User/{0}", userId);
            var response = await _client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
