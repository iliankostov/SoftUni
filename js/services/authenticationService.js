define(['app', 'constants', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('authenticationService',
        function ($rootScope, constants, requestService, notifyService, navigationService) {
            var service = {};

            var serviceUrl = constants.baseServiceUrl + '/users';

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
                        $rootScope.$broadcast('userDataUpdate');
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
                sessionStorage['isLogged'] = true;
            }

            return service;
        }
    );
});
