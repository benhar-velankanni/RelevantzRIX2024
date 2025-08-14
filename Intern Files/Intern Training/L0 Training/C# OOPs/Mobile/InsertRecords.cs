public class InsertRecords{
    public void Insertions(List<Mobile> mobiles){
        Console.WriteLine("\nEnter the number of mobiles: ");
        int n = int.Parse(Console.ReadLine());


        Console.WriteLine("\nEnter the details of the mobiles: ");
        Console.WriteLine("====================================");
        for (int i = 0; i < n; i++)
        {
            Mobile mobile = new Mobile();

            Console.Write("\nManufacturer: ");
            mobile.Manufacturer = Console.ReadLine();

            Console.Write("Price (in dollars): ");
            mobile.Price = double.Parse(Console.ReadLine());

            Console.Write("IMIE: ");
            mobile.IMIE = Console.ReadLine();

            mobiles.Add(mobile);
        }
    }
}