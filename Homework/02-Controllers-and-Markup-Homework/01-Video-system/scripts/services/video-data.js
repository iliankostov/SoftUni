define(['app'], function (app) {
    app.factory('videoData', function () {
        return [
            {
                title: 'Course introduction',
                pictureUrl: 'http://phfwc.org/wp-content/uploads/2015/01/example.jpg',
                length: '3:32',
                category: 'IT',
                subscribers: 3,
                date: new Date(2014, 12, 15),
                haveSubtitles: 'No',
                comments: [
                    {
                        username: 'Pesho Peshev',
                        content: 'Congratulations Nakov',
                        date: new Date(2014, 12, 15),
                        likes: 3,
                        websiteUrl: 'http://pesho.com/'
                    }
                ]
            }
        ];
    });
});