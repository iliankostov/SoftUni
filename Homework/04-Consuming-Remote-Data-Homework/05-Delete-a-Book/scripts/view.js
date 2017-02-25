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
            title: $('#add-title').val(),
            author: $('#add-author').val(),
            isbn: $('#add-isbn').val()
        };
        this.model.books.createBook(book,
            function (data) {
                _this.addBookToDom(book, data.objectId);
            },
            function (error) {
                console.error(error.responseText);
            }
        );
    };

    View.prototype.editBook = function (bookId) {
        var book = {
            title: $('#edit-title').val(),
            author: $('#edit-author').val(),
            isbn: $('#edit-isbn').val()
        };
        this.model.books.editBook(bookId, book,
            function (data) {
                var bookContainer = $('#wrapper').find('[data-id=' + bookId + ']');
                bookContainer.children('.title').text(book.title);
                bookContainer.children('.author').text(book.author);
                bookContainer.children('.isbn').text(book.isbn);
            },
            function (error) {
                console.error(error.responseText);
            }
        );
    };

    View.prototype.deleteBook = function (bookId) {
        this.model.books.deleteBook(bookId,
            function (data) {
                $('#wrapper').find('[data-id=' + bookId + ']').remove();
                cleanEditInputs();
            },
            function (error) {
                console.error(error.responseText);
            }
        )
    };

    View.prototype.attachEventListeners = function () {
        var _this = this;
        $('#add-btn').click(function () {
            _this.createBook();
            $('#add-title').val('');
            $('#add-author').val('');
            $('#add-isbn').val('');
        });
        $('#edit-btn').click(function () {
            var bookId = $('#edit-btn').attr('data-id');
            _this.editBook(bookId);
            cleanEditInputs();
        })
    };

    View.prototype.addBookToDom = function (book, bookId) {
        var _this, bookContainer, bookTitle, bookAuthor, bookIsbn, deleteButton;
        _this = this;
        bookContainer = $('<div />').attr('data-id', bookId);
        bookContainer.click(function () {
            $('#edit-title').val(book.title);
            $('#edit-author').val(book.author);
            $('#edit-isbn').val(book.isbn);
            $('#edit-btn').attr('data-id', bookId);
        });
        bookTitle = $('<p />').addClass('title').text(book.title);
        bookAuthor = $('<p />').addClass('author').text(book.author);
        bookIsbn = $('<p />').addClass('isbn').text(book.isbn);
        deleteButton = $('<button>Delete</button>').addClass('delete-btn');
        deleteButton.click(function () {
            _this.deleteBook(bookId);
        });
        bookContainer.append(bookTitle).append(bookAuthor).append(bookIsbn).append(deleteButton);
        $('#wrapper').append(bookContainer);
    };

    function cleanEditInputs() {
        $('#edit-title').val('');
        $('#edit-author').val('');
        $('#edit-isbn').val('');
    }

    return {
        loadView: function (model) {
            return new View(model);
        }
    };
})();