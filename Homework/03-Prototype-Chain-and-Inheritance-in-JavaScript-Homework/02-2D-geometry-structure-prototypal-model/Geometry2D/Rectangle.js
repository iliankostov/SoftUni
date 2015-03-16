var Geometry2D = Geometry2D || {};
// how to add it in a module?
var rectangle = shape.extend({
    init: function init(startPointX, startPointY, color, width, height) {
        this._super.init.call(this, startPointX, startPointY, color);
        this.width = width;
        this.height = height;
        return this;
    },
    toString: function(){
        return this._super.toString.call(this) +
            " width: " + this.width + " height " + this.height;
    }
});