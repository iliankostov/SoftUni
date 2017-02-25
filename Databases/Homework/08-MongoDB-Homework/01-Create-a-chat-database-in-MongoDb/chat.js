use chat

db.createCollection("users")

var PeshoId = ObjectId()
var GoshoId = ObjectId()
var MariaId = ObjectId()

db.users.insert({
    "_id": PeshoId,
    "username": "petar",
    "fullname": "petrov",
    "website": "http://www.pesho.com"
})

db.users.insert({
    "_id": GoshoId,
    "username": "georgi",
    "fullname": "georgiev",
    "website": "http://www.gosho.com"
})

db.users.insert({
    "_id": MariaId,
    "username": "maria",
    "fullname": "hristova",
    "website": "http://www.maria.com"
})

db.getCollection('users').find({})

db.createCollection("messages")

db.messages.insert({
    "text": "zdravei gosho",
    "date": "13.07.2015",
    "isRead": false,
    "author": PeshoId
})

db.messages.insert({
    "text": "zdrasti pesho",
    "date": "13.07.2015",
    "isRead": false,
    "author": GoshoId
})

db.messages.insert({
    "text": "kak si?",
    "date": "13.07.2015",
    "isRead": false,
    "author": PeshoId
})

db.messages.insert({
    "text": "dobre. a ti?",
    "date": "13.07.2015",
    "isRead": false,
    "author": GoshoId
})

db.messages.insert({
    "text": "i az sum dobre",
    "date": "13.07.2015",
    "isRead": false,
    "author": PeshoId
})

db.getCollection('messages').find({})