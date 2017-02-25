var validHexFormat = function checkHexFormat (format) {
		if (typeof format !== 'string' || format.length !== 8 ||
			isNaN(parseInt(format, 16))) {

			throw new Error('Invalid hex format.');
		}

		return true;
	};

var Color = (function (){
	function Color (value) {
		if (validHexFormat(value)) {
			this.format = value;
		}
	}
	Color.prototype.toString = function () {
		return JSON.stringify(this);
	};

	return Color;
}());
	
module.exports = Color;

//// Example
//var color = new Color('FFFFFFFF');
//console.log(color);