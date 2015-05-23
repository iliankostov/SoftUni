define(['app', 'HeaderController', 'validationService', 'userService', 'profileService', 'navigationService', 'notifyService',
        'ngPictureSelect', 'ngCoverSelect'], function (app) {
        app.controller('SettingsController', function ($scope, validationService, userService,
                                                   navigationService, notifyService, profileService ) {
            $scope.isLoggedIn = userService.isLoggedIn();
            $scope.myData = profileService.loadMyData();
            $scope.title = $scope.myData.name + ' - Edit settings';
            $scope.changePasswordData = {};

            $scope.editProfile = function () {
                var userData = $scope.myData;
                if (validationService.validateEditProfileForm(myData.name, myData.email)) {
                    myData = validationService.escapeHtmlSpecialChars(myData);
                    profileService.editProfile(myData).then(
                        function (serverResponse) {
                            $rootScope.$broadcast('userDataUpdate');
                            navigationService.loadHome();
                            notifyService.showInfo(serverResponse.message);
                        },
                        function (serverError) {
                            notifyService.showError("Unsuccessful edit profile", serverError);
                        }
                    )
                }
            };

            $scope.changePassword = function () {
                var changePasswordData = $scope.changePasswordData;
                if (validationService.validateChangePasswordForm(changePasswordData.newPassword, changePasswordData.confirmPassword)) {
                    changePasswordData = validationService.escapeHtmlSpecialChars(changePasswordData);
                    profileService.changePassword(changePasswordData).then(
                        function (serverResponse) {
                            notifyService.showInfo(serverResponse.message);
                            navigationService.loadHome();
                        },
                        function (serverError) {
                            notifyService.showError("Unsuccessful change password!", serverError);
                        }
                    )
                }
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            };
        })
    }
);
