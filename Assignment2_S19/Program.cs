﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment2_S19
{
    class Program
    {
        static void Main(string[] args)
        {
            //left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            //Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));

            //Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));
            Console.ReadKey();

            //Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };
            int[] brr = { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);
            Console.ReadKey();

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3 };
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 1800;
            Console.WriteLine(dayOfProgrammer(year));
            Console.ReadKey();
        }

        static void displayArray(int[] arr)
        {
            Console.WriteLine();
            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }
        }

        // Changes made by Prachi Gupta
        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {
            var ret = new int[a.Length];
            try
            {
                if (d >= 0)
                {
                    int length = a.Length;
                    d %= a.Length;

                    for (int i = 0; i < a.Length; ++i)
                    {
                        ret[i] = a[(i + d) % a.Length];
                    }
                }
                else
                {
                    Console.WriteLine("the number of rotations input is negative, hence the array will remain same");
                    return a;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e);
            }

            return ret;
        }

        // Changes made by Prachi Gupta
        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
           int count = 0;
            try
            {
                int n = prices.Length;
                prices = ArraySort(prices);

                int j = 0;

                for (int i = 0; i < n; i++)
                {
                    if (j + prices[i] < k)
                    {
                        count++;
                        j = j + prices[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e);
            }
            return count;
        }

        // Changes made by Arundhati Patil
        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            int[] newarr = new int[arr.Count];
            arr.CopyTo(newarr);
            int leftsum = 0;
            int totalsum = 0;
            bool flag = false;

            for (int i = 0; i < newarr.Length; i++)
            {
                totalsum += newarr[i];
            }
            for (int i = 0; i < newarr.Length; i++)
            {

                totalsum -= arr[i];
                if (leftsum == totalsum)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
                leftsum += arr[i];

            }
            if (flag == true)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }

        // Changes made by Arundhati Patil
        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            int maxbrr = brr.Max();
            int minbrr = brr.Min();
            Dictionary<int, int> arrnew = arr.GroupBy(x => x).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Count());
            Dictionary<int, int> brrnew = brr.GroupBy(x => x).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Count());
            ArrayList missingarr = new ArrayList();

            foreach (var y in brrnew)
            {
                if (arrnew.TryGetValue(y.Key, out int value))
                {
                    if (value != y.Value)
                    {
                        missingarr.Add(y.Key);
                    }
                }
                else
                {
                    missingarr.Add(y.Key);
                }
            }
            return missingarr.OfType<int>().ToArray();

        }

        // Changes made by Sudesh V Khillare
        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            int size = grades.Length;
            int[] score = new int[size];
            int i, temp, mul, diff;

            for (i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 0)
                {
                    Console.WriteLine("Enter Valid Marks");
                    break;
                }
                temp = grades[i];
                if (grades[i] > 37)
                {
                    mul = temp / 5;
                    diff = (mul + 1) * 5 - temp;
                    if (diff < 3)
                    {
                        temp = (mul + 1) * 5;

                    }
                }
                score[i] = temp;
            }

            return score;

        }
        // Changes made by Sudesh V Khillare
        // Complete the findMedian function below.
        static int findMedian(int[] arr)
        {
            int i, j, median, div;
            int temp = 0;

            for (i = 0; i < arr.Length; i++)
            {
                for (j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            /*
            // To verify if array is sorted properly
            for (i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
                Console.ReadKey(); */

            if (arr.Length % 2 == 0)
            {
                div = arr.Length / 2;
                median = (arr[div] + arr[div + 1]) / 2;
            }
            else
            {
                div = arr.Length / 2;
                median = arr[div];
            }
            return median;
        }

        // Changes made by Prachi Gupta
        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            List<int> lst = new List<int> { };
            try
            {
                arr = ArraySort(arr);
                int temp = 0;
                int diff = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    int first = arr[i];

                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        int second = arr[j];
                        diff = second - first;

                        if (i == 0 && j == 1)
                        {
                            temp = diff;
                        }

                        if (diff == temp)
                        {
                            lst.Add(arr[i]);
                            //lst.ForEach(Console.WriteLine);
                            lst.Add(arr[j]);
                        }

                        if (diff < temp)
                        {
                            lst.Clear();
                            temp = diff;
                            lst.Add(arr[i]);
                            lst.Add(arr[j]);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e);
            }
            return lst.ToArray();
        }

        // Changes made by Sudesh V Khillare
        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            string date = "";
            int flag=0;
            if (year<1700 && year>2700)
            {
                Console.WriteLine("Please enter valid year");
            }
            else
            {
                if (year > 1699 & year < 1918)
                {
                    if (year % 4 == 0)
                        flag = 1;
                }
                else if (year > 1918 && year < 2701)
                {
                    if (year % 400 == 0)
                    {
                        flag = 1;
                    }
                    if (year % 4 == 0)
                    {
                        if (year % 100 != 0)
                        {
                            flag = 1;
                        }
                    }
                }
                else
                    flag = 2;

                switch (flag)
                {
                    case 0:
                        date = "13.09."+ year.ToString();
                        break;

                    case 1:
                        date = "12.09."+year.ToString();
                        break;

                    case 2:
                        date = "26.09."+ year.ToString();
                        break;
                }

                
            }
            return date;

        }

        // Changes made by Prachi Gupta
        static int[] ArraySort(int[] arr)
        {
            try
            {
                int temp;

                // traverse 0 to array length 
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    // traverse i+1 to array length 
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        // compare array element with  
                        // all next element 
                        if (arr[j] < arr[i])
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e);
            }
            return arr;
        }
    }
}
