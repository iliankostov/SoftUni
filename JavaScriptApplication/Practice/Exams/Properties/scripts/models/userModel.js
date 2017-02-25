define(['storageService', 'constants', 'headerService', 'requestService'],
    function (storageService, constants, headerService, requestService) {

        function UserModel() {
            this.serviceUrl = constants.BASE_URL + 'users/';
            this.currentUserUrl = this.serviceUrl + 'me';
            this.loginUrl = constants.BASE_URL + 'login';
            this.logoutUrl = constants.BASE_URL + 'logout';
        }

        UserModel.prototype.register = function (user) {
            var url = this.serviceUrl;
            var headers = headerService.get();
            var data = JSON.stringify(user);

            return requestService.post(headers, url, data);
        };

        UserModel.prototype.login = function (user) {
            var username = user['username'];
            var password = user['password'];

            var url = this.loginUrl + '?username=' + username + '&password=' + password;
            var headers = headerService.get();

            return requestService.get(headers, url, user);
        };

        UserModel.prototype.logout = function () {
            var url = this.logoutUrl;
            var headers = headerService.get();

            return requestService.post(headers, url);
        };

        return {
            load: function () {
                return new UserModel();
            }
        }
    }
);
