// C# Program to print the given pattern
using System;
using System.Collections.Generic;

class GFG
{

    // Function to return the reversed queue
    static Queue<int> reverse(Queue<int> q)
    {
        // Size of queue
        int s = q.Count;

        // Second queue
        Queue<int> ans = new Queue<int>();

        for (int i = 0; i < s; i++)
        {
            

            // Get the last element to the
            // front of queue
            for (int j = 0; j < q.Count - 1; j++)
            {
                int x = q.Peek();
                q.Dequeue();
                q.Enqueue(x);
            }

            // Get the last element and
            // add it to the new queue
            ans.Enqueue(q.Peek());
            q.Dequeue();
        }
        return ans;
    }

    // Driver Code
    public static void Main(String[] args)
    {
        Queue<int> q = new Queue<int>();

        // Insert elements
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);
        q.Enqueue(5);

        q = reverse(q);

        // Print the queue
        while (q.Count != 0)
        {
            Console.Write(q.Dequeue() + " ");
            //q.Dequeue();
        }
    }
}

// This code is contributed by Princi Singh
