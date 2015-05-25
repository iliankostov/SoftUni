define(['app', 'constants', 'fileReaderService', 'validationService'], function (app) {
    app.directive("ngCoverSelect", function (constants, fileReaderService, validationService, $timeout) {
        return {
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
                    if (validationService.validatePictureSize(file, constants.coverPictureMaxSize)) {
                        getFile(file);
                    }
                });
            }
        };
    });
});
