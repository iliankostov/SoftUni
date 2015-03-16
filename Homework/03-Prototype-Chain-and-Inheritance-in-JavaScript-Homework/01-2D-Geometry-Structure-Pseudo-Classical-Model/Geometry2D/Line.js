var Geometry2D = Geometry2D || {};
Geometry2D.Line = (function() {
    var Line = function(startPointX, startPointY, color,
                            secondPointX, secondPointY) {
        Geometry2D.Shape.call(this, startPointX, startPointY, color);
        this._secondPointX = secondPointX;
        this._secondPointY = secondPointY;
    };

    Line.extend(Geometry2D.Shape);

    Line.prototype.toString = function(){
        return Geometry2D.Shape.prototype.toString.call(this) +
            " secondPointX: " + this._secondPointX + " secondPointY: " + this._secondPointY;
    };

    return Line;
})();
