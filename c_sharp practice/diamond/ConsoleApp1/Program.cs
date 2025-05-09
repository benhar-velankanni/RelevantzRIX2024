public class Diamond
{
    public static void Main(String[] args)
    {
        int n=5;
        
        for(int i=1; i<=n;i++)
        {
            if(i%2!=0)
            {
            for(int j=i;j<=n;j++)
            {
                Console.Write(" ");
            }
            
            for(int j=1;j<=i;j++)
            {
                Console.Write("* ");

            }
            }
            Console.WriteLine();
            
        }
    }
}