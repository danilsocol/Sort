using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 3, 4, 2, 5, 7, 6 };
            FindTimeSort(list, SelectionSort);
            FindTimeSort(list, BubbleSort);
            FindTimeSort(list, InsertionSort);
        }

        static void Swap(List<int> list,int i,int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        static void FindTimeSort(List<int> list , Action<List<int>> f)
        {
            List<int> newList = new List<int>();
            newList.AddRange(list.ToArray());

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(newList);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(ts);
        }

        static void InsertionSort(List<int> list)
        {
            int x,j;
            for (int i = 1; i < list.Count; i++)
            {
                x = list[i];
                j = i;
                while (j > 0 && list[j - 1] > x)
                {
                    Swap(list, j, j - 1);
                    j -= 1;
                }
                list[j] = x;
            }

            Console.WriteLine();
        }

        static public void SelectionSort(List<int> list)
        {
            int min;

            for (int i = 0; i < list.Count - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(list, i, min);
                }
            }
            Console.WriteLine();
        }

        static void BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        Swap(list, i, j);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
