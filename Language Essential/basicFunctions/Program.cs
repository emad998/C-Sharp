using System;

namespace basicFunctions
{
    class Program
    {
        // public static void PrintNumbers()
        // {
        //   // Print all of the integers from 1 to 255.
        //   for (int i=1; i<256; i++){
        //       Console.WriteLine(i);
        //   }
        // }

        // public static void PrintOdds()
        // {
        //   // Print all of the integers from 1 to 255.
        //   for (int i=1; i<256; i++){
        //       if(i%2 == 1){
        //           Console.WriteLine(i);
        //       }
        //   }
        // }


        // public static void PrintSum()
        // {
        //   // Print all of the integers from 1 to 255.
        //    int sum = 0;
        //   for (int i=1; i<256; i++){
        //      sum = sum + i;
        //   }
        //   Console.WriteLine(sum);
        // }


        // public static void LoopArray(int[] numbers)
        // {
        //  // Write a function that would iterate through each item of the given integer array and 
        //  // print each value to the console. 
        // //  for (int idx = 0; idx < numbers.Length; idx++){
        // //      Console.WriteLine(numbers[idx]);
        // //  }
        //  }
        // //  put in main console
        // // LoopArray(new int[] {2,7,9});


    //     public static int FindMax(int[] numbers)
    //    {
    //     // Write a function that takes an integer array and prints and returns the maximum value in the array. 
    //     // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    //     // or even a mix of positive numbers, negative numbers and zero.
    //      int max = 0;
    //      for (int idx=0; idx<numbers.Length; idx++){
    //          if (max < numbers[idx]){
    //              max = numbers[idx];
    //          }
    //      }
    //      return max;

    //    }



            // public static int GetAverage(int[] numbers)
            // {
            //     // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
            //     // For example, with an array [2, 10, 3], your program should write 5 to the console.
                
            //     int sum = 0;
            //     for (int idx=0; idx<numbers.Length; idx++){
            //         sum = sum + numbers[idx];
            //     }
            //     int avg = sum/numbers.Length;
            //     return avg;

            // }


            public static int[] OddArray()
            {
                // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
                // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
                

            }



        static void Main(string[] args)
        {
            Console.WriteLine(OddArray());
        }
    }
}
