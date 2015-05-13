define(['app', 'videoData'], function (app) {
    app.controller('VideoCtrl', function VideoCtrl($scope, videoData) {

        app.filter('dateFilter', function () {
            return function (videos) {
                var filteredVideos = [];
                angular.forEach(videos, function (video) {
                    if ($scope.date) {
                        if (video.date.toDateString() == $scope.date.toDateString()) {
                            filteredVideos.push(video);
                        }
                    } else {
                        filteredVideos.push(video);
                    }
                });
                return filteredVideos;
            }
        });

        $scope.message = 'Return to ';
        $scope.regex = /(https?:\/\/.*\.(?:png|jpg|gif))/i;

        $scope.addVideo = function addVideo(add) {
            var newVideo = {
                title: add.title,
                pictureUrl: add.pictureUrl,
                length: add.length,
                category: add.category,
                subscribers: 0,
                date: add.date,
                haveSubtitles: add.haveSubtitles,
                comments: []
            };

            videoData.push(newVideo);
        };

        $scope.videos = videoData;
    });
});
