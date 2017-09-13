function CallAPI() {
    console.log(5 + 6);

    var response = HttpUtils.getRequest("/api/General/GetUserByUserName", { "userName": $("#searchByUserName").val() }, function (response) {
        $("#log").innerHTML += JSON.parse(response);
    }, function (response) { });
}