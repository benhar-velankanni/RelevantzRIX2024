var Book = /** @class */ (function () {
    function Book(title, author, pages, isAvailable) {
        this.title = title;
        this.author = author;
        this.pages = pages;
        this.isAvailable = isAvailable;
    }
    return Book;
}());
var CheckBoxForBookInput = /** @class */ (function () {
    function CheckBoxForBookInput(checked) {
        this.checked = checked;
    }
    CheckBoxForBookInput.prototype.getValue = function () {
        return this.checked;
    };
    return CheckBoxForBookInput;
}());
var book_form = document.querySelector('.book-form');
book_form === null || book_form === void 0 ? void 0 : book_form.addEventListener('submit', function (e) {
    e.preventDefault();
    var book_title = document.getElementById('title');
    var author = document.getElementById('author');
    var pages = document.getElementById('pages');
    var availabile = document.getElementById('book');
    var checkbook = new CheckBoxForBookInput(availabile.checked);
    var book = new Book(book_title.value, author.value, Number(pages.value), Boolean(checkbook.getValue()));
    console.log("--- Book Details ---");
    console.log("Book Name : ".concat(book.title));
    console.log("Author : ".concat(book.author));
    console.log("Pages : ".concat(book.pages));
    if (book.isAvailable == true) {
        console.log("Availability : Yes");
    }
    else {
        console.log("Availability : No");
    }
});
