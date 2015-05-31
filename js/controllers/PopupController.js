define(['app', 'constants', 'userService'],
    function (app) {
        app.controller('PopupController', function ($scope, constants, userService) {
            $scope.userPreviewData = {};

            $scope.loadUserPreview = function (username) {
                userService.loadUserPreview(username).then(
                    function (serverData) {
                        $scope.userPreviewData = serverData;
                        if (!$scope.userPreviewData.profileImageData) {
                            $scope.userPreviewData.profileImageData = constants.baseProfilePicture;
                        }
                    },
                    function (serverError) {
                        console.error(serverError);
                    }
                )
            }
        })
    }
);
