define(['noty'], function (Noty) {
    return (function() {
        function UserController(model, views) {
            this.model = model;
            this.viewBag = views;
        }

        UserController.prototype.loadRegisterPage = function(selector) {
            this.viewBag.registerView.loadRegisterView(selector);
        };

        UserController.prototype.loadLoginPage = function(selector) {
            this.viewBag.loginView.loadLoginView(selector);
        };

        // todo load edit profile page
        UserController.prototype.loadEditProfilePage = function(selector) {
            var _this = this;
            var userId = sessionStorage['userId'];
            var data = {
                username: sessionStorage['username'],
                fullName: sessionStorage['fullName']
            };
            this.model.getUserById(userId)
                .then(
                function (response) {
                    data['picture'] = response.picture['url'];
                    _this.viewBag.editProfileView.loadEditProfileView(selector, data);
                },
                function (error) {
                    console.log(error);
                }
            );
        };

        UserController.prototype.login = function(username, password) {
            return this.model.login(username, password)
                .then(function(loginData) {
                    Noty.success("You have successfully logged in!");
                    setUserToStorage(loginData);
                    window.location.replace('#/home/');
                }, function(error) {
                    Noty.error("Your username or password is not correct!");
                    console.log(error);
                })
        };

        UserController.prototype.register = function(username, pass, fullName, file) {
            return this.model.register(username, pass, fullName, file)
                .then(function(registerData) {
                    var data = {
                        username: username,
                        fullName: fullName,
                        objectId: registerData.objectId,
                        sessionToken: registerData.sessionToken
                    };

                    setUserToStorage(data);
                    window.location.replace('#/home/');
                }, function(error) {
                    console.log(error);
                })
        };

        UserController.prototype.logout = function() {
            return this.model.logout()
                .then(function() {
                    clearUserFromStorage();
                    window.location.replace('#/');
                }, function(error) {
                    console.log(error);
                });

        };

        UserController.prototype.editProfile = function(username, pass, fullName, file) {
            var userId = sessionStorage['userId'];
            return this.model.editProfile(userId, username, pass, fullName, file)
                .then(function(){
                    if(username !== '') {
                        sessionStorage['username'] = username;
                    }
                    if(fullName !== '') {
                        sessionStorage['fullName'] = fullName;
                    }

                    window.location.replace('#/home/');
                })
        };

        function setUserToStorage(data) {
            sessionStorage['username'] = data.username;
            sessionStorage['userId'] = data.objectId;
            sessionStorage['fullName'] = data.fullName;
            sessionStorage['sessionToken'] = data.sessionToken;
        }

        function clearUserFromStorage() {
            delete sessionStorage['username'];
            delete sessionStorage['userId'];
            delete sessionStorage['fullName'];
            delete sessionStorage['sessionToken'];
        }

        return {
            load : function(model, views) {
                return new UserController(model, views);
            }
        }
    }());
});
