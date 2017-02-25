var Geometry2D = Geometry2D || {};
Geometry2D.Segment = (function() {
    var Segment = function(startPointX, startPointY, color,
                        endPointX, endPointY) {
        Geometry2D.Shape.call(this, startPointX, startPointY, color);
        this._endPointX = endPointX;
        this._endPointY = endPointY;
    };

    Segment.extend(Geometry2D.Shape);

    Segment.prototype.toString = function(){
        return Geometry2D.Shape.prototype.toString.call(this) +
            " secondPointX: " + this._endPointX + " secondPointY: " + this._endPointY;
    };

    return Segment;
})();