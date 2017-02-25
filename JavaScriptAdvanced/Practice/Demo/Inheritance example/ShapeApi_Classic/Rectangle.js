var assert = require('./lib/assertModule'),
	objExtentions = require('./lib/objectExtentions'),
	Color = require('./Color'),
	Vector = require('./Vector'),
	Shape = require('./Shape');

objExtentions(); // apply object extensions for this module.

var Rectangle = (function (){
	function Rectangle (position, width, height, color) {
		Shape.call(this, color);
		this.setPosition(position);
		this.setWidth(width);
		this.setHeigth(height);
	}

	Rectangle.inherit(Shape);
	Rectangle.prototype.setPosition = function(position) {
		assert.isTrue(position instanceof Vector, 
			'The position must be and instance of Vector.');

		this._position = position;
	};
	Rectangle.prototype.getPosition = function() {
		return this._position;
	};
	Rectangle.prototype.setWidth = function(width) {
		assert.isNumber(width, 'Width must be a number');
		this._width = width;
	};
	Rectangle.prototype.getWidth = function() {
		return this._width;
	};
	Rectangle.prototype.setHeigth = function(height) {
		assert.isNumber(height, 'Height must be a number');
		this._heigth = height;
	};
	Rectangle.prototype.getHeigth = function() {
		return this._heigth;
	};
	Rectangle.prototype.toString = function() {
		var baseStr = Shape.prototype.toString.call(this);
		return '{ position: ' + this._position + ', width: ' + this._width +
			', height: ' + this._heigth + ', ' + baseStr + ' }';
	};

	return Rectangle;
}());

module.exports = Rectangle;

// Example 
var v1 = new Vector([5, 5]);
var rect = new Rectangle(v1, 10, 10);
console.log(rect.toString());