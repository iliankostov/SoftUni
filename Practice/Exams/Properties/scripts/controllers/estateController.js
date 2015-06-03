define(['notificationService', 'parseService', 'storageService', 'validationService', 'constants'],
    function (notificationService, parseService, storageService, validationService, constants) {
        function EstateController(category, model, views) {
            this.category = category;
            this.model = model;
            this.view = views;
        }

        EstateController.prototype.showAddEstate = function (selector) {
            var _this = this;
            this.category.getCategories().then(
                function (categoriesData) {
                    _this.view.showAddEstateView(selector, categoriesData);
                },
                function() {
                    notificationService.showError("Sorry! We do not have categories.")
                }
            );
        };

        EstateController.prototype.showEditEstate = function (selector, data) {
            this.view.showEditEstateView(selector, data);
        };

        EstateController.prototype.showDeleteEstate = function (selector, data) {
            this.view.showDeleteEstateView(selector, data);
        };

        EstateController.prototype.showEstates = function (selector) {
            var _this = this;
            this.category.getCategories().then(
                function (categoriesData) {
                    _this.model.getEstates()
                        .then(function (estatesData) {
                            _this.view.showEstates(selector, estatesData, categoriesData);
                        }, function (error) {
                            var errorText = error['responseJSON']['error'] || constants.ERROR_GET_OBJECTS_MESSAGE;
                            notificationService.showError(errorText);
                        });
                },
                function() {
                    notificationService.showError("Sorry! We do not have categories.")
                }
            );
        };

        EstateController.prototype.addEstate = function (selector, estate) {
            if (validationService.validatePrice(estate.price) && validationService.validateName(estate.name)) {
                estate.name = validationService.escapeHtmlSpecialChars(estate.name, true);
                var categoryPointer = parseService.createCategoryPointer(estate.category.objectId);
                var acl = parseService.createACL();
                var estateData = {
                    name: estate.name,
                    category: categoryPointer,
                    price: estate.price,
                    ACL: acl
                };

                this.model.addEstate(estateData)
                    .then(function () {
                        notificationService.showSuccess(constants.SUCCESSFUL_ADD_OBJECT_MESSAGE);
                        window.location.hash = '/estates/';

                    }, function (error) {
                        var errorText = error['responseJSON']['error'] || constants.ERROR_ADD_OBJECT_MESSAGE;
                        notificationService.showError(errorText);
                    });
            }
        };

        EstateController.prototype.editEstate = function (selector, data) {
            if(validationService.validatePrice(data.price) && validationService.validateName(data.name)){
                data.name = validationService.escapeHtmlSpecialChars(data.name, true);
                var editEstateData = {
                    name: data.name,
                    price: data.price
                };
                this.model.editEstate(data.id, editEstateData)
                    .then(function () {
                        notificationService.showSuccess(constants.SUCCESSFUL_EDIT_OBJECT_MESSAGE);
                        window.location.hash = '/home/';
                    }, function (error) {
                        var errorText = error['responseJSON']['error'] || constants.ERROR_EDIT_OBJECT_MESSAGE;
                        notificationService.showError(errorText);
                    });
            }


        };

        EstateController.prototype.deleteEstate = function (selector, id) {
            this.model.deleteEstate(id)
                .then(function () {
                    notificationService.showSuccess(constants.SUCCESSFUL_DELETE_OBJECT_MESSAGE);
                    window.location.hash = '/home/';
                }, function (error) {
                    var errorText = error['responseJSON']['error'] || constants.ERROR_DELETE_OBJECT_MESSAGE;
                    notificationService.showError(errorText);
                });
        };

        EstateController.prototype.filterEstates = function (selector, data) {
            var _this = this;
            this.category.getCategories().then(
                function (categoriesData) {
                    _this.model.filterEstates(data)
                        .then(function (estatesData) {
                            _this.view.showEstates(selector, estatesData, categoriesData);
                        }, function (error) {
                            var errorText = error['responseJSON']['error'] || constants.ERROR_GET_OBJECTS_MESSAGE;
                            notificationService.showError(errorText);
                        });
                },
                function() {
                    notificationService.showError("Sorry! We do not have categories.")
                }
            );
        };

        return {
            load: function (category, model, views) {
                return new EstateController(category, model, views);
            }
        }
    }
);
