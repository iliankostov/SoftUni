define(['app', 'validationService', 'commentService', 'notifyService'],
    function (app) {
        app.controller('CommentController', function ($scope, validationService, commentService, notifyService) {

            $scope.loadComments = function (post) {
                commentService.loadComments(post.id).then(
                    function (serverData) {
                        post.comments = serverData;
                    },
                    function (serverError) {
                        console.log(serverError);
                    }
                )
            };

            $scope.createComment = function (post, commentData) {
                commentData = validationService.escapeHtmlSpecialChars(commentData);
                commentService.createComment(post.id, commentData).then(
                    function (serverData) {
                        post.totalCommentsCount++;
                        post.comments.unshift(serverData);
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.likeComment = function (post, comment) {
                commentService.likeComment(post.id, comment.id).then(
                    function () {
                        comment.likesCount++
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                )
            };

            $scope.unlikeComment = function (post, comment) {
                commentService.unlikeComment(post.id, comment.id).then(
                    function () {
                        comment.likesCount--;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                )
            };

        })
    }
);

