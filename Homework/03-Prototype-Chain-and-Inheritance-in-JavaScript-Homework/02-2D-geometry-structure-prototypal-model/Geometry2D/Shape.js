var Geometry2D = Geometry2D || {};
// how to add it in a module?
var shape = {
    init: function init(startPointX, startPointY, color) {
        this.startPointX = startPointX;
        this.startPointY = startPointY;
        this.color = color;
        return this;
    },
    toString: function(){
        return "start point X: " + this.startPointX + " start point Y: " + this.startPointY +
            " color: " + this.color;
    }
};