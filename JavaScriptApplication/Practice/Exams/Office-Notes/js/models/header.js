define([], function () {
    function Header(applicationId, restApiKey) {
        this.applicationId = applicationId;
        this.restApiKey = restApiKey;
    }

    Header.prototype.getHeaders = function (useSessionToken, fileType) {
        var contentType;
        if (fileType) {
            contentType = '' + fileType;
        } else {
            contentType = 'application/json';
        }

        var headers = {
            'X-Parse-Application-Id': this.applicationId,
            'X-Parse-REST-API-Key': this.restApiKey,
            'Content-Type': contentType
        };
        
        if (sessionStorage['sessionToken'] && useSessionToken) {
            headers['X-Parse-Session-Token'] = sessionStorage['sessionToken'];
        }

        return headers;
    };

    return {
        load: function (applicationId, restApiKey) {
            return new Header(applicationId, restApiKey);
        }
    }
});
