var specialConsole = (function () {

    function extractPlaceholders(input) {
        var pattern = /{(\d+)}/g;
        var matches = input.match(pattern);
        if (matches != null) {
            for (var i = 0; i < matches.length; i++) {
                var match = matches[i].replace("{", "").replace("}", "");
                matches[i] = parseInt(match);
            }
        }
        return matches;
    }

    function processInput(args) {
        var input = args[0];
        var output = args[0];
        var placeholders =  extractPlaceholders(input);

        if (placeholders != null) {
            for (var i = 1; i < args.length; i++) {

                if (placeholders.indexOf(i - 1) == -1) {
                    throw {
                        name: "Error",
                        message: "The number of placeholder is different than the number of arguments"
                    }
                }
                var replacement = "\\{" + (i-1) + "\\}";
                output = output.replace(new RegExp(replacement, 'g'), args[i])
            }
        }
        return output;
    }

    var writeLine = function writeLine() {
        console.log(processInput(arguments));
    };

    var writeError = function writeError() {
        console.error(processInput(arguments));
    };

    var writeInfo = function writeInfo() {
        console.info(processInput(arguments));
    };

    var writeWarning = function writeWarning() {
        console.warn(processInput(arguments));
    };

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeInfo: writeInfo,
        writeWarning: writeWarning
    };
})();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Object: {0}", { name: "Gosho", toString: function() { return this.name }});
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
specialConsole.writeError("Error object: {0}", { msg: "An error happened", toString: function() { return this.msg }});
