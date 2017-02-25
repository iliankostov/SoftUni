requirejs.config({
    baseUrl: 'scripts',
    paths: {
        jquery: 'libs/jquery-2.1.3.min',
        mustache: 'libs/mustache.min',
        sammy: 'libs/sammy-latest.min',

        modelRepo: 'modelRepo',
        outputView: 'view',
        controller: 'controller'
    },
    shim: {
        sammy: {
            deps: ['jquery'],
            exports: 'Sammy'
        }
    }
});

define(['jquery', 'sammy', 'modelRepo', 'controller'], function ($, Sammy, modelRepo, ctrl) {
    (function() {
        var selector = '#wrapper';
        var model = modelRepo.load();
        var controller = ctrl.load(model);

        var router = Sammy(function () {
            this.get('#/', function () {
                controller.getOutput(selector, model.data);
            })
        });

        router.run('#/')
    })();
});