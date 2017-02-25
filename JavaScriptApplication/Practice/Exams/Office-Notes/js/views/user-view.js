define(['mustache', 'sammy', 'noty'], function (Mustache, Sammy, Noty) {
    return (function() {
        function UserViews() {
            this.loginView = {
                loadLoginView: loadLoginView
            };
            this.registerView = {
                loadRegisterView: loadRegisterView
            };
            this.editProfileView = {
                loadEditProfileView: loadEditProfileView
            };
        }

        function loadLoginView (selector) {
            $.get('templates/login.html', function(template) {
                var outHtml = Mustache.render(template);
                $(selector).html(outHtml);
            }).then(function() {
                $('#loginButton').click(function() {
                    var username = $('#username').val();
                    var password = $('#password').val();

                    Sammy(function() {
                        this.trigger('login', {username: username, password: password});
                    });

                    return false;
                })
            }).done();
        }

        function loadRegisterView (selector) {
            $.get('templates/register.html', function(template) {
                var outHtml = Mustache.render(template);
                $(selector).html(outHtml);
            }).then(function() {
                var file;
                $('#upload-photo').on('change', function (e) {
                    var files = e.target.files || e.dataTransfer.files;
                    file = files[0];
                    validateFile(file);
                });

                $('#registerButton').click(function() {
                    var username = $('#username').val();
                    var password = $('#password').val();
                    var fullName = $('#fullName').val();

                    Sammy(function() {
                        this.trigger('register', {username: username, password: password, fullName: fullName, file: file});
                    });

                    return false;
                })
            }).done();
        }

        function loadEditProfileView(selector, data) {
            $.get('templates/edit-profile.html', function(template) {
                var outHtml = Mustache.render(template, data);
                $(selector).html(outHtml);
            }).then(function() {
                var file;
                $('#upload-photo').on('change', function (e) {
                    var files = e.target.files || e.dataTransfer.files;
                    file = files[0];
                    validateFile(file);
                });
                $('#editProfileButton').click(function() {
                    var username = $('#username').val();
                    var password = $('#password').val();
                    var fullName = $('#fullName').val();

                    Sammy(function() {
                        this.trigger('editProfile', {username: username, password: password, fullName: fullName, file: file});
                    });

                    return false;
                })
            }).done();
        }

        function validateFile(file) {
            if (file.type.match(/image\/.*/)) {
                if (file.size < 1000000) {
                    var reader = new FileReader();
                    reader.onload = function () {
                        $('#picture-preview').attr('src', reader.result);
                        $('#upload-photo').attr('data-file', file)
                    };
                    reader.readAsDataURL(file);
                }
                else {
                    Noty.error("The file size is limited to 1 MB!");
                }
            } else {
                Noty.error("Invalid file format.");
            }
        }

        return {
            load: function() {
                return new UserViews();
            }
        }
    }());
});
