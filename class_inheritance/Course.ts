class Course{
    title:string;
    instuction:string;
    duration:number;
    isOnline:boolean;
    constructor(title:string,instuction:string,duration:number,isOnline:boolean){
        this.title=title;
        this.instuction=instuction;
        this.duration=duration;
        this.isOnline=isOnline;
    }
getDetails(){
    console.log(`Title: ${this.title}, Instructor: ${this.instuction}, Duration: ${this.duration}, Is Online: ${this.isOnline}`);
}
}
class Person extends Course{
    instructor:string;
    constructor(title:string,instuction:string,duration:number,isOnline:boolean,instructor:string){
        super(title,instuction,duration,isOnline);
        this.instructor=instructor;
    }
    getDetails(): void {
        console.log(`Title: ${this.title}, Instructor: ${this.instuction}, Duration: ${this.duration}, Is Online: ${this.isOnline}, Instructor: ${this.instructor}`);
    }
}

const person=new Person("Java","John",2,true,"John");
person.getDetails();
const course=new Course("Java","John",2,true);
course.getDetails();
