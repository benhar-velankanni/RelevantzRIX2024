namespace ArrayException
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            try
            {
                arr[5] = 6;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Array index is out of range!");
            }
            finally
            {
                Console.WriteLine("Finally block executed!");
            }
        }
    }
}