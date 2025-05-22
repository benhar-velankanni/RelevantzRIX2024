

class Shopping
{
    public void Buy()
    {
        Console.Write("Enter the total amount: ");
        double totalAmount = double.Parse(Console.ReadLine());

        double discount = 0;

        if (totalAmount > 5000)
        {
            discount = 0.20; // 20%
        }
        else if (totalAmount > 2000)
        {
            discount = 0.10; // 10%
        }
        else
        {
            discount = 0.0; // No discount
        }

        double discountAmount = totalAmount * discount;
        double finalAmount = totalAmount - discountAmount;

        Console.WriteLine($"Total Amount: {totalAmount}");
        Console.WriteLine($"Discount Applied: {discount * 100}%");
        Console.WriteLine($"Discount Amount: {discountAmount}");
        Console.WriteLine($"Amount to Pay: {finalAmount}");
    }
}
