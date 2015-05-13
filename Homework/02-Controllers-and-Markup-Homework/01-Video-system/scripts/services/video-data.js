define(['app'], function (app) {
    app.factory('videoData', function () {
        return [
            {
                title: 'Course introduction',
                pictureUrl: 'http://phfwc.org/wp-content/uploads/2015/01/example.jpg',
                length: new Date(2015, 4, 14, 3, 32, 0),
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
                length: new Date(2015, 4, 14, 13, 32, 0),
                category: 'Mathematics',
                subscribers: 20,
                date: new Date(2015, 4, 13),
                haveSubtitles: true,
                comments: []
            },
            {
                title: 'Advanced Algorithms',
                pictureUrl: 'http://phfwc.org/wp-content/uploads/2015/01/example.jpg',
                length: new Date(2015, 4, 14, 23, 30, 0),
                category: 'Logical',
                subscribers: 15,
                date: new Date(2015, 4, 12),
                haveSubtitles: false,
                comments: [
                    {
                        username: 'Gosho Goshov',
                        content: 'Bravo',
                        date: new Date(2015, 4, 12),
                        likes: 1,
                        websiteUrl: 'http://gosho.com/'
                    },
                    {
                        username: 'Penka Ivanova',
                        content: 'Super',
                        date: new Date(2015, 4, 11),
                        likes: 2,
                        websiteUrl: 'http://gosho.com/'
                    }
                ]
            }
        ];
    });
});