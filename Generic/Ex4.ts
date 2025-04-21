//generic class
class Item<T> {
    id:T;
    name:string;
    price :number;
    constructor(id:T,name:string,price:number){
        this.id=id;
        this.name=name;
        this.price=price;
    }
    displayInfo():string{
        return `Id:${this.id} Name:${this.name} Price:${this.price}`;
    }
}
class PerishableItem<T> extends Item<T>{
    expirationDate:Date;
    constructor(id:T,name:string,price:number,expirationDate:Date){
        super(id,name,price);
        this.expirationDate=expirationDate;
    }
    isExpired():boolean{
        const today=new Date();
        return today>this.expirationDate;
    }
    displayInfo():string{
        const expiryStatus=this.isExpired()?"Expired":"Not Expired";
        return `${super.displayInfo()} Expiry Status:${expiryStatus}`;
    }   
}

const item1=new Item<number>(1,"Item 1",10);
const perishableItem1=new PerishableItem<number>(2,"Perishable Item 1",20,new Date("2023-01-01"));
console.log(item1.displayInfo());
console.log(perishableItem1.displayInfo());