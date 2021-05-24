using System;
using System.Linq;
using System.Collections.Generic;
/*
namespace _313_Assignment_2 {
    class Program {
        static void Main(string[] args) {
            FiniteStateTable table = new FiniteStateTable(0, 3, 3);

            // Setup the table requirements
            table.FillCell(0, 0, 1, new List<Action>() {
                () => Console.WriteLine("Action X"),
                () => Console.WriteLine("Action Y")
            });

            table.FillCell(1, 0, 0, new List<Action>() {
                () => Console.WriteLine("Action W")
            });

            table.FillCell(1, 1, 2, new List<Action>() {
                () => Console.WriteLine("Action X"),
                () => Console.WriteLine("Action Z")
            });

            table.FillCell(2, 2, 1, new List<Action>() {
                () => Console.WriteLine("Action X"),
                () => Console.WriteLine("Action Y")
            });

            table.FillCell(2, 0, 0, new List<Action>() {
                () => Console.WriteLine("Action W")
            });
            

            string userInput = null;

            // Key indexes of the table to the representative strings
            string[] events = {"a", "b", "c"}; 
            string[] states = {"S0", "S1", "S2"};

            while (userInput != "q") {
                Console.WriteLine("The current state is: " + states[table.getCurrentState()]);
                Console.WriteLine("Enter a event");
                userInput = Console.ReadLine().ToLower();
                if (events.Contains(userInput)) {
                    int eventIndex = Array.IndexOf(events, userInput);
                    int previousState = table.getCurrentState();
                    if (table.ExecuteEvent(eventIndex)) {
                        Console.WriteLine("State changed from " + states[previousState] + " to " + states[table.getCurrentState()]);
                    } else {
                        Console.WriteLine("That is not a valid action type for the current state");
                    }
                } else {
                    Console.WriteLine("That is not a valid action input - try again");
                }
            }
        }
    }
}
*/