using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Get user input
        Console.Write("Enter the count of numbers: ");
        int count = int.Parse(Console.ReadLine());

        int[] numbers = new int[count];
        Console.WriteLine("Enter the numbers:");
        for (int i = 0; i < count; i++)
        {
            Console.Write("Number " + (i + 1) + ": ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the target number: ");
        int targetNumber = int.Parse(Console.ReadLine());

        // Solve using DFS
        Console.WriteLine("Depth-First Search:");
        Stopwatch dfsStopwatch = new Stopwatch();
        dfsStopwatch.Start();
        bool dfsFound = DepthFirstSearch(numbers, targetNumber);
        dfsStopwatch.Stop();
        Console.WriteLine("Execution Time (DFS): " + dfsStopwatch.Elapsed.TotalMilliseconds + " ms");

        Console.WriteLine();

        // Solve using BFS
        Console.WriteLine("Breadth-First Search:");
        Stopwatch bfsStopwatch = new Stopwatch();
        bfsStopwatch.Start();
        bool bfsFound = BreadthFirstSearch(numbers, targetNumber);
        bfsStopwatch.Stop();
        Console.WriteLine("Execution Time (BFS): " + bfsStopwatch.Elapsed.TotalMilliseconds + " ms");

        Console.ReadLine();
    }

    static bool DepthFirstSearch(int[] numbers, int targetNumber)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(0);

        while (stack.Count > 0)
        {
            int currentIndex = stack.Pop();
            int currentNumber = numbers[currentIndex];
            Console.WriteLine("Current Number: " + currentNumber);

            if (currentNumber == targetNumber)
                return true;

            if (currentIndex + 1 < numbers.Length)
                stack.Push(currentIndex + 1);
            if (currentIndex + 2 < numbers.Length)
                stack.Push(currentIndex + 2);
        }

        return false;
    }

    static bool BreadthFirstSearch(int[] numbers, int targetNumber)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Count > 0)
        {
            int currentIndex = queue.Dequeue();
            int currentNumber = numbers[currentIndex];
            Console.WriteLine("Current Number: " + currentNumber);

            if (currentNumber == targetNumber)
                return true;

            if (currentIndex + 1 < numbers.Length)
                queue.Enqueue(currentIndex + 1);
            if (currentIndex + 2 < numbers.Length)
                queue.Enqueue(currentIndex + 2);
        }

        return false;
    }
}
