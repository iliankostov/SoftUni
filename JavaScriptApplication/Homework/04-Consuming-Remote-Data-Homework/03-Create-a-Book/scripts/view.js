var app = app || {};

app.view = (function() {
    function View(model) {
        this.model = model;
        this.attachEventListeners();
    }

    View.prototype.showAllBooks = function () {
        var _this = this;
        this.model.books.loadBooks(
            function (data) {
                data.results.forEach(function (book) {
                    _this.addBookToDom(book, book.objectId);
                })
            },
            function (error) {
                console.error(error.responseText);
            }
        )
    };

    View.prototype.createBook = function () {
        var _this = this;
        var book = {
            title: $('#title').val(),
            author: $('#author').val(),
            isbn: $('#isbn').val()
        };
        this.model.books.createBook(book,
            function (data) {
                _this.addBookToDom(book, data.objectId);
            },
            function (error) {
                console.log(error);
            }
        );
    };

    View.prototype.attachEventListeners = function () {
        var _this = this;
        $('#add-book').click(function () {
            _this.createBook();
        });
    };

    View.prototype.addBookToDom = function (book, bookId) {
        var bookContainer, bookTitle, bookAuthor, bookIsbn;
        bookContainer = $('<div />').attr('data-id', bookId);
        bookTitle = $('<p />').text(book.title);
        bookAuthor = $('<p />').text(book.author);
        bookIsbn = $('<p />').text(book.isbn);
        bookContainer.append(bookTitle).append(bookAuthor).append(bookIsbn);
        $('#wrapper').append(bookContainer);
    };

    return {
        loadView: function (model) {
            return new View(model);
        }
    };
})();
