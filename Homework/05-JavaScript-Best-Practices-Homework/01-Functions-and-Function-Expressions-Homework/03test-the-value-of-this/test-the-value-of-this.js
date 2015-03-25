function testContext() {
    console.log(this);
}

console.log("1. call testContext() from global scope:");
testContext();

console.log("2. call testContext() from another function:");
function anotherFunction() {
    testContext();
}
anotherFunction();

console.log("3. call testContext() as an object:");
console.log(new testContext());