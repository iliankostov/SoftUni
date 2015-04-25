var bookCollection = [
    {"book":"The Grapes of Wrath","author":"John Steinbeck","price":"34,24","language":"French"},
    {"book":"The Great Gatsby","author":"F. Scott Fitzgerald","price":"39,26","language":"English"},
    {"book":"Nineteen Eighty-Four","author":"George Orwell","price":"15,39","language":"English"},
    {"book":"Ulysses","author":"James Joyce","price":"23,26","language":"German"},
    {"book":"Lolita","author":"Vladimir Nabokov","price":"14,19","language":"German"},
    {"book":"Catch-22","author":"Joseph Heller","price":"47,89","language":"German"},
    {"book":"The Catcher in the Rye","author":"J. D. Salinger","price":"25,16","language":"English"},
    {"book":"Beloved","author":"Toni Morrison","price":"48,61","language":"French"},
    {"book":"Of Mice and Men","author":"John Steinbeck","price":"29,81","language":"Bulgarian"},
    {"book":"Animal Farm","author":"George Orwell","price":"38,42","language":"English"},
    {"book":"Finnegans Wake","author":"James Joyce","price":"29,59","language":"English"},
    {"book":"The Grapes of Wrath","author":"John Steinbeck","price":"42,94","language":"English"}
];

// Find the output at the console of the browser
console.log('Group all books by language and sort them by author (if two books have the same author, sort by price)');
console.log(_.chain(bookCollection)
    .sortBy(function (bookCollection) {
        return bookCollection.author;
    })
    .groupBy(function (bookCollection) {
        return bookCollection.language;
    }));
console.log('Get the average book price for each author');
console.log(_.groupBy(bookCollection, function (bookCollection) {
    return bookCollection.author;
}));

console.log('Get all books in English or German, with price below 30.00, and group them by author');
var englishBooks = _.where(bookCollection, {language: 'English'});
var germanBooks = _.where(bookCollection, {language: 'German'});
var allBooks = englishBooks.concat(germanBooks);
var filteredBooks = _.filter(allBooks, function (obj) {
    return obj.price < 30;
});
console.log(filteredBooks);