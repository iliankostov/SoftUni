use blog

db.createCollection("authors")

var PeshoId = ObjectId()
var GoshoId = ObjectId()
var MariaId = ObjectId()

db.authors.insert({
    "_id": PeshoId,
    "name": "pesho",
    "twiter": "https://www.twiter/pesho",
    "linkedIn": "https://www.linkedin.com/pesho"
})

db.authors.insert({
    "_id": GoshoId,
    "name": "gosho",
    "twiter": "https://www.twiter/gosho",
    "linkedIn": "https://www.linkedin.com/gosho"
})

db.authors.insert({
    "_id": MariaId,
    "name": "maria",
    "twiter": "https://www.twiter/maria",
    "linkedIn": "https://www.linkedin.com/maria"
})

db.getCollection('authors').find({})

db.createCollection("posts")

db.posts.insert({
    "title": "Post one",
    "content": "Hi I am Pesho and I ...",
    "dateOfCreation": "13.07.2015",
    "category": "Other",
    "tags": ["one", "post", "one"],
    "author": PeshoId
})

db.posts.insert({
    "title": "Post two",
    "content": "Hi I am Gosho and I ...",
    "dateOfCreation": "13.07.2015",
    "category": "Other",
    "tags": ["gosho", "post", "two"],
    "author": GoshoId
})

db.posts.insert({
    "title": "Post three",
    "content": "Hi I am Maria and I ...",
    "dateOfCreation": "13.07.2015",
    "category": "Other",
    "tags": ["maria", "post", "three"],
    "author": MariaId
})

db.getCollection('messages').find({})