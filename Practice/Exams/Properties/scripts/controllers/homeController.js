define(['storageService'], function (storageService) {
    function HomeController(view) {
        this.view = view;
    }

    HomeController.prototype.showWelcomeScreen = function (selector) {
        this.view.loadWelcome(selector);
    };

    HomeController.prototype.showHomeScreen = function (selector) {
        var data = storageService.getUserData();
        this.view.loadHome(selector, data);
    };

    return {
        load: function (view) {
            return new HomeController(view);
        }
    }
});
