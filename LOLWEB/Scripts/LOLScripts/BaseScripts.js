function CallAPI() {
    $.ajax({
        method: 'GET',
        url: '/api/General/GetUserByUserName',
        data: { "userName": $("#searchByUserName").val() }
    })
        .done(function (response) {
            console.log(response);
            if (response.summonerId == 0) {
                document.getElementById('log').innerHTML = "<h2>Summoner Not Found</h2>";
            }
            else {
                document.getElementById('log').innerHTML = "";
                document.getElementById('log').innerHTML += '<h2><img src="' + response.profileIconUrl + '"width="50" height="50">' + " " + response.name + '</h2>';
                document.getElementById('log').innerHTML += '</br><p> LastActivity: ' + response.lastActivity + '</p>';
                document.getElementById('log').innerHTML += '</br><p> SummonerLevel: ' + response.summonerLevel + '</p>';
                for (var leaguePosition of response.leaguePositions) {
                    document.getElementById('log').innerHTML += "</br><h2>" + leaguePosition.queueType + "</h2>";
                    document.getElementById('log').innerHTML += "</br><h3>" + leaguePosition.leagueName + " " + leaguePosition.tier + " " + leaguePosition.rank + "</h3>";
                    document.getElementById('log').innerHTML += "</br><p> League Points: " + leaguePosition.leaguePoints + "</p>";
                    document.getElementById('log').innerHTML += "</br><p> Wins: " + leaguePosition.wins + "</p>";
                    document.getElementById('log').innerHTML += "</br><p> Losses: " + leaguePosition.losses + "</p>";
                    document.getElementById('log').innerHTML += "</br><p> Win Ratio: " + leaguePosition.winRatio + "%</p>";
                }
            }
        });
}