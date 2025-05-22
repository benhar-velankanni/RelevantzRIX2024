class Book {
    title: string;
    author: string;
    pages: number;
    isAvailable: boolean;
  
    constructor(title: string, author: string, pages: number, isAvailable: boolean) {
      this.title = title;
      this.author = author;
      this.pages = pages;
      this.isAvailable = isAvailable;
    }
  
    toString(): string {
      return `Title: ${this.title}, Author: ${this.author}, Pages: ${this.pages}, Available: ${this.isAvailable}`;
    }
  }
  
  const form = document.getElementById('book-form') as HTMLFormElement;

  form.addEventListener('submit', (e) => {
    e.preventDefault();
  
    const titleInput = form.querySelector('#title') as HTMLInputElement;
    const authorInput = form.querySelector('#author') as HTMLInputElement;
    const pagesInput = form.querySelector('#pages') as HTMLInputElement;
    const isAvailableInput = form.querySelector('#isAvailable') as HTMLInputElement;
  
    const title = titleInput.value;
    const author = authorInput.value;
    const pages = parseInt(pagesInput.value);
    const isAvailable = isAvailableInput.checked;
  
    console.log('Book Details:');
    console.log(`Title: ${title}`);
    console.log(`Author: ${author}`);
    console.log(`Pages: ${pages}`);
    console.log(`Is Available: ${isAvailable ? 'Yes' : 'No'}`);
  
    const book = new Book(title, author, pages, isAvailable);
    console.log(book.toString());
  });