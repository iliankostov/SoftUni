define(['app'], function (app) {
    app.factory('requestService', function ($http, $q) {
        var service = {};

        service.GetRequest = function (url, headers, data) {
            return MakeRequest('GET', url, headers, data)
        };

        service.PostRequest = function (url, headers, data) {
            return MakeRequest('POST',url, headers, data)
        };

        service.PutRequest = function (url, headers, data) {
            return MakeRequest('PUT',url, headers, data)
        };

        service.DeleteRequest = function (url, headers, data) {
            return MakeRequest('DELETE',url, headers, data)
        };

        function MakeRequest(method, url, headers, data) {
            var deferred = $q.defer();

            $http({
                method: method,
                url: url,
                headers: headers,
                data: data
            })
            .success(deferred.resolve)
            .error(deferred.reject);

            return deferred.promise;
        }

        return service;
    })
});
