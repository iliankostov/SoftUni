define(['app', 'constants', 'validationService', 'authenticationService', 'navigationService', 'userService',
        'ngFacePictureSelect', 'ngCoverPictureSelect'],
    function (app) {
        app.controller('UserController', function ($scope, $location, validationService, authenticationService,
                                                   navigationService, userService) {

            $scope.changePasswordData = {};
            $scope.userData = userService.loadUserData();
            $scope.title = $scope.userData.name + ' - Edit settings';
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
                if (validationService.validateEditProfileForm(userData.name, userData.email)) {
                    userData = validationService.escapeHtmlSpecialChars(userData);
                    userService.EditProfile(userData);
                }
            };

            $scope.logout = function () {
                userService.Logout();
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            };
        })
    }
);
