class Car{
    make:string;
    model:string;
    year:number;
    isRunnung:boolean;
    constructor(make:string,model:string,year:number,isRunnung:boolean){
        this.make=make;
        this.model=model;
        this.year=year;
        this.isRunnung=isRunnung;
    }
    getDetails(){
        console.log(`Make: ${this.make}, Model: ${this.model}, Year: ${this.year}, Is Running: ${this.isRunnung}`);
    }
}
class Items extends Car{
    quantity:number;
    constructor(make:string,model:string,year:number,isRunnung:boolean,quantity:number){
        super(make,model,year,isRunnung);
        this.quantity=quantity;
    }
    getDetails(){
        console.log(`Make: ${this.make}, Model: ${this.model}, Year: ${this.year}, Is Running: ${this.isRunnung}, Quantity: ${this.quantity}`);
    }
}
const car=new Car("Toyota","Camry",2022,true);
const item1=new Items("Honda","Civic",2021,false,5);
car.getDetails();
item1.getDetails();