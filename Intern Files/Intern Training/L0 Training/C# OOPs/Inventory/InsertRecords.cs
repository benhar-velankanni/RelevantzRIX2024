public class InsertRecords
{
    public void Insertions(List<Product> products)
    {
        Console.WriteLine("\nEnter the number of products: ");
        int n = int.Parse(Console.ReadLine());


        Console.WriteLine("\nEnter the details of the products: ");
        Console.WriteLine("====================================");
        for (int i = 0; i < n; i++)
        {
            Product product = new Product();

            Console.Write("\nName: ");
            product.Name = Console.ReadLine();

            Console.Write("Stock: ");
            product.Stock = int.Parse(Console.ReadLine());

            products.Add(product);
        }
    }
}