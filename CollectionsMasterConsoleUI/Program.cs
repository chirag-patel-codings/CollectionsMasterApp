using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays

            //TODO: Create an integer Array of size 50
            int[] numbers = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(numbers);

            //TODO: Print the first number of the array
            Console.WriteLine("First Number: " + numbers[0]);

            //TODO: Print the last number of the array
            Console.WriteLine("Last Number: " + numbers[49]);

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array.
            //Do this 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____();
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
                Then print BOTH reversed arrays to the console.
            */

            Console.WriteLine("All Numbers Reversed:");
            Array.Reverse(numbers);
            NumberPrinter(numbers);
            
            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(numbers);
            NumberPrinter(numbers);
                
            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(numbers);
            NumberPrinter(numbers);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            
            Array.Sort(numbers);
            NumberPrinter(numbers);
            
            Console.WriteLine("\n************End Arrays*************** \n");

            #endregion

            #region Lists

            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> listNumbers = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine("Capacity of listNumbers: " + listNumbers.Capacity);

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(listNumbers);

            //TODO: Print the new capacity
            Console.WriteLine("New Capacity of listNumbers: " + listNumbers.Capacity);

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            NumberChecker(listNumbers, -1);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(listNumbers);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(listNumbers);
            NumberPrinter(listNumbers);

            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            listNumbers.Sort();
            NumberPrinter(listNumbers);

            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable.
            int[] intArrayListNumbers = listNumbers.ToArray();

            //TODO: Clear the list
            listNumbers.Clear();
            #endregion
        }

        // Sets the any multiple of '3' to '0' and those values will be reflected in the calling method's array.
        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if ((numbers[i]) % 3 == 0)
                {
                    numbers[i] = 0; 
                }
            }
        }


        // Removes any Odd numbers in the supplied list, which will be reflected in the calling method's list.
        private static void OddKiller(List<int> numberList)
        {

            // numberList.RemoveAll(l => l % 2 != 0);
            
            for (int i = 0; i < numberList.Count; i++)
            {
                if((numberList[i]) % 2 != 0)
                {
                    numberList.RemoveAt(i);
                    i--;
                }
            }
        }

        // Gets the user input and checks if the number exists in the list.
        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            string userInput = "";
            int intUserInput = searchNumber;
            bool isNumberInList = false;

            // Get user input
            while (!(int.TryParse(userInput, out intUserInput) && intUserInput > -1))
            {
                Console.WriteLine("Please enter a numberic integer between 0 and 50");
                userInput = Console.ReadLine().Trim();
            }

            // Check if number exists in the list
            isNumberInList = numberList.Contains(intUserInput);

            // Display message
            if (isNumberInList)
            {
                Console.WriteLine($"BINGO!!! This number: {intUserInput}, exists in list!!!");
            }
            else
            {
                Console.WriteLine($"Oops!!! The number: {intUserInput}, does not exists in list!!!");
            }

        }

        // Assigns the random values between 0 and 50, to the int List, which are relected in the List of calling method.
        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(0, 51));
            }
            
        }


        // Assigns the random values between 0 and 50, to the int Array, which are relected in the Array of calling method.
        private static void Populater(int[] numbers)
        {
            
            Random rng = new Random();
            
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(0, 51);
            }
        }


        // This method will Reverse the values of the supplied array
        private static void ReverseArray(int[] array)
        {
            
            if (array != null && array.Length > 0)
            {
                int arrayLength = array.Length;
                int[] reversedArray = new int[arrayLength];

                // Generating Reversed Array
                int revArrayCounter = 0;
                for (int i = arrayLength - 1; i >= 0; i--)
                {
                    reversedArray[revArrayCounter] = array[i];
                    revArrayCounter++;
                }
                
                // Changing the values that will reflect in the 'numbers' array in the calling method too...
                // Array.Copy(reversedArray, array, 50);        // Also Works
                for (int i= 0; i < array.Length; i++)
                {
                    array[i] = reversedArray[i];
                }
            }
            
        }
        
        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}