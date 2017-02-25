function solve(arr) {

    function CreateLuggage(kg, fragile, type, transferredWith) {
        return {
            kg: kg,
            fragile: fragile,
            type: type,
            transferredWith: transferredWith
        }
    }

    var persons = [];
    var sortingCriterion = "";

    for (var a in arr) {
        if (arr.hasOwnProperty(a)) {
            var line = arr[a];
            if (line !== "luggage name" && line !== "weight" && line !== "strict") {
                var elements = line.split(/\.+\*\.+/g);

                var name = elements[0];
                var luggageName = elements[1];
                var isFood = elements[2];
                var isDrink = elements[3];
                var isFragile = elements[4];
                var weightInKg = parseFloat(elements[5]);
                var transferredWith = elements[6];

                if (isFragile === "false") {
                    isFragile = false;
                } else if (isFragile === "true") {
                    isFragile = true;
                }

                var typeOfLuggage = "";
                if (isFood === 'true' && isDrink === 'false') {
                    typeOfLuggage = "food";
                } else if (isFood === 'false' && isDrink === 'true') {
                    typeOfLuggage = "drink"
                } else {
                    typeOfLuggage = "other";
                }

                var luggage = CreateLuggage(weightInKg, isFragile, typeOfLuggage, transferredWith);

                if (!persons[name]) {
                    persons[name] = { };
                }
                persons[name][luggageName] = luggage;

            } else {
                sortingCriterion = line;
            }
        }
    }
    var output = {};
    var keys = Object.keys(persons);

    if (sortingCriterion === "strict") {
        for (var j = 0; j < keys.length; j++) {
            output[keys[j]] = persons[keys[j]];
        }

        console.log(JSON.stringify(output));

    } else if (sortingCriterion === "weight") {

        //for (var b in persons) {
        //    if (persons.hasOwnProperty(b)) {
        //        console.log(persons[b]);
        //
        //    }
        //}

        //persons[name][luggageName].kg.sort(function(a, b) {
        //    return a < b;
        //});
        //
        //
        //
        //for (var k = 0; k < keys.length; k++) {
        //    output[keys[k]] = persons[keys[k]];
        //}
        //
        //console.log(JSON.stringify(output));

    } else if (sortingCriterion === "luggage name") {

    }
}

solve([
    'Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
    'weight'
]);