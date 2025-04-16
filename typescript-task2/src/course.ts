class Course{
    title:string;
    instructor:string;
    duration:number;
constructor(title:string,instructor:string,duration:number){
    this.title=title;
    this.instructor=instructor;
    this.duration=duration;
}
getDetails():string{
    return `Title:${this.title} Instructor:${this.instructor} Duration:${this.duration}`
    }
}
class item extends Course{
    isonline:boolean;
    constructor(title:string,instructor:string,duration:number,isonline:boolean){
        super(title,instructor,duration);
        this.isonline=isonline;
    }
    getDetails(): string {
        return `${super.getDetails()} Status:${this.isonline}`
        }
    }
let course=new item("Angular","Mukesh",2,true);
console.log(course.getDetails());