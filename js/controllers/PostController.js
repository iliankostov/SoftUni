define(['app', 'validationService', 'postService'],
    function (app) {
        app.controller('PostController', function ($scope, validationService, postService) {
            $scope.postData = {};

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

            $scope.likePost = function (post) {
                postService.likePost(post.id).then(
                    function (serverData) {
                        post.likesCount++
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                )
            };

            $scope.unlikePost = function (post) {
                postService.unlikePost(post.id).then(
                    function (serverData) {
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

