function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.name = firstName + " " + lastName;
    return this;
}

var peter = new Person("Peter", "Jackson");
console.log(peter.name);
console.log(peter.firstName);
console.log(peter.lastName);

var minka = new Person("Minka", "Drenska");
console.log(minka.name);
console.log(minka.firstName);
console.log(minka.lastName);