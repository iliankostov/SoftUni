function variablesTypes(arr) {
    return console.log('"My name: %s // type is %s\n' +
    'My age: %d // type is %s\n' +
    'I am male: %s //type is %s\n' +
    'My favorite foods are: %s //type is %s"',
        arr[0], typeof(arr[0]), arr[1], typeof(arr[1]),
        arr[2], typeof(arr[2]), arr[3], typeof(arr[3]) );
}

variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]);