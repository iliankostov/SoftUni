define(['app'], function (app) {
    app.directive('ngInfiniteScroll', ['$rootScope', '$window', '$timeout', function($rootScope, $window, $timeout) {
            return {
                link: function(scope, elem, attrs) {
                    var checkWhenEnabled, handler, scrollDistance, scrollEnabled;
                    $window = angular.element($window);
                    scrollDistance = 0;
                    if (attrs.ngInfiniteScrollDistance != null) {
                        scope.$watch(attrs.ngInfiniteScrollDistance, function(value) {
                            return scrollDistance = parseInt(value, 10);
                        });
                    }
                    scrollEnabled = true;
                    checkWhenEnabled = false;
                    if (attrs.ngInfiniteScrollDisabled != null) {
                        scope.$watch(attrs.ngInfiniteScrollDisabled, function(value) {
                            scrollEnabled = !value;
                            if (scrollEnabled && checkWhenEnabled) {
                                checkWhenEnabled = false;
                                return handler();
                            }
                        });
                    }
                    handler = function() {
                        var elementBottom, remaining, shouldScroll, windowBottom;
                        windowBottom = $window.height() + $window.scrollTop();
                        elementBottom = elem.offset().top + elem.height();
                        remaining = elementBottom - windowBottom;
                        shouldScroll = remaining <= $window.height() * scrollDistance;
                        if (shouldScroll && scrollEnabled) {
                            if ($rootScope.$$phase) {
                                return scope.$eval(attrs.ngInfiniteScroll);
                            } else {
                                return scope.$apply(attrs.ngInfiniteScroll);
                            }
                        } else if (shouldScroll) {
                            return checkWhenEnabled = true;
                        }
                    };
                    $window.on('scroll', handler);
                    scope.$on('$destroy', function() {
                        return $window.off('scroll', handler);
                    });
                    return $timeout((function() {
                        if (attrs.ngInfiniteScrollImmediateCheck) {
                            if (scope.$eval(attrs.ngInfiniteScrollImmediateCheck)) {
                                return handler();
                            }
                        } else {
                            return handler();
                        }
                    }), 0);
                }
            };
        }
    ])
});
