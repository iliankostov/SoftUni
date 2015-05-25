define(['app', 'constants', 'requestService'], function (app) {
    app.factory('userService', function ($rootScope, constants, requestService) {
        var service, serviceUrl;
        service = {};
        serviceUrl = constants.baseServiceUrl + '/users';

        service.isLoggedIn = function () {
            return !!(sessionStorage['accessToken'] && sessionStorage['accessToken'].length > constants.accessTokenMinLength);
        };

        service.signUp = function (registerData) {
            var url = serviceUrl + '/register';
            var headers = null;
            return requestService.postRequest(url, headers, registerData);
        };

        service.logIn = function (loginData) {
            var url = serviceUrl + '/login';
            var headers = null;
            return requestService.postRequest(url, headers, loginData);
        };

        service.setCredentials = function(serverData) {
            sessionStorage['accessToken'] = serverData.access_token;
        };

        service.searchUsersByName = function (searchData) {
            var url = serviceUrl + '/search?searchTerm=' + searchData;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.loadUserFullData = function (username) {
            var url = serviceUrl + '/' + username;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.getUserFriendsPreview = function (username) {
            var url = serviceUrl + '/' + username + '/friends/preview';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers)
        };

        service.getUserFriends = function (username) {
            var url = serviceUrl + '/' + username + '/friends';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers)
        };

        service.loadWallFeed = function (username, startPost) {
            if (!startPost) {
                startPost = '';
            }
            var url = serviceUrl + '/' + username + '/wall?StartPostId='+ startPost +'&PageSize=' + constants.pageSize;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.logout = function () {
            var url = serviceUrl + '/logout';
            var headers = requestService.getHeaders();
            return requestService.postRequest(url, headers);
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
