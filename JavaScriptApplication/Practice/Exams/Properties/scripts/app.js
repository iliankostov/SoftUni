define(['sammy', 'constants', 'notificationService', 'storageService',
        'homeViews', 'homeController',
        'userModel', 'userViews', 'userController',
        'categoryModel', 'estateModel', 'estateViews', 'estateController'],
    function (Sammy, constants, notificationService, storageService,
              homeViews, homeController,
              userModel, userViews, userController,
              categoryModel, estateModel, estateViews, estateController) {

        homeViews = homeViews.load();
        homeController = homeController.load(homeViews);

        userModel = userModel.load();
        userViews = userViews.load();
        userController = userController.load(userModel, userViews);

        categoryModel = categoryModel.load();
        estateModel = estateModel.load();
        estateViews = estateViews.load();
        estateController = estateController.load(categoryModel, estateModel, estateViews);

        var router = Sammy(function () {
            var selector = '#main';

            this.before(function () {
                if (storageService.isLogged()) {
                    $('#user-menu').show();
                    $('#guest-menu').hide();
                } else {
                    $('#user-menu').hide();
                    $('#guest-menu').show();
                }
            });

            //todo test this.before regex cannot redirect

            this.get('#/', function () {
                if (storageService.isLogged()) {
                    this.redirect('#/home/');
                } else {
                    this.redirect('#/welcome/');
                }
            });

            this.get('#/welcome/', function () {
                if (!storageService.isLogged()) {
                    homeController.showWelcomeScreen(selector);
                } else {
                    notificationService.showError(constants.USER_ACCESS_DENIED_MESSAGE);
                    this.redirect('#/')
                }
            });

            this.get('#/home/', function () {
                if (storageService.isLogged()) {
                    homeController.showHomeScreen(selector);
                } else {
                    notificationService.showError(constants.GUEST_ACCESS_DENIED_MESSAGE);
                    this.redirect('#/')
                }
            });

            this.get('#/register/', function () {
                if (!storageService.isLogged()) {
                    userController.showRegistrationScreen(selector);
                } else {
                    notificationService.showError(constants.USER_ACCESS_DENIED_MESSAGE);
                    this.redirect('#/')
                }
            });

            this.get('#/login/', function () {
                if (!storageService.isLogged()) {
                    userController.showLoginScreen(selector);
                } else {
                    notificationService.showError(constants.USER_ACCESS_DENIED_MESSAGE);
                    this.redirect('#/')
                }
            });

            this.get('#/logout/', function () {
                if (storageService.isLogged()) {
                    userController.logout();
                } else {
                    notificationService.showError(constants.GUEST_ACCESS_DENIED_MESSAGE);
                    this.redirect('#/')
                }
            });

            this.get('#/add/', function () {
                if (storageService.isLogged()) {
                    estateController.showAddEstate(selector);
                } else {
                    notificationService.showError(constants.GUEST_ACCESS_DENIED_MESSAGE);
                    this.redirect('#/')
                }
            });

            this.get('#/estates/', function () {
                if (storageService.isLogged()) {
                    estateController.showEstates(selector);
                } else {
                    notificationService.showError(constants.GUEST_ACCESS_DENIED_MESSAGE);
                    this.redirect('#/')
                }
            });

            this.bind('register', function (event, data) {
                userController.register(data);
            });

            this.bind('login', function (event, data) {
                userController.login(data);
            });

            this.bind('logout', function () {
                userController.logout();
            });

            this.bind('addEstate', function (event, data) {
                estateController.addEstate(selector, data);
            });

            this.bind('showEditEstate', function (e, data) {
                estateController.showEditEstate(selector, data);
            });

            this.bind('editEstate', function (e, data) {
                estateController.editEstate(selector, data);
            });

            this.bind('showDeleteEstate', function (e, data) {
                estateController.showDeleteEstate(selector, data);
            });

            this.bind('deleteEstate', function (e, data) {
                estateController.deleteEstate(selector, data);
            });

            this.bind('filterEstates', function (e, data) {
                estateController.filterEstates(selector, data);
            });
        });

        router.run('#/');
    }
);
