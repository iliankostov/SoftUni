var studentCollection = [
    {"gender":"Male","firstName":"Joe","lastName":"Riley","age":22,"country":"Russia"},
    {"gender":"Female","firstName":"Lois","lastName":"Morgan","age":41,"country":"Bulgaria"},
    {"gender":"Male","firstName":"Roy","lastName":"Wood","age":33,"country":"Russia"},
    {"gender":"Female","firstName":"Diana","lastName":"Freeman","age":40,"country":"Argentina"},
    {"gender":"Female","firstName":"Bonnie","lastName":"Hunter","age":23,"country":"Bulgaria"},
    {"gender":"Male","firstName":"Joe","lastName":"Young","age":16,"country":"Bulgaria"},
    {"gender":"Female","firstName":"Kathryn","lastName":"Murray","age":22,"country":"Indonesia"},
    {"gender":"Male","firstName":"Dennis","lastName":"Woods","age":37,"country":"Bulgaria"},
    {"gender":"Male","firstName":"Billy","lastName":"Patterson","age":24,"country":"Bulgaria"},
    {"gender":"Male","firstName":"Willie","lastName":"Gray","age":42,"country":"China"},
    {"gender":"Male","firstName":"Justin","lastName":"Lawson","age":38,"country":"Bulgaria"},
    {"gender":"Male","firstName":"Ryan","lastName":"Foster","age":24,"country":"Indonesia"},
    {"gender":"Male","firstName":"Eugene","lastName":"Morris","age":37,"country":"Bulgaria"},
    {"gender":"Male","firstName":"Eugene","lastName":"Rivera","age":45,"country":"Philippines"},
    {"gender":"Female","firstName":"Kathleen","lastName":"Hunter","age":28,"country":"Bulgaria"}
];

// Find the output at the console of the browser
console.log('Get all students with age between 18 and 24:');
console.log(_.filter(studentCollection, function(obj) {
    return (obj.age > 18 && obj.age < 24);
}));
console.log('Get all students whose first name is alphabetically before their last name:');
console.log(_.filter(studentCollection, function (obj) {
    return (obj.firstName < obj.lastName);
}));
console.log('Get only the names of all students from Bulgaria:');
console.log(_.filter(studentCollection, function (obj) {
    return (obj.country === 'Bulgaria');
}));
console.log('Get the last five students:');
console.log(_.slice(studentCollection, [start=studentCollection.length - 5], [end=studentCollection.length]));
console.log('Get the first three students who are not from Bulgaria and are male');
console.log(_.filter(studentCollection, function (obj) {
    return (obj.country != 'Bulgaria' && obj.gender == 'Male')
}).slice([start=0], [end=3]));