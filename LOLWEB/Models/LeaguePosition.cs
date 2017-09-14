using System;

namespace LOLWEB.Models
{
    public class LeaguePosition
    {
        public string queueType { get; set; }
        public string rank { get; set; }
        public Boolean hotStreak { get; set; }
        public MiniSeries MiniSeriesDTO { get; set; }
        public int wins { get; set; }
        public Boolean veteran { get; set; }
        public int losses { get; set; }
        public Boolean freshBlood { get; set; }
        public string playerOrTeamName { get; set; }
        public int leaguePoints { get; set; }
        public long playerOrTeamId { get; set; }
        public string leagueName { get; set; }
        public string tier { get; set; }
    }
}