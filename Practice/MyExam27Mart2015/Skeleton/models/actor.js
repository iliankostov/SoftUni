var imdb = imdb || {};

(function(scope) {
    var actorId = 0;

    function Actor(name, bio, born){
        this.name = name;
        this.bio = bio;
        this.born = born;
        this._id = actorId;
    }    
    scope.getActor = function(name, bio, born) {
        actorId++;
        return new Actor(name, bio, born);
    }
})(imdb);