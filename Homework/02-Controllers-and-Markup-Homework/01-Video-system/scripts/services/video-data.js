define(['app'], function (app) {
    app.factory('videoData', function () {
        return [
            {
                title: 'Course introduction',
                pictureUrl: 'http://phfwc.org/wp-content/uploads/2015/01/example.jpg',
                length: '3:32',
                category: 'IT',
                subscribers: 3,
                date: new Date(2015, 4, 14),
                haveSubtitles: false,
                comments: [
                    {
                        username: 'Pesho Peshev',
                        content: 'Congratulations Nakov',
                        date: new Date(2015, 4, 14),
                        likes: 3,
                        websiteUrl: 'http://pesho.com/'
                    }
                ]
            },
            {
                title: 'Mathematics fundamentals',
                pictureUrl: 'http://phfwc.org/wp-content/uploads/2015/01/example.jpg',
                length: '13:32',
                category: 'Mathematics',
                subscribers: 20,
                date: new Date(2015, 4, 13),
                haveSubtitles: true,
                comments: []
            },
            {
                title: 'Advanced Algorithms',
                pictureUrl: 'http://phfwc.org/wp-content/uploads/2015/01/example.jpg',
                length: '33:30',
                category: 'Logical',
                subscribers: 15,
                date: new Date(2015, 4, 12),
                haveSubtitles: false,
                comments: [
                    {
                        username: 'Gosho Goshov',
                        content: 'Bravo',
                        date: new Date(2015, 4, 12),
                        likes: 3,
                        websiteUrl: 'http://gosho.com/'
                    }
                ]
            }
        ];
    });
});