define(['app', 'authentication', 'notifyService'], function (app) {
    app.controller('MainController', function ($scope, $location, $route, authentication, notifyService) {

        var ClearData = function () {
            $scope.loginData = '';
            $scope.registerData = '';
            $scope.userData = '';
            $scope.passwordData = '';
        };
        $scope.isLoggedIn = authentication.isLoggedIn();

        function escapeHtml(text) {
            var map = {
                '&': '&amp;',
                '<': '&lt;',
                '>': '&gt;',
                '"': '&quot;',
                "'": '&#039;'
            };

            return text.replace(/[&<>"']/g, function(m) { return map[m]; });
        }

        $scope.validateWhenSignUp = function () {

            var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

            if ($scope.registerData.username.length < 4 || $scope.registerData.username.length > 32) {
                notifyService.showError("The username must be from 4 to 32 characters long.");
            } else if (!emailPattern.test($scope.registerData.email)) {
                notifyService.showError("Incorrect email address.");
            } else if ($scope.registerData.password.length < 6 || $scope.registerData.password.length > 32) {
                notifyService.showError("The password must be from 6 to 32 characters long.");
            } else if ($scope.registerData.password !== $scope.registerData.confirmPassword) {
                notifyService.showError("The password and confirmation password do not match.");
            } else {
                var registerData = {
                    username: escapeHtml($scope.registerData.username),
                    email: escapeHtml($scope.registerData.email),
                    password: escapeHtml($scope.registerData.password),
                    confirmPassword: escapeHtml($scope.registerData.confirmPassword),
                    name: escapeHtml($scope.registerData.name),
                    gender: escapeHtml($scope.registerData.gender)
                };

                $scope.register(registerData);
            }
        };

        $scope.register = function (registerData) {
            authentication.Register(registerData,
                function (serverData) {
                    notifyService.showInfo("Successful Register!");
                    authentication.SetCredentials(serverData);
                    ClearData();
                    $route.reload();
                    $location.path('/');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Register!", serverError)
                });
        };

        $scope.validateWhenLogIn = function () {
            if ($scope.loginData.username.length < 4 || $scope.loginData.username.length > 32) {
                notifyService.showError("The username must be from 4 to 32 characters long.");
            } else if ($scope.loginData.password.length < 6 || $scope.loginData.password.length > 32) {
                notifyService.showError("The password must be from 6 to 32 characters long.");
            } else {
                var loginData = {
                    username: escapeHtml($scope.loginData.username),
                    password: escapeHtml($scope.loginData.password)
                };
                $scope.login(loginData);
            }
        };

        $scope.login = function (loginData) {
            authentication.Login(loginData,
                function (serverData) {
                    notifyService.showInfo("Successful Login!");
                    authentication.SetCredentials(serverData);
                    ClearData();
                    $route.reload();
                    $location.path('/');
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Login!", serverError)
                });
        };

        $scope.logout = function () {
            authentication.Logout(
                function () {
                    notifyService.showInfo("Successful Logout!");
                    ClearData();
                    authentication.ClearCredentials();
                    $route.reload();
                },
                function (serverError) {
                    notifyService.showError("Unsuccessful Logout!", serverError)
                }
            )
        };

        $scope.cancel = function () {
            $location.path('/');
        };
    });
});
