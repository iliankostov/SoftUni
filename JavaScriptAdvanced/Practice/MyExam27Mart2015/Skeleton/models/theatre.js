var imdb = imdb || {};

(function(scope) {
    var id = 0;
    function Theatre(title, length, rating, country){
        scope.Movie.apply(this, arguments);
        this.isPuppet = false;
    }

    Theatre.extends(scope.Movie);

    scope.getTheatre = function(title, length, rating, country) {
        id++;
        return new Theatre(title, length, rating, country);
    }
})(imdb);