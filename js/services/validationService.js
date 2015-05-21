define(['app', 'notifyService'], function (app) {
    app.factory('validationService', function (notifyService) {
        var service = {};

        service.escapeHtmlSpecialChars = function (inputObject) {
            var outputObject = {};
            for (var key in inputObject) {
                if (inputObject.hasOwnProperty(key)) {
                    if (key !== 'gender' && key !== 'profileImageData' && key !== 'coverImageData') {
                        outputObject[key] = escapeHtmlSpecialChars(inputObject[key]);
                    } else {
                        outputObject[key] = inputObject[key];
                    }
                }
            }
            return outputObject;
        };

        service.validateLogInForm = function (username, password) {
            return (validateUsername(username) && validatePassword(password));
        };

        service.validateRegisterForm = function (username, email, password, confirmPassword) {
            return (validateUsername(username) && validateEmailAddress(email) &&
            validatePassword(password) && validateConfirmPasswordMatch(password, confirmPassword));
        };

        service.validateChangePasswordForm = function (newPassword, confirmPassword) {
            return (validatePassword(newPassword) && validateConfirmPasswordMatch(newPassword, confirmPassword));
        };

        service.validateEditProfileForm = function (email) {
            return (validateEmailAddress(email));
        };

        service.validatePictureType = function (picture) {
            if (picture.type !== 'image/jpeg') {
                notifyService.showError("The picture format must be .jpg!");
                return false;
            }
            return true;
        };

        service.validatePictureSize = function (picture, maxSize) {
            if (picture.size > maxSize) {
                notifyService.showError('The picture size cannot be more than ' + (maxSize / 1024) + 'KB');
                return false;
            }
            return true;
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
