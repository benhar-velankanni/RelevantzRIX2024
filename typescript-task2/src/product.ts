class Product{
    id:number;
    name:string;
    price:number;
    constructor(id:number,name:string,price:number){
        this.id=id;
        this.name=name;
        this.price=price;
    }
     getDetails(): string{
        
        return `${this.id} ${this.name} ${this.price}`;


}
}
class item extends Product{
    quantity:number;
    isstock:boolean;
    constructor(id:number,name:string,price:number,quantity:number,isstock:boolean){
        super(id,name,price);
        this.quantity=quantity;
        this.isstock=isstock;
    }
    getDetails(): string{
        
        return `Id:${this.id} Name:${this.name} Price:${this.price } quantity:${this.quantity} stock:${this.isstock}`;


}

}
let item1=new item(1,"apple",10,5,true);
console.log(item1.getDetails());

