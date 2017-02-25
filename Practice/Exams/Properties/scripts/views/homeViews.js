define(['mustache', 'storageService'], function (Mustache, storageService) {
    function HomeViews() {
        this.loadWelcome = loadWelcome;
        this.loadHome = loadHome;
    }

    function loadWelcome(selector) {
        $.get('templates/welcome.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        })
    }

    function loadHome(selector, data) {
        $.get('templates/home.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
            $('#welcome-message').text('Welcome, ' +storageService.getUsername())
        })
    }

    return {
        load: function () {
            return new HomeViews();
        }
    }
});
