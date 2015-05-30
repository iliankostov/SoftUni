define(['app', 'validationService', 'commentService', 'notifyService'],
    function (app) {
        app.controller('CommentController', function ($scope, validationService, commentService, notifyService) {

            $scope.loadComments = function (postId) {
                commentService.loadComments(postId).then(
                    function (serverData) {
                        console.log(serverData);
                    },
                    function (serverError) {
                        console.log(serverError);
                    }
                )
            };

            $scope.createComment = function (post, commentData, isNewCommentTextareaExpanded) {
                isNewCommentTextareaExpanded = false;
                commentData = validationService.escapeHtmlSpecialChars(commentData);
                commentService.createComment(post.id, commentData).then(
                    function (serverData) {
                        post.totalCommentsCount++;
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

