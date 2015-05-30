define(['app', 'CommentController', 'validationService', 'postService', 'notifyService'],
    function (app) {
        app.controller('PostController', function ($scope, validationService, postService, notifyService) {
            $scope.postData = {};
            $scope.isEditPostTextareaExpanded = false;
            $scope.isNewCommentTextareaExpanded = false;

            $scope.expandEditPostTextarea = function (postId) {
                $scope.editPostId = postId;
                $scope.isEditPostTextareaExpanded = !$scope.isEditPostTextareaExpanded;
            };

            $scope.expandNewCommentTextarea = function (postId) {
                $scope.commentPostId = postId;
                $scope.isNewCommentTextareaExpanded = !$scope.isNewCommentTextareaExpanded;
            };

            $scope.likeSecurity = function (post) {
                var isMe = post.wallOwner.username === $scope.myData.username;
                var isAuthorFriend = post.author.isFriend;
                var isWallOwnerFriend = post.wallOwner.isFriend;

                if (isWallOwnerFriend || isMe) {
                    return true;
                } else {
                    return !!isAuthorFriend;
                }
            };

            $scope.createPost = function () {
                var postData = validationService.escapeHtmlSpecialChars($scope.postData);
                postData.username = $scope.userData.username;
                postService.createPost(postData).then(
                    function (serverData) {
                        $scope.feedData.unshift(serverData);
                        $scope.postData.postContent = '';
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                );
            };

            $scope.editPost = function (post) {
                var newPostData = {};
                newPostData.id = post.id;
                newPostData.postContent = validationService.escapeHtmlSpecialChars(post.postContent, true);
                postService.editPost(newPostData).then(
                    function (serverData) {
                        post.postContent = newPostData.postContent;
                        $scope.isEditPostTextareaExpanded = false;
                        notifyService.showInfo("Your post has been successfully edited.");
                    },
                    function (serverError) {
                        notifyService.showError("Cannot edit post.", serverError);
                    }
                );
            };

            $scope.deletePost = function (post) {
                postService.deletePost(post.id).then(
                    function () {
                        var index =  $scope.feedData.indexOf(post);
                        $scope.feedData.splice(index, 1);
                        notifyService.showInfo("The post has been successfully deleted.");
                    },
                    function (serverError) {
                        notifyService.showError("Cannot delete post.", serverError);
                    }
                );
            };

            $scope.likePost = function (post) {
                postService.likePost(post.id).then(
                    function () {
                        post.likesCount++
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                )
            };

            $scope.unlikePost = function (post) {
                postService.unlikePost(post.id).then(
                    function () {
                        post.likesCount--;
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                )
            };
        })
    }
);

