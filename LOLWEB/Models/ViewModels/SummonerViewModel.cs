using System;
using System.Collections.Generic;

namespace LOLWEB.Models.ViewModels
{
    public class SummonerViewModel
    {
        public string profileIconUrl { get; set; }
        public string name { get; set; }
        public long summonerLevel { get; set; }
        public DateTime lastActivity { get; set; }
        public long summonerId { get; set; }
        public List<LeaguePositionViewModel> leaguePositions { get; set; }
    }
}