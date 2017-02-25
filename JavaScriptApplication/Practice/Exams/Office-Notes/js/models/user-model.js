define([], function () {
    return (function() {
        function UserModel(baseUrl, requester, headers) {
            this.baseUrl = baseUrl;
            this.requester = requester;
            this.headers = headers;
        }

        UserModel.prototype.register = function(username, password, fullName, file) {
            var _this, serviceUrl, headers, data;
            _this = this;
            serviceUrl = this.baseUrl + 'users/';
            headers = this.headers.getHeaders();
            data = {
                username: username,
                password: password,
                fullName: fullName
            };
            if (file) {
                var serviceFileUrl = this.baseUrl + 'files/' + file.name;
                var fileHeaders = this.headers.getHeaders(false, file.type);
                this.requester.post(serviceFileUrl, fileHeaders, file)
                    .then(function (response) {
                        response['__type'] = 'File';
                        data['picture'] = response;
                        data = JSON.stringify(data);
                        return _this.requester.post(serviceUrl, headers, data);
                    }, function (error) {
                        console.error(error);
                    })

            } else {
                data = JSON.stringify(data);
                return this.requester.post(serviceUrl, headers, data);
            }
        };

        UserModel.prototype.login = function(username, password) {
            var serviceUrl = this.baseUrl + 'login?username=' + username + '&password=' + password;
            return this.requester.get(serviceUrl, this.headers.getHeaders());
        };

        UserModel.prototype.logout = function() {
            var serviceUrl = this.baseUrl + 'logout';
            return this.requester.post(serviceUrl, this.headers.getHeaders(true));
        };

        UserModel.prototype.editProfile = function(userId, username, password, fullName, file) {
            var _this, serviceUrl, headers, data;
            _this = this;
            serviceUrl = this.baseUrl + 'users/' + userId;
            headers = this.headers.getHeaders(true);
            data = {};
            if(username !== '') {
                data.username = username;
            }
            if(password !== '') {
                data.password = password;
            }
            if(fullName !== '') {
                data.fullName = fullName;
            }
            if (file) {
                var serviceFileUrl = this.baseUrl + 'files/' + file.name;
                var fileHeaders = this.headers.getHeaders(true, file.type);
                this.requester.post(serviceFileUrl, fileHeaders, file)
                    .then(function (response) {
                        response['__type'] = 'File';
                        data['picture'] = response;
                        data = JSON.stringify(data);
                        return _this.requester.put(serviceUrl, headers, data);
                    }, function (error) {
                        console.error(error);
                    })
            } else {
                data = JSON.stringify(data);
                return this.requester.post(serviceUrl, headers, data);
            }
        };

        UserModel.prototype.getUserById = function (userId) {
            var serviceUrl, headers;
            serviceUrl = this.baseUrl + 'users/' + userId;
            headers = this.headers.getHeaders();
            return this.requester.get(serviceUrl, headers);
        };

        return {
            load: function(baseUrl, requester, headers) {
                return new UserModel(baseUrl, requester, headers);
            }
        }
    }());
});
