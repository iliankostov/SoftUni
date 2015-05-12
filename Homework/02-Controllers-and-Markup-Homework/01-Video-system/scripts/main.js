requirejs.config({
    baseUrl: 'scripts',

    paths: {
        //libs
        angular: 'libs/angular',
        angularRouter: 'libs/AngularJS-Route-1.3.15-min',
        angularAMD: 'libs/AngularAMD-0.2.1-min',
        //services
        'videoData': 'services/video-data',
        //app
        app: 'app'
    },

    shim: {
        'angularAMD': ['angular'],
        'angularRouter': ['angular']
    }
});

requirejs(['app'], function () {
});