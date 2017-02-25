define(['q'], function (q) {
    var requestService = {};

    function request(method, headers, url, data) {
        var defer = q.defer();

        $.ajax({
            method: method,
            headers: headers,
            url: url,
            data: data,
            processData: false,
            success: function (response) {
                defer.resolve(response);
            },
            error: function (error) {
                defer.reject(error);
            }
        });

        return defer.promise;
    }

    requestService.post = function (headers, url, data) {
        return request('POST', headers, url, data);
    };

    requestService.get = function (headers, url) {
        return request('GET', headers, url);
    };

    requestService.update = function (headers, url, data) {
        return request('PUT', headers, url, data);
    };

    requestService.remove = function (headers, url) {
        return request('DELETE', headers, url);
    };

    return requestService;
});
