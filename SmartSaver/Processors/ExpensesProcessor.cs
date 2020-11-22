using Newtonsoft.Json;
using SmartSaver.DTO.Expenses.Input;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartSaver.Processors
{
    class ExpensesProcessor
    { 
    private static readonly HttpClient client = new HttpClient();

    public async Task<string> AddExpense(NewExpenseDTO data)
        {
            var json = JsonConvert.SerializeObject(data);
            var sending = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://194.5.157.98:88/api/Expense";
            var response = await client.PostAsync(url, sending);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
