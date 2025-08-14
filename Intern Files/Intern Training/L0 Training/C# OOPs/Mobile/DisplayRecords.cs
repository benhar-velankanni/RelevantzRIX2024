public class DisplayRecords{
    public void dispayRecords(List<Mobile> mobiles){
        Console.WriteLine("\n======================");
        Console.WriteLine("The Mobile Catalog: ");
        Console.WriteLine("======================");

        foreach (Mobile mobile in mobiles)
        {
            Console.WriteLine($"\nManufacturer: {mobile.Manufacturer} \nPrice: ${mobile.Price} \nIMIE: {mobile.IMIE}");
        }
    }
}