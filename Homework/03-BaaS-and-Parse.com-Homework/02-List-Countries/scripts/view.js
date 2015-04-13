var world = world || {};

world.View = (function() {
    function View(model) {
        this.model = model;
    }

    View.prototype.showAllCountries = function () {
        this.model.countries.loadCountries(
            function (countryData) {
                countryData.results.forEach(function (country) {
                    var countryWrapper = $('<div />');
                    var countryName = $('<p/>').text(country.name);
                    countryWrapper.append(countryName);
                    $("#wrapper").append(countryWrapper);

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
