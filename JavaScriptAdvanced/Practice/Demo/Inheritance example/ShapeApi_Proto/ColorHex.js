var validHexFormat = function checkHexFormat (format) {
		if (typeof format !== 'string' || format.length !== 8 ||
			isNaN(parseInt(format, 16))) {

			throw new Error('Invalid hex format.');
		}

		return true;
	};

var ColorHexPrototype = {
	format : null,
	constructor : function (value) {
		if (validHexFormat(value)) {
			this.format = value;
		}

		return this;
	},
	toColorRGB : function () {
		var r = this.format.substring(0, 2),
		g = this.format.substring(2, 4),
		b = this.format.substring(4, 6),
		a = this.format.substring(6, 8);

		return new ColorRGB(r, g, b, a);
	},
	toString : function () {
		return JSON.stringify(this);
	}
}

module.exports = ColorHexPrototype;

// // Example
// var color = Object.create(ColorHexPrototype);
// color.constructor('FFFFFFFF');
// console.log(color);