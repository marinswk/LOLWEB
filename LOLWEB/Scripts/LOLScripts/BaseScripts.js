function CallAPI() {
    console.log("something");

    $.ajax({
        method: 'GET',
        url: '/api/General/GetUserByUserName',
        data: { "userName": $("#searchByUserName").val() }
    })
        .done(function (response) {
            console.log(response);
            document.getElementById('log').innerHTML += JSON.stringify(response);
        });
}