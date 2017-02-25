var assert = require('./lib/assertModule'),
	objExtentions = require('./lib/objectExtentions'),
	Color = require('./Color'),
	Vector = require('./Vector'),
	Shape = require('./Shape');

objExtentions(); // apply object extensions for this module.

var Line = (function (){
	function Line (a, b, color) {
		Shape.call(this, color);
		this.setA(a);
		this.setB(b);
	}

	Line.inherit(Shape);
	Line.prototype.setA = function(a) {
		assert.isTrue(a instanceof Vector, 'point a must be a vector.');
		this._a = a;
	};
	Line.prototype.getA = function() {
		return this._a;
	};
	Line.prototype.setB = function(b) {
		assert.isTrue(b instanceof Vector, 'point b must be a vector.');
		this._b = b;
	};
	Line.prototype.getB = function() {
		return this._b;
	};
	Line.prototype.toString = function() {
		var baseStr = Shape.prototype.toString.call(this);
		return '{ a: ' + this._a + ', b: ' + this._b + ', ' + baseStr + ' }';
	};

	return Line;
}());

module.exports = Line;

// Example
var v1 = new Vector([0, 0]),
	v2 = new Vector([2, 2]),
	rect = new Line(v1, v2, new Color('13F2F0FF'));

console.log(rect);
console.log(rect.toString());