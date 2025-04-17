//multiple interface
interface Engine{
    horsePower:number;
}
interface Car{
    model:string;
}
type CarWithEngine=Car&Engine;
const car:CarWithEngine={
    model:"BMW",
    horsePower:100
}
console.log(car);