using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace vk_api
{
    class Program
    {
        VkAPI ApiRequest;
        private static string Token;
        private static string UserId;
        private static Dictionary<string, string> Response;

        static void Main(string[] args)
        {
            // move to json file later
            Token = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("BotPassport.json"))["Token"];
            Console.WriteLine(Token);
            
        }
    }
}
