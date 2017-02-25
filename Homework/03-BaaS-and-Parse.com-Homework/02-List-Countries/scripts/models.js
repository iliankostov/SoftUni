var world = world || {};

world.model = (function() {
    function Model(baseUrl) {
        this.countries = new Country(baseUrl);
    }

    var Request = (function() {
        function makeRequest(method, url, data, success, error) {
            $.ajax({
                method: method,
                headers: {
                    'X-Parse-Application-Id': 'hcmyvWbukYJkHIshECknrOcrMV9sn5wBWJiWQPN6',
                    'X-Parse-REST-API-Key': 'FG6PMDsqHQZ6RBxmHulEzD3vZFR1b5hHlfQNgr6y'
                },
                url: url,
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: success,
                error: error
            })
        }

        function getRequest(url, success, error) {
            makeRequest('Get', url, null, success, error)
        }

        return {
            getRequest: getRequest
        }
    })();

    var Country = (function() {
        function Country(baseUrl) {
            this.serviceUrl = baseUrl + 'Country/';
        }

        Country.prototype.loadCountries = function loadCountries(success, error) {
            return Request.getRequest(this.serviceUrl, success, error);
        };
        return Country;
    })();

    return {
        loadModel: function (baseUrl) {
            return new Model(baseUrl);
        }
    }
})();