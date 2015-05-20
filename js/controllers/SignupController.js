define(['app', 'validationService', 'authenticationService', 'navigationService'], function (app) {
    app.controller('SignupController', function ($scope, validationService, authenticationService, navigationService) {
        $scope.title = "Sign up to iBook";
        $scope.signUpData = {};
        $scope.isLoggedIn = authenticationService.isLoggedIn();

        $scope.signUp = function () {
            var registerData = $scope.signUpData;
            if (validationService.ValidateRegisterForm(registerData.username, registerData.email,
                    registerData.password, registerData.confirmPassword)) {
                registerData = validationService.EscapeHtmlSpecialChars(registerData);
                authenticationService.SignUp(registerData);
            }
        };

        $scope.cancel = function () {
            navigationService.loadHome();
        }
    })
});
