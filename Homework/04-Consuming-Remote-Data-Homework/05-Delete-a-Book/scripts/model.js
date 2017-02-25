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

    var Book = (function() {
        function Book(baseUrl) {
            this.classUrl = baseUrl + 'Book/';
        }

        Book.prototype.loadBooks = function (success, error) {
            return Request.getRequest(this.classUrl, success, error);
        };

        Book.prototype.createBook = function (book, success, error) {
            return Request.postRequest(this.classUrl, book, success, error);
        };

        Book.prototype.editBook = function (id, book, success, error) {
            return Request.editRequest(this.classUrl + id, book, success, error);
        };

        Book.prototype.deleteBook = function (id, success, error) {
            return Request.deleteRequest(this.classUrl + id, success, error);
        };

        return Book;
    })();

    return {
        loadModel: function (baseUrl) {
            return new Model(baseUrl);
        }
    }
})();