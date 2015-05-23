define(['app', 'constants', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('postService', function ($rootScope, constants, requestService, notifyService, navigationService) {
        var headers, service, url, serviceUrl;
        service = {};
        headers = requestService.getHeaders();
        serviceUrl = constants.baseServiceUrl + '/Posts';

        service.createPost = function (postData) {
            url = serviceUrl;
            return requestService.postRequest(url, headers, postData);
        };

        service.loadPosts = function (id) {
            url = serviceUrl + '/' + id;
            return requestService.getRequest(url, headers)
        };

        return service;
    });
});
