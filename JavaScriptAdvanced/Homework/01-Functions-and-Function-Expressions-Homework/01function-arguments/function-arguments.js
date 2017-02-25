function typeOf(value) {
    var output = typeof (value);
    if (output === 'object') {
        if (value) {
            if (value instanceof Array) {
                output = 'array';
            }
        } else {
            output = 'null';
        }
    }
    return output;
}

function printArgsInfo() {
    for (var i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + " (" + typeOf(arguments[i]) + ")");
    }
    console.log();
}

printArgsInfo(2, 3, 2.5, -110.5564, false);
printArgsInfo(null, undefined, "", 0, [], {});
printArgsInfo([1, 2], ["string", "array"], ["single value"]);
printArgsInfo("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], {name: "Peter", age: 20});
printArgsInfo([[1, [2, [3, [4, 5]]]], ["string", "array"]]);