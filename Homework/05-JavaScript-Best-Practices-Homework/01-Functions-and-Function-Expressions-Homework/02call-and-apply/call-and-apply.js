var printArgsInfo = (function() {
    function printArgsInfo(){
        for (var i = 0; i < arguments.length; i++) {
            console.log(arguments[i] + " (" + typeOf(arguments[i]) + ")");
        }
        console.log();
    }

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

    return printArgsInfo;
})();

printArgsInfo.call(undefined, 'Hi!', 'How', 'are', 'you?');
printArgsInfo.apply(null, ['Hi!', 'I', 'am', 'fine', 'thanks!']);