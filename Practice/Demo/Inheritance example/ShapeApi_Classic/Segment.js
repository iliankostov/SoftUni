var assert = require('./lib/assertModule'),
	objExtentions = require('./lib/objectExtentions'),
	Color = require('./Color'),
	Vector = require('./Vector'),
	Shape = require('./Shape');

objExtentions(); // apply object extensions for this module.

var Segment = (function (){
	function Segment (a, b, color) {
		Shape.call(this, color);
		this.setA(a);
		this.setB(b);
	}

	Segment.inherit(Shape);
	Segment.prototype.setA = function(a) {
		assert.isTrue(a instanceof Vector, 'point a must be a vector.');
		this._a = a;
	};
	Segment.prototype.getA = function() {
		return this._a;
	};
	Segment.prototype.setB = function(b) {
		assert.isTrue(b instanceof Vector, 'point b must be a vector.');
		this._b = b;
	};
	Segment.prototype.getB = function() {
		return this._b;
	};
	Segment.prototype.toString = function() {
		var baseStr = Shape.prototype.toString.call(this);
		return '{ a: ' + this._a + ', b: ' + this._b + ', ' + baseStr + ' }';
	};

	return Segment;
}());

module.exports = Segment;