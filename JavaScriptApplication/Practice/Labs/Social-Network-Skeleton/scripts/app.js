requirejs.config({
    baseUrl: 'scripts',

    paths: {
        // libs
        noty: '../libs/jquery.noty.packaged.min',
        jquery: '../libs/jquery-2.1.3.min',
        mustache: '../libs/mustache.min',
        q: '../libs/q.min',
        sammy: '../libs/sammy-latest.min',

        // models
        model: 'model',
        // views
        view: 'view',
        // controller
        ctrl: 'controller'
    },

    shim: {
        sammy: {
            deps: ['jquery'],
            exports: 'Sammy'
        },
        noty: {
            deps: ['jquery'],
            exports: 'noty'
        }
    }
});