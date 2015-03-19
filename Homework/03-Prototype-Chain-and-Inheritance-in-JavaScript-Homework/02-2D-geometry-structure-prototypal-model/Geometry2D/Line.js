var Geometry2D = Geometry2D || {};

Geometry2D.line = (function () {
    var line;
    line = Geometry2D.shape.extend({
        init: function init(startPointX, startPointY, color, secondPointX, secondPointY) {
            this._super.init.call(this, startPointX, startPointY, color);
            this.secondPointX = secondPointX;
            this.secondPointY = secondPointY;
            return this;
        },
        toString: function () {
            return this._super.toString.call(this) +
                " secondPointX: " + this.secondPointX + " secondPointY " + this.secondPointY;
        }
    });
    return line;
})();