using System;  //using missing 
using System.Collections.Generic; //missing semicolon
using System.Threading;

namespace ProblematicProblem //namespace missing
{
    class Program //class should be class name
    {
        
        static bool cont = true;
        static bool seeList = true;
        static bool addToList = true;
        
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" }; //missing simi-colon at end of scope
        static void Main(string[] args)
        {
            Random rng = new Random();                                      
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");                                                                                                                   //bool cont;// = bool.Parse(Console.ReadLine());
            string userInput = Console.ReadLine().ToLower();
            cont = GetUserInPut(userInput);
            if (cont == true) // continues program only if user response = yes
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge = int.Parse(Console.ReadLine()); //added parse for numeric input
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                userInput = Console.ReadLine().ToLower();
                seeList = GetUserInPut(userInput);// set seeList value to response using GetUserInput method
                Console.WriteLine();
                if (seeList == true)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                }//end if
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine().ToLower();
                                
                addToList = GetUserInPut(userInput);
                Console.WriteLine();      
                while (addToList == true)
                {
                   Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities) 
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine("Would you like to add more? yes/no: ");
                   //repromt for response 
                    userInput = Console.ReadLine().ToLower();
                    addToList = GetUserInPut(userInput);
                    Console.WriteLine();
                }//end while

                do
                {
                    Console.WriteLine();
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine(); //missing semicolon
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine(); //missing semicolon
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber]; //missing semicolon
                    if (userAge < 21 && randomActivity == "Wine Tasting") // change > to <  
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}"); //missing semicolon
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count); //value already declared as int
                        randomActivity = activities[randomNumber]; //value already declared as string
                    }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: "); //missing simi-colon -switch userName place with randomActivity
                    Console.WriteLine();// missing period
                    userInput = " ";
                    userInput = Console.ReadLine().ToLower();
                    cont = GetUserInPut(userInput);
                    // cont = bool.Parse(Console.ReadLine()); //cont already declared as type bool - omit 
                }while (cont != true);
                Console.WriteLine("\nThank you for stopping by!!");
            }
            else
                Console.WriteLine("Thank you for stopping by!!");
        }
        public static bool GetUserInPut(string userInput)
    {

            bool userResponse = true;
        switch (userInput)
        {                        
            case "yes":
                    userResponse = true;
                    break;
                 
                case "y":
                    userResponse = true;
                    break;
                case "sure":
                    userResponse = true;
                    break;
               case "redo":
                    userResponse = false;
                    break;
                case "no":
                    userResponse = false;
                    break;
                case "n":
                    userResponse = false;
                    break;
                case "no thanks":
                    userResponse = false;
                    break;
                case "keep":
                    userResponse = true;
                    break;
                default:
                Console.WriteLine("You have not entered a valid response. Response defaulted to NO!");
                    userResponse = false;
                break;
                 
        }// end switch
            return userResponse;
    }//end of method
    
    }     
    
}
