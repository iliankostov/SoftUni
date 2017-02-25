define(['app'], function (app) {
    app.controller('HomeCtrl', function ($scope) {
        $scope.regex = /(https?:\/\/.*\.(?:png|jpg|gif))/i;
        $scope.picture = {
            address: 'http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png'
        };
    });
});
