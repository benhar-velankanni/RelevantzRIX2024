class Diamond {
    public void pattern(int size)
    {
        int calc = size/2;
        int star = 1;
        Console.WriteLine();
        Console.WriteLine();

        for (int i = 0; i <= calc; i++)
        {
            for(int j = 0 ;j < calc - i ; j++)
            {
                Console.Write("  ");
            }
            for(int k = 0 ; k < star ; k++)
            {
                Console.Write("* ");
            }
            star += 2;
            Console.WriteLine();
        }
 
        star -= 4;
       
        for (int i = 0; i < calc ; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Console.Write("  ");
            }
            for (int k = 0; k < star; k++)
            {
                Console.Write("* ");
            }
            star -= 2;
            Console.WriteLine();
        }
    }
}
 
 