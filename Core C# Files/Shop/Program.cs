namespace Shop
{
    class ShoppingItem
    {
        private long itemNo;
        private string? itemName;
        private string? itemSize;
        private decimal itemPrice;

        public long ItemNo
        {
            get
            {
                return itemNo;
            }
            set
            {
                if (value <= 0)
                {
                    itemNo = 0;
                }
                else
                {
                    itemNo = value;
                }
            }
        }

        public string? ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                if (value == null)
                {
                    itemName = "Item Name not provided";
                }
                else
                {
                    itemName = value;
                }
            }
        }

        public string? ItemSize
        {
            get
            {
                return itemSize;
            }
            set
            {
                if (value == null)
                {
                    itemSize = "Item Size not provided";
                }
                else
                {
                    itemSize = value;
                }
            }
        }

        public decimal ItemPrice
        {
            get
            {
                return itemPrice;
            }
            set
            {
                if (value <= 0)
                {
                    itemPrice = 0;
                }
                else
                {
                    itemPrice = Math.Round(value, 2);
                }
            }
        }
    }

    class Shop
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Item Number: ");
            long itemNo = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string? itemName = Console.ReadLine();
            Console.Write("Enter Item Size: ");
            string? itemSize = Console.ReadLine();
            Console.Write("Enter Item Price: ");
            decimal itemPrice = Convert.ToDecimal(Console.ReadLine());
            ShoppingItem item = new ShoppingItem();
            item.ItemNo = itemNo;
            item.ItemName = itemName;
            item.ItemSize = itemSize;
            item.ItemPrice = itemPrice;
            Console.WriteLine("\nItem Details:\n=============================================");
            Console.WriteLine("Item Number: {0}", item.ItemNo);
            Console.WriteLine("Item Name: {0}", item.ItemName);
            Console.WriteLine("Item Size: {0}", item.ItemSize);
            Console.WriteLine("Item Price: {0:F2}", item.ItemPrice);
        }
    }
}
