var assert = require('./lib/assertModule'),
	objExtentions = require('./lib/objectExtentions'),
	Color = require('./Color'),
	Vector = require('./Vector'),
	Shape = require('./Shape');

objExtentions(); // apply object extensions for this module.

var Triangle = (function (){
	function Triangle (a, b, c, color) {
		Shape.call(this, color);
		this.setA(a);
		this.setB(b);
		this.setC(c);
	}

	Triangle.inherit(Shape);
	Triangle.prototype.setA = function(a) {
		assert.isTrue(a instanceof Vector, 'point a must be a vector.');
		this._a = a;
	};
	Triangle.prototype.getA = function() {
		return this._a;
	};
	Triangle.prototype.setB = function(b) {
		assert.isTrue(b instanceof Vector, 'point b must be a vector.');
		this._b = b;
	};
	Triangle.prototype.getB = function() {
		return this._b;
	};
	Triangle.prototype.setC = function(c) {
		assert.isTrue(c instanceof Vector, 'point c must be a vector.');
		this._c = c;
	};
	Triangle.prototype.getC = function() {
		return this._c;
	};
	Triangle.prototype.toString = function() {
		var baseStr = Shape.prototype.toString.call(this);
		return '{ a: ' + this._a + ', b: ' + this._b + 
			', c: ' + this._c + ', ' + baseStr +' }';
	};

	return Triangle;
}());

module.exports = Triangle;

// Example
var v1 = new Vector([0, 1]),
	v2 = new Vector([1, 1]),
	v3 = new Vector([3, 3]),
	triangle = new Triangle(v1, v2, v3);

console.log(triangle);
console.log(triangle.toString());