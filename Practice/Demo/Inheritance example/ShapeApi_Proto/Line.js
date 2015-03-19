var assert = require('./lib/assertModule'),
	ColorHexPrototype = require('./ColorHex'),
	ShapePrototype = require('./Shape'),
	VectorPrototype = require('./Vector');

var LinePrototype = Object.create(ShapePrototype);
LinePrototype.constructor = function (a, b, color) {
	ShapePrototype.constructor.call(this, color);
	this.setA(a);
	this.setB(b);
};
LinePrototype.setA = function (a) {
	assert.isTrue(a.__proto__ === VectorPrototype,
		'point a must be a vector.');

	this._a = a;
};
LinePrototype.getA = function () {
	return this._a;
};
LinePrototype.setB = function (b) {
	assert.isTrue(b.__proto__ === VectorPrototype,
		'point b must be a vector.');

	this._b = b;
};
LinePrototype.getB = function () {
	return this._b;
};
LinePrototype.toString = function () {
	return '{ a: ' + this._a + ', b: ' + this._b + 
		', color: ' + this._color + ' }';
};

// // Example
// var v1 = Object.create(VectorPrototype);
// v1.constructor(0, 0);

// var v2 = Object.create(VectorPrototype);
// v2.constructor(1, 1);

// var line = Object.create(LinePrototype);
// line.constructor(v1, v2);

// console.log(line.toString());
