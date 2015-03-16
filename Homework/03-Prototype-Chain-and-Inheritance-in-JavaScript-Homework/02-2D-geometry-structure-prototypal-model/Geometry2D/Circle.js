var Geometry2D = Geometry2D || {};
// how to add it in a module?
var circle = shape.extend({
    init: function init(startPointX, startPointY, color, radius) {
        this._super.init.call(this, startPointX, startPointY, color);
        this.radius = radius;
        return this;
    },
    toString: function(){
        return this._super.toString.call(this) + " radius: " + this.radius;
    }
});