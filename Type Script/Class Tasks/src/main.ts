class item{
  category:string;
  constructor(category:string){
      this.category=category;
      console.log("category",this.category);
  }
}

class product extends item{
  name:string;
  price:number;
  inStock:boolean;

  constructor(name:string,category:string,price:number,inStock:boolean){
    super(category);
      this.name=name;
      this.price=price;
      this.inStock=inStock;
      console.log("name",this.name);
      console.log("price",this.price);
      console.log("inStock",this.inStock);
  }
}

var obj1=new product("laptop","Product",50000,true);

class book extends item{
  title:string;
  author:string;
  pages:number;
  isAvailable:boolean;
  constructor(title:string,author:string,pages:number,isAvailable:boolean,category:string){
    super(category);
      this.title=title;
      this.author=author;
      this.pages=pages;
      this.isAvailable=isAvailable;
      console.log("title",this.title);
      console.log("author",this.author);
      console.log("pages",this.pages);
      console.log("isAvailable",this.isAvailable);
  }
}

var obj2=new book("The Alchemist","Paulo Coelho",208,true,"Book");

class car extends item{
  make:string;
  model:string;
  year:number;
  isRunning:boolean;
  constructor(make:string,model:string,year:number,isRunning:boolean,category:string){
    super(category);
      this.make=make;
      this.model=model;
      this.year=year;
      this.isRunning=isRunning;
      console.log("make",this.make);
      console.log("model",this.model);
      console.log("year",this.year);
      console.log("isRunning",this.isRunning);
  }
}

var obj3=new car("Toyota","Camry",2022,true,"Car");

class Employee extends item{
  name:string;
  salary:number;
  isWorking:boolean;
  constructor(name:string,salary:number,isWorking:boolean,category:string){
    super(category);
      this.name=name;
      this.salary=salary;
      this.isWorking=isWorking;
      console.log("name",this.name);
      console.log("salary",this.salary);
      console.log("isWorking",this.isWorking);
  }
}

var obj4=new Employee("John Doe",50000,true,"Employee");

class Student extends item{
  name:string;
  age:number;
  isEnrolled:boolean;
  constructor(name:string,age:number,isEnrolled:boolean,category:string){
    super(category);
      this.name=name;
      this.age=age;
      this.isEnrolled=isEnrolled;
      console.log("name",this.name);
      console.log("age",this.age);
      console.log("isEnrolled",this.isEnrolled);
  }
}

var obj5=new Student("Alice",20,true,"Student");