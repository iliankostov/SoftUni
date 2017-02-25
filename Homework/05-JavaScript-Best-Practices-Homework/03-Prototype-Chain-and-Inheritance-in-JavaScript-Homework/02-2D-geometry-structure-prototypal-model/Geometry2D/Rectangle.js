var Geometry2D = Geometry2D || {};

Geometry2D.rectangle = (function () {
    var rectangle;
    rectangle = Geometry2D.shape.extend({
        init: function init(startPointX, startPointY, color, width, height) {
            this._super.init.call(this, startPointX, startPointY, color);
            this.width = width;
            this.height = height;
            return this;
        },
        toString: function () {
            return this._super.toString.call(this) +
                " width: " + this.width + " height " + this.height;
        }
    });
    return rectangle;
})();