class Course {
    title: string;
    instructor: string;
    duration: number; 
    isOnline: boolean;
  
    constructor(title: string, instructor: string, duration: number, isOnline: boolean) {
      this.title = title;
      this.instructor = instructor;
      this.duration = duration;
      this.isOnline = isOnline;
    }
  }
  function createAndDisplayCourse(title: string, instructor: string, duration: number, isOnline: boolean) {
    const course = new Course(title, instructor, duration, isOnline);
    console.log(`Course Details:`);
    console.log(`Title: ${course.title}`);
    console.log(`Instructor: ${course.instructor}`);
    console.log(`Duration: ${course.duration} hours`);
    console.log(`Is Online: ${course.isOnline ? 'Yes' : 'No'}`);
  }
  
  const form = document.getElementById('course-form') as HTMLFormElement;
  
  form.addEventListener('submit', (e) => {
    e.preventDefault();
    const titleInput = document.getElementById('title') as HTMLInputElement;
    const instructorInput = document.getElementById('instructor') as HTMLInputElement;
    const durationInput = document.getElementById('duration') as HTMLInputElement;
    const isOnlineInput = document.getElementById('isOnline') as HTMLInputElement;
  
    createAndDisplayCourse(
      titleInput.value,
      instructorInput.value,
      parseFloat(durationInput.value),
      isOnlineInput.checked
    );
  });