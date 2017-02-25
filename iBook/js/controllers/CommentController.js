define(['app', 'PopupController', 'ngPopup', 'validationService', 'commentService', 'notifyService'],
    function (app) {
        app.controller('CommentController', function ($scope, validationService, commentService, notifyService) {
            $scope.isEditCommentTextareaExpanded = false;

            $scope.expandEditCommentTextarea = function (commentId) {
                $scope.editCommentId = commentId;
                $scope.isEditCommentTextareaExpanded = !$scope.isEditCommentTextareaExpanded;
            };

            $scope.loadComments = function (post) {
                commentService.loadComments(post.id).then(
                    function (serverData) {
                        post.comments = serverData;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                )
            };

            $scope.createComment = function (post, commentData) {
                commentData = validationService.escapeHtmlSpecialChars(commentData);
                if (validationService.validateMessage(commentData.commentContent)) {
                    commentService.createComment(post.id, commentData).then(
                        function (serverData) {
                            post.totalCommentsCount++;
                            post.comments.unshift(serverData);
                        },
                        function (serverError) {
                            console.error(serverError);
                        }
                    );
                }
            };

            $scope.editComment = function (post, comment) {
                var newCommentData = {};
                newCommentData.id = comment.id;
                newCommentData.commentContent = validationService.escapeHtmlSpecialChars(comment.commentContent, true);
                commentService.editComment(post.id, newCommentData).then(
                    function () {
                        comment.commentContent = newCommentData.commentContent;
                        $scope.isEditCommentTextareaExpanded = false;
                        notifyService.showInfo("Your comment has been successfully edited.");
                    },
                    function (serverError) {
                        notifyService.showError("Cannot edit comment.", serverError);
                    }
                );
            };

            $scope.deleteComment = function (post, comment) {
                commentService.deleteComment(post.id, comment.id).then(
                    function () {
                        var index =  post.comments.indexOf(comment);
                        post.comments.splice(index, 1);
                        post.totalCommentsCount--;
                        notifyService.showInfo("The comment has been successfully deleted.");
                    },
                    function (serverError) {
                        notifyService.showError("Cannot delete comment.", serverError);
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
