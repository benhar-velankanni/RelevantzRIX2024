// import './style.css'
// import typescriptLogo from './typescript.svg'
// import viteLogo from '/vite.svg'
// import { setupCounter } from './counter.ts'
// import { handleSubmit } from './Forms';
// import { Book, Product, Car,  Employee, Course, processForm } from './Forms';

// document.getElementById('exampleForm')?.addEventListener('submit', (event) => {
//   event.preventDefault();

//   const productnameElement = document.getElementById('productname') as HTMLInputElement;
//   const priceElement = document.getElementById('price') as HTMLInputElement;
//   const onStackElement = document.getElementById('onstack') as HTMLInputElement;
//   const booktitleElement = document.getElementById('title') as HTMLInputElement;
//   const authorElement = document.getElementById('author') as HTMLInputElement;
//   const pagesElement = document.getElementById('pages') as HTMLInputElement;
//   const isAvailableElement = document.getElementById('isavailable') as HTMLInputElement;
//   const makeElement = document.getElementById('make') as HTMLInputElement;
//   const modelElement = document.getElementById('model') as HTMLInputElement;
//   const yearElement = document.getElementById('year') as HTMLInputElement;
//   const isRunningElement = document.getElementById('isrunning') as HTMLInputElement;
//   const nameElement = document.getElementById('name') as HTMLInputElement;
//   const positionElement = document.getElementById('position') as HTMLInputElement;
//   const salaryElement = document.getElementById('salary') as HTMLInputElement;
//   const isFullTimeElement = document.getElementById('isfulltime') as HTMLInputElement;
//   const courseTitleElement = document.getElementById('coursetitle') as HTMLInputElement;
//   const instructorElement = document.getElementById('instructor') as HTMLInputElement;
//   const durationElement = document.getElementById('duration') as HTMLInputElement;
//   const isOnlineElement = document.getElementById('isonline') as HTMLInputElement;

//   const product = new Product(productnameElement.value, parseFloat(priceElement.value), onStackElement.checked);
//   const book = new Book(booktitleElement.value, authorElement.value, parseInt(pagesElement.value), isAvailableElement.checked);
//   const car = new Car(makeElement.value, modelElement.value, parseInt(yearElement.value), isRunningElement.checked);
//   const employee = new Employee(nameElement.value, positionElement.value, parseFloat(salaryElement.value), isFullTimeElement.checked);
//   const course = new Course(courseTitleElement.value, instructorElement.value, parseInt(durationElement.value), isOnlineElement.checked);

//   processForm(product);
//   processForm(book);
//   processForm(car);
//   processForm(employee);
//   processForm(course);
// });

// document.getElementById('exampleForm')?.addEventListener('submit', handleSubmit);


// document.querySelector<HTMLDivElement>('#app')!.innerHTML = `
//   <div>
//     <a href="https://vite.dev" target="_blank">
//       <img src="${viteLogo}" class="logo" alt="Vite logo" />
//     </a>
//     <a href="https://www.typescriptlang.org/" target="_blank">
//       <img src="${typescriptLogo}" class="logo vanilla" alt="TypeScript logo" />
//     </a>
//     <h1>Vite + TypeScript</h1>
//     <div class="card">
//       <button id="counter" type="button"></button>
//     </div>
//     <p class="read-the-docs">
//       Click on the Vite and TypeScript logos to learn more
//     </p>
//   </div>
// `

// setupCounter(document.querySelector<HTMLButtonElement>('#counter')!)
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