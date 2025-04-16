class CheckBoxInput{
    constructor(public checked: Boolean){}
        getValue(){
            return this.checked
        }
    }

class Product{
    name: String;
    price:Number
    inStock:Boolean
    constructor(name : String, price:Number, inStock:Boolean){
        this.name = name
        this.price =price
        this.inStock = inStock
        
    }
}


var form = document.getElementById("products-form") as HTMLFormElement
form.addEventListener('submit',function(e){
    e.preventDefault()
    var name  = document.getElementById('name') as HTMLInputElement
    var price = document.getElementById('price') as HTMLInputElement
    var stock = document.getElementById('stock') as HTMLInputElement

    const checkInput = new CheckBoxInput(stock.checked)


    const prod = new Product(name.value,Number(price.value),Boolean(checkInput.getValue()))
    console.log("--- Product Details ---")
    console.log(`Product name : ${prod.name}`)
    console.log(`Price : ${prod.price}`)
    if(prod.inStock == true){
        console.log(`In Stock : Yes`)
    }else{
        console.log(`In Stock : No`)
    }
})