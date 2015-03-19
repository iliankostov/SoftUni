var assert = require('./lib/assertModule'),
	objExtentions = require('./lib/objectExtentions'),
	Color = require('./Color'),
	Vector = require('./Vector'),
	Shape = require('./Shape');

objExtentions(); // apply object extensions for this module.

var Circle = (function (){
	function Circle (position, radius, color) {
		Shape.call(this, color);
		this.setPosition(position)
		this.setRadius(radius);
	}

	Circle.inherit(Shape);
	Circle.prototype.setPosition = function(position) {
		assert.isTrue(position instanceof Vector, 
			'The position must be and instance of Vector.');

		this._position = position;
	};
	Circle.prototype.getPosition = function() {
		return this._position;
	};
	Circle.prototype.setRadius = function(radius) {
		assert.isNumber(radius, 'Radius must be a number.');
		this._radius = radius;
	};
	Circle.prototype.getRadius = function() {
		return this._radius;
	};
	Circle.prototype.toString = function() {
		var baseStr = Shape.prototype.toString.call(this);
		return '{ position: ' + this._position + ', radius: ' + this._radius +
			', ' + baseStr + ' }';
	};

	return Circle;
}());

module.exports = Circle;

// Example
var v1 = new Vector([0, 0]),
	color = new Color('FFFFFFFF');
	circle = new Circle(v1, 5, color);

console.log(circle.toString());