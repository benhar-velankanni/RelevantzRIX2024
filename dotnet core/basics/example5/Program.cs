using System;

class ShoppingDiscount
{
    static void Main()
    {
        Console.Write("Enter total amount: ");
        double totalAmount = Convert.ToDouble(Console.ReadLine());

        double discount = 0;
        double discountedAmount = totalAmount;

        if (totalAmount > 5000)
        {
            discount = totalAmount * 0.20;
            discountedAmount = totalAmount - discount;
            Console.WriteLine("Discount: 20% = " + discount);
        }
        else if (totalAmount > 2000)
        {
            discount = totalAmount * 0.10;
            discountedAmount = totalAmount - discount;
            Console.WriteLine("Discount: 10% = " + discount);
        }
        else
        {
            Console.WriteLine("No discount");
        }

        Console.WriteLine("Discounted Amount: " + discountedAmount);
    }
}