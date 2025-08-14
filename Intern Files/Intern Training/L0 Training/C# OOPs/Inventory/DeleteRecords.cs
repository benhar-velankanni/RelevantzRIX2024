public class DeleteRecords
{
    public void deletions(List<Product> products)
    {
        Console.WriteLine("\nEnter the name of the product to delete: ");
        string target = Console.ReadLine();

        Product productToRemove = products.Find(x => x.Name == target);

        if (productToRemove != null){
            products.Remove(productToRemove);
            Console.WriteLine("\nProduct Record Deleted Sussessfully!");
        }
        else{
            Console.WriteLine("\nThe product you are searching for, does not exist!");
        }
    }
}