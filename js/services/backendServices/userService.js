define(['app', 'constants', 'requestService'], function (app) {
    app.factory('userService', function ($rootScope, constants, requestService) {
        var headers, service, url, serviceUrl;
        service = {};
        headers = requestService.getHeaders();
        serviceUrl = constants.baseServiceUrl + '/users';

        service.signUp = function (registerData) {
            url = serviceUrl + '/register';
            headers = null;
            return requestService.postRequest(url, headers, registerData);
        };

        service.logIn = function (loginData) {
            url = serviceUrl + '/login';
            headers = null;
            return requestService.postRequest(url, headers, loginData);
        };

        service.loadWallFeed = function (username, startPost) {
            if (!startPost) {
                startPost = '';
            }
            url = serviceUrl + '/' + username + '/wall?StartPostId='+ startPost +'&PageSize=' + constants.pageSize;
            return requestService.getRequest(url, headers);
        };

        service.logout = function () {
            url = serviceUrl + '/logout';
            return requestService.postRequest(url, headers);
        };

        service.isLoggedIn = function () {
            return !!(sessionStorage['accessToken'] && sessionStorage['accessToken'].length > 490);
        };

        service.setCredentials = function(serverData) {
            sessionStorage['accessToken'] = serverData.access_token;
        };

        service.clearCredentials = function() {
            for (var key in sessionStorage) {
                if (sessionStorage.hasOwnProperty(key)) {
                    delete sessionStorage[key];
                }
            }
        };

        return service;
    });
});
