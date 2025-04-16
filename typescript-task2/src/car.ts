class Car{
    company:string;
    model:string;
    year:number;
    constructor(company:string,model:string,year:number){
        this.company=company;
        this.model=model;
        this.year=year;
    }
    getDetails():string{
        return `Company:${this.company} Model:${this.model} Year:${this.year}`;
    }

}
class sportscar extends Car{
    isrunning:boolean;
    constructor(company:string,model:string,year:number,isrunning:boolean){
        super(company,model,year);
        this.isrunning=isrunning;
    }
    getDetails(): string {
        return super.getDetails() + ` Status:${this.isrunning}`;
        
    }
}
let car1=new sportscar('Toyota','Camry',2019,true);
console.log(car1.getDetails());