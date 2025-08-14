using System.Collections;

class ArrayListOperations
{
    public void Addition(){
        ArrayList arrayListValues = new ArrayList();
        Console.WriteLine();
        Console.WriteLine("Enter the size of the array: ");
        int size = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Enter the array elements: ");
        for(int i = 0; i < size; i++){
            arrayListValues.Add(Convert.ToInt32(Console.ReadLine()));
        }

        int result = 0;
        Console.Write("Array Values: ");
        foreach(int value in arrayListValues){
            Console.Write(value + ", ");
            result += value;
        }

        Console.WriteLine("\nThe Sum: " + result);
     }
}