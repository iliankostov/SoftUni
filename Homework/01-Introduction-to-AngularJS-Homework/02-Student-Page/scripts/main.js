requirejs.config({
    baseUrl: 'scripts',

    paths: {
        angular: 'libs/AngularJS-1.3.15-min',
        angularRouter: 'libs/AngularJS-Route-1.3.15-min',
        angularAMD: 'libs/AngularAMD-0.2.1-min',

        app: 'app'
    },

    shim: {
        'angularAMD': ['angular'],
        'angularRouter': ['angular']
    }
});

requirejs(['app'], function () {
});