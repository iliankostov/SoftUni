var app = app || {};

app.model = (function() {
    var Model = function (baseUrl) {
        this.books = new Book(baseUrl);
    };

    var Request = (function() {
        function makeRequest(method, url, data, success, error) {
            $.ajax({
                method: method,
                headers: {
                    'X-Parse-Application-Id': '3R0am7DNpyhAa3olwfzK9eYI2kNXvhZHx0yHtVLI',
                    'X-Parse-REST-API-Key': '0TaeWn9gGcyzjwg2ymvqPPubWDNupaPn91Er3jCJ'
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

    var Book = (function() {
        function Book(baseUrl) {
            this.classUrl = baseUrl + 'Book/';
        }

        Book.prototype.loadBooks = function (success, error) {
            return Request.getRequest(this.classUrl, success, error);
        };

        return Book;
    })();

    return {
        loadModel: function (baseUrl) {
            return new Model(baseUrl);
        }
    }
})();