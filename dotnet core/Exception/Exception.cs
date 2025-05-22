using System;
 public class ArrayOut{
        public void calcSum(){
            int sum = 0;
            int[] arr = new int[5]{1,2,3,4,5};
            try{
                Console.WriteLine("Before throw");
                for(int i = 1; i <= 5; i++ ){
                    sum = sum + arr[i];
                }
            }
            catch(IndexOutOfRangeException e){
                Console.WriteLine(e.Message);
 
            }
        }
        public void DivideByZero(){
            int a = 10;
            int b = 0;
            try{
                Console.WriteLine(a/b);
            }
            catch(DivideByZeroException e){
                Console.WriteLine(e.Message);
            }
        }
 
    }