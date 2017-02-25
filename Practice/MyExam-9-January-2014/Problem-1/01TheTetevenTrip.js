function solve(arr) {

    var baseConsumption = 10;

    for (var i = 0; i < arr.length; i++) {
        var elements = arr[i].split(" ");
        var carModel = elements[0];
        var fuelType = elements[1];
        var routeNumber = elements[2];
        var luggageWeight = parseFloat(elements[3]);

        var consumption = 0;

        if (fuelType == 'petrol') {
            consumption = baseConsumption;
        } else if (fuelType == 'gas') {
            consumption = 1.2 * baseConsumption;
        } else if (fuelType == 'diesel') {
            consumption = 0.8*baseConsumption;
        } else {
            consumption = -1;
        }

        consumption += 0.01 * luggageWeight;
        var length = 0;
        var normalRoad = 0;
        var snowRoad = 0;
        var totalConsumption = 0;
        var extraSnowConsumption = 0.3*consumption;

        if (routeNumber == '1') {
            length = 110;
            normalRoad = 100;
            snowRoad = 10;
        } else if (routeNumber == '2') {
            length = 95;
            normalRoad = 65;
            snowRoad = 30;
        } else {
            console.log('error');
        }

        totalConsumption = length*consumption/100;
        totalConsumption += snowRoad*extraSnowConsumption/100;
        totalConsumption = parseInt(Math.round(totalConsumption));

        var output = carModel + " " + fuelType + " " + routeNumber + " " + totalConsumption;
        console.log(output);
    }
}

solve([
    'BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54'
]);