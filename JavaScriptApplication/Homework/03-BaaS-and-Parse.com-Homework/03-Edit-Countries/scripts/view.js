var world = world || {};

world.View = (function() {
    function View(model) {
        this.model = model;
        this.attachEventListeners(this);
    }

    View.prototype.showAllCountries = function () {
        var _this = this;
        this.model.countries.loadCountries(
            function (countryData) {
                countryData.results.forEach(function (country) {
                    _this.addCountryToDom(country.name, country.objectId);
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
                _this.addCountryToDom(countryName, data.objectId);
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

    View.prototype.attachEventListeners = function (View) {
        $('#add-country').click(function () {
            View.addCountry(View);
        });
    };

    View.prototype.addCountryToDom = function(country, countryId) {
        var _this = this;
        var countryWrapper = $('<div />').addClass('country-list');
        countryWrapper.attr('data-id', countryId);
        var countryName = $('<p/>').text(country);
        var editInput = $('<input/>');
        var editButton = $('<button class="edit-country">Edit</button>');
        editButton.click(function () {
            var newCountryName = editInput.val();
            _this.editCountry(countryId, newCountryName);
        });

        var deleteButton = $('<button class="delete-country">Delete</button>');
        deleteButton.click(function () {
            _this.deleteCountry(countryId);
        });

        countryWrapper
            .append(countryName)
            .append(editInput)
            .append(editButton)
            .append(deleteButton);

        $("#wrapper").append(countryWrapper);
    };

    return {
        loadView: function (model) {
            return new View(model);
        }
    };
})();