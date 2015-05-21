define(['app', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('userService', function (baseServiceUrl, requestService, notifyService, navigationService) {
        var service = {};

        service.GetUser = function () {
            var url = baseServiceUrl + '/me';
            var headers = getHeaders();
            return requestService.GetRequest(url, headers);
        };

        service.ChangePassword = function (changePasswordData) {
            var url = baseServiceUrl + '/me/changepassword';
            var headers = getHeaders();
            return requestService.PutRequest(url, headers, changePasswordData).then(
                function (serverResponse) {
                    notifyService.showInfo(serverResponse.message);
                    navigationService.loadHome();
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful change password!", serverError);
                }
            )
        };

        service.EditProfile = function (editProfileData) {
            var url = baseServiceUrl + '/me';
            var headers = getHeaders();
            return requestService.PutRequest(url, headers, editProfileData).then(
                function (serverResponse) {
                    notifyService.showInfo(serverResponse.message);
                    navigationService.loadHome();
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful edit profile", serverError);
                }
            )
        };

        service.Logout = function () {
            var url = baseServiceUrl + '/users/logout';
            var headers = getHeaders();
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

        function clearCredentials() {
            delete sessionStorage['accessToken'];
            delete sessionStorage['userName'];
            delete sessionStorage['isLogged'];
        }

        function getHeaders() {
            return {
                Authorization: "Bearer " + sessionStorage['accessToken']
            };
        }

        return service;
    });
});
