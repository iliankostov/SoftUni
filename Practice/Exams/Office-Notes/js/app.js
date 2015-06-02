require.config({
    baseUrl: 'js',
    paths: {
        // libs
        notyLib: 'libs/jquery.noty.packaged.min',
        pagination: 'libs/jquery.simplePagination',
        jquery: 'libs/jquery-2.1.3.min',
        lodash: 'libs/lodash.min',
        mustache: 'libs/mustache.min',
        q: 'libs/q.min',
        sammy: 'libs/sammy-latest.min',

        //models
        header: 'models/header',
        requester: 'models/requester',
        userModel: 'models/user-model',
        noteModel: 'models/note-model',
        noty: 'models/noty',

        //views
        homeView: 'views/home-view',
        userView: 'views/user-view',
        noteView: 'views/note-view',

        // controllers
        homeController: 'controllers/home-controller',
        userController: 'controllers/user-controller',
        noteController: 'controllers/note-controller'
    },
    shim: {
        sammy: {
            exports: 'Sammy',
            deps: ["jquery"]
        },
        notyLib: {
            exports: 'notyLib',
            deps: ["jquery"]
        },
        lodash: {
            exports: '_'
        },
        jquery: {
            exports: '$'
        }
    }
});

define(['jquery', 'sammy', 'noty', 'header', 'requester', 'userModel', 'noteModel',
        'homeView', 'userView', 'noteView', 'homeController', 'userController', 'noteController'],
    function ($, Sammy, Noty, header, requester, userModel, noteModel,
              homeView, userView, noteView, homeController, userController, noteController) {
        (function () {
            var baseUrl, applicationId, restApiKey;
            baseUrl = 'https://api.parse.com/1/';
            applicationId = 'o3lDoP651QHjWshK7HeCM2Y4Ot0ws9jV26qVxKcc';
            restApiKey = '2euhCIbg2r6uXZ0ljQGVba4y5ZlEFBsT3eV9q3Hy';

            var headers = header.load(applicationId, restApiKey);
            var requiters = requester.load();

            var homeViews = homeView.load();
            var homeControllers = homeController.load(homeViews);

            var userModels = userModel.load(baseUrl, requiters, headers);
            var userViews = userView.load();
            var userControllers = userController.load(userModels, userViews);

            var noteModels = noteModel.load(baseUrl, requiters, headers);
            var noteViews = noteView.load();
            var noteControllers = noteController.load(noteModels, noteViews);

            var router = Sammy(function () {
                var selector = '#container';

                this.before(function () {
                    var userId = sessionStorage['userId'];
                    if (userId) {
                        $('#menu').show();
                    } else {
                        $('#menu').hide();
                    }
                });

                this.before('#/home/', function () {
                    var userId = sessionStorage['userId'];
                    if (!userId) {
                        this.redirect('#/');
                        return false;
                    }
                });

                this.before('#/office/', function() {
                    var userId = sessionStorage['userId'];
                    if(!userId) {
                        this.redirect('#/');
                        return false;
                    }
                });

                this.before('#/myNotes/', function() {
                    var userId = sessionStorage['userId'];
                    if(!userId) {
                        this.redirect('#/');
                        return false;
                    }
                });

                this.before('#/logout/', function () {
                    var userId = sessionStorage['userId'];
                    if (!userId) {
                        this.redirect('#/');
                        return false;
                    }
                });

                this.get('#/', function () {
                    homeControllers.welcomeScreen(selector);
                });

                this.get('#/register/', function () {
                    userControllers.loadRegisterPage(selector);
                });
                this.get('#/login/', function () {
                    userControllers.loadLoginPage(selector);
                });

                this.get('#/home/', function () {
                    homeControllers.homeScreen(selector);
                });

                this.get('#/office/', function() {
                    noteControllers.listOfficeNotes(selector);
                });

                this.get('#/myNotes/', function() {
                    noteControllers.listMyNotes(selector);
                });

                this.get('#/addNote/', function() {
                    noteControllers.loadAddNoteView(selector);
                });

                this.get('#/logout/', function () {
                    userControllers.logout();
                });

                this.get('#/myNotes/edit/:id', function() {
                    noteControllers.loadNoteView(selector, this.params['id'], 'edit');
                });

                this.get('#/myNotes/delete/:id', function() {
                    noteControllers.loadNoteView(selector, this.params['id'], 'delete');
                });

                this.bind('login', function (e, data) {
                    userControllers.login(data.username, data.password);
                });

                this.bind('register', function (e, data) {
                    userControllers.register(data.username, data.password, data.fullName, data.file);
                });

                this.bind('addNote', function(e, data) {
                    noteControllers.addNote(data.title, data.text, data.deadline);
                });

                this.bind('editNote', function(e, data) {
                    noteControllers.editNote(data.title, data.text, data.deadline);
                });

                this.bind('deleteNote', function(e, data) {
                    noteControllers.deleteNote(data.id);
                });
            });
            router.run('#/');
        })();
    });