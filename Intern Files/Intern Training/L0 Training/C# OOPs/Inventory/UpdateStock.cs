class UpdateStock
{
    public void update(List<Product> products)
    {
        Console.WriteLine("\nEnter the name of the product to update: ");
        string target = Console.ReadLine();

        Product productToUpdate = products.FirstOrDefault(x => x.Name == target);

        Console.WriteLine("\nEnter the stock update: ");
        productToUpdate.Stock = int.Parse(Console.ReadLine());

        Console.WriteLine("\nProduct Record Updated Sussessfully!");      
    }
}