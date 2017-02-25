function calcCircleArea(r) {
    return Math.PI * Math.pow(r, 2);
}

document.getElementById("areaOne").innerHTML += calcCircleArea(7);
document.getElementById("areaTwo").innerHTML += calcCircleArea(1.5);
document.getElementById("areaThree").innerHTML += calcCircleArea(20);