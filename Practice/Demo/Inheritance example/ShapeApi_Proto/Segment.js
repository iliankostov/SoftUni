var assert = require('./lib/assertModule'),
	ColorHexPrototype = require('./ColorHex'),
	ShapePrototype = require('./Shape'),
	VectorPrototype = require('./Vector');

var SegmentPrototype = Object.create(ShapePrototype);
SegmentPrototype.constructor = function (a, b, color) {
	ShapePrototype.constructor.call(this, color);
	this.setA(a);
	this.setB(b);
};
SegmentPrototype.setA = function (a) {
	assert.isTrue(a.__proto__ === VectorPrototype,
		'point a must be a vector.');

	this._a = a;
};
SegmentPrototype.getA = function () {
	return this._a;
};
SegmentPrototype.setB = function (b) {
	assert.isTrue(b.__proto__ === VectorPrototype,
		'point b must be a vector.');

	this._b = b;
};
SegmentPrototype.getB = function () {
	return this._b;
};
SegmentPrototype.toString = function () {
	return '{ a: ' + this._a + ', b: ' + this._b + 
		', color: ' + this._color + ' }';
};

// // Example
// var v1 = Object.create(VectorPrototype);
// v1.constructor(0, 0);

// var v2 = Object.create(VectorPrototype);
// v2.constructor(1, 1);

// var segment = Object.create(SegmentPrototype);
// segment.constructor(v1, v2);

// console.log(segment.toString());