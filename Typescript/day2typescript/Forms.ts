// export class Product {
//     constructor(public productname: string, public price: number, public onStack: boolean) {}

//     getValue(){
//         return [this.productname, this.price, this.onStack];
//     }
// }

// export class Book {
//     constructor(public booktitle: string, public author: string, public pages: number, public isavailable: boolean) {}

//     getValue(){
//         return [this.booktitle, this.author, this.pages, this.isavailable];
//     }
// }

// export class Car {
//     constructor(public make: string, public model: string, public year: number, public isrunning: boolean) {}

//     getValue(){
//         return [this.make, this.model, this.year, this.isrunning];
//     }
// }

// export class Employee {
//     constructor(public employeename: string, public position: string, public salary: number, public isfulltime: boolean) {}

//     getValue(){
//         return [this.employeename, this.position, this.salary, this.isfulltime];
//     }
// }

// export class Course { 
//     constructor(public coursetitle: string, public instructor: string, public duration: number, public isonline: string) {}

//     getValue(){
//         return [this.coursetitle, this.instructor, this.duration, this.isonline];
//     }
// }

// export function processForm(input:Product | Book | Car| Employee | Course){
//     console.log(`${input.constructor.name}: ${input.getValue().join(', ')}`);
// }


 
export function handleSubmit(event: SubmitEvent) {
    event.preventDefault();
    const form =event.currentTarget as HTMLFormElement;
    const formData = new FormData(form);
    if((event.currentTarget as HTMLFormElement).id === "productform"){
      console.log(
        "Product Form: \n Name: " +
          formData.get("name") +
          "\n Price: " +
          formData.get("price") +
          "\n In Stock: " +
          formData.get("inStock")
      );
    }
    else if((event.currentTarget as HTMLFormElement).id === "bookform"){
      console.log(
        "Book Form: \n Title: " +
          formData.get("title") +
          "\n Author: " +
          formData.get("author") +
          "\n Pages: " +
          formData.get("pages") +
          "\n Is Available: " +
          formData.get("isAvailable")
      );
    }
    else if((event.currentTarget as HTMLFormElement).id === "carform"){
      console.log(
        "Car Form: \n Make: " +
          formData.get("make") +
          "\n Model: " +
          formData.get("model") +
          "\n Year: " +
          formData.get("year") +
          "\n Is Running: " +
          formData.get("isRunning")
      );
    }
    else if((event.currentTarget as HTMLFormElement).id === "courseform"){
      console.log(
        "Course Form: \n Name: " +
          formData.get("name") +
          "\n Price: " +
          formData.get("price") +
          "\n Is Free: " +
          formData.get("isFree")
      );
    }
    else if((event.currentTarget as HTMLFormElement).id === "employeeform"){
      console.log(
        "Employee Form: \n Name: " +
          formData.get("name") +
          "\n Position: " +
          formData.get("position") +
          "\n Salary: " +
          formData.get("salary") +
          "\n Is Full Time: " +
          formData.get("isFullTime")
      );
    }
    if(event.currentTarget != null){
      (event.currentTarget as HTMLFormElement).reset();
    }
  }

