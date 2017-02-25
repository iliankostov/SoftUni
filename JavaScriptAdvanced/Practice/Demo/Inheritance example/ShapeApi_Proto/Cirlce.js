var assert = require('./lib/assertModule'),
	ColorHexPrototype = require('./ColorHex'),
	ShapePrototype = require('./Shape'),
	VectorPrototype = require('./Vector');

var CirclePrototype = Object.create(ShapePrototype);
CirclePrototype.constructor = function (position, radius, color) {
	ShapePrototype.constructor.call(this, color);
	this.setPosition(position);
	this.setRadius(radius);
};
CirclePrototype.setPosition = function (vector) {
	assert.isTrue(vector.__proto__ === VectorPrototype, 
		'The position must be have the VectorPrototype.');
	this._pos = vector;
};
CirclePrototype.getPosition = function() {
	return this._pos;
};
CirclePrototype.setRadius = function(radius) {
	assert.isNumber(radius, 'Radius must be a number.');
	this._radius = radius;
};
CirclePrototype.getRadius = function () {
	return this._radius;
};
CirclePrototype.toString = function () {
	return '{ pos: ' + this._pos + ', r: ' + this._radius + 
		', color: ' + this._color + ' }'; 
};

module.exports = CirclePrototype;

// // Example
// var v1 = Object.create(VectorPrototype);
// v1.constructor(0, 0);

// var color = Object.create(ColorHexPrototype);
// color.constructor('FF00FF00');

// var cirlce = Object.create(CirclePrototype);
// cirlce.constructor(v1, 5, color);
// console.log(cirlce.toString());