class LowInv{
    public void Warn(List<Product> products){
        Console.WriteLine("\n========================");
        Console.WriteLine("The Critical Inventory: ");
        Console.WriteLine("========================");

        foreach(Product product in products){
            if(product.Stock < 5){
                Console.WriteLine(product.Name +": "+ product.Stock);
            }
        }
    }
}