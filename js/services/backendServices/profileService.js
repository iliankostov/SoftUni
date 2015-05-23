define(['app', 'constants', 'requestService'], function (app) {
    app.factory('profileService', function ($rootScope, constants, requestService) {
        var service, serviceUrl;
        service = {};
        serviceUrl = constants.baseServiceUrl + '/me';

        service.loadNewsFeed = function (startPost) {
            if (!startPost) {
                startPost = '';
            }
            var url = serviceUrl + '/feed?StartPostId='+ startPost +'&PageSize=' + constants.pageSize;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.getUser = function () {
            var url = serviceUrl;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
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

        service.getOwnFriends = function () {
            var url = serviceUrl + '/friends';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers)
        };

        service.getFriendRequests = function () {
            var url = serviceUrl + '/requests';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.editProfile = function (editProfileData) {
            var url = serviceUrl;
            var headers = requestService.getHeaders();
            return requestService.putRequest(url, headers, editProfileData);
        };

        service.changePassword = function (changePasswordData) {
            var url = serviceUrl + '/changepassword';
            var headers = requestService.getHeaders();
            return requestService.putRequest(url, headers, changePasswordData);
        };

        return service;
    });
});
