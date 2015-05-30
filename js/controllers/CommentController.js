define(['app', 'validationService', 'postService', 'notifyService'],
    function (app) {
        app.controller('CommentController', function ($scope, validationService, postService, notifyService) {

            $scope.createComment = function (postId, commentData) {
                commentData = validationService.escapeHtmlSpecialChars(commentData);
                postService.createPost(postId, commentData).then(
                    function (serverData) {
                        console.log(serverData);
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };
        })
    }
);

