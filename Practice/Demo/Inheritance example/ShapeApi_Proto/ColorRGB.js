var assert = require('./lib/assertModule'),
	validRGBFormat = function validRGBFormat (r, g, b, a) {
		assert.isInt(r, 'r must be an integer.');
		assert.isInt(g, 'g must be an integer.');
		assert.isInt(b, 'b must be an integer.');
		assert.isInt(a, 'a must be an integer.');

		assert.isTrue(0 > r || r <= 255, 'r must be in [0..255].');
		assert.isTrue(0 > g || g <= 255, 'g must be in [0..255].');
		assert.isTrue(0 > b || b <= 255, 'b must be in [0..255].');
		assert.isTrue(0 > a || a <= 255, 'a must be in [0..255].');

		return true;
	},
	padHexNumber = function padHexNumber (hex, paddValue) {
		assert.isTrue(typeof hex === 'string', 'Hex must be a string.');
		assert.isInt(paddValue, 'padding value must be an integer.');
		assert.isTrue(paddValue > 0, 'padding value can\'t be negative.');

		var hexLen = hex.length;

		while(hexLen < paddValue) {
			hex = '0' + hex;
			paddValue--;
		}

		return hex;
	};

var ColorRGBPrototype =  {
	r : 0,
	g : 0,
	b : 0,
	a : 0,
	constructor : function(r, g, b, a) {
		if (validRGBFormat(r, g, b, a)) {
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		return this;
	},
	toColorHex : function() {
		var hexFormat = '';
		hexFormat = hexFormat + padHexNumber(this.r.toString(16), 2);
		hexFormat = hexFormat + padHexNumber(this.g.toString(16), 2);
		hexFormat = hexFormat + padHexNumber(this.b.toString(16), 2);
		hexFormat = hexFormat + padHexNumber(this.a.toString(16), 2);
		return hexFormat;
	},
	toString : function() {
		return JSON.stringify(this);
	}
}

module.exports = ColorRGBPrototype;

// // Example
// var color = Object.create(ColorRGBPrototype);
// color.constructor(1, 2, 0, 255);
// console.log(color);
// console.log(color.toColorHex());