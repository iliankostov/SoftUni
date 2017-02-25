var AssertModule = (function(){

	function AssertModule () {}

	AssertModule.prototype.areEqual = function(first, second, equalsFunction, errMessage) {
		var result = equalsFunction(first, second);
		if (result !== true){
			throw new Error(errMessage);
		}

		return true;
	};
	AssertModule.prototype.isNumber = function(num, errMessage) {
		if (typeof num !== 'number' || isNaN(num)) {
			throw new Error(errMessage);
		}
		
		return true;
	};
	AssertModule.prototype.isInt = function(num, errMessage) {
		if (typeof num !== 'number' || num % 1 !== 0){
			throw new Error(errMessage);
		}
		
		return true;
	};
	AssertModule.prototype.isTrue = function(expression, errMessage) {
		if (!expression) {
			throw new Error(errMessage);
		}

		return true;
	};

	return AssertModule;
})();

var assert = new AssertModule();
module.exports = assert;

assert.isNumber(1, 'err msg');
assert.isNumber(1.2, 'err msg');
// assert.isNumber(NaN, 'err msg'); //ERR

assert.isInt(1, 'err msg');
// assert.isInt(1.2, 'err msg');
// assert.isInt(NaN, 'err msh'); // ERR