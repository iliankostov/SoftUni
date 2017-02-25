define(['mustache', 'sammy'], function (Mustache, Sammy) {
    function UserViews() {
        this.loadRegistration = loadRegistration;
        this.loadLogin = loadLogin;
    }

    function loadRegistration(selector) {
        $.get('templates/register.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        }).then(function () {
            $('#register-button').click(function () {
                var user = {
                    username: $('#username').val(),
                    password: $('#password').val(),
                    confirmPassword: $('#confirm-password').val()
                };

                Sammy(function () {
                    this.trigger('register', user);
                });

                return false;
            })
        }).done();
    }

    function loadLogin(selector) {
        $.get('templates/login.html', function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        }).then(function () {
            $('#login-button').click(function () {
                var user = {
                    username: $('#username').val(),
                    password: $('#password').val()
                };

                Sammy(function () {
                    this.trigger('login', user);
                });

                return false;
            })
        }).done();

    }

    return {
        load: function () {
            return new UserViews();
        }
    }
});
