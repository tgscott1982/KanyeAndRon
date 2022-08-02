using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanyeAndRon;
public class QuoteGenerator
{
    public static void KanyeQuote()
    {
        //make requests to the internet
        var client = new HttpClient();
        //url that we're using for the api
        var kanyeURL = "https://api.kanye.rest";
        //using instance of url "client" we'll use the api url to get a response and store it in a variable
        var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
        //"quote" will be the NAME of the value but the VALUE (the quote itself) will be stored in variable kanyeQuote
        // parsing through response with object that can work with json (nuget package 'Newtonsoft.Json'
        var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

        Console.WriteLine("Kanye says:");
        Console.WriteLine($"'{kanyeQuote}'");
        Console.WriteLine($"============================");

    }

    public static void RonQuote()
    {
        var client = new HttpClient();
        var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        var ronResponse = client.GetStringAsync(ronURL).Result;
        //need to use jarray.parse because url returns an array, and then replace brackets with nothing and then trim any whitespace before or after the string
        var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

        Console.WriteLine("Ron responds:");
        Console.WriteLine($"{ronQuote}");
        Console.WriteLine($"============================");

    }

}
