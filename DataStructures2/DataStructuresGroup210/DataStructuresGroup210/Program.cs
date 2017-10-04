using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresGroup210
{
    class Program
    {
        static void Main(string[] args)
        {

            // variable input used to track user menu item selection
            int input = 0;
            //menu tracks which menu was selected
            int menu = 0;
            //menuText is used to set the current menu name selected
            string menutext = " ";
            //Tracks valid input
            bool invalidInput = true;
            //creates data stuctures to be used in program
            Stack<string> myStack = new Stack<string>();
            Queue<string> myQueue = new Queue<string>();
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            //string used to handle a string temporarily
            string myString;
            //tracks whether user should be returned to top menu
            bool Restart = false;
            //used to hold size of data structure
            int size;
            //used to hold currentValue of data structure to move it between inputs, structures
            string currentValue;


            //starts menu, in a do while as it will always show once, menu will be repeated if user does not choose to exit.
            do
            {
                invalidInput = true;
                while (invalidInput)
                {
                    //original menu
                    Console.WriteLine("1. Stack\n" +
                                        "2. Queue\n" +
                                        "3. Dictionary\n" +
                                        "4. Exit\n");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        input = 0;

                    }

                    switch (input)
                    {
                        case 1:
                            menu = 1;
                            menutext = "Stack";
                            invalidInput = false;

                            break;
                        case 2:
                            menu = 2;
                            menutext = "Queue";
                            invalidInput = false;
                            break;
                        case 3:
                            menu = 3;
                            menutext = "Dictionary";
                            invalidInput = false;
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nWrong Input Try Again\n");
                            break;
                    }
                }
                invalidInput = true;
                while (invalidInput)
                {
                    Console.WriteLine("\n1.Add one item to " + menutext +
                        "\n2.Add Huge List of Items to " + menutext +
                        "\n3.Display " + menutext +
                        "\n4.Delete from " + menutext +
                        "\n5.Clear " + menutext +
                        "\n6.Search " + menutext +
                        "\n7.Return to Main Menu\n");

                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        input = 0;
                        Console.WriteLine("\nPlease Enter a Valid Menu Option\n");
                    }
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("\nPlease Enter a String\n");
                            myString = Console.ReadLine();
                            if (menu == 1)
                            {
                                myStack.Push(myString);
                            }
                            else if (menu == 2)
                            {
                                myQueue.Enqueue(myString);
                            }
                            else
                            {
                                myDictionary.Add(myString, 1);
                            }
                            break;

                        case 2:
                            if (menu == 1)
                            {
                                myStack.Clear();
                                for (int i = 0; i < 2000; i++)
                                {
                                    myStack.Push("New Entry " + (i + 1));
                                }
                            }
                            else if (menu == 2)
                            {
                                myQueue.Clear();
                                for (int i = 0; i < 2000; i++)
                                {
                                    myQueue.Enqueue("New Entry " + (i + 1));
                                }
                            }
                            else
                            {
                                myDictionary.Clear();
                                for (int i = 0; i < 2000; i++)
                                {
                                    myDictionary.Add("New Entry " + (i + 1), (i + 1));
                                }
                            }
                            break;

                        case 3:
                            if (menu == 1)
                            {
                                foreach (string currentString in myStack)
                                {
                                    Console.WriteLine(currentString);

                                }
                            }
                            else if (menu == 2)
                            {
                                foreach (string currentString in myQueue)
                                {
                                    Console.WriteLine(currentString);
                                }
                            }
                            else
                            {
                                foreach (KeyValuePair<string, int> currentEntry in myDictionary)
                                {
                                    Console.WriteLine(currentEntry.Key + " " + currentEntry.Value);
                                }
                            }
                            break;

                        case 4:
                            Console.WriteLine("\nWhat do you want to delete?\n");
                            myString = Console.ReadLine();


                            if (menu == 1 && myStack.Contains(myString))
                            {

                                Stack<string> tempStack = new Stack<string>();
                                size = myStack.Count();
                                //foreach(string currentValue in myStack){
                                for (int j = 0; j < size; j++)
                                {
                                    currentValue = myStack.Peek();
                                    if (currentValue == myString)
                                    {
                                        myStack.Pop();
                                    }
                                    else
                                    {
                                        tempStack.Push(myStack.Pop());
                                    }

                                }
                                //foreach(string currentValue in tempStack)
                                size = tempStack.Count();
                                for (int j = 0; j < size; j++)
                                {
                                    myStack.Push(tempStack.Pop());
                                }


                            }
                            else if (menu == 2 && myQueue.Contains(myString))
                            {
                                Queue<string> tempQueue = new Queue<string>();
                                // foreach (string currentValue in myQueue)
                                size = myQueue.Count();

                                for (int j = 0; j < size; j++)
                                {
                                    currentValue = myQueue.Peek();
                                    if (currentValue == myString)
                                    {
                                        myQueue.Dequeue();
                                    }
                                    else
                                    {
                                        tempQueue.Enqueue(myQueue.Dequeue());
                                    }

                                }
                                myQueue = tempQueue;
                            }
                            else if (menu == 3 && myDictionary.ContainsKey(myString))
                            {
                                myDictionary.Remove(myString);
                            }
                            else
                            {
                                Console.WriteLine("\nThat string does not exist");
                            }
                            break;
                            
                        case 5:
                            if (menu == 1)
                            {
                                myStack.Clear();
                            }
                            else if (menu == 2)
                            {
                                myQueue.Clear();
                            }
                            else
                            {
                                myDictionary.Clear();
                            }
                            break;

                        case 6:
                            Console.WriteLine("\nWhat do you want search for:\n");
                            myString = Console.ReadLine();
                            bool found = false;
                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                            sw.Restart();
                            if (menu == 1)
                            {
                                //searching through the stack
                                found = myStack.Contains(myString);
                            }
                            else if (menu == 2)
                            {
                                found = myQueue.Contains(myString);
                            }
                            else
                            {
                                found = myDictionary.ContainsKey(myString);

                            }
                            sw.Stop();
                            if (found)
                            {
                                Console.WriteLine("\nYour Item Was Found");
                            }
                            else
                            {
                                Console.WriteLine("\nYour Item Was Not Found");
                            }

                            Console.WriteLine("The Search Took " + sw.Elapsed + "\n");
                            break;

                        case 7:
                            Restart = true;
                            invalidInput = false;
                            break;
                        default:
                            Console.WriteLine("\nWrong Input Try Again\n");
                            break;
                    }
                    Restart = true;
                }
            } while (Restart);
            Console.ReadLine();
        }
    }
}
