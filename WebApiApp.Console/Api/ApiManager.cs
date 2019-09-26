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
        LogDb logDb;

        public ApiManager(string APP_PATH, HttpClient client)
        {
            this.client = client;
            this.APP_PATH = APP_PATH;

            logDb = new LogDb();
        }

        public string GetDateRanges()
        {
            var request = APP_PATH + "/api/dateranges";
            var response = client.GetAsync(request).Result;
            var data = response.Content.ReadAsStringAsync().Result;

            Log log = new Log()
            {
                Date = DateTime.Now,
                Request = request,
                RequestMethod = "GET",
                ResponseStatus = (int)response.StatusCode,
                ResponseDataCount = data.Length
            };
            logDb.Add(log);
            logDb.Save();

            return data;
        }

        public string AddDateRange(string from, string to)
        {
            var request = APP_PATH + "/api/dateranges";
            var content = new { from = from, to = to };
            var response = client.PostAsJsonAsync(request, content);
            var data = response.Result.Content.ReadAsStringAsync().Result;

            Log log = new Log()
            {
                Date = DateTime.Now,
                Request = request,
                RequestMethod = "GET",
                ResponseStatus = (int)response.Result.StatusCode,
                ResponseDataCount = data.Length
            };
            logDb.Add(log);
            logDb.Save();

            return data;
        }

        public string GetDateRanges(string from, string to)
        {
            var request = $"{APP_PATH}/api/dateranges?from={from}&to={to}";
            var response = client.GetAsync(request).Result;
            var data = response.Content.ReadAsStringAsync().Result;

            Log log = new Log()
            {
                Date = DateTime.Now,
                Request = request,
                RequestMethod = "GET",
                ResponseStatus = (int)response.StatusCode,
                ResponseDataCount = data.Length
            };
            logDb.Add(log);
            logDb.Save();

            return data;
        }
    }
}
