using LOLWEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace LOLWEB.Controllers
{
    public class GeneralController : ApiController
    {
        private string apiKeyParameter = "?api_key=" + WebConfigurationManager.AppSettings["ApiKey"];
        private string euwAddress = WebConfigurationManager.AppSettings["ServerAddressEUW"];

        [HttpGet]
        public SummonerViewModel GetUserByUserName([FromUri]string userName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(euwAddress + "lol/summoner/v3/summoners/by-name/" + userName);
            SummonerViewModel summoner = new SummonerViewModel();
            HttpResponseMessage response = client.GetAsync(apiKeyParameter).Result;
            if (response.IsSuccessStatusCode)
                summoner = response.Content.ReadAsAsync<SummonerViewModel>().Result;

            return summoner;
        }
    }
}
