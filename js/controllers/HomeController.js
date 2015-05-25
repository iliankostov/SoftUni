define(['app', 'constants', 'HeaderController', 'userService', 'profileService',
        'ngInfiniteScroll'],
    function (app) {
        app.controller('HomeController', function ($scope, $rootScope, constants, userService, profileService) {
            var newsFeedStartPost;
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.newsFeedBusy = false;
            $scope.feedData = [];
            if ($scope.isLoggedIn) {
                $scope.title = $scope.myData.name + ' - News Feed';
            } else {
                $scope.title = "Welcome to iBook";
            }



            $scope.loadNewsFeed = function () {
                if ($scope.isLoggedIn) {
                    if ($scope.newsFeedBusy){
                        return;
                    }
                    $scope.newsFeedBusy = true;

                    profileService.loadNewsFeed(newsFeedStartPost).then(
                        function (serverData) {
                            $scope.feedData = $scope.feedData.concat(serverData);
                            if($scope.feedData.length > 0){
                                newsFeedStartPost = $scope.feedData[$scope.feedData.length - 1].id;
                                $scope.newsFeedBusy = false;
                            }
                        },
                        function (serverError) {
                            console.error(serverError);
                        }
                    );
                }
            };
        })
    }
);
