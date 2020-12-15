using System;
using System.Collections.Generic;
using System.Text;

namespace BasgruppsInlamning
{
    class BaseGroup
    {
        private static List<Human> groupList = new List<Human>();
        private bool keepGoing;
        private bool runProgram;
        private string passWord = "Götebuggarna";   //I´m not using "Trim" or "ToLower"-method cause a password is and should be unique. 
        private int loggInTries = 2;
        private bool correctPassword;
        private bool choiceInBool;
        private string userAnswer;

       
        public void Start()
        {
            runProgram = true;
            AddMembersToList();

            if (IsPassWordCorrect())
            {
                do
                {

                    Console.WriteLine("\n-----Meny-----");
                    Console.WriteLine("1. Visa medlemmar");
                    Console.WriteLine("2. Lär känna en medlem");
                    Console.WriteLine("3. Lägg till en medlem");
                    Console.WriteLine("4. Ta bort en medlem");
                    Console.WriteLine("5. Ändra intressen");
                    Console.WriteLine("6. Avsluta");

                    choiceInBool = int.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
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
                            Console.Clear();
                            runProgram = IsGoodBye();       //Change the variabel runProgram to false to end the loop. 
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Felaktig input.");
                            break;
                    }

                } while (runProgram);
            }

        }

        private bool IsPassWordCorrect()
        {


            Console.WriteLine("Välkommen till programmet Basgruppsinformation");
            do
            {
                Console.WriteLine("Var god skriv in ditt lösenord");
                userAnswer = Console.ReadLine();
                if (userAnswer == passWord)
                {
                    correctPassword = true;
                    loggInTries = -1;               // When password is correct the variabel change to -1 to end the loop. 
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


        private void AddMembersToList()   

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

        private void ShowOnlyNames()        //for information about choice of loop, please read the report. 
        {
            for (int i = 0; i < groupList.Count - 1; i++)
            {
                Console.Write(groupList[i].Name + ",");
            }
            int lastIndex = groupList.Count - 1;
            Console.WriteLine(groupList[lastIndex].Name);
        }

        private void ShowingNamesWithNr()

        {
            int counter = 0;
            foreach (Human members in groupList)
            {
                Console.WriteLine($"{++counter}. {members.Name}");

            }
        }

        private void InformationOfMember()
        {
            keepGoing = true;
            Console.WriteLine("\nVem är du intresserad av att lära känna mer?\n");
            ShowingNamesWithNr();
            do
            {
                choiceInBool = int.TryParse(Console.ReadLine(), out int choice);
                if (choiceInBool && choice <= groupList.Count && choice > 0)
                {
                    Console.WriteLine($"du valde {groupList[choice - 1].Name}");
                    Console.WriteLine("\n");
                    groupList[choice - 1].Describe();
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine("Var god mata in en siffa som syns i listan");
                }

            } while (keepGoing);
        }


        private void AddMember()
        {

            Console.WriteLine("\nFyll i nedanstående information kring personen du önskar lägga till");
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Ålder: ");
            bool ageInBool = int.TryParse(Console.ReadLine(), out int age);
            Console.Write("Födelsedag: ");
            string birthday = Console.ReadLine();
            Console.Write("Favoritmat: ");
            string favouriteFood = Console.ReadLine();
            Console.Write("Favoritband: ");
            string favouriteBand = Console.ReadLine();
            Console.Write("Favoritfilm: ");
            string favouriteMovie = Console.ReadLine();
            Console.Write("Älskar: ");
            string loves = Console.ReadLine();
            Console.Write("Hatar: ");
            string hates = Console.ReadLine();
            Console.Write("Stjärntecken: ");
            string zodiac = Console.ReadLine();
            Console.Write("Superkraft: ");
            string superPower = Console.ReadLine();
            Console.Write("Varför vill du programmera:");
            string reasonToPrograming = Console.ReadLine();

            groupList.Add(new Human(name, age, birthday, favouriteFood, favouriteBand, favouriteMovie, loves, hates, zodiac, superPower, reasonToPrograming));
        }
        private void DeleteMember()
        {
            keepGoing = true;
            Console.WriteLine("\nVem har slutat i klassen och bör såldes tas bort?\nHar du ångrat dig och vill gå tillbaka så mata in \"-1\"\n");
            ShowingNamesWithNr();
            do
            {
                choiceInBool = int.TryParse(Console.ReadLine(), out int choice);
                if (choiceInBool && choice <= groupList.Count && choice > 0)
                {
                    Console.WriteLine($" Är du säker på att du vill ta bort {groupList[choice - 1].Name}? ja/nej + enter");
                    userAnswer = Console.ReadLine();
                    if (userAnswer.Trim().ToLower() == "ja")
                    {
                        Console.WriteLine($"{groupList[choice - 1].Name} är nu borttagen");
                        groupList.RemoveAt(choice - 1);
                        keepGoing = false;
                    }
                    else
                    {
                        Console.WriteLine($"{groupList[choice - 1].Name} är fortsatt delaktig i gruppen :)");
                        break;
                    }

                }
                else if (choice == -1)
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Var god mata in siffan som motsvarar personen du vill ta bort eller \"-1\" om du ångrat dig");

                }
            } while (keepGoing);
        }

        private void ChangeInformation()
        {
            keepGoing = true;

            Console.WriteLine("\nVem vill du ändra information kring?\nHar du ångrat dig och vill gå tillbaka så mata in \"-1\"\n");
            ShowingNamesWithNr();
            do
            {
                choiceInBool = int.TryParse(Console.ReadLine(), out int choice);
                if (choiceInBool && choice <= groupList.Count && choice > 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Du valde {groupList[choice - 1].Name}");
                    Console.WriteLine("Vad önskar du ändra?\nTryck enter om du inte önskar ändra något\n");
                    groupList[choice - 1].Change();
                    bool decisionInBool = int.TryParse(Console.ReadLine(), out int decision);
                    switch (decision)
                    {
                        case 1:
                            Console.Write("Skriv in personens nya namn:  ");
                            groupList[choice - 1].Name = Console.ReadLine();
                            Console.WriteLine($"Personens nya namn: {groupList[choice - 1].Name} ");
                            break;
                        case 2:
                            Console.Write("Skriv in den nya ålderna: ");
                            groupList[choice - 1].Age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"{groupList[choice - 1].Name} är nu {groupList[choice - 1].Age} år ");
                            break;
                        case 3:
                            Console.Write("Skriv in den nya födelsedagen ");
                            groupList[choice - 1].Birthday = Console.ReadLine();
                            Console.WriteLine($"{groupList[choice - 1].Name} föddes: {groupList[choice - 1].Birthday} ");
                            break;
                        case 4:
                            Console.Write("Skriv in den nya favoritmaten: ");
                            groupList[choice - 1].FavouriteFood = Console.ReadLine();
                            Console.WriteLine($"{groupList[choice - 1].Name} tycker nu att {groupList[choice - 1].FavouriteFood} är den bästa maten");
                            break;
                        case 5:
                            Console.Write("Skriv in de nya favoritbandet alternativt den nya artisten: ");
                            groupList[choice - 1].FavouriteBand = Console.ReadLine();
                            Console.WriteLine($"{groupList[choice - 1].Name} anser att {groupList[choice - 1].FavouriteBand} är det bästa bandet/artisten");
                            break;
                        case 6:
                            Console.Write("Skriv in den nya favoritfilmen: ");
                            groupList[choice - 1].FavouriteMovie = Console.ReadLine();
                            Console.WriteLine($"{groupList[choice - 1].Name} hävdar numera att {groupList[choice - 1].FavouriteMovie} är den nr 1 movie in the world ");
                            break;
                        case 7:
                            Console.Write("Skriv in vad personen älskar: ");
                            groupList[choice - 1].Loves = Console.ReadLine();
                            Console.WriteLine($"{groupList[choice - 1].Name} älskar numera: {groupList[choice - 1].Loves}");
                            break;
                        case 8:
                            Console.Write("Skriv in vad personen hatar: ");
                            groupList[choice - 1].Hates = Console.ReadLine();
                            Console.WriteLine($"{groupList[choice - 1].Name} hatar numera: {groupList[choice - 1].Hates}");
                            break;
                        case 9:
                            Console.Write("Skriv in personens stjärntecken: ");
                            groupList[choice - 1].Zodiac = Console.ReadLine();
                            Console.WriteLine($"{ groupList[choice - 1].Name} är nu av stjärntecknet {groupList[choice - 1].Zodiac}");
                            break;
                        case 10:
                            Console.Write("Skriv in personens nya superkraft: ");
                            groupList[choice - 1].SuperPower = Console.ReadLine();
                            Console.WriteLine($"{ groupList[choice - 1].Name} har nu antagit superkraften:  {groupList[choice - 1].SuperPower}");
                            break;

                        default:
                            Console.WriteLine("Du ändrade inget");
                            break;
                    }
                    keepGoing = false;
                }
                else if (choice == -1)
                {
                    break;
                }
                else if (choice == 0 || choice > groupList.Count)
                {
                    Console.WriteLine("Var god mata in siffan som motsvarar personen du vill ändra uppgifter kring\"-1\" om du ångrat dig");

                }

            } while (keepGoing);
        }

        private bool IsGoodBye()
        {
            Console.WriteLine("På återseende!");
            return keepGoing = false;
        }
    }
}
