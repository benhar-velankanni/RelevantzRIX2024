class Car{
    make: string;
    model: string;
    year: number;
    constructor(make: string, model: string, year: number){
        this.make = make;
        this.model = model;
        this.year = year;
    }
}
class Truck extends Car{
    isRunning: boolean;
    constructor(make: string, model: string, year: number, isRunning: boolean){
        super(make, model, year);
        this.isRunning = isRunning;
        
    }
    getDetails(){
        return `Make: ${this.make}, Model: ${this.model}, Year: ${this.year}, Running: ${this.isRunning}`;
    }
}
let truck = new Truck("Toyota", "Camry", 2022, true);
console.log(truck.getDetails());