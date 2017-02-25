var world = world || {};

world.View = (function() {
    function View(model) {
        this.model = model;
    }

    View.prototype.showAllCountries = function () {
        var _this = this;
        this.model.countries.loadCountries(
            function (countryData) {
                countryData.results.forEach(function (country) {
                    var countryWrapper = $('<div />');
                    countryWrapper.attr('country-id', country.objectId);
                    var countryName = $('<p/>').text(country.name);
                    countryWrapper.append(countryName);
                    $("#wrapper").append(countryWrapper);
                });
                _this.showTownsByCountries();
            },
            function (error) {
                console.error(error.responseText);
            }
        )
    };

    View.prototype.showTownsByCountries = function () {
        this.model.towns.loadTowns(
            function (townData) {
                townData.results.forEach(function (town) {
                    var countryWrapper = $('#wrapper').find('[country-id=' + town.country.objectId + ']');
                    var townWrapper = $('<div />').text(town.name);
                    countryWrapper.append(townWrapper);
                })
            },
            function (error) {
                console.error(error.responseText);
            }
        )
    };

    return {
        loadView: function (model) {
            return new View(model);
        }
    };
})();
