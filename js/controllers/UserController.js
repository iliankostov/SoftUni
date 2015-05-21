define(['app', 'constants', 'validationService', 'authenticationService', 'userService',
        'ngFacePictureSelect', 'ngCoverPictureSelect'],
    function (app) {
        app.controller('UserController', function ($scope, $location, validationService,
                                                   authenticationService, userService) {
            $scope.title = "Edit settings";
            $scope.changePasswordData = {};
            $scope.userData = getUserData();
            $scope.isLoggedIn = authenticationService.isLoggedIn();

            $scope.changePassword = function () {
                var changePasswordData = $scope.changePasswordData;
                if (validationService.validateChangePasswordForm(changePasswordData.newPassword, changePasswordData.confirmPassword)) {
                    changePasswordData = validationService.escapeHtmlSpecialChars(changePasswordData);
                    userService.ChangePassword(changePasswordData);
                }
            };

            $scope.editProfile = function () {
                var userData = $scope.userData;
                if (validationService.validateEditProfileForm(userData.email)) {
                    userData = validationService.escapeHtmlSpecialChars(userData);
                    userService.EditProfile(userData);
                }
            };
            
            $scope.logout = function () {
                userService.Logout();
            };

            $scope.redirect = function () {
                $location.path('/');
            };

            function getUserData() {
                var data = {};
                for (var d in sessionStorage) {
                    if (sessionStorage.hasOwnProperty(d)) {
                        data[d] = sessionStorage[d];
                    }
                }
                return data;
            }
        })
    }
);
