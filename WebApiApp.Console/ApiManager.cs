using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.Console
{
    class ApiManager
    {
        HttpClient client;
        string APP_PATH;

        public ApiManager(string APP_PATH, HttpClient client)
        {
            this.client = client;
            this.APP_PATH = APP_PATH;
        }

        public string GetDateRanges()
        {
            var response = client.GetAsync(APP_PATH + "/api/dateranges").Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        public string AddDateRange(string from, string to)
        {
            var content = new { from = from, to = to };
            var response = client.PostAsJsonAsync(APP_PATH + "/api/dateranges", content);

            return response.Result.Content.ReadAsStringAsync().Result;
        }

        public string GetDateRanges(string from, string to)
        {
            var response = client.GetAsync($"{APP_PATH}/api/dateranges?from={from}&to={to}").Result;

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
