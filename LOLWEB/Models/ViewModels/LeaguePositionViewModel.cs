namespace LOLWEB.Models.ViewModels
{
    public class LeaguePositionViewModel
    {
        public string queueType { get; set; }
        public string rank { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int winRatio { get; set; }
        public string playerOrTeamName { get; set; }
        public int leaguePoints { get; set; }
        public string leagueName { get; set; }
        public string tier { get; set; }
    }
}