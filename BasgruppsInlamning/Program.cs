using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using Microsoft.VisualBasic.FileIO;

namespace BasgruppsInlamning
{
    class Program
    {
        public static List<Human> groupList = new List<Human>();
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            bool keepGoing = true;
            AddMembersToList();


            if (LoggIn())
            {
                do
                {

                    Console.WriteLine("\n-----Meny-----");
                    Console.WriteLine("1. Visa Medlemmar");
                    Console.WriteLine("2. Lära känna medlemmarna");
                    Console.WriteLine("3. Lägg till en medlem");
                    Console.WriteLine("4. Ta bort en medlem");
                    Console.WriteLine("5. Ändra intressen");
                    Console.WriteLine("6. Avsluta");

                    bool choiceInBool = int.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)        //TODO: Skapa metoder för samtliga alternativ. 
                    {
                        case 1:
                            Console.Clear();
                            ShowOnlyNames();
                            break;

                        case 2:
                            Console.Clear();
                            InformationOfMember();
                            break;

                        case 3:
                            Console.Clear();
                            AddMember();
                            break;

                        case 4:
                            Console.Clear();
                            DeleteMember();
                            break;
                          
                        case 5:
                            Console.Clear();
                            ChangeInformation();
                            break; 
                        case 6:
                            Console.WriteLine("På återseende!");
                            keepGoing = false;
                            break;

                        default:
                            Console.WriteLine("Felaktig input.");
                            break;
                    }

                } while (keepGoing);
            }

        }
   
        static bool LoggIn()
        {
            string passWord = "Götebuggarna";
            int loggInTries = 2;
            bool correctPassword = false;

            Console.WriteLine("Välkommen till programmet Basgruppsinformation");
            do
            {
                Console.WriteLine("Var god skriv in ditt lösenord");
                string userAnswer = Console.ReadLine();
                if (userAnswer == passWord)
                {
                    correctPassword = true;
                    loggInTries = -1;
                    Console.Clear();
                }
                else if (loggInTries > 0)
                {
                    Console.WriteLine($"Du har uppgivet ett felaktigt lösenord. {loggInTries} försök återstår");
                    loggInTries--;
                    correctPassword = false;
                }
                else
                {
                    Console.WriteLine("Du har uppgett fel lösenord för många gånger. Basgruppen \"Götebuggarna\" kommer nu hemsöka dig. Du är förvisad ifrån min konsol.");
                    correctPassword = false;
                    break;

                }
            } while (loggInTries >= 0);

            return correctPassword;
        }


        static void AddMembersToList()

        {

            groupList.Add(new Human("MA Lin", 29, "13 mars", "Råkaka", "Modest Mouse", "Snatch", "Höst/vinter", "Banan", "Mrs.Hindsight", "Fisk", "Skapande"));
            groupList.Add(new Human("Andrie", 26, "12 januari", "Carbonara", "Two Steps from Hell", "The Lord of the Rings", "Resa", "Oliver", "Instant olive detection", "Stenbock", "Problemlösning"));
            groupList.Add(new Human("Jesper", 28, "29 maj", "Lammracks", "Lars Winnerbäck", "Catch me if you can", "De enkla sakerna", "Folk som filmar på konserter", "Teleportering", "Tvilling", "Frihet"));
            groupList.Add(new Human("Leroy", 32, "22 oktober", "Pizza", "We the best music", "Matrix", "Choklad", "Kaviar", "Flyga", "Våg", "Dynamisk"));
            groupList.Add(new Human("Gurra M", 33, "17 november", "Tacos", "Berliner Philharmoniker", "Any Star Wars :) ", "J.S. Bach", "Schlager", "Tala med hundvalpar", "Skorpion", "Problemlösning"));
            groupList.Add(new Human("Jonna", 30, "5 februari", "Pizza", "Full of hell", "Interstellar", "Musik", "Kött", "Odödlig", "Vattumann", "Tjurskallig"));
            groupList.Add(new Human("Linus", 27, "17 juli", "Fisksoppa", "Jack Moy", "The secret life of Walter Mitty", "Banan", "Senap", "Andas under vatten", "Kräfta", "Få ett riktigt skoj jobb"));
            groupList.Add(new Human("Nils", 21, "15 mars", "Pannkakor", "Beach Boys", "American Psycho", "höst/vinter", "Snö", "Slask", "Fisk", "Roligt"));
            groupList.Add(new Human("Yulrok", 38, "23 april", "Musli", "Morcheeba", "The green book", "Ost", "Slöseri", "Tankeöverföring", "Oxen", "Biljett till \"digital nomad\" - livet"));

        }

        static void ShowOnlyNames()        //Var god se rapporten för val av Loop. 
        {
            for (int i = 0; i < groupList.Count - 1; i++)
            {
                Console.Write(groupList[i].Name + ",");
            }
            int lastIndex = groupList.Count - 1;
            Console.WriteLine(groupList[lastIndex].Name);
        }
    }
}
