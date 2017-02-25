app.controller('FirstDemoController', function ($scope) {
    var people = {
        angel: {
            name: 'Angel',
            hometown: 'Sofia'
        },
        georgi: {
            name: 'Georgi',
            hometown: 'Plovdiv'
        }
    };
    $scope.people = people;
    $scope.message = 'Hello AngularJS'
});
