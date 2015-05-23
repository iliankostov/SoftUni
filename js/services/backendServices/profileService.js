define(['app', 'constants', 'requestService'], function (app) {
    app.factory('profileService', function ($rootScope, constants, requestService) {
        var headers, service, url, serviceUrl;
        service = {};
        headers = requestService.getHeaders();
        serviceUrl = constants.baseServiceUrl + '/me';

        service.loadNewsFeed = function (startPost) {
            if (!startPost) {
                startPost = '';
            }
            url = serviceUrl + '/feed?StartPostId='+ startPost +'&PageSize=' + constants.pageSize;
            return requestService.getRequest(url, headers);
        };

        service.getUser = function () {
            url = serviceUrl;
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
            url = serviceUrl + '/friends';
            return requestService.getRequest(url, headers)
        };

        service.getFriendRequests = function () {
            url = serviceUrl + '/requests';
            return requestService.getRequest(url, headers);
        };

        service.editProfile = function (editProfileData) {
            url = serviceUrl;
            return requestService.putRequest(url, headers, editProfileData);
        };

        service.changePassword = function (changePasswordData) {
            url = serviceUrl + '/changepassword';
            return requestService.putRequest(url, headers, changePasswordData);
        };

        return service;
    });
});
