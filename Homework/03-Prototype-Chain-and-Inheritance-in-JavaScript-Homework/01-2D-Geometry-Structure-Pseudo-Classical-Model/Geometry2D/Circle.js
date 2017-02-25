var Geometry2D = Geometry2D || {};
Geometry2D.Circle = (function() {
    var Circle = function(startPointX, startPointY, color, radius) {
        Geometry2D.Shape.call(this, startPointX, startPointY, color);
        this._radius = radius;
    };

    Circle.extend(Geometry2D.Shape);

    Circle.prototype.toString = function(){
        return Geometry2D.Shape.prototype.toString.call(this) + " radius " + this._radius;
    };

    return Circle;
})();