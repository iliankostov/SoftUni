define(['mustache', 'sammy'], function (Mustache, Sammy) {
    return (function() {
        function NoteViews() {
            this.listOfficeNotes = {
                loadOfficeNotesView: loadOfficeNotesView
            };

            this.listMyNotes = {
                loadMyNotesView: loadMyNotesView
            };

            this.addNote = {
                addNoteView: addNoteView
            };

            this.editNote = {
                editNoteView: editNoteView
            };

            this.deleteNote = {
                deleteNoteView: deleteNoteView
            }
        }

        function loadOfficeNotesView (selector, data) {
            $.get('templates/office-note-template.html', function (template) {
                var outHtml = Mustache.render(template, data);
                $(selector).html(outHtml);
            });
        }

        function loadMyNotesView (selector, data) {
            $.get('templates/my-note-template.html', function (template) {
                var outHtml = Mustache.render(template, data);
                $(selector).html(outHtml);
            });
        }

        function addNoteView (selector) {
            $.get('templates/add-note.html', function (template) {
                var outHtml = Mustache.render(template);
                $(selector).html(outHtml);
            }).then(function() {
                $('#addNoteButton').click(function() {
                    var title = $('#title').val();
                    var text = $('#text').val();
                    var deadline = $('#deadline').val();

                    Sammy(function() {
                        this.trigger('addNote', {title: title, text: text, deadline: deadline});
                    });

                    return false;
                })
            }).done();
        }

        function editNoteView (selector, data) {
            $.get('templates/edit-note.html', function (template) {
                var outHtml = Mustache.render(template, data);
                $(selector).html(outHtml);
            }).then(function() {
                $('#editNoteButton').click(function() {
                    var title = $('#title').val();
                    var text = $('#text').val();
                    var deadline = $('#deadline').val();

                    Sammy(function() {
                        this.trigger('editNote', {id:data['results'][0].objectId, title: title, text: text, deadline: deadline});
                    });

                    return false;
                })
            }).done();
        }

        function deleteNoteView (selector, data) {
            $.get('templates/delete-note.html', function (template) {
                var outHtml = Mustache.render(template, data);
                $(selector).html(outHtml);
            }).then(function() {
                $('#deleteNoteButton').click(function() {
                    Sammy(function() {
                        this.trigger('deleteNote', {id: data['results'][0].objectId});
                    });

                    return false;
                })
            }).done();
        }

        return {
            load: function() {
                return new NoteViews();
            }
        }
    }());
});
