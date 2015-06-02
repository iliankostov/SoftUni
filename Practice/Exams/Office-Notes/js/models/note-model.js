define([], function () {
    return (function() {
        function NoteModel(baseUrl, requester, headers) {
            this.serviceUrl = baseUrl + 'classes/Note/';
            this.requester = requester;
            this.headers = headers;
        }

        NoteModel.prototype.listOfficeNotes = function(dateTimeNow) {
            var serviceUrl = this.serviceUrl + '?where={"deadline":"' + dateTimeNow + '"}';
            return this.requester.get(serviceUrl, this.headers.getHeaders());
        };

        NoteModel.prototype.listMyNotes = function(userId) {
            var serviceUrl = this.serviceUrl + '?where={"author": { "__type": "Pointer", "className": "_User", "objectId": "' + userId + '"}}';
            return this.requester.get(serviceUrl, this.headers.getHeaders());
        };

        NoteModel.prototype.addNote = function(author, authorName, title, text, deadline) {
            var data = {
                author: author,
                authorName: authorName,
                title: title,
                text: text,
                deadline: deadline,
                ACL : {}
            };

            data.ACL[author.objectId] = {"write":true,"read":true};
            data.ACL["*"] = {"read":true};

            return this.requester.post(this.serviceUrl, this.headers.getHeaders(true), JSON.stringify(data));
        };

        NoteModel.prototype.getNoteById = function (noteId) {
            var serviceUrl = this.serviceUrl + '?where={"objectId":"' + noteId + '"}';
            return this.requester.get(serviceUrl, this.headers.getHeaders(true));
        };

        NoteModel.prototype.editNote = function(authorName, userId, title, text, deadline) {
            var data = {
                authorName: authorName,
                title: title,
                text: text,
                deadline: deadline,
                ACL : {}
            };

            return this.requester.put(this.serviceUrl, this.headers.getHeaders(true), JSON.stringify(data));
        };

        NoteModel.prototype.deleteNote = function(noteId) {
            return this.requester.remove(this.serviceUrl + noteId, this.headers.getHeaders(true));
        };

        return {
            load: function(baseUrl, requester, headers) {
                return new NoteModel(baseUrl, requester, headers);
            }
        }
    }());
});
