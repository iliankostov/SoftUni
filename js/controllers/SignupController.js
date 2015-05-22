define(['app', 'validationService', 'userService', 'navigationService', 'notifyService'],
    function (app) {
        app.controller('SignupController', function ($scope, $rootScope, validationService, userService,
                                                     navigationService, notifyService) {
            $scope.title = "Sign up to iBook";
            $scope.signUpData = {};
            $scope.isLoggedIn = userService.isLoggedIn();

            $scope.signUp = function () {
                var registerData = $scope.signUpData;
                if (validationService.validateRegisterForm(registerData.username, registerData.email,
                        registerData.password, registerData.confirmPassword, registerData.name)) {
                    registerData = validationService.escapeHtmlSpecialChars(registerData);
                    userService.SignUp(registerData).then(
                        function (serverResponse) {
                            $rootScope.$broadcast('userDataUpdate');
                            userService.setCredentials(serverResponse);
                            navigationService.loadHome();
                            notifyService.showInfo("Sign Up successful.");
                        },
                        function (serverError) {
                            notifyService.showError("Unsuccessful Sign Up!", serverError)
                        }
                    );
                }
            };

            $scope.cancel = function () {
                navigationService.loadHome();
            }
        })
    }
);
