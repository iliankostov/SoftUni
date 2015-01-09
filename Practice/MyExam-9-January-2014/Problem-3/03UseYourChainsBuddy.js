function solve(arr) {

    var str = arr[0];
    var paragraphs = [];
    var m, rex = /<p>(.*?)<\/p>/g;

    while ( ( m = rex.exec( str ) ) != null ) {
        paragraphs.push( m[1] );
    }

    var output = [];

    for (var a in paragraphs) {
        if (paragraphs.hasOwnProperty(a)) {
            var tempParagraph = paragraphs[a];
            var paragraph = "";
            for (var c in tempParagraph) {
                if (tempParagraph.hasOwnProperty(c)) {
                    var ch = tempParagraph[c];
                    var charPatern = /[a-z0-9]/g;
                    if (ch.match(charPatern)) {
                        paragraph += ch;
                    } else{
                        paragraph += " ";
                    }
                }
            }
            paragraph = paragraph.replace(/\s+/g, " ").trim();

            var convertedParagraph = "";

            for (var e in paragraph) {
                if (paragraph.hasOwnProperty(e)) {
                    var charToConvert = paragraph[e];
                    if (!isNaN(charToConvert)) {
                        convertedParagraph += charToConvert;
                    } else if (charToConvert.charCodeAt(0) >= 97 && charToConvert.charCodeAt(0) <= 109) {
                        convertedParagraph += String.fromCharCode(charToConvert.charCodeAt(0) + 13);
                    } else if (charToConvert.charCodeAt(0) >= 110 && charToConvert.charCodeAt(0) <= 122) {
                        convertedParagraph += String.fromCharCode(charToConvert.charCodeAt(0) - 13);
                    } else if (charToConvert === "\n") {
                        console.log('error');
                    }
                }
            }

            output.push(convertedParagraph);
        }
    }
    console.log(output.join(" "));
}

solve([
'\<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>'
]);

solve([
'\<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>'
]);