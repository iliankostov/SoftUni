function displayProperties() {
    var properties = [];
    for (var property in document) {
        properties.push(property);
    }
    properties.sort();
    console.log(properties.join('\n'));
}

displayProperties();