class ListOperations
{
    public void Addition(){
        List<int> listValues = new List<int>();
        Console.WriteLine();
        Console.WriteLine("Enter the size of the list: ");
        int size = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Enter the list elements: ");
        for(int i = 0; i < size; i++){
            listValues.Add(Convert.ToInt32(Console.ReadLine()));
        }

        int result = 0;
        Console.Write("List Values: ");
        foreach(int value in listValues){
            Console.Write(value + ", ");
            result += value;
        }

        Console.WriteLine("\nThe Sum: " + result);
     }
}