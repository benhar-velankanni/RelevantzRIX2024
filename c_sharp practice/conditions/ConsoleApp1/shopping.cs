public class Shopping
{
    public void calculateDiscount()
    {
        Console.WriteLine("Enter the price");
        double amount=Convert.ToDouble(Console.ReadLine());
        double discount;
        if(amount > 5000)
        {
           discount=amount*(20/100);
            Console.WriteLine("Discount is"+discount);
        }
        else if (amount > 2000)
        {
            discount=amount*(10/100);
            Console.WriteLine("Discount is"+discount);
        }
        else
        {
            Console.WriteLine("No discount");
        }
        
        
    }
}