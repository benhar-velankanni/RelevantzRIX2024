//generic class 
class DataStorage<T> {
    private items:T[] = [];

    addItem(item:T) {
        this.items.push(item);
    }

    removeItem(item:T) {
        this.items=this.items.filter(i => i !== item);
    }

    getItems() :T[]{
        return this.items;
    }
}
const stringStorage= new DataStorage<string>();
stringStorage.addItem("Hello");
stringStorage.addItem("World");
stringStorage.removeItem("Hello");
console.log(stringStorage.getItems());
