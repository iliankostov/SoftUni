var VectorPrototype = {
	x : 0,
	y : 0,
	constructor : function (x, y) {
		this.x = x;
		this.y = y;
		return this;
	},
	toString : function () {
		return '{ x: ' + this.x + ', y: ' + this.y + ' }';
	}
}

module.exports = VectorPrototype;