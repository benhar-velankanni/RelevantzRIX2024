type cou={
    title:string,
    instructor:string,
    duration:number,
    isOnline:boolean
}
   
export class course{

    courdis(input:cou){
        console.log("Course Section!!");
        console.log(`Course title is ${input.title} and instructor is ${input.instructor} and duration is ${input.duration} and course is ${input.isOnline}`);
    }
}