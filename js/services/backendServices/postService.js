define(['app', 'constants', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('postService', function ($rootScope, constants, requestService, notifyService, navigationService) {
        var service = {};

        var serviceUrl = constants.baseServiceUrl + '/Posts';

        service.createPost = function (postData) {
            var url = serviceUrl;
            var headers = requestService.getHeaders();
            return requestService.PostRequest(url, headers, postData);
        };

        service.loadPosts = function (id) {
            var url = serviceUrl + '/' + id;
            var headers = requestService.getHeaders();
            return requestService.GetRequest(url, headers)
        };

        return service;
    });
});
