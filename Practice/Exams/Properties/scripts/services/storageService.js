define(function () {
    var storageService = {};

    storageService.getSessionToken = function () {
        return sessionStorage.getItem('sessionToken');
    };

    storageService.setSessionToken = function (sessionToken) {
        sessionStorage.setItem('sessionToken', sessionToken);
    };

    storageService.getUserId = function () {
        return sessionStorage.getItem('userId');
    };

    storageService.setUserId = function (userId) {
        sessionStorage.setItem('userId', userId);
    };

    storageService.getUsername = function () {
        return sessionStorage.getItem('username');
    };

    storageService.setUsername = function (username) {
        sessionStorage.setItem('username', username);
    };

    storageService.getName = function () {
        return sessionStorage.getItem('fullName');
    };

    storageService.setName = function (name) {
        sessionStorage.setItem('fullName', name);
    };

    storageService.isLogged = function () {
        return !!storageService.getSessionToken();
    };

    storageService.getUserData = function () {
        var data = {};
        for (var property in sessionStorage) {
            if (sessionStorage.hasOwnProperty(property)) {
                data[property] = sessionStorage[property];
            }
        }

        return data;
    };

    storageService.setUserData = function (data) {
        storageService.setSessionToken(data['sessionToken']);
        storageService.setUserId(data['objectId']);
        storageService.setUsername(data['username']);
        storageService.setName(data['fullName']);
    };

    storageService.clearStorage = function () {
        for (var property in sessionStorage) {
            if (sessionStorage.hasOwnProperty(property)) {
                delete sessionStorage[property];
            }
        }
    };

    return storageService;
});
