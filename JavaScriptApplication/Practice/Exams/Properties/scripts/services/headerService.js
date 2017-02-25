define(['storageService', 'constants'], function (storageService, constants) {
    var headerService = {};

    headerService.get = function () {
        var headers = {};

        headers['X-Parse-Application-Id'] = constants.APPLICATION_ID;
        headers['X-Parse-REST-API-Key'] = constants.REST_API_KEY;
        headers['Content-Type'] = constants.DEFAULT_CONTENT_TYPE;

        if (storageService.isLogged()) {
            headers['X-Parse-Session-Token'] = storageService.getSessionToken();
        }

        return headers;
    };

    return headerService;
});
