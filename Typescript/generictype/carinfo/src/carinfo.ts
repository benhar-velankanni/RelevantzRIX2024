class Car {
    make: string;
    model: string;
    year: number;
    isRunning: boolean;
  
    constructor(make: string, model: string, year: number, isRunning: boolean) {
      this.make = make;
      this.model = model;
      this.year = year;
      this.isRunning = isRunning;
    }
  
    displayDetails(): void {
      console.log(`Make: ${this.make}`);
      console.log(`Model: ${this.model}`);
      console.log(`Year: ${this.year}`);
      console.log(`Is Running: ${this.isRunning}`);
    }
  }
  
  const form = document.getElementById('car-form') as HTMLFormElement;
  
  form.addEventListener('submit', (e) => {
    e.preventDefault();
    const make = (document.getElementById('make') as HTMLInputElement).value;
    const model = (document.getElementById('model') as HTMLInputElement).value;
    const year = parseInt((document.getElementById('year') as HTMLInputElement).value);
    const isRunning = (document.getElementById('isRunning') as HTMLInputElement).checked;
  
    const car = new Car(make, model, year, isRunning);
    car.displayDetails();
  });