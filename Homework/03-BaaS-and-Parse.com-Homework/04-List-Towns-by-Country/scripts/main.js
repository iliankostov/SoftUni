var world = world || {};

(function() {
    var model = world.model.loadModel('https://api.parse.com/1/classes/');
    var view = world.View.loadView(model);
    view.showAllCountries();
    view.showTownsByCountries();
})();