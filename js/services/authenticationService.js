define(['app', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('authenticationService', function (baseServiceUrl, requestService, notifyService, navigationService) {
        var service = {};

        var serviceUrl = baseServiceUrl + '/users';

        service.SignUp = function (registerData) {
            var url = serviceUrl + '/register';
            var headers = null;
            return requestService.PostRequest(url, headers, registerData).then(
                function (serverResponse) {
                    notifyService.showInfo("Sign Up successful.");
                    setCredentials(serverResponse);
                    navigationService.loadHome();
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Sign Up!", serverError)
                }
            );
        };

        service.LogIn = function (loginData) {
            var url = serviceUrl + '/login';
            var headers = null;
            return requestService.PostRequest(url, headers, loginData).then(
                function (serverResponse) {
                    notifyService.showInfo("Log In successful.");
                    setCredentials(serverResponse);
                    navigationService.loadHome();
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Log In!", serverError)
                }
            )
        };

        service.isLoggedIn = function () {
            var isLoggedIn = false;
            if (sessionStorage['accessToken'] && sessionStorage['accessToken'].length > 490 && sessionStorage['isLogged']) {
                isLoggedIn = true;
            }
            return isLoggedIn;
        };

        function setCredentials(serverData) {
            sessionStorage['accessToken'] = serverData.access_token;
            sessionStorage['userName'] = serverData.userName;
            sessionStorage['isLogged'] = true;
        }

        return service;
    });
});
