interface Item {
  name: string;
}

interface Product extends Item {
  price: number;
  inStock: boolean;
}

interface Book extends Item {
  author: string;
  pages: number;
}

interface Car extends Item {
  make: string;
  model: string;
  year: number;
  isRunning: boolean;
}

interface Employee extends Item {
  position: string;
  salary: number;
  isFullTime: boolean;
}

interface Course extends Item {
  instructor: string;
  duration: number;
  isOnline: boolean;
}

class ProductImpl implements Product {
  productId: number;
  name: string;
  price: number;
  inStock: boolean;

  constructor(
    productId: number,
    name: string,
    price: number,
    inStock: boolean
  ) {
    this.productId = productId;
    this.name = name;
    this.price = price;
    this.inStock = inStock;
  }
}

class BookImpl implements Book {
  bookId: number;
  name: string;
  author: string;
  pages: number;

  constructor(bookId: number, name: string, author: string, pages: number) {
    this.bookId = bookId;
    this.name = name;
    this.author = author;
    this.pages = pages;
  }
}

class CarImpl implements Car {
  carId: number;
  name: string;
  make: string;
  model: string;
  year: number;
  isRunning: boolean;

  constructor(
    carId: number,
    name: string,
    make: string,
    model: string,
    year: number,
    isRunning: boolean
  ) {
    this.carId = carId;
    this.name = name;
    this.make = make;
    this.model = model;
    this.year = year;
    this.isRunning = isRunning;
  }
}

class EmployeeImpl implements Employee {
  empId: number;
  name: string;
  position: string;
  salary: number;
  isFullTime: boolean;

  constructor(
    empId: number,
    name: string,
    position: string,
    salary: number,
    isFullTime: boolean
  ) {
    this.empId = empId;
    this.name = name;
    this.position = position;
    this.salary = salary;
    this.isFullTime = isFullTime;
  }
}

class CourseImpl implements Course {
  courseId: number;
  name: string;
  instructor: string;
  duration: number;
  isOnline: boolean;

  constructor(
    courseId: number,
    name: string,
    instructor: string,
    duration: number,
    isOnline: boolean
  ) {
    this.courseId = courseId;
    this.name = name;
    this.instructor = instructor;
    this.duration = duration;
    this.isOnline = isOnline;
  }
}

function getInput(
  formData: FormData,
  formId: string
): ProductImpl | BookImpl | CarImpl | EmployeeImpl | CourseImpl {
  if (formId === "productForm") {
    const id = parseInt(formData.get("productId") as string);
    const name = formData.get("name") as string;
    const price = parseFloat(formData.get("price") as string);
    const inStock = (formData.get("inStock") as string) === "true";
    return new ProductImpl(id, name, price, inStock);
  } else if (formId === "bookForm") {
    const id = parseInt(formData.get("bookId") as string);
    const name = formData.get("name") as string;
    const author = formData.get("author") as string;
    const pages = parseInt(formData.get("pages") as string);
    return new BookImpl(id, name, author, pages);
  } else if (formId === "carForm") {
    const id = parseInt(formData.get("carId") as string);
    const name = formData.get("name") as string;
    const make = formData.get("make") as string;
    const model = formData.get("model") as string;
    const year = parseInt(formData.get("year") as string);
    const isRunning = (formData.get("isRunning") as string) === "true";
    return new CarImpl(id, name, make, model, year, isRunning);
  } else if (formId === "employeeForm") {
    const id = parseInt(formData.get("empId") as string);
    const name = formData.get("name") as string;
    const position = formData.get("position") as string;
    const salary = parseFloat(formData.get("salary") as string);
    const isFullTime = (formData.get("isFullTime") as string) === "true";
    return new EmployeeImpl(id, name, position, salary, isFullTime);
  } else if (formId === "courseForm") {
    const id = parseInt(formData.get("courseId") as string);
    const name = formData.get("name") as string;
    const instructor = formData.get("instructor") as string;
    const duration = parseFloat(formData.get("duration") as string);
    const isOnline = (formData.get("isOnline") as string) === "true";
    return new CourseImpl(id, name, instructor, duration, isOnline);
  }
  throw new Error("Invalid form id");
}

function dispOutput(
  data: ProductImpl | BookImpl | CarImpl | EmployeeImpl | CourseImpl
): void {
  if (data instanceof ProductImpl) {
    const stockStatus = data.inStock ? "Yes" : "No";
    console.log(
      `Product Details: \n===================================\nID: ${data.productId} \nName: ${data.name} \nPrice: ${data.price} INR \nIn Stock: ${stockStatus}`
    );
    alert(
      `Product Details: \n===================================\nID: ${data.productId} \nName: ${data.name} \nPrice: ${data.price} INR \nIn Stock: ${stockStatus}`
    );
  } else if (data instanceof BookImpl) {
    console.log(
      `Book Details: \n===================================\nID: ${data.bookId} \nName: ${data.name} \nAuthor: ${data.author} \nPages: ${data.pages}`
    );
    alert(
      `Book Details: \n===================================\nID: ${data.bookId} \nName: ${data.name} \nAuthor: ${data.author} \nPages: ${data.pages}`
    );
  } else if (data instanceof CarImpl) {
    const runningStatus = data.isRunning ? "Yes" : "No";
    console.log(
      `Car Details: \n===================================\nID: ${data.carId} \nName: ${data.name} \nMake: ${data.make} \nModel: ${data.model} \nYear: ${data.year} \nIs Running: ${runningStatus}`
    );
    alert(
      `Car Details: \n===================================\nID: ${data.carId} \nName: ${data.name} \nMake: ${data.make} \nModel: ${data.model} \nYear: ${data.year} \nIs Running: ${runningStatus}`
    );
  } else if (data instanceof EmployeeImpl) {
    const fullTimeStatus = data.isFullTime ? "Yes" : "No";
    console.log(
      `Employee Details: \n===================================\nID: ${data.empId} \nName: ${data.name} \nPosition: ${data.position} \nSalary: ${data.salary} INR \nIs Full Time: ${fullTimeStatus}`
    );
    alert(
      `Employee Details: \n===================================\nID: ${data.empId} \nName: ${data.name} \nPosition: ${data.position} \nSalary: ${data.salary} INR \nIs Full Time: ${fullTimeStatus}`
    );
  } else if (data instanceof CourseImpl) {
    const onlineStatus = data.isOnline ? "Yes" : "No";
    console.log(
      `Course Details: \n===================================\nID: ${data.courseId} \nName: ${data.name} \nInstructor: ${data.instructor} \nDuration: ${data.duration} Hours \nIs Online: ${onlineStatus}`
    );
    alert(
      `Course Details: \n===================================\nID: ${data.courseId} \nName: ${data.name} \nInstructor: ${data.instructor} \nDuration: ${data.duration} Hours \nIs Online: ${onlineStatus}`
    );
  }
}

export function handleFormSubmit(event: SubmitEvent): void {
  event.preventDefault();
  const form = event.target as HTMLFormElement;
  const formData = new FormData(form);
  const formId = (event.currentTarget as HTMLFormElement).id as string;
  const data = getInput(formData, formId);
  dispOutput(data);
  form.reset();
}
