function solve(arr) {

    console.log('\<table border="1">\n<thead>\n<tr><th colspan="3">Blades</th></tr>\n<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n</thead>\n<tbody>');

    for (var i = 0; i < arr.length; i++) {
        var length = parseInt(Math.floor(arr[i]));
        if (length > 10) {
            var application = app(length);
            var blade = "";
            if (length > 40) {
                blade = "sword";
            } else {
                blade = "dagger";
            }
            console.log("\<tr><td>" + length + "\</td><td>" + blade + "\</td><td>" + application + "\</td></tr>");
        }
    }

    console.log("\</tbody>\n</table>");

    function app(length) {
        var num = length % 5;
        switch (num) {
            case 1:
                application = "blade";
                break;
            case 2:
                application = "quite a blade";
                break;
            case 3:
                application = "pants-scraper";
                break;
            case 4:
                application = "frog-butcher";
                break;
            case 0:
                application = "*rap-poker";
                break;
            default :
                application = "unknown";
                break;
        }
        return application;
    }
}

solve([
    '17.8',
    '19.4',
    '13',
    '55.8',
    '126.96541651',
    '3'
]);