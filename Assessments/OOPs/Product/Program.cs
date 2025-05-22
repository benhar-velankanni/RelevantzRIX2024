using System;
using System.Collections.Generic;
class Product{
    public int Id{get;set;}
    public string Name{get;set;}
    public double Price{get;set;}
    public string Description{get;set;}
}
class ProductList{
    private List<Product> products=new List<Product>();
    public void AddProduct(){
        Console.WriteLine("Enter product id");
        int id=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter product name");
        string name=Console.ReadLine();
        Console.WriteLine("Enter product price");
        double price=double.Parse(Console.ReadLine());
        Console.WriteLine("Enter product description");
        string description=Console.ReadLine();
        Product product=new Product();
        product.Id=id;
        product.Name=name;
        product.Price=price;
        product.Description=description;
        products.Add(product);
        Console.WriteLine("Product added successfully");
    }
    public void UpdateProduct(){
        Console.WriteLine("Enter product id");
        int id=int.Parse(Console.ReadLine());
        Product product=products.Find(p=>p.Id==id);
        if(product!=null){
            Console.WriteLine("Enter product name");
            string name=Console.ReadLine();
            Console.WriteLine("Enter product price");
            double price=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter product description");
            string description=Console.ReadLine();
            product.Name=name;
            product.Price=price;
            product.Description=description;
            Console.WriteLine("Product updated successfully");
        }
        else{
            Console.WriteLine("Product not found");
        }
    }
    public void DisplayProducts(){
        foreach(Product product in products){
            Console.WriteLine("Id: "+product.Id);
            Console.WriteLine("Name: "+product.Name);
            Console.WriteLine("Price: "+product.Price);
            Console.WriteLine("Description"+product.Description);
        }
    }
}
class Program{
    static void Main(string[] args){
        ProductList productList=new ProductList();
        while(true){
            Console.WriteLine("Enter your choice");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Update product");
            Console.WriteLine("3. Display products");
            Console.WriteLine("4. Exit");
            int choice=int.Parse(Console.ReadLine());
            switch(choice){
                case 1:
                    productList.AddProduct();
                    break;
                case 2:
                    productList.UpdateProduct();
                    break;
                case 3:
                    productList.DisplayProducts();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}