class Book{
    title: string;
    author: string;
    pages: number;

    constructor(title: string, author: string, pages: number){
        this.title = title;
        this.author = author;
        this.pages = pages;
    }
}
class Novel extends Book{
    isAvailable: boolean;
    constructor(title: string, author: string, pages: number, isAvailable: boolean){
        super(title, author, pages);
        this.isAvailable = isAvailable;
       
    }
    getDetails(){
        return `Title: ${this.title}, Author: ${this.author}, Pages: ${this.pages}, Available: ${this.isAvailable}`;
    }
}
let novel = new Novel("The Great Gatsby", "F. Scott Fitzgerald", 180, true);
console.log(novel.getDetails());