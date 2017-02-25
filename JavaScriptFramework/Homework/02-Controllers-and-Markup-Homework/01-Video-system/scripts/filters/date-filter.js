define(['app'], function (app) {
    app.filter('filterByDate', function () {
        return function (videos, date) {
            var filteredVideos = [];
            angular.forEach(videos, function (video) {
                if (date) {
                    if (video.date.toDateString() == date.toDateString()) {
                        filteredVideos.push(video);
                    }
                } else {
                    filteredVideos.push(video);
                }
            });
            return filteredVideos;
        }
    })
});
