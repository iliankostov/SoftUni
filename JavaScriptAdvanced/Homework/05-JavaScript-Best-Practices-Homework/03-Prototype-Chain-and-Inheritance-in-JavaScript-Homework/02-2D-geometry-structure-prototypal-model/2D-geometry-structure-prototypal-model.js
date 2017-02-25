var c1 = Object.create(Geometry2D.circle).init(1, 1, "#FFF", 1);
var r1 = Object.create(Geometry2D.rectangle).init(1, 1, "#FFF", 1, 1);
var t1 = Object.create(Geometry2D.triangle).init(1, 1, "#FFF", 2, 2, 3, 3);
var l1 = Object.create(Geometry2D.line).init(1, 1, "#FFF", 2, 2);
var s1 = Object.create(Geometry2D.segment).init(1, 1, "#FFF", 2, 2);

console.log(c1);
console.log(r1);
console.log(t1);
console.log(l1);
console.log(s1);