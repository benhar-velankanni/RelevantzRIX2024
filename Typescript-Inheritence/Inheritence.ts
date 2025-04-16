class Book
  {
      title:string;
      author:string;
      pages:number;
     
      constructor(title:string, author:string, pages:number)
      {
          this.title=title;
          this.author=author;
          this.pages=pages;
      }
      getBookDetails() :string
          {
              return `Title: ${this.title}, Author: ${this.author}, Pages: ${this.pages}`
          }
  }
  class Novel extends Book
  {
      genre:string;
      isAvailable:boolean;
      constructor(title:string, author:string, pages:number, genre:string,isAvailable:boolean)
      {
          super(title, author, pages);
          this.genre=genre;
          this.isAvailable=isAvailable
      }
      getNovelDetails() :string
          {
              return `Title: ${this.title}, Author: ${this.author}, Pages: ${this.pages}, Genre: ${this.genre} this. isAvailable: ${this.isAvailable}`
          }
  }
   
  let  b=new Book("Wings of fire", "Abdulkalam", 50);
  let  n=new Novel("Marvel", "james", 80, "Fantasy",true);
   
  console.log(b.getBookDetails());
  console.log(n.getNovelDetails());
   
  class Car
  {
      make :string;
      model :string;
      year :number;
      constructor(make :string, model :string, year :number)
      {
          this.make=make;
          this.model=model;
          this.year=year;
      }  
      getCarDetails() :string
      {
          return `Make: ${this.make}, Model: ${this.model}, Year: ${this.year}`
      }
  }
   
  class SportsCar extends Car
  {
      topSpeed :number;
      constructor(make :string, model :string, year :number, topSpeed :number)
      {
          super(make, model, year);
          this.topSpeed=topSpeed;
      }
      getSportsCarDetails() :string
      {
          return `Make: ${this.make}, Model: ${this.model}, Year: ${this.year}, TopSpeed: ${this.topSpeed}`
      }
  }
   
  let  c=new Car("Honda", "Civic", 2022);        
  let  sc=new SportsCar("Honda", "Civic", 2022, 300);
  console.log(c.getCarDetails());
  console.log(sc.getSportsCarDetails());
   
  class Employee
  {
      name :string;
      position :string;
      salary :number;
          constructor(name :string, position :string, salary :number)
      {
          this.name=name;
          this.position=position;
          this.salary=salary;
         
      }
      getDetailsemployee() :string
      {
          return `Name: ${this.name}, Position: ${this.position}, Salary: ${this.salary}, `;
      }
  }
  class developer extends Employee
  {
      language :string;
      constructor(name :string, position :string, salary :number, language :string)
      {
          super(name, position, salary);
          this.language=language;
      }
      getdeveloperDetails() :string
      {  
          return `Name: ${this.name}, Position: ${this.position}, Salary: ${this.salary}, Language: ${this.language}`;
      }
  }
   
  let  e=new Employee("John", "Manager", 50000);
  let  d=new developer("John", "Manager", 50000, "Java");
  console.log(e.getDetailsemployee());
  console.log(d.getdeveloperDetails());
   
  class Course
  {
      title: string;  
      instructor: string;
      duration :number;
      constructor(title: string, instructor: string, duration :number)
      {
          this.title=title;
          this.instructor=instructor;
          this.duration=duration;
      }
   
      getCourseDetails() :string
      {
          return `Title: ${this.title}, Instructor: ${this.instructor}, Duration: ${this.duration}`;
      }
  }
   
  class WebDevelopment extends Course
  {
      framework :string;
      constructor(title: string, instructor: string, duration :number, framework :string)
      {
          super(title, instructor, duration);
          this.framework=framework;
      }
      getWebDevelopmentDetails() :string
      {
          return `Title: ${this.title}, Instructor: ${this.instructor}, Duration: ${this.duration}, Framework: ${this.framework}`;
      }
  }  
   
  let  c1=new Course("Python", "John", 30);  
  let  c2=new WebDevelopment("Python", "John", 30, "Django");
  console.log(c1.getCourseDetails());
  console.log(c2.getWebDevelopmentDetails());  
 


