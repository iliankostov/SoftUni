define(['app', 'validationService', 'userService', 'navigationService', 'notifyService'],
    function (app) {
        app.controller('LoginController', function ($scope, $rootScope, validationService, userService,
                                                    navigationService, notifyService) {
            $scope.title = "Log in to iBook";
            $scope.logInData = {};
            $scope.isLoggedIn = userService.isLoggedIn();

            $scope.logIn = function () {
                var loginData = $scope.logInData;
                if (validationService.validateLogInForm(loginData.username, loginData.password)) {
                    loginData = validationService.escapeHtmlSpecialChars(loginData);
                    userService.logIn(loginData).then(
                        function (serverResponse) {
                            $rootScope.$broadcast('userDataUpdate');
                            userService.setCredentials(serverResponse);
                            navigationService.loadHome();
                            notifyService.showInfo("Log In successful.");
                        },
                        function (serverError) {
                            notifyService.showError("Unsuccessful Log In!", serverError)
                        }
                    )
                }
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            }
        })
    }
);
