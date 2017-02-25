var assert = require('./lib/assertModule'),
	ColorHexPrototype = require('./ColorHex'),
	ShapePrototype = require('./Shape'),
	VectorPrototype = require('./Vector');

var TrianglePrototype = Object.create(ShapePrototype);
TrianglePrototype.constructor = function (a, b, c, color) {
	ShapePrototype.constructor.call(this, color);
	this.setA(a);
	this.setB(b);
	this.setC(c);
};
TrianglePrototype.setA = function (a) {
	assert.isTrue(a.__proto__ === VectorPrototype,
		'point a must be a vector.');

	this._a = a;
};
TrianglePrototype.getA = function () {
	return this._a;
};
TrianglePrototype.setB = function (b) {
	assert.isTrue(b.__proto__ === VectorPrototype,
		'point b must be a vector.');

	this._b = b;
};
TrianglePrototype.getB = function () {
	return this._b;
};
TrianglePrototype.setC = function (c) {
	assert.isTrue(c.__proto__ === VectorPrototype,
		'point c must be a vector.');

	this._c = c;
};
TrianglePrototype.getC = function () {
	return this._c;
};
TrianglePrototype.toString = function () {
	return '{ a: ' + this._a + ', b: ' + this._b +
		', c: ' + this._c + ', color: ' + this._color + ' }';
};

module.exports = TrianglePrototype;

// // Example
// var v1 = Object.create(VectorPrototype);
// v1.constructor(0, 0);

// var v2 = Object.create(VectorPrototype);
// v2.constructor(1, 1);

// var v3 = Object.create(VectorPrototype);
// v3.constructor(2, 2);

// var triangle = Object.create(TrianglePrototype);
// triangle.constructor(v1, v2, v3);
// console.log(triangle.toString());