define(['noty'], function (Noty) {
    return (function () {
        function NoteController(model, views) {
            this.model = model;
            this.viewBag = views;
        }

        NoteController.prototype.loadAddNoteView = function(selector) {
            this.viewBag.addNote.addNoteView(selector);
        };

        NoteController.prototype.listMyNotes = function(selector) {
            var _this = this;
            var userId = sessionStorage['userId'];
            return this.model.listMyNotes(userId)
                .then(function (data) {
                    _this.viewBag.listMyNotes.loadMyNotesView(selector, data);
                }, function (error) {
                    console.log(error);
                });
        };

        NoteController.prototype.listOfficeNotes = function (selector) {
            var _this = this;
            var dateTimeNow = getDate();
            return this.model.listOfficeNotes(dateTimeNow)
                .then(function (data) {
                    _this.viewBag.listOfficeNotes.loadOfficeNotesView(selector, data);
                }, function (error) {
                    console.log(error);
                });
        };

        NoteController.prototype.loadNoteView = function(selector, noteId, action) {
            var _this = this;
            return this.model.getNoteById(noteId).then(
                function () {
                    if(action === 'delete') {
                        _this.viewBag.deleteNote.deleteNoteView(selector, data);
                    } else {
                        _this.viewBag.editNote.editNoteView(selector, data);
                    }
                }
            )
        };

        NoteController.prototype.addNote = function (title, text, deadline) {
            var author = getAuthorFromStorage();
            var authorName = sessionStorage['fullName'];
            return this.model.addNote(author, authorName, title, text, deadline)
                .then(function() {
                    Noty.success("You have successfully added note!");
                    window.location.replace('#/myNotes/');
                }, function() {
                    Noty.success("You have not added note!");
                })
        };

        NoteController.prototype.editNote = function (title, text, deadline) {
            var authorName = sessionStorage['fullName'];
            return this.model.editNote(authorName, title, text, deadline)
                .then(function() {
                    Noty.success("You have successfully edit your note!");
                    window.location.replace('#/myNotes/');
                }, function() {
                    Noty.success("You have not edit note!");
                })
        };

        NoteController.prototype.deleteNote = function (noteId) {
            return this.model.deleteNote(noteId)
                .then(function() {
                    Noty.success("You have successfully edit your note!");
                    window.location.replace('#/myNotes/');
                }, function() {
                    Noty.success("You have not edit note!");
                })
        };

        function getAuthorFromStorage() {
            return {
                __type: "Pointer",
                className: "_User",
                objectId: sessionStorage['userId']
            }
        }

        function getDate() {
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth()+1; //January is 0!
            var yyyy = today.getFullYear();

            if(dd<10) {
                dd='0'+dd
            }

            if(mm<10) {
                mm='0'+mm
            }

            today = yyyy + '-' + mm + '-' + dd;
            return today;
        }

        return {
            load: function (model, views) {
                return new NoteController(model, views);
            }
        }
    }());
});
