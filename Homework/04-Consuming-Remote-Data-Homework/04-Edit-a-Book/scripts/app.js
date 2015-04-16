var app = app || {};

(function() {
    var model = app.model.loadModel('https://api.parse.com/1/classes/');
    var view = app.view.loadView(model);
    view.showAllBooks();
})();