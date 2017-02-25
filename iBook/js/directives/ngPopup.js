define(['app'], function (app) {
    app.directive('ngPopup', function() {
        return {
            restrict: 'AEC',
            link: function(scope, elem) {
                elem.parent().bind('mouseover', function() {
                    elem.css('display', 'block');
                    elem.parent().children().eq(0).addClass("highlight");
                });
                elem.parent().bind('mouseleave', function() {
                    elem.css('display', 'none');
                    elem.parent().children().eq(0).removeClass("highlight");
                });
            }
        };
    });
});
