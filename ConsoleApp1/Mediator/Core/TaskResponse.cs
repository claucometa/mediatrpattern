using System;

namespace ConsoleApp1
{
    public class TaskResponse
    {
        public readonly string message;

        public TaskResponse(string message)
        {
            Console.WriteLine(message);
            this.message = message;
        }
    }
}