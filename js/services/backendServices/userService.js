define(['app', 'constants', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('userService', function ($rootScope, constants, requestService, notifyService, navigationService) {
        var service = {};

        var serviceUrl = constants.baseServiceUrl + '/users';

        service.SignUp = function (registerData) {
            var url = serviceUrl + '/register';
            var headers = null;
            return requestService.PostRequest(url, headers, registerData);
        };

        service.LogIn = function (loginData) {
            var url = serviceUrl + '/login';
            var headers = null;
            return requestService.PostRequest(url, headers, loginData);
        };

        service.Logout = function () {
            var url = serviceUrl + '/logout';
            var headers = requestService.getHeaders();
            return requestService.PostRequest(url, headers).then(
                function (serverResponse) {
                    notifyService.showInfo(serverResponse.message);
                    clearCredentials();
                    navigationService.loadHome(true);
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Logout!", serverError);
                }
            )
        };

        service.isLoggedIn = function () {
            return !!(sessionStorage['accessToken'] && sessionStorage['accessToken'].length > 490);
        };

        service.setCredentials = function(serverData) {
            sessionStorage['accessToken'] = serverData.access_token;
            sessionStorage['isLogged'] = true;
        };

        function clearCredentials() {
            for (var key in sessionStorage) {
                if (sessionStorage.hasOwnProperty(key)) {
                    delete sessionStorage[key];
                }
            }
        }

        return service;
    });
});
