using Newtonsoft.Json;
using SmartSaver.DTO.Expenses.Input;
using SmartSaver.DTO.Expenses.Output;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartSaver.Processors
{
    class ExpensesProcessor
    {

        HttpClient client;

        public ExpensesProcessor()
        {
            client = new HttpClient();
        }

        public async Task<string> AddExpense(string userId, string ownerId, string expenseName, float moneyUsed, int expenseCategory)
        {

            NewExpenseDTO data = new NewExpenseDTO { userId = userId, ownerId = ownerId, expenseName = expenseName, moneyUsed = moneyUsed, expenseCategory = expenseCategory};
            var json = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://194.5.157.98:88/api/Expenses", stringContent);

                if (response != null)
                {
                    return response.ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "Unexpected error";

        }



        public async Task<List<ExpenseDTO>> GetExpenses(string ownerId, int numberOfDaysToShow, int maxNumberOfExpensesToShow)
        {

            try
            {
                var response = await client.GetAsync(String.Format("http://194.5.157.98:88/api/Expenses/GetExpenses?ownerId={0}&numberOfDaysToShow={1}&maxNumberOfExpensesToShow={2}", ownerId, numberOfDaysToShow, maxNumberOfExpensesToShow));
                //var responseInfo = response.GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    List<ExpenseDTO> expenses = JsonConvert.DeserializeObject<List<ExpenseDTO>>(responseBody);
                    if (expenses != null)
                    {
                        return expenses;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new List<ExpenseDTO>();

        }


        public async Task<List<SumByCatDTO>> GetSumOfExpensesByCategory(string ownerId, string numberOfDaysToShow)
        {
            try
            {
                var response = await client.GetAsync(String.Format("http://194.5.157.98:88/api/Expenses/GetSumOfExpensesByCategory?ownerId={0}&numberOfDaysToShow={1}", ownerId, numberOfDaysToShow));
                //var responseInfo = response.GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    List<SumByCatDTO> expensesByCat = JsonConvert.DeserializeObject<List<SumByCatDTO>>(responseBody);
                    if (expensesByCat != null)
                    {
                        return expensesByCat;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return new List<SumByCatDTO>();
        }



    }

}
