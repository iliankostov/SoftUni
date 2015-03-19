var Geometry2D = Geometry2D || {};

Geometry2D.segment = (function () {
    var segment;
    segment = Geometry2D.shape.extend({
        init: function init(startPointX, startPointY, color, endPointX, endPointY) {
            this._super.init.call(this, startPointX, startPointY, color);
            this.endPointX = endPointX;
            this.endPointY = endPointY;
            return this;
        },
        toString: function () {
            return this._super.toString.call(this) +
                " endPointX: " + this.endPointX + " endPointY " + this.endPointY;
        }
    });
    return segment;
})();