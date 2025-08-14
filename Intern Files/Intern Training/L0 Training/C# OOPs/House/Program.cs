class Catalog{
    public static void Main() {
        House virudhunagar = new House("30J","Cross St.", 30000000);

        Console.WriteLine($"\nThe Details of the property are: \nProperty Number: {virudhunagar.PropertyNumber} \nProperty Location: {virudhunagar.PropertyLocation} \nProperty Price (in INR): {virudhunagar.PropertyPrice}");
    }
}