var Geometry2D = Geometry2D || {};
Geometry2D.Triangle = (function() {
    var Triangle = function(startPointX, startPointY, color,
                            secondPointX, secondPointY, thirdPointX, thirdPointY) {
        Geometry2D.Shape.call(this, startPointX, startPointY, color);
        this._secondPointX = secondPointX;
        this._secondPointY = secondPointY;
        this._thirdPointX = thirdPointX;
        this._thirdPointY = thirdPointY;
    };

    Triangle.extend(Geometry2D.Shape);

    Triangle.prototype.toString = function(){
        return Geometry2D.Shape.prototype.toString.call(this) +
            " secondPointX: " + this._secondPointX + " secondPointY: " + this._secondPointY +
            " thirdPointX: " + this._thirdPointX + " thirdPointY: " + this._thirdPointY;
    };

    return Triangle;
})();