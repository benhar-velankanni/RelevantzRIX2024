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
 
var book_form = document.querySelector('#form2')
book_form?.addEventListener('submit',function(e){
    e.preventDefault()
 
    var book_title = document.getElementById('title') as HTMLInputElement
    var author = document.getElementById('author') as HTMLInputElement
    var pages = document.getElementById('pages') as HTMLInputElement
    var availabile = document.getElementById('book') as HTMLInputElement
 
    const checkbook = new CheckBoxForBookInput(availabile.checked)
 
    const book = new Book(book_title.value,author.value,Number(pages.value),Boolean(checkbook.getValue()))
 
    
    console.log(book.title)
    console.log(book.author)
    console.log(book.pages)
    console.log(book.isAvailable)
 
 
})
 
 