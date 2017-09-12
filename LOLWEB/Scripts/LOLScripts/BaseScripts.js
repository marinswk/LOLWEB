function CallAPI() { }

CallAPI.callSOmething = function () {
    console.log("called");
    HttpUtils.getDeferred("api/General", 5);
}