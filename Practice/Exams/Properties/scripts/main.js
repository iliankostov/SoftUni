requirejs.config({
    baseUrl: 'scripts',

    paths: {
        // Libraries
        'noty': '../libs/jquery.noty.packaged.min',
        'jquery': '../libs/jquery-2.1.4.min',
        'lodash': '../libs/lodash.min',
        'mustache': '../libs/mustache.min',
        'q': '../libs/q.min',
        'sammy': '../libs/sammy-latest.min',

        // App
        'app': 'app',

        // Service
        'constants': 'services/constants',
        'headerService': 'services/headerService',
        'notificationService': 'services/notificationService',
        'parseService': 'services/parseService',
        'requestService': 'services/requestService',
        'storageService': 'services/storageService',
        'validationService': 'services/validationService',

        // Models
        'categoryModel': 'models/categoryModel',
        'estateModel': 'models/estateModel',
        'userModel': 'models/userModel',

        // Views
        'homeViews': 'views/homeViews',
        'estateViews': 'views/estateViews',
        'userViews': 'views/userViews',

        // Controllers
        'homeController': 'controllers/homeController',
        'estateController': 'controllers/estateController',
        'userController': 'controllers/userController'
    },

    shim: {
        'noty': ['jquery'],
        'sammy': ['jquery']
    },

    deps: ['app']
});
