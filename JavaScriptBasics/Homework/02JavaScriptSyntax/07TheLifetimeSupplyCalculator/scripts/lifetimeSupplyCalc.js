function calcSupply(age, maxAge, food, foodPerDay) {
    var amount = (maxAge - age)* 365 * foodPerDay;
    return console.log('%dkg of %s would be enough until I am %d years old.', amount, food, maxAge)
}

calcSupply(38, 118, 'chocolate', 0.5);
calcSupply(20, 87, 'fruits', 2);
calcSupply(16, 102, 'nuts', 1.1);