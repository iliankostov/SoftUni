var imdb = imdb || {};

(function(scope) {
    var genreId = 0;

    function delMovie(collection, movie)
    {
        var index = collection.indexOf(movie);
        if (index > -1) {
            collection.splice(index, 1);
        }
    }

    function Genre(name){
        this.name = name;
        this._movies = [];
        this._id = genreId;
    }

    Genre.prototype.addMovie = function addMovie(movie) {
        this._movies.push(movie);
    };

    Genre.prototype.deleteMovie = function deleteMovie(movie) {
        delMovie(this._movies, movie);
    };

    Genre.prototype.deleteMovieById = function deleteMovieById(id) {
        var movies = this._movies;
        movies.forEach(function(movie) {
            if(movie._id === id) {
                delMovie(movies, movie);
            }
        })
    };

    Genre.prototype.getMovies = function getMovies() {
        return this._movies;
    };

    scope.getGenre = function(name) {
        genreId++;
        return new Genre(name);
    }
})(imdb);