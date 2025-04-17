//class implementation in interface
interface Shape{
    area():number;
}
class Rectangle implements Shape{
    constructor(public width:number,public height:number){};
    area():number{
        return this.width*this.height;
    }
}    
const rectangle=new Rectangle(10,20);
console.log(rectangle.area());