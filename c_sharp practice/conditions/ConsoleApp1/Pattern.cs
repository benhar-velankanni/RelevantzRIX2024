public class Pattern
{
    public void pattern()
    {
        Console.WriteLine("Enter n");
        int n=Convert.ToInt32(Console.ReadLine());
        for(int i=1;i<=n;i++)
        {
            for(int j=1;j<=i;j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

    }
    public void diamond()
    {
        int n=5;
        for(int i=0;i<n;i++)
        {
            for(int j)
        }

        
    }
    public void duplicate()
    {
    


        int[] originalArray = { 1, 2, 3, 2, 4, 1, 5 };
        int[] uniqueArray = new int[originalArray.Length];
        int uniqueCount = 0;

        for (int i = 0; i < originalArray.Length; i++)
        {
            bool isDuplicate = false;

            for (int j = 0; j < uniqueCount; j++)
            {
                if (originalArray[i] == uniqueArray[j])
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                uniqueArray[uniqueCount] = originalArray[i];
                uniqueCount++;
            }
        }

        Console.WriteLine("Array without duplicates:");
        for (int i = 0; i < uniqueCount; i++)
        {
            Console.Write(uniqueArray[i] + " ");
        }
    }
}


    