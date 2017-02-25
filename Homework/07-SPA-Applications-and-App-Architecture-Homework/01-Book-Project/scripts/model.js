define(['q'], function (Q) {
    return (function() {
        var Model = function (baseUrl) {
            this.books = new Book(baseUrl);
        };

        var Request = (function() {
            function makeRequest(method, url, data) {
                var defer = Q.defer();

                $.ajax({
                    method: method,
                    headers: {
                        'X-Parse-Application-Id': '3R0am7DNpyhAa3olwfzK9eYI2kNXvhZHx0yHtVLI',
                        'X-Parse-REST-API-Key': '0TaeWn9gGcyzjwg2ymvqPPubWDNupaPn91Er3jCJ'
                    },
                    url: url,
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    success: function (data) {
                        defer.resolve(data);
                    },
                    error: function (error) {
                        defer.reject(error);
                    }
                });

                return defer.promise;
            }

            function getRequest(url) {
                var defer = Q.defer();
                makeRequest('Get', url, null).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
            }

            function postRequest(url, data) {
                var defer = Q.defer();
                makeRequest('POST', url, data).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
            }

            function editRequest(url, data) {
                var defer = Q.defer();
                makeRequest('PUT', url, data).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
            }

            function deleteRequest(url) {
                var defer = Q.defer();
                makeRequest('DELETE', url, null).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
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

            Book.prototype.loadBooks = function () {
                var defer = Q.defer();
                Request.getRequest(this.classUrl).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
            };

            Book.prototype.createBook = function (book) {
                var defer = Q.defer();
                Request.postRequest(this.classUrl, book).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
            };

            Book.prototype.editBook = function (id, book) {
                var defer = Q.defer();
                Request.editRequest(this.classUrl + id, book).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
            };

            Book.prototype.deleteBook = function (id) {
                var defer = Q.defer();
                Request.deleteRequest(this.classUrl + id).then(
                    function (data) {
                        defer.resolve(data);
                    },
                    function (error) {
                        defer.reject(error);
                    }
                );
                return defer.promise;
            };

            return Book;
        })();

        return {
            loadModel: function (baseUrl) {
                return new Model(baseUrl);
            }
        }
    })();
});

