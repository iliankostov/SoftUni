var app = app || {};

app.view = (function() {
    function View(model) {
        this.model = model;
    }

    View.prototype.showAllBooks = function () {
        this.model.books.loadBooks(
            function (data) {
                data.results.forEach(function (book) {
                    var bookContainer, bookTitle, bookAuthor, bookIsbn;
                    bookContainer = $('<div />').attr('data-id', book.objectId);
                    bookTitle = $('<p />').text(book.title);
                    bookAuthor = $('<p />').text(book.author);
                    bookIsbn = $('<p />').text(book.isbn);
                    bookContainer.append(bookTitle).append(bookAuthor).append(bookIsbn);
                    $('#wrapper').append(bookContainer);
                })
            },
            function (error) {
                console.error(error.responseText);
            }
        )
    };

    return {
        loadView: function (model) {
            return new View(model);
        }
    };
})();
