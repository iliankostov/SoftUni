var Geometry2D = Geometry2D || {};
// how to add it in a module?
Geometry2D.triangle = (function () {
    var triangle = Geometry2D.shape.extend({
        init: function init(startPointX, startPointY, color,
                            secondPointX, secondPointY, thirdPointX, thirdPointY) {
            this._super.init.call(this, startPointX, startPointY, color);
            this.secondPointX = secondPointX;
            this.secondPointY = secondPointY;
            this.thirdPointX = thirdPointX;
            this.thirdPointY = thirdPointY;
            return this;
        },
        toString: function(){
            return this._super.toString.call(this) +
                " secondPointX: " + this.secondPointX + " secondPointY " + this.secondPointY +
                " thirdPointX: " + this.thirdPointX + " thirdPointY " + this.thirdPointY;
        }
    });
    return triangle;
})();