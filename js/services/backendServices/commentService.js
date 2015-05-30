define(['app', 'constants', 'requestService'], function (app) {
    app.factory('commentService', function ($rootScope, constants, requestService) {
        var service, serviceUrl;
        service = {};
        serviceUrl = constants.baseServiceUrl + '/posts/';

        service.createComment = function (postId, commentData) {
            var url = serviceUrl + postId + '/comments';
            var headers = requestService.getHeaders();
            return requestService.postRequest(url, headers, commentData);
        };

        service.loadComment = function (postId) {
            var url = serviceUrl + postId + '/comments';
            var headers = requestService.getHeaders();
            return requestService.getRequest(url, headers);
        };

        service.editComment = function (postId, newCommentData) {
            var url = serviceUrl + postId + '/comments/' + newCommentData.id;
            var headers = requestService.getHeaders();
            return requestService.putRequest(url, headers, newCommentData);
        };

        service.deleteComment = function (postId, commentId) {
            var url = serviceUrl + postId + '/comments/' + commentId;
            var headers = requestService.getHeaders();
            return requestService.deleteRequest(url, headers);
        };

        service.likeComment = function (postId, commentId) {
            var url = serviceUrl + postId + '/comments/' + commentId + '/likes';
            var headers = requestService.getHeaders();
            return requestService.postRequest(url, headers);
        };

        service.unlikeComment = function (postId, commentId) {
            var url = serviceUrl + postId + '/comments/' + commentId + '/likes';
            var headers = requestService.getHeaders();
            return requestService.deleteRequest(url, headers);
        };

        return service;
    });
});
