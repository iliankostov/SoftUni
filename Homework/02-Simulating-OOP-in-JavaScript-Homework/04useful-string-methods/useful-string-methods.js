String.prototype.startsWith = function (substring) {
    var substringLength = substring.length;

    if (substringLength > this.length) {
        return false;
    }

    for (var i = 0; i < substringLength; i += 1) {
        if (substring[i] !== this[i]) {
            return false;
        }
    }

    return true;
};

String.prototype.endsWith = function (substring) {
    var stringLength = this.length;
    var substringLength = substring.length;

    if (substringLength > stringLength) {
        return false;
    }

    for (var i = 0; i < substringLength; i += 1) {
        if (substring[substringLength - i] !== this[stringLength - i]) {
            return false;
        }
    }

    return true;
};

String.prototype.left = function (count) {
    var result = "";
    var stringLength = this.length;

    if (count > stringLength) {
        count = stringLength;
    }

    for (var i = 0; i < count; i += 1) {
        result += this[i];
    }

    return result;
};

String.prototype.right = function (count) {
    var result = "";
    var stringLength = this.length;

    if (count > stringLength) {
        count = stringLength;
    }

    var startIndex = stringLength - count;

    for (var i = startIndex; i < stringLength; i += 1) {
        result += this[i];
    }

    return result;
};

String.prototype.padLeft = function (count, character) {
    var ch = character || " ";
    return ch.repeat(count) + this;
};

String.prototype.padRight = function (count, character) {
    var ch = character || " ";
    return this + ch.repeat(count);
};

String.prototype.repeat = function (count) {
    var repeat = [];

    for (var i = 0; i < count; i++) {
        repeat[i] = this;
    }

    return repeat.join( '' );
};

var example = "This is an example string used only for demonstration purposes.";
console.log(example.startsWith("This"));
console.log(example.startsWith("this"));
console.log(example.startsWith("other"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.endsWith("poses."));
console.log(example.endsWith ("example"));
console.log(example.startsWith("something else"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.left(9));
console.log(example.left(90));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.right(9));
console.log(example.right(90));

// Combinations must also work
var example = "abcdefgh";
console.log(example.left(5).right(2));

var hello = "hello";
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, "."));
console.log(hello.padLeft(10, "."));
console.log(hello.padLeft(2, "."));

var hello = "hello";
console.log(hello.padRight(5) + "// There are 5 spaces here");
console.log(hello.padRight(10) + "// There are 10 spaces here");
console.log(hello.padRight(5, "."));
console.log(hello.padRight(10, "."));
console.log(hello.padRight(2, "."));

var character = "*";
console.log(character.repeat(5));
// Alternative syntax
console.log("~".repeat(3));

// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));
