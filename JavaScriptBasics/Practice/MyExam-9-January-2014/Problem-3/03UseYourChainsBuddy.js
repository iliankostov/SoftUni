function useYourChains(array) {
    var input = array[0];
    var pattern = /<p>(.*?)<\/p>/g;
    var matches = pattern.exec(input);
    var matches_array = [];

    while (matches != null) {
        var match = matches[1];
        matches_array.push(match);
        matches = pattern.exec(input);
    }

    var output_string = '';

    for (var a in matches_array) {
        if (matches_array.hasOwnProperty(a)) {
            var characters = '';

            for (var b = 0; b < matches_array[a].length; b++) {

                var char = matches_array[a][b];
                var char_pattern = /[a-z0-9]/g;
                var char_match = char.match(char_pattern);

                if (char_match) {
                    characters += char;
                }
                else {
                    characters += ' ';
                }

            }
            output_string += characters;
        }
    }
    output_string = output_string.replace(/\s+/g, ' ');
    var final_output = '';

    for (var c = 0; c < output_string.length; c++) {

        var current_char_code = output_string.charCodeAt(c);

        if (current_char_code >= 97 && current_char_code <= 109) {
            final_output += String.fromCharCode(current_char_code + 13);
        }
        else if (current_char_code >= 110 && current_char_code <= 122) {
            final_output += String.fromCharCode(current_char_code - 13);
        }
        else {
            final_output += String.fromCharCode(current_char_code);
        }
    }

    console.log(final_output);
}

useYourChains([
'\<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>'
]);

useYourChains([
'\<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>'
]);