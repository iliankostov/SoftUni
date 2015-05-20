define(['app', 'authenticationService', 'validationService', 'ngFileSelect'], function (app) {
    app.controller('MainController', function ($scope, $location, baseFacePicture, authenticationService, validationService) {
        $scope.registerData = {};
        $scope.loginData = {};
        $scope.changePasswordData = {};
        $scope.editProfileData = {};
        $scope.editProfileData.facePicture = baseFacePicture;


        $scope.isLoggedIn = authenticationService.isLoggedIn();

        $scope.register = function () {
            var registerData = $scope.registerData;
            if (validationService.ValidateRegisterForm(registerData.username, registerData.email,
                    registerData.password, registerData.confirmPassword)) {
                registerData = validationService.EscapeHtmlSpecialChars(registerData);
                authenticationService.Register(registerData);
            }
        };

        $scope.login = function () {
            var loginData = $scope.loginData;
            if (validationService.ValidateLoginForm(loginData.username, loginData.password)) {
                loginData = validationService.EscapeHtmlSpecialChars(loginData);
                authenticationService.Login(loginData);
            }
        };

        $scope.changePassword = function () {
            var changePasswordData = $scope.changePasswordData;
            if (validationService.ValidateChangePasswordForm(changePasswordData.newPassword, changePasswordData.confirmPassword)) {
                changePasswordData = validationService.EscapeHtmlSpecialChars(changePasswordData);
                authenticationService.ChangePassword(changePasswordData);
            }
        };

        $scope.logout = function () {
            authenticationService.Logout();
        };

        $scope.cancel = function () {
            $location.path('/');
        };
    });
});
