define(['app', 'constants', 'requestService'], function (app) {
    app.factory('postService', function ($rootScope, constants, requestService) {
        var service, serviceUrl;
        service = {};
        serviceUrl = constants.baseServiceUrl + '/Posts';

        service.createPost = function (postData) {
            var url = serviceUrl;
            var headers = requestService.getHeaders();
            return requestService.postRequest(url, headers, postData);
        };

        service.loadPosts = function (id) {
            var url = serviceUrl + '/' + id;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers)
        };

        return service;
    });
});
