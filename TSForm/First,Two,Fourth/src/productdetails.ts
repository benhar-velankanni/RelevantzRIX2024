class PName {
    constructor(public name: string) {}
    getName(): string {
      return this.name;
    }
  }
   
  class PPrice {
    constructor(public price: number) {}
    getPrice(): number {
      return this.price;
    }
  }
   
  class PStock {
    constructor(public isstock: boolean) {}
    getStock(): string {
      return this.isstock ? "Stock available " : "Stock not available";
    }
  }
   
  function ProcessInput(input: PName | PPrice | PStock) {
    if (input instanceof PName) {
      console.log("Name:", input.getName());
    } else if (input instanceof PPrice) {
      console.log("Price:", input.getPrice());
    } else if (input instanceof PStock) {
      console.log("In Stock:", input.getStock());
    }
  }
   
  const form = document.querySelector("#form1") as HTMLFormElement;
   
  form.addEventListener("submit", (event) => {
    event.preventDefault();
   
    const nameInput = document.getElementById("name") as HTMLInputElement;
    const priceInput = document.getElementById("price") as HTMLInputElement;
    const stockInput = document.getElementById("stock") as HTMLInputElement;
   
    const name = nameInput.value;
    const price = Number(priceInput.value);
    const stock = stockInput.checked;
   
    const product = new PName(name);
    const price1 = new PPrice(price);
    const stock1 = new PStock(stock);
   
    ProcessInput(product);
    ProcessInput(price1);
    ProcessInput(stock1);
  });
   