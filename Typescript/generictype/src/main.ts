function identity<T>(value: T): T {
  return value;
}
const number = identity<number>(5);
const string = identity<string>('string');
console.log(number);
console.log(string);
interface Box<T> {
  content: T;
}
const numberBox: Box<number> = {
  content: 27,
};
const stringBox: Box<string> = {
  content: 'Hello',
};
console.log(numberBox.content);
console.log(stringBox.content);
class DataStorage<T> {
  private items: T[] = [];

  addItem(item: T) {
    this.items.push(item);
  }

  removeItem(item: T) {
    this.items.filter((i) => i !== item);
  }

  getItems() {
    return this.items;
  }
}
const stringStorage = new DataStorage<string>();
stringStorage.addItem('Cricket');
stringStorage.addItem('Football');
stringStorage.removeItem('Cricket');
console.log(stringStorage.getItems());//['Football']
class Item<T> {
  id: T;
  name: string;
  price: number;
  constructor(id: T, name: string, price: number) {
    this.id = id;
    this.name = name;
    this.price = price;
  }
  displayInfo():string {
    return `Id: ${this.id}, Name: ${this.name}, Price: ${this.price}`;
  }
}
class Publishableitem<T> extends Item<T> {
  expiryDate: Date;
  constructor(id: T, name: string, price: number, expiryDate: Date) {
    super(id, name, price);
    this.expiryDate = expiryDate;
  }
  isExpired(): boolean {
    const today = new Date();
    return today > this.expiryDate;
  }
}

const item = new Publishableitem<string>('1', 'Laptop', 50000, new Date());
console.log(item.displayInfo());
console.log(item.isExpired());
// contact.ts
// ...

const contactsList = document.getElementById('contacts-list') as HTMLDivElement;

contactService.getContacts().forEach((contact) => {
  const contactHTML = `
    <h2>${contact.name}</h2>
    <p>Email: ${contact.email}</p>
    <p>Contact Number: ${contact.contactNumber}</p>
    <p>Address: ${contact.address}</p>
  `;
  contactsList.innerHTML += contactHTML;
});