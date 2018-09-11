using System;

namespace CustomListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> listOne = new CustomList<string> { "This", "add", "operator", "is", "working!" };
            CustomList<string> listTwo = new CustomList<string> { "add" };
            CustomList<string> actual = new CustomList<string>();
            actual = listOne - listTwo;
            Console.WriteLine(actual);
            Console.ReadLine();

        }
    }
}
