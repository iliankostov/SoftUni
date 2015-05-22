define(['app', 'constants', 'requestService', 'notifyService', 'navigationService'], function (app) {
    app.factory('profileService', function ($rootScope, constants, requestService, notifyService, navigationService) {
        var service = {};

        var serviceUrl = constants.baseServiceUrl + '/me';

        service.loadFeeds = function () {
            var lastPost = '';
            var url = serviceUrl + '/feed?StartPostId='+ lastPost +'&PageSize=5';
            var headers = requestService.getHeaders();
            return requestService.GetRequest(url, headers);
        };

        service.GetUser = function () {
            var url = serviceUrl;
            var headers = requestService.getHeaders();
            return requestService.GetRequest(url, headers);
        };

        service.saveUserData = function(data) {
            for (var d in data) {
                if (data.hasOwnProperty(d)) {
                    switch (d) {
                        case 'profileImageData':
                            sessionStorage[d] = data[d] || constants.baseProfilePicture;
                            break;
                        case 'coverImageData':
                            sessionStorage[d] = data[d] || constants.baseCoverPicture;
                            break;
                        default:
                            sessionStorage[d] = data[d];
                            break;
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

        service.EditProfile = function (editProfileData) {
            var url = serviceUrl;
            var headers = requestService.getHeaders();
            return requestService.PutRequest(url, headers, editProfileData);
        };

        service.ChangePassword = function (changePasswordData) {
            var url = serviceUrl + '/changepassword';
            var headers = requestService.getHeaders();
            return requestService.PutRequest(url, headers, changePasswordData);
        };

        return service;
    });
});
