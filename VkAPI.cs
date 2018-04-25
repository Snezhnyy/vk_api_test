using System;
using System.Collections.Generic;
using xNet;
using Newtonsoft.Json;

namespace vk_api
{

    class VkAPI
    {
        private const string APPID = "6460980";
        private const string VKAPIURL = "https://api.vk.com/method/";
        private string Token;

        public VkAPI(string AccessToken)
        {
            Token = AccessToken;
        }

        public Dictionary<string, string> GetInformation(string UserId, string[] Fields)
        {
            HttpRequest GetInformation = new HttpRequest();
            GetInformation.AddUrlParam("user_ids", UserId);
            GetInformation.AddUrlParam("access_token", Token);
            string Params = "";
            foreach (string str in Fields)
            {
                Params += str + ",";
            }
            Params = Params.Remove(Params.Length - 1);
            GetInformation.AddUrlParam("fields", Params);
            string Result = GetInformation.Get(VKAPIURL + "users.get").ToString();
            Result = Result.Substring(13, Result.Length - 15);
            Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(Result);
            return Dict;            
        }

        public string GetCityById(string CityId)
        {
            HttpRequest GetCityById = new HttpRequest();
            GetCityById.AddUrlParam("city_ids", CityId);
            GetCityById.AddUrlParam("access_token", Token);
            string Result = GetCityById.Get(VKAPIURL + "database.getSitiesById").ToString();
            Result = Result.Substring(13, Result.Length - 15);
            Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(Result);
            return Dict["name"];
        }

        public string GetCountryById(string CountryId)
        {
            HttpRequest GetCountryById = new HttpRequest();
            GetCountryById.AddUrlParam("country_ids", CountryId);
            GetCountryById.AddUrlParam("access_token", Token);
            string Result = GetCountryById.Get(VKAPIURL + "database.getCountriesById").ToString();
            Result = Result.Substring(13, Result.Length - 15);
            Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(Result);
            return Dict["name"];
        }

        
    }
}