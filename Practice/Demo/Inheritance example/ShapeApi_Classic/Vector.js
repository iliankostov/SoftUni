function isNumber(n) {
	return typeof n == 'number' && !isNaN(n);
}

var Vector = (function(){

	// constructor
	function Vector (dimensions) {
		this.setDimensions(dimensions);
	}

	// Dimensions getter and setter
	Vector.prototype.setDimensions = function(dimensions) {
		if (dimensions instanceof Array && dimensions.length !== 0){
			this._dimensions = dimensions;
		} else {
			throw new Error("dimensions must be a non-empty array.");
		}

		this._setDimLen(this._dimensions.length);
	};
	Vector.prototype.getDimensions = function() {
		return this._dimensions;	
	};

	// DimLen getter and setter.
	Vector.prototype._setDimLen = function(dimLen) {
		this._dimLen = dimLen;
	};
	Vector.prototype.getDimLen = function() {
		return this._dimLen;
	};

	// add vectors.
	Vector.prototype.add = function(other) {
		var otherLen;

		if (other instanceof Vector){
			otherLen = other.getDimLen();

			if (otherLen === this._dimLen){
				for (var i = 0; i < this._dimLen; i++) {
					this._dimensions[i] += other._dimensions[i];
				}
			} else {
				throw new Error("Can't add vectors of different dimensions.");
			}
		} else if (isNumber(other)){
			for (var i = 0; i < this._dimLen; i++) {
				this._dimensions[i] += other;
			}
		} else {
			throw new Error("other must be a Vector or an number.");
		}

		return this;
	};

	// subtract vectors.
	Vector.prototype.subtract = function(other) {
		var otherLen;

		if (other instanceof Vector){
			otherLen = other.getDimLen();

			if (otherLen === this._dimLen){
				for (var i = 0; i < otherLen; i++) {
					this._dimensions[i] -= other._dimensions[i];
				}
			} else {
				throw new Error("Can't subtract vectors of different dimensions.");
			}
		} else if (isNumber(other)){
			for (var i = 0; i < this._dimLen; i++) {
				this._dimensions[i] -= other;
			}
		} else {
			throw new Error("other must be a Vector or an number.");
		}

		return this;
	};

	// dot vectors.
	Vector.prototype.dot = function(other) {
		var otherLen, 
			dotVal = 0;

		if (other instanceof Vector){
			otherLen = other.getDimLen();

			if (otherLen === this._dimLen){
				for (var i = 0; i < otherLen; i++) {
					dotVal += this._dimensions[i] * other._dimensions[i];
				}
			} else {
				throw new Error("Can't add dot of different dimensions.");
			}
		} else if (isNumber(other)){
			for (var i = 0; i < this._dimLen; i++) {
				dotVal += this._dimensions[i] * other;
			}
		} else {
			throw new Error("other must be a Vector or an number.");
		}

		return dotVal;
	};

	// normalize vectors.
	Vector.prototype.norm = function() {
		var normVal = 0;

		for (var i = 0; i < this._dimLen; i++) {
			normVal += this._dimensions[i] * this._dimensions[i];
		}

		return Math.sqrt(normVal);
	};

	// override toString().
	Vector.prototype.toString = function() {
		var dimStr = this._dimensions.join(', ');
		return '{ ' + dimStr + ' }';
	};

	return Vector;
})();

module.exports = Vector;

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
// console.log(a.toString());
// console.log(c.toString());

// The following throws errors
//var wrong = new Vector();
//var anotherWrong = new Vector([]);

// var result = a.add(b);
// console.log(result.toString());

// var result = a.subtract(b);
// console.log(result.toString());

// var result = a.dot(b);
// console.log(result.toString());

// console.log(a.norm());
// console.log(b.norm());
// console.log(c.norm());
// console.log(a.add(b).norm());