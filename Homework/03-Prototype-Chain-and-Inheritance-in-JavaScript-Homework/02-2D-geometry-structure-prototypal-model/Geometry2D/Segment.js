var Geometry2D = Geometry2D || {};
// how to add it in a module?
var segment = shape.extend({
    init: function init(startPointX, startPointY, color, endPointX, endPointY) {
        this._super.init.call(this, startPointX, startPointY, color);
        this.endPointX = endPointX;
        this.endPointY = endPointY;
        return this;
    },
    toString: function(){
        return this._super.toString.call(this) +
            " endPointX: " + this.endPointX + " endPointY " + this.endPointY;
    }
});