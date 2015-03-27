var imdb = imdb || {};

(function(scope) {
    var reviewId = 0;
    function Review(author, content, date){
        this.author = author;
        this.content = content;
        this.date = date;
        this._id = reviewId;
    }    
    scope.getReview = function(author, content, date) {
        reviewId++;
        return new Review(author, content, date);
    }
})(imdb);