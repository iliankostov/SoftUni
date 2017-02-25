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

        function postRequest(url, data, success, error) {
            makeRequest('POST', url, data, success, error)
        }

        function editRequest(url, data, success, error) {
            makeRequest('PUT', url, data, success, error)
        }

        function deleteRequest(url, success, error) {
            makeRequest('DELETE', url, null, success, error);
        }

        return {
            getRequest: getRequest,
            postRequest: postRequest,
            editRequest: editRequest,
            deleteRequest: deleteRequest
        }
    })();

    var Country = (function() {
        function Country(baseUrl) {
            this.serviceUrl = baseUrl + 'Country/';
        }

        Country.prototype.loadCountries = function loadCountries(success, error) {
            return Request.getRequest(this.serviceUrl, success, error);
        };

        Country.prototype.addCountry = function addCountry(country, success, error) {
            return Request.postRequest(this.serviceUrl, country, success, error);
        };

        Country.prototype.editCountry = function editCountry(id, country, success, error) {
            return Request.editRequest(this.serviceUrl + id, country, success, error)
        };

        Country.prototype.deleteCountry = function deleteCountry(id, success, error) {
            return Request.deleteRequest(this.serviceUrl + id, success, error)
        };
        return Country;
    })();

    return {
        loadModel: function (baseUrl) {
            return new Model(baseUrl);
        }
    }
})();