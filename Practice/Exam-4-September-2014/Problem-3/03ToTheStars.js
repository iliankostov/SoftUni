function solve(arr) {
    function Coordinates(star, x, y) {
        return {
            obj: star,
            x: x,
            y: y,
            sideX1: x - 1,
            sideX2: x + 1,
            sideY1: y - 1,
            sideY2: y + 1
        }
    }

    var stars = [];
    for (var i = 0; i < arr.length - 2; i++) {
        var elements = arr[i].split(" ");
        stars.push(Coordinates(elements[0], parseFloat(elements[1]), parseFloat(elements[2])));
    }

    var coo = arr[3].split(" ");
    var normandy = Coordinates('Normandy', parseFloat(coo[0]), parseFloat(coo[1]));
    var moves = parseFloat(arr[4]);

    for (var j = 0; j < moves + 1; j++) {
        var inSpace = true;
        for (var century in stars) {
            if (stars.hasOwnProperty(century)) {
                var star = stars[century];
                if (normandy.x >= star.sideX1 && normandy.x <= star.sideX2 && normandy.y >= star.sideY1 && normandy.y <= star.sideY2) {
                    console.log(star.obj.toLowerCase());
                    inSpace = false;
                }
            }
        }
        if (inSpace) {
            console.log("space");
        }
        normandy.y++;
    }
}

solve([
    'Sirius 3 7',
    'Alpha-Centauri 7 5',
    'Gamma-Cygni 10 10',
    '8 1',
    '6'
]);

solve([
    'Terra-Nova 16 2',
    'Perseus 2.6 4.8',
    'Virgo 1.6 7',
    '2 5',
    '4'
]);