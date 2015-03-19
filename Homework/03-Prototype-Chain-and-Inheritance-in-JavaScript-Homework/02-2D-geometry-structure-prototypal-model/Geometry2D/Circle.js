var Geometry2D = Geometry2D || {};

Geometry2D.circle = (function() {
    var circle;
    circle = Geometry2D.shape.extend({
        init: function init(startPointX, startPointY, color, radius) {
            this._super.init.call(this, startPointX, startPointY, color);
            this.radius = radius;
            return this;
        },
        toString: function () {
            return this._super.toString.call(this) + " radius: " + this.radius;
        }
    });
    return circle;
})();