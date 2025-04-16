import {Product, processForm} from './formhandler';
import {Book, processBook} from './formhandler';
import {Car, processCar} from './formhandler';
import {Employee, processEmployee} from './formhandler';
import {Course, processCourse} from './formhandler';


document.querySelector<HTMLFormElement>('#exampleForm')!.addEventListener('submit', (event) => {
  event.preventDefault();

  const productInput = document.querySelector<HTMLInputElement>('#productInput')!;
  const productPrice = document.querySelector<HTMLInputElement>('#productPrice')!;
  const inStock = document.querySelector<HTMLInputElement>('#inStock')!;

  const product = new Product(productInput.value, parseFloat(productPrice.value), inStock.checked);

  processForm(product);
  alert('Displayed successfully');
});

document.querySelector<HTMLFormElement>('#book')!.addEventListener('submit', (event) => {
    event.preventDefault();
  
    const title = document.querySelector<HTMLInputElement>('#title')!;
    const author = document.querySelector<HTMLInputElement>('#author')!;
    const pages = document.querySelector<HTMLInputElement>('#pages')!;
    const available = document.querySelector<HTMLInputElement>('#isavailable')!;
  
    const books = new Book(title.value, author.value, parseInt(pages.value), available.checked);
  
    processBook(books);
    alert('Displayed successfully');
  });

document.querySelector<HTMLFormElement>('#car')!.addEventListener('submit', (event) => {
    event.preventDefault();
  
    const make = document.querySelector<HTMLInputElement>('#make')!;
    const model = document.querySelector<HTMLInputElement>('#model')!;
    const year = document.querySelector<HTMLInputElement>('#year')!;
    const isrunning = document.querySelector<HTMLInputElement>('#isrunning')!;
  
    const cars = new Car(make.value, model.value, parseInt(year.value), isrunning.checked);
  
    processCar(cars);
    alert('Displayed successfully');
  });

  document.querySelector<HTMLFormElement>('#employee')!.addEventListener('submit', (event) => {
    event.preventDefault();
  
    const name = document.querySelector<HTMLInputElement>('#name')!;
    const position = document.querySelector<HTMLInputElement>('#position')!;
    const salary = document.querySelector<HTMLInputElement>('#salary')!;
    const isfulltimes = document.querySelector<HTMLInputElement>('#isfulltime')!;
  
    const employee = new Employee(name.value, parseInt(position.value), parseFloat(salary.value), isfulltimes.checked);
  
    processEmployee(employee);
    alert('Displayed successfully');
  });

  document.querySelector<HTMLFormElement>('#course')!.addEventListener('submit', (event) => {
    event.preventDefault();
  
    const coursename = document.querySelector<HTMLInputElement>('#coursename')!;
    const instructor = document.querySelector<HTMLInputElement>('#instructor')!;
    const duration = document.querySelector<HTMLInputElement>('#duration')!;
    const isonline = document.querySelector<HTMLInputElement>('#isonline')!;
  
    const course = new Course(coursename.value, instructor.value, parseInt(duration.value), isonline.checked);
  
    processCourse(course);
    alert('Displayed successfully');
  });
