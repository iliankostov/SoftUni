var assert = require('./lib/assertModule'),
	Color = require('./Color');

var Shape = (function (){
	function Shape (color) {
		this.setColor(color);
	}

	Shape.prototype.setColor = function (color) {
		color = color || new Color('00000000');
		assert.isTrue(color instanceof Color, 'color must be an instance of Color.');

		this._color = color;
	};
	Shape.prototype.getColor = function () {
		return this._color;
	};
	Shape.prototype.toString = function () {
		return '{ color: #' + this._color.format + ' }';
	};

	return Shape;
}());

module.exports = Shape;

// Example
var color = new Color('FFFFFFFF'),
	shape = new Shape(color);

console.log(shape.toString());