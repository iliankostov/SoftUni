define(['app', 'validationService', 'authenticationService', 'navigationService'],
    function (app) {
        app.controller('LoginController', function ($scope, validationService, authenticationService,
                                                    navigationService) {
            $scope.title = "Log in to iBook";
            $scope.logInData = {};
            $scope.isLoggedIn = authenticationService.isLoggedIn();

            $scope.logIn = function () {
                var loginData = $scope.logInData;
                if (validationService.validateLogInForm(loginData.username, loginData.password)) {
                    loginData = validationService.escapeHtmlSpecialChars(loginData);
                    authenticationService.LogIn(loginData);
                }
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            }
        })
    }
);
