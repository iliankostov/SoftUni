var Field = (function () {
    function Field(name, age) {
        this.name = name;
        this.age = age;
    }

    Field.prototype = {
        get name() {
            return this._name
        },
        set name(name) {
            if (typeof  name === 'number' || name.length < 3) {
                throw  {
                    name: "Invalid name",
                    message: "name must be greater than 3 symbols."
                }
            }
            this._name = name;
        },
        get age() {
            return this._age;
        },
        set age(age) {
            if (age < 0) {
                throw {
                    name: "Invalid age",
                    message: "age cannot be negative"
                }
            }
            this._age = age;
        },
        toString: function () {
            return "Name: " + this.name + " Age: " + this.age;
        }
    };
    return Field;
}());

var ivan = new Field("Ivan", 25);
var minka = new Field("Minka", 18);
console.log(ivan.toString());
console.log(minka.toString());

try {
    ivan.name = "";
}
catch (err) {
    console.log(err.name +": " +err.message);
}

try {
    minka.age = -5;
}
catch (err) {
    console.log(err.name +": " +err.message);
}