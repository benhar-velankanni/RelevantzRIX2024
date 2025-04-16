class Book{
    title:String
    author:String
    pages:Number
    isAvailable:Boolean
    constructor(title:string, author:String,pages:Number,isAvailable:Boolean){
        this.title = title
        this.author = author
        this.pages = pages
        this.isAvailable = isAvailable

    }

}

class CheckBoxForBookInput{
    constructor(public checked: Boolean){}
        getValue(){
            return this.checked
        }
    }

var book_form = document.querySelector('.book-form')
book_form?.addEventListener('submit',function(e){
    e.preventDefault()

    var book_title = document.getElementById('title') as HTMLInputElement
    var author = document.getElementById('author') as HTMLInputElement
    var pages = document.getElementById('pages') as HTMLInputElement
    var availabile = document.getElementById('book') as HTMLInputElement

    const checkbook = new CheckBoxForBookInput(availabile.checked)

    const book = new Book(book_title.value,author.value,Number(pages.value),Boolean(checkbook.getValue()))

    console.log("--- Book Details ---")
    console.log(`Book Name : ${book.title}`)
    console.log(`Author : ${book.author}`)
    console.log(`Pages : ${book.pages}`)
    if(book.isAvailable == true){
        console.log(`Availability : Yes`)
    }else{
        console.log(`Availability : No`)
    }


})
