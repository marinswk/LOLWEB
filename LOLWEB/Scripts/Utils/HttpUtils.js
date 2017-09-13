function HttpUtils() { }

HttpUtils.getRequest = function (url, data, successHandler, errorHandler) {
    $.ajax({
        method: 'GET',
        url: url,
        data: data
    })
        .done(function (response) {
            if (typeof successHandler === 'function') {
                successHandler(response);
            }
        })
        //.fail(function (response) {
        //    if (!_.isNull(errorHandler) && !_.isUndefined(errorHandler)) {
        //        errorHandler(response);
        //    } else {
        //        MessageUtils.showError("Loading data failed.");
        //    }
        //});
        //.always(function () {
        //    var endTime = new Date().getTime();
        //    log.warn('<<< GET [' + startTime + '] duration: ' + (endTime - startTime) + 'ms');
        //});
};

HttpUtils.postRequest = function (url, data, successHandler, errorHandler) {
    $.ajax({
        method: 'POST',
        url: url,
        data: JSON.stringify(data),
        processData: false,
        contentType: "application/json; charset=UTF-8",
    })
        .done(function (response) {
            if (typeof successHandler === 'function') {
                successHandler(response);
            }
        })
        .fail(function (response) {
            if (!_.isNull(errorHandler) && !_.isUndefined(errorHandler)) {
                errorHandler(response);
            } else {
                MessageUtils.showError("Posting data failed.");
            }
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
HttpUtils.postDeferred = function (url, data) {
    var defer = $.Deferred();
    HttpUtils.postRequest(url, data,
        function (response) {
            defer.resolve(response);
        }, function (error) {
            defer.reject(error);
        });
    return defer.promise();
};