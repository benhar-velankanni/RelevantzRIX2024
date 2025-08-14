public class DisplayRecords{
    public void dispayRecords(List<Product> products){
        Console.WriteLine("\n===============");
        Console.WriteLine("The Inventory: ");
        Console.WriteLine("===============");

        foreach (Product product in products)
        {
            Console.WriteLine($"\nName: {product.Name} \nStock Remaining: {product.Stock}");
        }
    }
}