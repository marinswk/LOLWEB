function HttpUtils() { }

HttpUtils.getRequest = function (url, data) {
    $.ajax({
        method: 'GET',
        url: url,
        data: data
    })
};

HttpUtils.postRequest = function (url, data) {
    $.ajax({
        method: 'POST',
        url: url,
        data: JSON.stringify(data),
        processData: false,
        contentType: "application/json; charset=UTF-8",
    })
};

/**
 * wrap http get request into promise 
 */
HttpUtils.getDeferred = function (url, data) {
    var defer = $.Deferred();
    HttpUtils.getRequest(url, data,
        function (response) {
            defer.resolve(response);
        }, function (error) {
            defer.reject(error);
        });
    return defer.promise();
};

/**
 * wrap http post request into promise 
 */
HttpUtils.postDeferred = function (url, data, hideSpinner) {
    var defer = $.Deferred();
    HttpUtils.postRequest(url, data,
        function (response) {
            defer.resolve(response);
        }, function (error) {
            defer.reject(error);
        }, hideSpinner);
    return defer.promise();
};