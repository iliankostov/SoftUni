function calcCylinderVol(arr) {
    var volume = (Math.PI * Math.pow(arr[0], 2) * arr[1]).toFixed(3);
    return console.log(volume);
}
calcCylinderVol([2, 4]);
calcCylinderVol([5, 8]);
calcCylinderVol([12, 3]);