var assert = require('./lib/assertModule'),
	ColorHexPrototype = require('./ColorHex');

var ShapePrototype = {
	_color: null,
	constructor: function (color) {
		this.setColor(color);
		return this;
	},
	setColor: function (color) {
		if (color === undefined) {
			color = Object.create(ColorHexPrototype);
			color.constructor('00000000');
		}

		assert.isTrue(color.__proto__ === ColorHexPrototype,
			'color must have the same prototype as ColorHexPrototype');

		this._color = color;
	},
	getColor: function () {
		return this._color;
	},
	toString: function () {
		return JSON.stringify(this);
	}
}

module.exports = ShapePrototype;

// // Example
// var color = Object.create(ColorHexPrototype);
// color.constructor('FFFFFFFF')

// var shape = Object.create(ShapePrototype);
// shape.constructor(color);
// console.log(shape);