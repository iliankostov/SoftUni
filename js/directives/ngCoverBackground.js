define(['app'], function (app) {
    app.directive("ngCoverBackground", function () {
        return function(scope, element, attrs){
            var url = attrs.ngCoverBackground;
            element.css({
                'background-image': 'url(' + url +')',
                'background-size' : 'cover'
            });
        };
    });
});
