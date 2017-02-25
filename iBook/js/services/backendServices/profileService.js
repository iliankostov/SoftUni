define(['app', 'constants', 'requestService'], function (app) {
    app.factory('profileService', function ($rootScope, constants, requestService) {
        var service, serviceUrl;
        service = {};
        serviceUrl = constants.baseServiceUrl + '/me';

        service.loadNewsFeed = function (startPost) {
            if (!startPost) {
                startPost = '';
            }
            var url = serviceUrl + '/feed?StartPostId=' + startPost + '&PageSize=' + constants.pageSize;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.getMe = function () {
            var url = serviceUrl;
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.saveMyData = function (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property)) {
                    switch (property) {
                        case 'profileImageData':
                            sessionStorage[property] = data[property] || constants.baseProfilePicture;
                            break;
                        case 'coverImageData':
                            sessionStorage[property] = data[property] || constants.baseCoverPicture;
                            break;
                        default:
                            sessionStorage[property] = data[property];
                            break;
                    }
                }
            }
        };

        service.loadMyData = function () {
            var data = {};
            for (var property in sessionStorage) {
                if (sessionStorage.hasOwnProperty(property)) {
                    data[property] = sessionStorage[property];
                }
            }
            return data;
        };

        service.getMyFriendsPreview = function () {
            var url = serviceUrl + '/friends/preview';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.getMyFriends = function () {
            var url = serviceUrl + '/friends';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.sendFriendRequest = function (username) {
            var url = serviceUrl + '/requests/' + username;
            var headers = requestService.getHeaders();
            return requestService.postRequest(url, headers);
        };

        service.getFriendRequests = function () {
            var url = serviceUrl + '/requests';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.acceptFriendRequest = function (requestId) {
            var url = serviceUrl + '/requests/' + requestId + '?status=approved';
            var headers = requestService.getHeaders();
            return requestService.putRequest(url, headers);
        };

        service.rejectFriendRequest = function (requestId) {
            var url = serviceUrl + '/requests/' + requestId + '?status=rejected';
            var headers = requestService.getHeaders();
            return requestService.putRequest(url, headers);
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
