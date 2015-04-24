requirejs.config({
    baseUrl: 'scripts',
    paths: {
        jquery: 'libs/jquery-2.1.3.min',
        sammy: 'libs/sammy-latest.min'
    },
    shim: {
        sammy: {
            deps: ['jquery'],
            exports: 'Sammy'
        }
    }
});

define(['jquery', 'sammy'], function ($, Sammy) {
    (function () {
        var selector = $('#wrapper');

        function printInput() {
            clear();
            var names = ['Sam', 'Bob', 'Tom'];
            var list = $('<ul />');
            names.forEach(function (name) {
                list.append($('<li />').append($('<a href="#/' + name + '" />').text(name)));
            });
            selector.append(list);
        }

        function printOutput(name) {
            clear();
            var greetingTag = $('<h2 />').text('Hello ' + name);
            selector.append(greetingTag);
        }

        function clear() {
            selector.text('');
        }

        var router = Sammy(function () {
            this.get('#/', function () {
                printInput();
            });
            this.get('#/Sam', function () {
                printOutput('Sam');
            });
            this.get('#/Bob', function () {
                printOutput('Bob');
            });
            this.get('#/Tom', function () {
                printOutput('Tom');
            });
        });

        router.run('#/')
    })();
});