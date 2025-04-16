class Course {
    coursetitle: string;
    instructor: string;
    duration: number;

    constructor(coursetitle: string, instructor: string, duration: number) {
        this.coursetitle = coursetitle;
        this.instructor = instructor;
        this.duration = duration;
    }
}
class Java extends Course {
    isOnline: boolean;
    constructor(coursetitle: string, instructor: string, duration: number, isOnline: boolean) {
        super(coursetitle, instructor, duration);
        this.isOnline = isOnline;
    }
    getDetails() {
        return `Title: ${this.coursetitle}, Instructor: ${this.instructor}, Duration: ${this.duration}, Online: ${this.isOnline}`;
    }
}

let java = new Java("Java", "Arul Naveen", 6, true);
console.log(java.getDetails());
