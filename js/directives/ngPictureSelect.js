define(['app', 'constants', 'fileReaderService', 'validationService'], function (app) {
    app.directive("ngPictureSelect", function (constants, fileReaderService, validationService, $timeout) {
        return {
            restrict: 'AEC',
            scope: {
                ngModel: '='
            },
            link: function ($scope, el) {
                function getFile(file) {
                    fileReaderService.readAsDataURL(file, $scope)
                        .then(function (result) {
                            $timeout(function () {
                                $scope.ngModel = result;
                            });
                        });
                }

                el.bind("change", function (e) {
                    var file = (e.srcElement || e.target).files[0];
                    if (validationService.validatePictureType(file) &&
                        validationService.validatePictureSize(file, constants.profilePictureMaxSize)) {
                        getFile(file);
                    }
                });
            }
        };
    });
});
