define(['app', 'fileReaderService', 'validationService'], function (app) {
    app.directive("ngPictureSelect", function (fileReaderService, validationService, $timeout) {
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
                    if (validationService.validatePictureType(file) && validationService.validatePictureSize(file, 128*1024)) {
                        getFile(file);
                    }
                });
            }
        };
    });
});
