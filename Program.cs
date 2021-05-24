using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace _313_Assignment_2 {
    class Program {
        StringBuilder logString = new StringBuilder();

        static void Main(string[] args) {
            FiniteStateTable numberStateTable = new FiniteStateTable(0, 3, 3);
            FiniteStateTable letterStateTable = new FiniteStateTable(1, 2, 2);

            // Setup the table requirements
            numberStateTable.FillCell(0, 0, 1, new List<Action>() {
                () => Console.WriteLine("Action X"),
                () => Console.WriteLine("Action Y")
            });

            numberStateTable.FillCell(1, 0, 0, new List<Action>() {
                () => Console.WriteLine("Action W")
            });

            numberStateTable.FillCell(1, 1, 2, new List<Action>() {
                () => Console.WriteLine("Action X"),
                () => Console.WriteLine("Action Z")
            });


            numberStateTable.FillCell(2, 2, 1, new List<Action>() {
                () => Console.WriteLine("Action X"),
                () => Console.WriteLine("Action Y")
            });

            numberStateTable.FillCell(2, 0, 0, new List<Action>() {
                () => Console.WriteLine("Action W")
            });

            letterStateTable.FillCell(1, 0, 0, new List<Action>() {
                () => new Thread(() => Console.WriteLine("Action J")).Start(),
                () => new Thread(() => Console.WriteLine("Action K")).Start(),
                () => new Thread(() => Console.WriteLine("Action L")).Start()
            });

            string userInput = null;

            // Key indexes of the table to the representative strings
            string[] events = {"a", "b", "c"}; 
            string[] states = {"S0", "S1", "S2"};

            while (userInput != "q") {
                LogAndPrint($"The current state is: {states[numberStateTable.getCurrentState()]}");
                Console.WriteLine("Enter a event");
                userInput = Console.ReadLine().ToLower();
                if (events.Contains(userInput)) {
                    int eventIndex = Array.IndexOf(events, userInput);
                    int previousState = numberStateTable.getCurrentState();
                    if (numberStateTable.ExecuteEvent(eventIndex)) {
                        Console.WriteLine("State changed from " + states[previousState] + " to " + states[numberStateTable.getCurrentState()]);
                        if (previousState == 0) {
                            letterStateTable.ExecuteEvent(0);
                        }
                    } else {
                        Console.WriteLine("That is not a valid action type for the current state");
                    }
                } else {
                    Console.WriteLine("That is not a valid action input - try again");
                }
            }

        }

        static void LogAndPrint(String str) {
            Console.WriteLine(str);
            Log(str);
        }

        static void Log(String str) {
            Console.WriteLine($"[{DateTime.Now}] {str} \n");
        }

    }
}
