using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApp.Console
{
    class Program
    {
        private const string APP_PATH = @"http://localhost:61089/";
        private static string token = String.Empty;

        static void Main(string[] args)
        {

            System.Console.WriteLine("Enter login: ");
            string username = System.Console.ReadLine();

            System.Console.WriteLine("Enter password: ");
            string password = System.Console.ReadLine();

            AuthorizationManager authorization = new AuthorizationManager(APP_PATH);
            token = authorization.GetTokenDictionary(username, password)["access_token"];

            System.Console.WriteLine();
            System.Console.WriteLine("Access Token:");
            System.Console.WriteLine(token);

            ApiManager apiManager = new ApiManager(APP_PATH, authorization.CreateClient(token));

            System.Console.WriteLine();
            string userInfo = authorization.GetUserInfo(token);
            System.Console.WriteLine("User info:");
            System.Console.WriteLine(userInfo);

            System.Console.WriteLine();
            string values = apiManager.GetDateRanges();
            System.Console.WriteLine("Values: ");
            System.Console.WriteLine(values);

            //System.Console.WriteLine();
            //System.Console.WriteLine(apiManager.AddDateRange("2018-01-01", "2018-01-03"));
            //System.Console.WriteLine(apiManager.AddDateRange("2018-01-01", "2018-01-31"));
            //System.Console.WriteLine(apiManager.AddDateRange("2018-01-03", "2018-01-05"));

            System.Console.WriteLine();
            System.Console.WriteLine(apiManager.GetDateRanges("2018-01-04", "2018-02-03"));

        }
    }
}
