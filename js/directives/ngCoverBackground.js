define(['app'], function (app) {
    app.directive("ngCoverBackground", function () {
        return function(scope, element, attrs){
            var url = attrs.ngCoverBackground;
            // todo check if it works
            element.css({
                'background-image': 'url(' + url +')',
                'background-size' : 'cover'
            });
        };
    });
});
