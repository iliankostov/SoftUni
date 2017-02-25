requirejs.config({
    baseUrl: 'scripts',
    paths: {
        //libs
        jquery: 'libs/jquery-2.1.3.min',
        sammy: 'libs/sammy-latest.min',
        mustache: 'libs/mustache.min',
        q: 'libs/q',

        //scripts
        model: 'model',
        view: 'view'
    },
    shim: {
        sammy: {
            deps: ['jquery'],
            exports: 'Sammy'
        }
    }
});

define(['jquery', 'sammy', 'model', 'view'], function ($, Sammy, model, view) {
    (function() {
        var modelInstance = model.loadModel('https://api.parse.com/1/classes/');
        var viewInstance = view.loadView(modelInstance);

        var router = Sammy(function () {
            this.get('#/', function () {
                viewInstance.showAllBooks();
            })
        });

        router.run('#/');
    })();
});
