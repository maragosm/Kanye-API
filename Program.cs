using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;

namespace KanyAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest/";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            Console.WriteLine("And now... Kanye West and Ron Swanson, a story of love, lust and loss:\n");

            for (int i = 0; i < 5; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($"Kanye: {kanyeQuote}\n");
                Thread.Sleep(4000);
                var ronResponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
                Console.WriteLine($"Ron: {ronQuote}\n");
                Thread.Sleep(4000);
            }

        }
    }
}
