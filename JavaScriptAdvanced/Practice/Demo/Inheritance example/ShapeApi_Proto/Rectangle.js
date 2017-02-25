var assert = require('./lib/assertModule'),
	ColorHexPrototype = require('./ColorHex'),
	ShapePrototype = require('./Shape'),
	VectorPrototype = require('./Vector');

var RectanglePrototype = Object.create(ShapePrototype);
RectanglePrototype.constructor = function (position, width, height, color) {
	ShapePrototype.constructor.call(this, color);
	this.setPosition(position);
	this.setWidth(width);
	this.setHeight(height);
};
RectanglePrototype.setPosition = function (vector) {
	assert.isTrue(vector.__proto__ === VectorPrototype, 
		'The position must be have the VectorPrototype.');
	this._pos = vector;
};
RectanglePrototype.getPosition = function() {
	return this._pos;
};
RectanglePrototype.setWidth = function(width) {
	assert.isNumber(width, 'Width must be a number.');
	this._width = width;
};
RectanglePrototype.getWidth = function() {
	return this._width;
};
RectanglePrototype.setHeight = function(height) {
	assert.isNumber(height, 'Height must be a number.');
	this._height = height;
};
RectanglePrototype.getHeight = function() {
	return this._height;
};
RectanglePrototype.toString = function () {
	return '{ pos: ' + this._pos + ', width: ' + 
		this._width + ', height: ' + this._height + ', color: ' + this._color + ' }'; 
};

module.exports = RectanglePrototype;

// // Example
// var v1 = Object.create(VectorPrototype);
// v1.constructor(0, 0);

// var color = Object.create(ColorHexPrototype);
// color.constructor('FF00FF00');

// var rect = Object.create(RectanglePrototype);
// rect.constructor(v1, 10, 10, color);

// console.log(rect.toString());
// rect.constructor(v1, 10, 10);
// console.log(rect.toString());