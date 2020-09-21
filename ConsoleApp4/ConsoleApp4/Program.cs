using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{


    class Program
    {
        //Question 1
        private static void PrintTriangle(int n)
        {
            string star = "*"; // Declare the variable and initialize it.
            string space = " "; // Declare the variable and initialize it.

            int numOfSpace = n * 2 - 1; //Counting the number of spaces where either star or space will be printed each line. For n = 5, 11 of either space or star will be printed each line.
            int middlePoint = numOfSpace / 2; //To get the middle point where star will be displayed in the first line. Two stars will be added to the middle star.

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < numOfSpace; j++)
                {
                    if (j != middlePoint && j > middlePoint + i || j < middlePoint - i)
                    {
                        // j represents the index of each character of 11 in each line.
                        // i represents the number of line out of all the lines given by parameter n.
                        // The 1 of two conditions for printing blank space in each character is that the j is not equal to the middle point and the j is greater than the middle point and i.
                        // The second condition for printing blank space is that j is less than middle point - 1. 
                        // If one of these two conditions are met, blank space will be printed. Otherwise, the star will be printed.
                        Console.Write(space);
                    }


                    else
                    {
                        Console.Write(star);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /*Self reflection (time taken, learning, and recommendations)	
        The time taken were only less than 1 hour.
        There was not much learning as this was easy task with already learned skills.
        Recommendation is to make a more challenging task.
            */


        //Question 2
        private static void PrintSeriesSum(int n2)
        {
            int sum = 0; // Declare and initialize the variable sum that will be printed in the method.

            Console.Write("The odd numbers are : ");

            for (int i = 0; i < n2; i++)
            {
                int num = 1 + 2 * i; // The odd number starts with 1 when i = 0. As shown with 1+2*i, the variable increments by 2 from 1, which will be printed out. 
                Console.Write(num); // Printing out the odd numbers.
                if (i+1 != n2)
                {
                    Console.Write(", "); //Printing comma between numbers with the given condition.
                }
                sum += num; //Summing up all the odd numbers.
            }

            Console.WriteLine();
            Console.Write("The sum is : " + sum); // Printing the sum amount.
            Console.WriteLine();
            Console.WriteLine();
        }
        /*Self reflection (time taken, learning, and recommendations)	
        The time taken were about 1 hour.
        There was not much learning as this was easy task with already learned skills.
        Recommendation is to make a more challenging task.
    */



        //Question 3
        public static bool MonotonicCheck(int[] A)
        {
            int lengthArr = A.Length; // Initialize the variable with the length of the array from the parameter.
            int increasing = 0; // Initialize and declare the variable increasing to note the increasing trend in the given array.
            int decreasing = 0;// Initialize and declare the variable decreasing to note the decreasing trend in the given array.


            for (int i = 0; i < lengthArr - 1; i++)
            {
                //Comparison of two elements continue until it reaches the last element with for loop.
                if (A[i + 1] - A[i] > 0)
                {
                    increasing++; // If the two elements of the given array is increasing, the variable increasing increments by 1.
                }
                else if (A[i + 1] - A[i] < 0)
                {
                    decreasing++;// If the two elements of the given array is decreasing, the variable decreasing increments by 1.
                }
            }

            if (increasing > 0 && decreasing > 0)
            {
                return false;//If the given array had at least 1 increasing trend and at least 1 decreasing trend, then the array is not monotonic, thus false will be returned.
            }

            return true; // Otherwise, it is monotonic, thus, true will be returned.
        }
        /*Self reflection (time taken, learning, and recommendations)	
    The time taken were about 3 hour.
    I learned that I had to use the boolean variable to use it to detect the uptrend and downtrend as both uptrend and downtrend includes the same numbers.
    Recommendation is to make a more challenging task.
*/



        //Question 4
        public static int DiffPairs(int[] nums, int k)
        {
            int length = nums.Length;
            int numDiffPairs = 0;
            bool sameNumber; //boolean variable that we are going to use.


            LinkedList<int> myList = new LinkedList<int>();
            // We will use linked list to solve this question.


            //Special case when the given number k is 0.
            if (k == 0)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (j < i && nums[j] == nums[i]) // Compare the elements of the array, if statement continues where the different index of the array contain the same value.
                        {
                            int temp = nums[j];
                            sameNumber = false;
                           
                            for (int l = 0; l < myList.Count; l++)
                                //Compare the element that we had repetitively in the given array with the elements of the linked list. 
                            {
                                if (temp == myList.ElementAt(l))
                                {
                                    sameNumber = true;
                                }
                            }
                            if (!sameNumber)
                                //If the element we got that we had repetitively in the given area is already stored in the linked list, we cannot store one more time, otherwise, we store the element in the linked list.
                            {
                                myList.AddLast(nums[j]);
                            }
                        }
                    }
                }
                //Returning the count of the linked list to get the element that we had repetitively at least twice in the given array. This number will match with the numbe of distinct coordinates when k = 0;
                return myList.Count;
            }

            //This case is applied to all cases except when k = 0;

            myList.AddLast(nums[0]); // Storing the first element of the given array.

            for (int j = 0; j < nums.Length; j++)
            {
                sameNumber = false;
                for (int i = 0; i < myList.Count; i++)
                {
                    //Compare the elements of the given array and the linked list we have.
                    //If the elements of the array are not already in the linked list, it will be added to the linked list
                    if (nums[j] == myList.ElementAt(i))
                    {
                        sameNumber = true;
                    }
                }
                if (!sameNumber) //Condition filters so that we only add distinct number to our linked list.
                {
                    myList.AddLast(nums[j]); // We will have a linked list with distinct number, no number will be repetitive.
                }
            }

            
            for (int j = 0; j < myList.Count; j++)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        if (j < i && (myList.ElementAt(j) - myList.ElementAt(i) == k || myList.ElementAt(j) - myList.ElementAt(i) == k * -1))
                        // We compare the given number k with the absolute value of the difference of the two element in our linked list.
                        // If the given number k matches with the absolute value of the difference of two elements, the variable numDiffPairs will increment, which we will return at the end of the method.
                        {
                            numDiffPairs++;
                        }
                    }
                }
            return numDiffPairs;
        }
        /*Self reflection (time taken, learning, and recommendations)	
The time taken were about 6 hour.
I learned that I had to code for the special case of k = 0 and other code when k != 0.
I learned that I needed the help of using linked list to create a list of distinct numbers. 
Both cases involved extensive coding to execute the deliverables.
Recommendation is to make a more challenging task.
*/


        //Question 5
        public static int BullsKeyboard(string keyboard, string word)
        {
            int sumIndex = 0;

            int wordLength = word.Length;

            int[] arr = new int[wordLength]; // Initialize the int array with the length of the word.
            
                for (int j = 0; j < word.Length; j++)
                {
                    arr[j] = keyboard.IndexOf(word[j]); // Storing the index of each character of the keyboard that matches with the each character of the given word. 
                }

            sumIndex += arr[0]; //The first character has to by typed first from index 0.

            for (int i = 0; i < wordLength - 1; i++)
            {
                //Comparing the second index with the first index. Summing up the absolute value of the difference between the first index and second index. It continues summing up the absoulte value of difference of second and third indexes and goes on until it reaches the end of the array.
                if (arr[i + 1] - arr[i] > 0)
                {
                    //If the difference of the two indexes is positive, the sum amount sums up the positive value of the difference.
                    sumIndex += arr[i + 1] - arr[i];
                }
                else
                {
                    //Otherwise, it sums up the the difference multiplied by -1 so that it only sums up the absolute value of the differences. 
                    sumIndex += -(arr[i + 1] - arr[i]);
                }


            }

            return sumIndex; // Finally, return the sum amount. 
        }

        /*Self reflection (time taken, learning, and recommendations)	
The time taken were about 4 hour.
This was a moderate level task for me. This was much easier than the previous task.
I did not learn anything specific new to me. Fairly designed task.
Recommendation is to make a more challenging task.
*/



   

        //Question 6
        public static int StringEdit(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;

            int first = 0, second = 0;

            int diffIndex = 0;

            if (len1 - len2 == 1 || len1 - len2 == -1)
                //Adding algorithm - Incomplete, Inaccurate......
            {
                //////////////////////
                for (int i = 0; i < len2; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        second = i;
                        break;
                    }
                }


                for (int i = 1; i < len1; i++)
                {
                    if (str1[len1 - i] != str2[len2 - i])
                    {
                        first = i;
                        break;
                    }
                }

                if (first == second)
                {
                    return 1;
                }
            }
            

            else if (len1 - len2 == 0)
                //Replace algorithm
            {
                
                for (int i = 0; i < len2; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        diffIndex++; // When the length of two strings are the same, we count how many chars are different and return it.
                    }
                }
                return diffIndex;
                
            }

            else {
                //Algorithm to count how many missing chars are there between two strings.
                
                for (int i = 0; i < len2; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        first = i; // First point where the char is different between two strings.
                        break; 
                    }
                }

                
                for (int i = 1; i < len1; i++)
                {
                    if (str1[len1 - i] != str2[len2 - i])
                    {
                        second = i; // Second point where the char is different between two strings.
                        break;
                    }
                }

                return second - first; //return the difference between first point and second point.
            }

            return 0;
        }
        /*Self reflection (time taken, learning, and recommendations)	
The time taken were about 8 + alpha hour.
This was a very difficult task. And I could not execute all the deliverables.
I learned that there are so many ways a sequence of remove, add and replace can make.
This was a very difficult task for me.
I learned that my algorithm failed because of index out of bounds error.
I emptied adding algorithm because of error.

Recommendation is to make a sufficiently challenging task because I felt like this task was a huge leap from the previous 5 tasks. 
*/

        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Question 1");
            PrintTriangle(5);
            PrintTriangle(7);

            //Question 2
            Console.WriteLine("Question 2");
            PrintSeriesSum(5);

            //Question 3
            Console.WriteLine("Question 3");
            int[] sample = { 1, 2, 2, 6 };
            int[] sample2 = { 3, 3, 2, 1 };
            int[] sample3 = { 4, 5, 2, 3 };
            int[] sample4 = { 1, 1, 1, 1 };
            Console.WriteLine(MonotonicCheck(sample));
            Console.WriteLine(MonotonicCheck(sample2));
            Console.WriteLine(MonotonicCheck(sample3));
            Console.WriteLine(MonotonicCheck(sample4));
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] sample1Test4 = { 3,1,4,1,5 };
            int[] sample2Test4 = { 1,2,3,4,5 };
            int[] sample3Test4 = { 1,3,1,5,4 };

            Console.WriteLine(DiffPairs(sample1Test4, 2));
            Console.WriteLine(DiffPairs(sample2Test4, 1));
            Console.WriteLine(DiffPairs(sample3Test4, 0));
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            Console.WriteLine(BullsKeyboard("abcdefghijklmnopqrstuvwxyz", "dis"));
            Console.WriteLine(BullsKeyboard("hijklmnopqrstuvwxyzabcdefg", "gobulls"));
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            Console.WriteLine(StringEdit("goulls", "gobulls"));
            Console.WriteLine(StringEdit("robky", "rocky"));
            Console.WriteLine(StringEdit("sunday", "saturday"));
            Console.WriteLine();


        }
    }




}
