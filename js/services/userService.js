define(['app', 'constants', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('userService', function ($rootScope, constants, requestService, notifyService, navigationService) {
        var service = {};

        var baseServiceUrl = constants.baseServiceUrl;

        service.GetUser = function () {
            var url = baseServiceUrl + '/me';
            var headers = getHeaders();
            return requestService.GetRequest(url, headers);
        };

        service.saveUserData = function(data) {
            for (var d in data) {
                if (data.hasOwnProperty(d)) {
                    if (d == 'profileImageData') {
                        sessionStorage[d] = data[d] || constants.baseProfilePicture;
                    } else if (d == 'coverImageData') {
                        sessionStorage[d] = data[d] || constants.baseCoverPicture;
                    } else {
                        sessionStorage[d] = data[d];
                    }
                }
            }
        };

        service.loadUserData = function () {
            var data = {};
            for (var d in sessionStorage) {
                if (sessionStorage.hasOwnProperty(d)) {
                    data[d] = sessionStorage[d];
                }
            }
            return data;
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
                    $rootScope.$broadcast('userDataUpdate');
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
            for (var key in sessionStorage) {
                if (sessionStorage.hasOwnProperty(key)) {
                    delete sessionStorage[key];
                }
            }
        }

        function getHeaders() {
            return {
                Authorization: "Bearer " + sessionStorage['accessToken']
            };
        }

        return service;
    });
});
