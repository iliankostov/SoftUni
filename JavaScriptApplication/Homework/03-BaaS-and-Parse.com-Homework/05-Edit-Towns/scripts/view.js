var world = world || {};

world.View = (function() {
    function View(model) {
        this.model = model;
        this.attachEventListeners(this);
    }

    View.prototype.attachEventListeners = function (View) {
        $('#add-country').click(function () {
            View.addCountry(View);
        });
    };

    View.prototype.showAllCountries = function () {
        var _this = this;
        this.model.countries.loadCountries(
            function (countryData) {
                countryData.results.forEach(function (country) {
                    _this.modifyCountry(country.name, country.objectId);
                });
            },
            function (error) {
                console.error(error.responseText);
            }
        )
    };

    View.prototype.addCountry = function () {
        var _this = this;
        var countryName = $('#country-name').val();
        this.model.countries.addCountry({name: countryName},
            function (data) {
                _this.modifyCountry(countryName, data.objectId);
            },
            function (error) {
                console.log(error);
            }
        )
    };

    View.prototype.editCountry = function (countryId, country) {
        this.model.countries.editCountry(countryId, {name:country},
            function (data) {
                $('#wrapper').find($('[data-id=' + countryId + '] > p')).text(country);
            },
            function (error) {
                console.log(error.responseText);
            }
        );
    };
    
    View.prototype.deleteCountry = function (countryId) {
        this.model.countries.deleteCountry(countryId,
            function (data) {
                $('#wrapper').find('[data-id=' + countryId + ']').remove();
            },
            function (error) {
                console.log(error.responseText);
            }
        );
    };

    View.prototype.modifyCountry = function(country, countryId) {
        var _this = this;
        var countryWrapper = $('<div />').addClass('country-list');
        countryWrapper.attr('data-id', countryId);
        var countryName = $('<p/>').text(country);
        var editInput = $('<input/>');
        var editButton = $('<button class="edit-country">Edit country</button>');
        editButton.click(function () {
            var newCountryName = editInput.val();
            _this.editCountry(countryId, newCountryName);
        });

        var deleteButton = $('<button class="delete-country">Delete country</button>');
        deleteButton.click(function () {
            _this.deleteCountry(countryId);
        });

        var addInput = $('<input/>');

        var addButton = $('<button class="add-town">Add town</button>');
        addButton.click(function () {
            _this.addTown(countryId, null, addInput.val());
        });

        var loadButton = $('<button class="load-towns">Load towns</button>');
        loadButton.click(function () {
            _this.showTownsByCountry(countryId);
        });

        countryWrapper
            .append(countryName)
            .append(editInput)
            .append(editButton)
            .append(deleteButton)
            .append(addInput)
            .append(addButton)
            .append(loadButton);

        $("#wrapper").append(countryWrapper);
    };

    View.prototype.showTownsByCountry = function (countryId) {
        var _this = this;
        this.model.towns.loadTowns(
            function (data) {
                data.results.forEach(function (town) {
                    if (town.country.objectId === countryId) {
                        _this.modifyTown(countryId, town.objectId, town.name);
                    }
                });
            },
            function (error) {
                console.error(error.responseText);
            }
        )
    };

    View.prototype.addTown = function (countryId, townName) {
        var _this = this;
        this.model.towns.addTown({name: townName},
            function (data) {
                _this.modifyTown(countryId, townName);
            },
            function (error) {
                console.log(error);
            }
        )
    };

    View.prototype.editTown = function (townId, townName) {
        this.model.towns.editTown(townId, {name:townName},
            function (data) {
                $('#wrapper').find($('[data-id=' + townId + '] > p')).text(townName);
            },
            function (error) {
                console.log(error.responseText);
            }
        )
    };

    View.prototype.deleteTown = function (townId) {
        this.model.towns.deleteTown(townId,
            function (data) {
                $('#wrapper').find('[data-id=' + townId + ']').remove();
            },
            function (error) {
                console.log(error.responseText);
            }
        );
    };

    View.prototype.modifyTown = function (countryId, townId, townName) {
        var _this = this;
        var countryWrapper = $('#wrapper').find('[data-id=' + countryId + ']');
        var townWrapper = $('<div />').addClass('town-list');
        townWrapper.attr('data-id', townId);
        var townP = $('<p/>').text(townName);
        var editInput = $('<input/>');
        var editButton = $('<button class="edit-town">Edit</button>');
        editButton.click(function () {
            var newTownName = editInput.val();
            _this.editTown(townId, newTownName);
        });

        var deleteButton = $('<button class="delete-town">Delete</button>');
        deleteButton.click(function () {
            _this.deleteTown(townId);
        });

        townWrapper
            .append(townP)
            .append(editInput)
            .append(editButton)
            .append(deleteButton);

        countryWrapper.append(townWrapper);
    };

    return {
        loadView: function (model) {
            return new View(model);
        }
    };
})();