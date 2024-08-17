using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmployeesApp
{
    public class EmployeeService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Employee>> GetEmployeeDataAsync()
        {
            string apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var timeEntries = JsonConvert.DeserializeObject<List<Employee>>(json);

                    List<Employee> employees = timeEntries
                        .Where(te => !te.DeletedOn.HasValue && !string.IsNullOrEmpty(te.EmployeeName)) 
                        .GroupBy(te => te.EmployeeName)
                        .Select(g => new Employee
                        {
                            EmployeeName = g.Key,
                            TotalHoursWorked = g.Sum(te => (te.EndTimeUtc - te.StarTimeUtc).TotalHours)
                        })
                        .ToList();

                    return employees;
                }
                else
                {
                    return new List<Employee>();
                }
            }
        }

    }
}