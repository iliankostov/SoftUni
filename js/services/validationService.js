define(['app', 'notifyService'], function (app) {
    app.factory('validationService', function (notifyService) {
        var service = {};

        service.EscapeHtmlSpecialChars = function (inputObject) {
            var outputObject = {};
            for (var key in inputObject) {
                if (inputObject.hasOwnProperty(key)) {
                    outputObject[key] = escapeHtmlSpecialChars(inputObject[key])
                }
            }
            return outputObject;
        };

        service.ValidateLoginForm = function (username, password) {
            return (validateUsername(username) && validatePassword(password));
        };

        service.ValidateRegisterForm = function (username, email, password, confirmPassword) {
            return (validateUsername(username) && validateEmailAddress(email) &&
            validatePassword(password) && validateConfirmPasswordMatch(password, confirmPassword));
        };

        function validateUsername(username) {
            if (username.length < 4 || username.length > 32) {
                notifyService.showError("The username must be from 4 to 32 characters long.");
                return false;
            }
            return true;
        }

        function validateEmailAddress(email) {
            var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
            if (!emailPattern.test(email)) {
                notifyService.showError("Incorrect email address.");
                return false;
            }
            return true;
        }

        function validatePassword(password) {
            if (password.length < 6 || password.length > 32) {
                notifyService.showError("The password must be from 6 to 32 characters long.");
                return false;
            }
            return true;
        }

        function validateConfirmPasswordMatch(password, confirmPassword) {
            if (password !== confirmPassword) {
                notifyService.showError("The password and confirmation password do not match.");
                return false;
            }
            return true;
        }

        function escapeHtmlSpecialChars(text) {
            var map = {
                '&': '&amp;',
                '<': '&lt;',
                '>': '&gt;',
                '"': '&quot;',
                "'": '&#039;'
            };

            return text.replace(/[&<>"']/g, function (m) {
                return map[m];
            });
        }

        return service;
    })
});
