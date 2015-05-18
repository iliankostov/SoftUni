define(['app', 'requestService', 'notifyService'], function (app) {
    app.factory('authenticationService', function ($route, $location, baseServiceUrl, requestService, notifyService) {
        var service = {};

        var serviceUrl = baseServiceUrl + '/users';

        service.Register = function (registerData) {
            var url = serviceUrl + '/register';
            var headers = null;
            return requestService.PostRequest(url, headers, registerData).then(
                function (serverResponse) {
                    notifyService.showInfo(serverResponse.message);
                    setCredentials(serverResponse);
                    $route.reload();
                    $location.path('/');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Register!", serverError)
                }
            );
        };

        service.Login = function (loginData) {
            var url = serviceUrl + '/login';
            var headers = null;
            return requestService.PostRequest(url, headers, loginData).then(
                function (serverResponse) {
                    notifyService.showInfo("Login successful.");
                    setCredentials(serverResponse);
                    $route.reload();
                    $location.path('/');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Login!", serverError)
                }
            )
        };

        service.ChangePassword = function (changePasswordData) {
            var url = baseServiceUrl + '/me/changepassword';
            var headers = getHeaders();
            return requestService.PutRequest(url, headers, changePasswordData).then(
                function (serverResponse) {
                    notifyService.showInfo(serverResponse.message);
                    $route.reload();
                    $location.path('/');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful change password!", serverError)
                }
            )
        };

        service.Logout = function () {
            var url = serviceUrl + '/logout';
            var headers = getHeaders();
            return requestService.PostRequest(url, headers).then(
                function (serverResponse) {
                    notifyService.showInfo(serverResponse.message);
                    clearCredentials();
                    $route.reload();
                    $location.path('/');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Logout!", serverError)
                }
            )
        };

        service.isLoggedIn = function () {
            var isLoggedIn = false;
            if (localStorage['accessToken'] && localStorage['accessToken'].length > 490 && localStorage['isLogged']) {
                isLoggedIn = true;
            }
            return isLoggedIn;
        };

        function setCredentials(serverData) {
            localStorage['accessToken'] = serverData.access_token;
            localStorage['userName'] = serverData.userName;
            localStorage['isLogged'] = true;
        }

        function clearCredentials() {
            delete localStorage['accessToken'];
            delete localStorage['userName'];
            delete localStorage['isLogged'];
        }

        function getHeaders() {
            return {
                Authorization: "Bearer " + localStorage['accessToken']
            };
        }

        return service;
    });
});
