define(['notificationService', 'storageService', 'validationService', 'constants'],
    function (notificationService, storageService, validationService, constants) {

        function UserController(model, view) {
            this.model = model;
            this.view = view;
        }

        UserController.prototype.showRegistrationScreen = function (selector) {
            this.view.loadRegistration(selector);
        };

        UserController.prototype.showLoginScreen = function (selector) {
            this.view.loadLogin(selector);
        };

        UserController.prototype.register = function (user) {
            if(validationService.validateSignUpForm(user['username'], user['password'], user['confirmPassword'])) {
                user = validationService.escapeHtmlSpecialChars(user);
                return this.model.register(user).then(
                    function (data) {
                        data['username'] = user['username'];
                        data['fullName'] = user['fullName'];
                        storageService.setUserData(data);
                        notificationService.showSuccess(constants.SUCCESSFUL_REGISTRATION_MESSAGE);
                        window.location.hash = '/home/';
                    }, function (error) {
                        var errorText = error['responseJSON']['error'] || constants.ERROR_REGISTRATION_MESSAGE;
                        notificationService.showError(errorText);
                    });
            }
        };

        UserController.prototype.login = function (user) {
            if (validationService.validateLogInForm(user['username'], user['password'])) {
                user = validationService.escapeHtmlSpecialChars(user);
                return this.model.login(user).then(
                    function (data) {
                        storageService.setUserData(data);
                        notificationService.showSuccess(constants.SUCCESSFUL_LOGIN_MESSAGE);
                        window.location.hash = '/home/';
                    }, function (error) {
                        var errorText = error['responseJSON']['error'] || constants.ERROR_LOGIN_MESSAGE;
                        notificationService.showError(errorText);
                    });
            }
        };

        UserController.prototype.logout = function () {
            return this.model.logout().then(
                function () {
                    storageService.clearStorage();
                    notificationService.showSuccess(constants.SUCCESSFUL_LOGOUT_MESSAGE);
                    window.location.hash = '/';
                }, function (error) {
                    var errorText = error['responseJSON']['error'] || constants.ERROR_LOGOUT_MESSAGE;
                    notificationService.showError(errorText);
                });
        };

        return {
            load: function (model, view) {
                return new UserController(model, view);
            }
        }
    }
);
