module.exports = function() {
	Object.prototype.inherit = function (parent) {
		this.prototype = Object.create(parent.prototype);
		this.prototype.constructor = this;		
	}
}