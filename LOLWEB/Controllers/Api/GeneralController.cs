using LOLWEB.Models;
using LOLWEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace LOLWEB.Controllers
{
    public class GeneralController : ApiController
    {
        private string apiKeyParameter = "?api_key=" + WebConfigurationManager.AppSettings["ApiKey"];
        private string euw1Address = WebConfigurationManager.AppSettings["ServerAddressEUW1"];

        [HttpGet]
        public SummonerViewModel GetUserByUserName([FromUri]string userName)
        {
            return BuildSummonerViewModel(userName);
        }


        private SummonerViewModel BuildSummonerViewModel(string userName)
        {
            SummonerViewModel summonerViewModel = new SummonerViewModel();
            Summoner summoner = new Summoner();
            List<LeaguePosition> leaguePositions = new List<LeaguePosition>();

            var getSummonerResponse = GetAPIResponse(euw1Address + "lol/summoner/v3/summoners/by-name/" + userName);
            if (getSummonerResponse.IsSuccessStatusCode)
            {
                summoner = getSummonerResponse.Content.ReadAsAsync<Summoner>().Result;
                summonerViewModel.lastActivity = new DateTime(1970, 1, 1).AddMilliseconds(summoner.revisionDate);
                summonerViewModel.name = summoner.name;
                summonerViewModel.profileIconUrl = $"http://ddragon.leagueoflegends.com/cdn/7.18.1/img/profileicon/{summoner.profileIconId}.png";
                summonerViewModel.summonerId = summoner.id;
                summonerViewModel.summonerLevel = summoner.summonerLevel;


                var getLeaguePositionResponse = GetAPIResponse(euw1Address + "lol/league/v3/positions/by-summoner/" + summoner.id);
                if (getLeaguePositionResponse.IsSuccessStatusCode)
                {
                    leaguePositions = getLeaguePositionResponse.Content.ReadAsAsync<List<LeaguePosition>>().Result;
                    summonerViewModel.leaguePositions = new List<LeaguePositionViewModel>();
                    foreach (var leaguePosition in leaguePositions)
                    {
                        double totalGames = leaguePosition.losses + leaguePosition.wins;
                        double winRatio = (leaguePosition.wins / totalGames) * 100;
                        summonerViewModel.leaguePositions.Add(new LeaguePositionViewModel() {
                            leagueName = leaguePosition.leagueName,
                            leaguePoints = leaguePosition.leaguePoints,
                            playerOrTeamName = leaguePosition.playerOrTeamName,
                            queueType = leaguePosition.queueType,
                            losses = leaguePosition.losses,
                            wins = leaguePosition.wins,
                            winRatio = (int) winRatio,
                            rank = leaguePosition.rank,
                            tier = leaguePosition.tier
                        });
                    }
                }
            }
            return summonerViewModel;
        }

        private HttpResponseMessage GetAPIResponse(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            return client.GetAsync(apiKeyParameter).Result;
        }
    }
}
