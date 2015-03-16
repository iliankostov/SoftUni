var Geometry2D = Geometry2D || {};
Geometry2D.Rectangle = (function() {
    var Rectangle = function(startPointX, startPointY, color, width, height) {
        Geometry2D.Shape.call(this, startPointX, startPointY, color);
        this._width = width;
        this._height = height;
    };

    Rectangle.extend(Geometry2D.Shape);

    Rectangle.prototype.toString = function(){
        return Geometry2D.Shape.prototype.toString.call(this) +
            " width: " + this._width + " height: " + this._height;
    };

    return Rectangle;
})();