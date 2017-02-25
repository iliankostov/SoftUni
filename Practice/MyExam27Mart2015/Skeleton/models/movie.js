var imdb = imdb || {};

(function(scope) {
    var id = 0;

    function delReview(reviews, review) {
        var index = reviews.indexOf(review);
        if (index > -1) {
            reviews.splice(index, 1);
        }
    }

    function Movie(title, length, rating, country){
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
        this._id = id;
    }

    Movie.prototype.addActor = function addActor(actor) {
        this._actors.push(actor);
    };

    Movie.prototype.getActors = function getActors() {
        return this._actors;
    };

    Movie.prototype.addReview = function addReview(review) {
        this._reviews.push(review);
    };

    Movie.prototype.deleteReview = function deleteReview(review) {
        delReview(this._reviews, review);
    };

    Movie.prototype.deleteReviewById = function deleteReviewById(id) {
        var reviews = this._reviews;
        reviews.forEach(function(review) {
            if(review._id === id) {
                delReview(reviews, review);
            }
        })
    };

    Movie.prototype.getReviews = function getReviews() {
        return this._reviews;
    };

    scope.Movie = Movie;

    scope.getMovie = function(title, length, rating, country) {
        id++;
        return new Movie(title, length, rating, country);
    }
})(imdb);