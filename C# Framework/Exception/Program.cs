// Exception handling of above code
// using try catch blocks

using System;

class Program : System.Exception {
	static void Main(string[] args)
	{
		// Declare an array of max index 4
		int[] arr = { 1, 2, 3, 4, 5 };

		// Display values of array elements
		for (int i = 0; i < arr.Length; i++) {
			Console.WriteLine(arr[i]);
		}

		try {

			// Try to access invalid index of array
			Console.WriteLine(arr[2]);
			// An exception is thrown upon executing
			// the above line
		}
		catch (IndexOutOfRangeException e) {

			// The Message property of the object 
			// of type IndexOutOfRangeException
			// is used to display the type of exception
			// that has occurred to the user.
			Console.WriteLine("An Exception has occurred : {0}", e.Message);
		}
	}
}
