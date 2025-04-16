import { Product,processForm,Book,processBookForm,Car,processCarForm,Employee,processEmployeeForm,Course,processCourseForm } from './formHander.ts'

import './style.css'

document.getElementById('ProductForm')!.addEventListener('submit', (event)=>{
  event.preventDefault();
  const textInputElement =document.getElementById('textInput') as HTMLInputElement;
  const priceInputElement =document.getElementById('price') as HTMLInputElement;
  const instockInputElement =document.getElementById('instock') as HTMLInputElement;
  const product = new Product(textInputElement.value,Number(priceInputElement.value),instockInputElement.checked);
  processForm(product);
});

document.getElementById('bookForm')!.addEventListener('submit', (event)=>{
  event.preventDefault();
  const titleInputElement =document.getElementById('title') as HTMLInputElement;
 const authorInputElement =document.getElementById('author') as HTMLInputElement;
 const pagesInputElement =document.getElementById('pages') as HTMLInputElement;
 const isAvailableInputElement =document.getElementById('isAvailable') as HTMLInputElement;
 const books = new Book(titleInputElement.value,authorInputElement.value,Number(pagesInputElement.value),isAvailableInputElement.checked);
 processBookForm(books);
});
document.getElementById('carForm')!.addEventListener('submit', (event)=>{
  event.preventDefault();
  const nameInputElement =document.getElementById('name') as HTMLInputElement;
 const modelInputElement =document.getElementById('model') as HTMLInputElement;
 const yearInputElement =document.getElementById('year') as HTMLInputElement;
 const isRunningInputElement =document.getElementById('isRunning') as HTMLInputElement;
 const car =new Car(nameInputElement.value,modelInputElement.value,Number(yearInputElement.value), isRunningInputElement.checked);
 processCarForm(car);
})
document.getElementById('employeeForm')!.addEventListener('submit', (event)=>{
  event.preventDefault();
  const nameInputElement =document.getElementById('name') as HTMLInputElement;
 const positionInputElement =document.getElementById('position') as HTMLInputElement;
 const salaryInputElement =document.getElementById('salary') as HTMLInputElement;
 const isFulltimeInputElement =document.getElementById('isFulltime') as HTMLInputElement;
 const employee = new Employee(nameInputElement.value,positionInputElement.value,Number(salaryInputElement.value),isFulltimeInputElement.checked);
 processEmployeeForm(employee);
})
document.getElementById('courseForm')!.addEventListener('submit', (event)=>{
  event.preventDefault();
  const titleInputElement =document.getElementById('title') as HTMLInputElement;
 const instructorInputElement =document.getElementById('instructor') as HTMLInputElement;
 const durationInputElement =document.getElementById('duration') as HTMLInputElement;
 const isOnlineInputElement =document.getElementById('isOnline') as HTMLInputElement;
 const course = new Course(titleInputElement.value,instructorInputElement.value,Number(durationInputElement.value),isOnlineInputElement.checked);
 processCourseForm(course);
})