function CallAPI() {
    console.log("called");
    HttpUtils.getDeferred("api/General/GetUserByUserName?userName=" + $("#searchByUserName").val(), 0);

}