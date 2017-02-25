define(['notificationService'], function (notificationService) {
    var validationService = {};

    validationService.escapeHtmlSpecialChars = function (inputObject, isString) {
        if (!isString) {
            var outputObject = {};
            for (var property in inputObject) {
                if (inputObject.hasOwnProperty(property)) {
                    outputObject[property] = escapeHtmlSpecialChars(inputObject[property]);
                }
            }
            return outputObject;
        } else {
            return escapeHtmlSpecialChars(inputObject)
        }
    };

    validationService.validateLogInForm = function (username, password) {
        return (validateUsername(username) && validatePassword(password));
    };

    validationService.validateSignUpForm = function (username, password, confirmPassword) {
        return (validateUsername(username) && validatePassword(password) &&
                validateConfirmPasswordMatch(password, confirmPassword));
    };

    validationService.validateChangePasswordForm = function (newPassword, confirmPassword) {
        return (validatePassword(newPassword) && validateConfirmPasswordMatch(newPassword, confirmPassword));
    };

    validationService.validateEditProfileForm = function (name, email) {
        return (validateName(name) && validateEmailAddress(email));
    };

    validationService.validatePictureType = function (picture) {
        if (picture.type !== 'image/jpeg') {
            notificationService.showError("The picture format must be .jpg!");
            return false;
        }
        return true;
    };

    validationService.validatePictureSize = function (picture, maxSize) {
        if (picture.size > maxSize) {
            notificationService.showError('The picture size cannot be more than ' + (maxSize / 1024) + 'KB');
            return false;
        }
        return true;
    };

    validationService.validateMessage = function (postDataContent) {
        if (postDataContent.length < 2) {
            notificationService.showError("The message content must be at least 2 symbols long.");
            return false;
        }
        return true;
    };

    validationService.validatePrice = function (priceNumber) {
        if (isNaN(priceNumber)) {
            notificationService.showError("The price must be number");
            return false;
        }
        return true;
    };

    validationService.validateName = function (name) {
        return validateName(name);
    };

    function validateUsername(username) {
        var usernamePattern = /^[a-zA-Z0-9]{4,32}$/;
        if (!usernamePattern.test(username)) {
            notificationService.showError("The username can only contain letters or digits from 4 to 32 symbols.");
            return false;
        }
        return true;
    }

    function validateEmailAddress(email) {
        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
        if (!emailPattern.test(email)) {
            notificationService.showError("Incorrect email address.");
            return false;
        }
        return true;
    }

    function validatePassword(password) {
        if (password.length < 6 || password.length > 32) {
            notificationService.showError("The password must be from 6 to 32 characters long.");
            return false;
        }
        return true;
    }

    function validateConfirmPasswordMatch(password, confirmPassword) {
        if (password !== confirmPassword) {
            notificationService.showError("The password and confirmation password do not match.");
            return false;
        }
        return true;
    }

    function validateName(name) {
        if (name.length < 4 || name.length > 32) {
            notificationService.showError("The name must be from 4 to 32 characters long.");
            return false;
        }
        return true;
    }

    function escapeHtmlSpecialChars(text) {
        var map = {
            '<': '&lt;',
            '>': '&gt;'
        };

        return text.replace(/[<>]/g, function (m) {
            return map[m];
        });
    }

    return validationService;
});
