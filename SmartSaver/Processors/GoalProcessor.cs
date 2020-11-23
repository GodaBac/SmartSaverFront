﻿using Newtonsoft.Json;
using SmartSaver.DTO.Goal.Input;
using SmartSaver.DTO.Goal.Output;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartSaver.Processors
{
    class GoalProcessor
    {
        public async Task<List<GoalDTO>> GetGoals(string ownerId)
        {
            string url = string.Format("http://194.5.157.98:88/api/Goal?ownerId={0}", ownerId);
            var response = await App.client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                List<GoalDTO> listOfGoals = JsonConvert.DeserializeObject<List<GoalDTO>>(responseBody);
                return listOfGoals;
            }
            else return new List<GoalDTO>();
        }

        public async Task<bool> DeleteGoal(string goalId)
        {
            string url = string.Format("http://194.5.157.98:88/api/User/{0}", goalId);
            var response = await App.client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ModifyGoal(ModifyGoalDTO data)
        {
            
             string json = JsonConvert.SerializeObject(data);
             HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, "http://194.5.157.98:88/api/Goal");
             message.Content = new StringContent(json, Encoding.UTF8, "application/json");
             var response = await App.client.SendAsync(message);
             if (response.IsSuccessStatusCode)
                 return true;
             return false;
        }

        public async Task<bool> AddGoal(NewGoalDTO data)
        {
            var json = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await App.client.PostAsync("http://194.5.157.98:88/api/User", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CompleteGoal(string goalId)
        {
            string url = string.Format("http://194.5.157.98:88/api/Goal/CompleteGoal/{0}", goalId);
            var response = await App.client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddMoneyToGoal(AddMoneyDTO data)
        {
            string json = JsonConvert.SerializeObject(data);
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, "http://194.5.157.98:88/api/Goal/AddMoneyToGoal");
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await App.client.SendAsync(message);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}
