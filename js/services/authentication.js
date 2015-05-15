define(['app'], function (app) {
    app.factory('authentication', function ($http, baseServiceUrl) {
        var service = {};

        var serviceUrl = baseServiceUrl + '/users';

        service.Register = function (registerData, success, error) {
            $http.post(serviceUrl + '/register', registerData)
                .success(function (data) {
                    success(data);
                }).error(error);
        };

        service.Login = function (loginData, success, error) {
            $http.post(serviceUrl + '/login', loginData)
                .success(function (data) {
                    success(data);
                }).error(error);
        };

        service.Logout = function (success, error) {
            $http.post(serviceUrl + '/logout', null, {headers: this.GetHeaders()})
                .success(function () {
                    success();
                }).error(error);
        };

        service.SetCredentials = function (serverData) {
            localStorage['accessToken'] = serverData.access_token;
            localStorage['userName'] = serverData.userName;
            localStorage['isLogged'] = true;
        };

        service.ClearCredentials = function () {
            delete localStorage['accessToken'];
            delete localStorage['userName'];
            delete localStorage['isLogged'];
        };

        service.GetHeaders = function() {
            return {
                Authorization: "Bearer " + localStorage['accessToken']
            };
        };

        service.isLoggedIn = function () {
            var isLoggedIn = false;
            if (localStorage['accessToken'] && localStorage['accessToken'].length == 512 && localStorage['isLogged']) {
                isLoggedIn = true;
            }
            return isLoggedIn;
        };

        return service;
    });
});
