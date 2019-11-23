using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void BubbleSort1()
        {
            Console.WriteLine("Введите количество элементов массива для сортировки методом пузырька");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            int compareCounter = 0;
            int changeCounter = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 1000000);
                //Console.WriteLine($"{i}-й элемент исходного массива = {array[i]}");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    compareCounter++;
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                        changeCounter++;
                    }
                }
            }

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"\t{i}-й элемент отсортированного массива = {array[i]}");
            //}

            Console.WriteLine($"{compareCounter} сравнений");
            Console.WriteLine($"{changeCounter} перестановок");
        }

        static void BubbleSort2()
        {
            Console.WriteLine("Введите количество элементов массива для сортировки методом пузырька");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            int compareCounter = 0;
            int changeCounter = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 1000000);
                //Console.WriteLine($"{i}-й элемент исходного массива = {array[i]}");
            }

            for (int i = n - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    compareCounter++;
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        changeCounter++;
                    }
                }
            }

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"\t{i}-й элемент отсортированного массива = {array[i]}");
            //}

            Console.WriteLine($"{compareCounter} сравнений");
            Console.WriteLine($"{changeCounter} перестановок");
        }

        static void SelectionSort1()
        {
            Console.WriteLine("Введите количество элементов массива для сортировки методом выбора");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            int minIndex = 0;
            int compareCounter = 0;
            int changeCounter = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 1000000);
                //Console.WriteLine($"{i}-й элемент исходного массива = {array[i]}");
            }

            for (int i = 0; i < n - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    compareCounter++;
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;

                changeCounter++;
            }

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"\t{i}-й элемент отсортированного массива = {array[i]}");
            //}

            Console.WriteLine($"{compareCounter} сравнений");
            Console.WriteLine($"{changeCounter} перестановок");
        }

        // ???
        static void SelectionSort2()
        {
            Console.WriteLine("Введите количество элементов массива для сортировки методом выбора");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            int maxIndex = 0;
            int compareCounter = 0;
            int changeCounter = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 1000000);
                Console.WriteLine($"{i}-й элемент исходного массива = {array[i]}");
            }

            for (int i = n - 1; i >= 0; i--)
            {
                maxIndex = i;

                for (int j = 0; j < i - 1; j++)
                {
                    compareCounter++;
                    if (array[j] > array[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int temp = array[i];
                array[i] = array[maxIndex];
                array[maxIndex] = temp;

                changeCounter++;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\t{i}-й элемент отсортированного массива = {array[i]}");
            }

            Console.WriteLine($"{compareCounter} сравнений");
            Console.WriteLine($"{changeCounter} перестановок");
        }

        static void InsertionSort()
        {
            Console.WriteLine("Введите количество элементов массива для сортировки методом вставки");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            int maxIndex = 0;

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 1000000);
                Console.WriteLine($"{i}-й элемент исходного массива = {array[i]}");
            }

            int j;
            for (int i = 1; i < n; i++)
            {
                int temp = array[i];
                j = i;
                while (j > 0 && array[j - 1] >= temp)
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\t{i}-й элемент отсортированного массива = {array[i]}");
            }
        }


        static void Main(string[] args)
        {
            BubbleSort1();
            BubbleSort2();

            SelectionSort1();
            SelectionSort2();

            InsertionSort();

            Console.ReadLine();
        }
    }
}
