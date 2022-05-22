using System;
using System.Collections;

namespace RadixSort
{
/*    Сравнение производится поразрядно: сначала сравниваются значения одного крайнего разряда, и элементы группируются 
        по результатам этого сравнения, затем сравниваются значения следующего разряда, соседнего, 
        и элементы либо упорядочиваются по результатам сравнения значений этого разряда внутри образованных на предыдущем проходе групп, 
        либо переупорядочиваются в целом, но сохраняя относительный порядок, достигнутый при предыдущей сортировке.
        Затем аналогично делается для следующего разряда, и так до конца.*/
    class Program
    {
        //msd:
        public static void sorting(int[] arr, int range, int length)
        {
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();

            for (int step = 0; step < length; ++step)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; ++i)
                {
                    int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /
                                                  (int)Math.Pow(range, step);
                    lists[temp].Add(arr[i]);
                }
                //сборка
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[10];

            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(0, 100);
            }

            System.Console.WriteLine("The array before sorting:");
            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }

            sorting(arr, 10, 2);
            System.Console.WriteLine("\n\nThe array after sorting:");

            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }

            System.Console.WriteLine("\n\nPress the <Enter> key");
            System.Console.ReadLine();
        }
    }
}
