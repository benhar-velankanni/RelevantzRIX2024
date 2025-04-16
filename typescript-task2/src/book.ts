class Book{
    id:number;
    author:string;
    pages:number;
   
    constructor(id:number,author:string,pages:number){
        this.id=id;
        this.author=author;
        this.pages=pages;
       
        
    }
    getDetails():string{
        return `${this.id} ${this.author} ${this.pages}`;
    }
}
class item extends Book{
    quantity:number;
    isavailable:boolean;
    constructor(id:number,author:string,pages:number,quantity:number,isavailable:boolean)
    {
        super(id,author,pages);
        this.quantity=quantity;
        this.isavailable=isavailable;
    }
    getDetails():string{
        return `Id:${this.id} Author:${this.author} Age:${this.pages} Quantity:${this.quantity} Available:${this.isavailable}`;
    }
}
let book=new item(1,"author1",100,10,true);
console.log(book.getDetails());
