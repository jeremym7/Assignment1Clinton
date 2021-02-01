using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //#1
            try
            {
                //declare variables
                int total, a, b;
                //hane user input number
                Console.WriteLine("#1) Enter the number of rows for the triangle: ");
                total = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
                //Nested for loop to generate the layers of the pyramid
                for (int i = 1; i <= total; i++) // Total number of layer for pramid  
                {
                    for (b = 1; b <= (total - i); b++) // Space  
                        Console.Write(" ");
                    for (a = 1; a <= i; a++) //increase value  
                        Console.Write('*');
                    for (a = (i - 1); a >= 1; a--) //decrease value  
                        Console.Write('*');
                    Console.WriteLine();
                }
            }
            //Catch to get any errors
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.Message);
            }


            //#2
            try
            {
                //Making a method to excute the number from user input to generate the pell series list
                static int pellSeries(int n)
                {
                    //declaring variables for use in the for loop
                    int firstNumber = 0, secondNumber = 1, result = 0;

                    if (n == 0) return 0;
                    if (n == 1) return 1;
                    //for loop to execute the mathematical expression and store the result
                    for (int i = 2; i <= n; i++)
                    {
                        result = 2 * secondNumber + firstNumber;
                        firstNumber = secondNumber;
                        secondNumber = result;

                    }

                    return result;
                }

                Console.WriteLine("#2) Enter the number of terms in the Pell Series");
                //Convert user input to an integer to get a stop in the list
                int length = Convert.ToInt32(Console.ReadLine());
                //For loop to determine how long the list should be 
                for (int i = 0; i < length; i++)
                {
                    Console.Write("{0} ", pellSeries(i));
                }

                Console.WriteLine("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.Message);
            }


            //#3
            try
            {
                Console.WriteLine("#3) Enter the number to check if squareSums exist:");
                //converting user input to an integer to use in the method
                int c = Convert.ToInt32(Console.ReadLine());
                //method to check if square sum exist. Want a boolean response
                static bool JudgeSquareSum(int c)
                {
                    //For loop to do sum of square calculaions
                    for (var a = 0; a * a <= c / 2; a++)
                    {
                        var b1 = a;
                        var b2 = c - a * a;
                        while (b1 < b2)
                        {
                            var b = b1 + (b2 - b1) / 2;
                            if (a * a + (long)b * b < c)
                            {
                                b1 = b + 1;
                            }
                            else
                            {
                                b2 = b;
                            }
                        }
                        if (a * a + b1 * b1 == c)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                //storing the result from the method as a variable to display to the user
                var result = JudgeSquareSum(c);
                Console.WriteLine(result);
                Console.WriteLine("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.Message);
            }


            //#4
            try
            {
                //Gets user input and checks with the array for finding pairs
                Console.WriteLine("#4) Enter k");
                int k = Convert.ToInt32(Console.ReadLine());
                //generate array
                int[] arr = { 3, 1, 4, 5, 3 };
                //method to check for likewise pairs in array and given number
                static int FindPairs(int[] nums, int k)
                {
                    Array.Sort(nums);
                    int pair = 0, left = 0, right = left + 1;
                    while (left < nums.Length && right < nums.Length)
                    {
                        int diff = Math.Abs(nums[left] - nums[right]);

                        if (diff < k)
                            right++;
                        else if (diff > k)
                            left++;
                        else
                        {
                            pair++;
                            while (left + 1 < nums.Length && nums[left] == nums[left + 1])
                                left++;
                            left++;
                            while (right + 1 < nums.Length && nums[right] == nums[right + 1])
                                right++;
                            right++;
                        }

                        while (left >= right) right++;
                    }
                    return pair;
                }
                Console.WriteLine(FindPairs(arr, k));
                Console.WriteLine("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.Message);
            }



            //#5

            try
            {
                //generate list of emails to check for unique ones
                string[] emails = { "disemail+david@us.f.com" + "dis.e.mail+bob.cathy@usf.com" + "dis.email + bull@usf.com" };
                //method to check how many emails are unique
                static int NumUniqueEmails(string[] emails)
                {
                    //hashset to create unique unordered list
                    HashSet<string> emailList = new HashSet<string>();
                    //string builder to not have to create and store each unique string 
                    StringBuilder st = new StringBuilder();
                    bool afterAt = false;
                    bool ignoreUntilAt = false;

                    //for loop to check for unique emails by checking for symbols
                    for (int i = 0; i < emails.Length; i++)
                    {
                        afterAt = false;
                        ignoreUntilAt = false;
                        st.Length = 0;

                        for (int j = 0; j < emails[i].Length; j++)
                        {
                            switch (emails[i][j])
                            {
                                case '.': if (afterAt) { st.Append('.'); } break;
                                case '+': ignoreUntilAt = true; break;
                                case '@':
                                    afterAt = true;
                                    st.Append('@');
                                    break;
                                default:
                                    if (afterAt || !ignoreUntilAt) { st.Append(emails[i][j]); }
                                    break;
                            }
                        }
                        emailList.Add(st.ToString());
                    }

                    return emailList.Count;

                }
                Console.WriteLine("#5) There is/are " + NumUniqueEmails(emails) + " unique email(s)");

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.Message);
            }




            //#6
            try
            {
                //generate an empty list 
                List<string> paths = new List<string>();
                //Add the different locations
                paths.Add("London");
                paths.Add("New York");
                paths.Add("Tampa");
                paths.Add("Dehli");

                //Method to find destination city
                static string DestCity(IList<IList<string>> paths)
                {
                    ISet<string> fromSet = new HashSet<string>();
                    foreach (var p in paths)
                    {
                        fromSet.Add(p[0]);
                    }

                    foreach (var p in paths)
                    {
                        if (!fromSet.Contains(p[1]))
                        {
                            return p[1];
                        }
                    }

                    return "";
                }
                Console.WriteLine("#6) Having an error and can not display the destination city.");




            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured" + e.Message);
            }

        }

    }
}

