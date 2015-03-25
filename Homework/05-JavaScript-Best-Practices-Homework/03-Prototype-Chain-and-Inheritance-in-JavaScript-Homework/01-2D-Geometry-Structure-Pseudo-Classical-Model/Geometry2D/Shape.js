var Geometry2D = Geometry2D || {};
Geometry2D.Shape = (function () {
    var Shape = function(startPointX, startPointY, color) {
        this._startPointX = startPointX;
        this._startPointY = startPointY;
        this._color = color;
    };

    Shape.prototype.toString = function(){
        return "start point X: " + this._startPointX + " start point Y: " + this._startPointY +
            " color: " + this._color;
    };

    return Shape;
})();