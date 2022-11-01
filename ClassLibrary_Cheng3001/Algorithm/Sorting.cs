using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_Cheng3001.Algorithm
{
    public class Sorting
    {
        #region global
        public static int i = 0; 
        public static int j = 0; 
        public static int k = 0;
        public static int temp = 0;
        public static int start = 0;
        public static int min_position;
        #endregion global

        public static void BubblieSort(int[] data)
        {
            for (i = 0; i < data.Length; i++) //Bubble sorting
            {
                for (j = 0; j < data.Length - 1; j++)
                {
                    while (data[j] > data[j + 1])
                    {
                        temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
                foreach (var item in data)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            } // end of outer loop
        } //BubbleSort

        public static void Cocktail(int[] data)
        {
            int end = data.Length;

            for (i = start; i < end - 1; i++) //sort
            {
                for (j = start; j < end - 1; j++) // 由小到大排序 
                {
                    while (data[j] > data[j + 1])
                    {
                        temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }

                end = end - 1;

                for (j = end; j > start; j--) // 從數列尾由大到小排序
                {
                    while (data[j] < data[j - 1])
                    {
                        temp = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = temp;
                    }
                }

                start = start + 1;

                Console.Write("第 {0} 回合排序\t", i + 1);
                foreach (var item in data)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            } // end of outer loop
        } //Cocktail

        public static void InsertionSort(int[] data)
        {
            for (i = 1; i < data.Length; i++)
            {
                temp = data[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (data[j] > temp)
                    {
                        data[j + 1] = data[j];
                        if (j == 0)
                            data[j] = temp;
                    }
                    else
                    {
                        data[j + 1] = temp;
                        break;
                    }
                } // inner loop
                Console.Write("第{0}回合排序: ", i);
                foreach (int var in data)
                    Console.Write(var.ToString().PadLeft(4));
                Console.WriteLine();
            }
        } //InsertionSort

        public static void SelectionSort(int[] data)
        {
            for (i = 0; i < data.Length - 1; i++)
            {
                min_position = i;
                for (j = i + 1; j < data.Length; j++)
                {
                    if (data[j] < data[min_position])  //如果發現[j]的數字比[min_position]的數字小，就將j取代min_position 
                        min_position = j;  //remember the position
                } // inner loop

                temp = data[i];
                data[i] = data[min_position];
                data[min_position] = temp;   // 25-27行即完成一回合的交換

                Console.Write($"第{i + 1}回合排序結果\t");

                for (j = 0; j < data.Length; j++)
                    Console.Write($"{data[j].ToString().PadLeft(4)}");
                Console.WriteLine("\n");
            } //outer loop
        }

    }
}
