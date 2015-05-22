requirejs.config({
    baseUrl: 'js',

    paths: {
        // libs
        angular: 'libs/angular-1.3.15',
        angularRouter: 'libs/angular-route-1.3.15-min',
        angularAMD: 'libs/AngularAMD-0.2.1-min',
        skel: 'libs/skel.min',
        jquery: 'libs/jquery-2.1.4',
        noty: 'libs/jquery.noty.packaged',

        // app
        app: 'app',

        // constants
        constants: 'constants',

        // back-end services
        postService: 'services/backendServices/postService',
        profileService: 'services/backendServices/profileService',
        userService: 'services/backendServices/userService',

        // services
        fileReaderService: 'services/fileReaderService',
        navigationService: 'services/navigationService',
        notifyService: 'services/notifyService',
        requestService: 'services/requestService',
        validationService: 'services/validationService',

        // directives
        ngPictureSelect: 'directives/ngPictureSelect',
        ngCoverSelect: 'directives/ngCoverSelect',
        ngCoverBackground: 'directives/ngCoverBackground',
        ngInfiniteScroll: 'directives/ngInfiniteScroll'
    },

    shim: {
        noty: ['jquery'],
        angular: ['jquery'],
        angularAMD: ['angular'],
        angularRouter: ['angular']
    }
});

requirejs(['app', 'skel'], function (app, skel) {
    (function () {

        skel.init({
            reset: 'full',
            breakpoints: {
                'global': {range: '*', href: 'css/style.css'},
                'desktop': {range: '737-', href: 'css/style-desktop.css', containers: 1200, grid: {gutters: 25}},
                '1000px': {
                    range: '737-1200',
                    href: 'css/style-1000px.css',
                    containers: 960,
                    grid: {gutters: 25},
                    viewport: {width: 1080}
                },
                'mobile': {
                    range: '-736',
                    href: 'css/style-mobile.css',
                    containers: '100%!',
                    grid: {collapse: true, gutters: 15},
                    viewport: {scalable: false}
                }
            }
        });

    })();
});
