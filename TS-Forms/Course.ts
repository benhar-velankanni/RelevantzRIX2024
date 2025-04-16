class Course {
    title: string;
    instructor: string;
    duration: number; // Duration in hours
    isOnline: boolean;

    constructor(title: string, instructor: string, duration: number, isOnline: boolean) {
      this.title = title;
      this.instructor = instructor;
      this.duration = duration;
      this.isOnline = isOnline;
    }
   }


   class CheckBoxClassInput{
    constructor(public checked: Boolean){}
        getValue(){
            return this.checked
        }
    }

var form = document.getElementById("course-form") as HTMLFormElement
form.addEventListener('submit',function(e){
    e.preventDefault()
    var title  = document.getElementById('title') as HTMLInputElement
    var instructor = document.getElementById('instructor') as HTMLInputElement
    var duration = document.getElementById('duration') as HTMLInputElement
    var online = document.getElementById('online') as HTMLInputElement

    const checkInput = new CheckBoxClassInput(online.checked)


    const course = new Course(title.value,instructor.value,Number(duration.value),Boolean(checkInput.getValue()))
    console.log("--- Course Details ---")
    console.log(`Title : ${course.title}`)
    console.log(`Instructor : ${course.instructor}`)    
    console.log(`Duration : ${course.duration}`)
    if(course.isOnline == true){
        console.log(`Is Online : Yes`)
    }else{
        console.log(`Is Online : No`)
    }
})