using System;
using System.Collections.Generic;
using System.Text;

namespace BasgruppsInlamning
{
    class BaseGroupLogic
    {
        private static List<Human> groupList = new List<Human>();
        private bool keepGoing;
        private bool runProgram;
        private string passWord = "Götebuggarna";   //I´m not using "Trim" or "ToLower"-method cause a password is and should be unique. 
        private int loggInTries = 2;
        private bool correctPassword;
        private bool choiceInBool;
        private string userAnswer;
        private int choice;
        public int PersonIndex { get => choice - 1;}
        internal Human SelectedPerson { get => groupList[PersonIndex];}

        
        public void Run()
        {
            AddMembersToList();
            Menu();
        }


      
        public void Menu()
        {
            runProgram = true;

            if (IsPassWordCorrect())     //Menu is shown if user enter correct password
            {
                while (runProgram)
                {

                    Console.WriteLine("\n-----Meny-----");
                    Console.WriteLine("1. Visa medlemmar");
                    Console.WriteLine("2. Lär känna en medlem");
                    Console.WriteLine("3. Lägg till en medlem");
                    Console.WriteLine("4. Ta bort en medlem");
                    Console.WriteLine("5. Ändra intressen");
                    Console.WriteLine("6. Avsluta");

                    choiceInBool = int.TryParse(Console.ReadLine(), out choice);
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

                }
            }

        }

        // What user first meets when running the program. 
        private bool IsPassWordCorrect()
        {


            Console.WriteLine("Välkommen till programmet Basgruppsinformation");
            while (loggInTries >= 0)   
            {
                Console.WriteLine("Var god skriv in ditt lösenord");
                userAnswer = Console.ReadLine();
                if (userAnswer == passWord)
                {
                    correctPassword = true;
                    loggInTries = -1;               // When password is correct the variabel change to 0 to end the loop. The user have 3 attempts. 
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
            } 

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
                Console.Write(groupList[i] + ",");
            }
            int lastIndex = groupList.Count - 1;
            Console.WriteLine(groupList[lastIndex]);
        }

        private void ShowingNamesWithNr()

        {
            int counter = 0;
            foreach (Human person in groupList)
            {
                Console.WriteLine($"{++counter}. {person}");
            }
        }

        private void InformationOfMember()
        {
            keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("\nVem är du intresserad av att lära känna mer?\n");
                ShowingNamesWithNr();


                choiceInBool = int.TryParse(Console.ReadLine(), out choice);

                if (choiceInBool && choice <= groupList.Count && choice > 0)
                {
                   
                    Console.WriteLine($"du valde {SelectedPerson}\n");
                    SelectedPerson.Describe();                             //calls for a Method in Class Human
                    Console.WriteLine("\nVill du fortsätta söka information om någon medlem? ja/nej");
                    userAnswer = Console.ReadLine();
                    if (userAnswer.Trim().ToLower() == "ja")
                    {
                        keepGoing = true;
                    }
                    else
                    {
                        keepGoing = false;
                    }
                }
                else
                {
                    Console.WriteLine("Var god mata in en siffa som syns i listan");
                }
            } 
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
            while (keepGoing) 
            {
                choiceInBool = int.TryParse(Console.ReadLine(), out choice);   //every "wrong" input is casts to "0". 
                if (choiceInBool && choice <= groupList.Count && choice > 0)
                {
        
                    Console.WriteLine($" Är du säker på att du vill ta bort {SelectedPerson}? ja/nej + enter");   //to make sure the user enter the number he/she wanted to.
                    userAnswer = Console.ReadLine();
                    if (userAnswer.Trim().ToLower() == "ja")
                    {
                        Console.WriteLine($"{SelectedPerson} är nu borttagen");
                        groupList.RemoveAt(PersonIndex);
                        keepGoing = false;
                    }
                    else
                    {
                        Console.WriteLine($"{SelectedPerson} är fortsatt delaktig i gruppen :)");
                        break;
                    }

                }
                else if (choice == -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Var god mata in siffan som motsvarar personen du vill ta bort eller \"-1\" om du har ångrat dig");

                }
            } 
        }

        //If a member wants to update their information about themselfs
        private void ChangeInformation()
        {
            keepGoing = true;

            Console.WriteLine("\nVem vill du ändra information kring?\nHar du ångrat dig och vill gå tillbaka så mata in \"-1\"\n");
            ShowingNamesWithNr();

            while (keepGoing)
            {
                choiceInBool = int.TryParse(Console.ReadLine(), out choice);
                if (choiceInBool && choice <= groupList.Count && choice > 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Du valde {SelectedPerson}");
                    Console.WriteLine("Vad önskar du ändra?\nTryck enter om du inte önskar ändra något\n");
                    SelectedPerson.Change();                                                        // calling for a Method in class Human. Shows a list of what is possible to change.
                    choiceInBool = int.TryParse(Console.ReadLine(), out int choice1);
                    switch (choice1)
                    {
                        case 1:
                            Console.Write("Skriv in personens nya namn:  ");
                            SelectedPerson.Name = Console.ReadLine();
                            Console.WriteLine($"Personens nya namn: {SelectedPerson} ");
                            break;
                        case 2:
                            Console.Write("Skriv in den nya ålderna: ");
                            SelectedPerson.Age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"{SelectedPerson} är nu {SelectedPerson.Age} år ");
                            break;
                        case 3:
                            Console.Write("Skriv in den nya födelsedagen ");
                            SelectedPerson.Birthday = Console.ReadLine();
                            Console.WriteLine($"{SelectedPerson} föddes: {SelectedPerson.Birthday} ");
                            break;
                        case 4:
                            Console.Write("Skriv in den nya favoritmaten: ");
                            SelectedPerson.FavouriteFood = Console.ReadLine();
                            Console.WriteLine($"{SelectedPerson} tycker nu att {SelectedPerson.FavouriteFood} är den bästa maten");
                            break;
                        case 5:
                            Console.Write("Skriv in de nya favoritbandet alternativt den nya artisten: ");
                            SelectedPerson.FavouriteBand = Console.ReadLine();
                            Console.WriteLine($"{SelectedPerson} anser att {SelectedPerson.FavouriteBand} är det bästa bandet/artisten");
                            break;
                        case 6:
                            Console.Write("Skriv in den nya favoritfilmen: ");
                            SelectedPerson.FavouriteMovie = Console.ReadLine();
                            Console.WriteLine($"{SelectedPerson} hävdar numera att {SelectedPerson.FavouriteMovie} är den nr 1 movie in the world ");
                            break;
                        case 7:
                            Console.Write("Skriv in vad personen älskar: ");
                            SelectedPerson.Loves = Console.ReadLine();
                            Console.WriteLine($"{SelectedPerson} älskar numera: {SelectedPerson.Loves}");
                            break;
                        case 8:
                            Console.Write("Skriv in vad personen hatar: ");
                            SelectedPerson.Hates = Console.ReadLine();
                            Console.WriteLine($"{SelectedPerson} hatar numera: {SelectedPerson.Hates}");
                            break;
                        case 9:
                            Console.Write("Skriv in personens stjärntecken: ");
                            SelectedPerson.Zodiac = Console.ReadLine();
                            Console.WriteLine($"{ SelectedPerson} är nu av stjärntecknet {SelectedPerson.Zodiac}");
                            break;
                        case 10:
                            Console.Write("Skriv in personens nya superkraft: ");
                            SelectedPerson.SuperPower = Console.ReadLine();
                            Console.WriteLine($"{ SelectedPerson} har nu antagit superkraften:  {SelectedPerson.SuperPower}");
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
                else
                {
                    Console.WriteLine("Var god mata in siffan som motsvarar personen du vill ändra uppgifter kring eller \"-1\" om du ångrat dig");

                }

            } 
        }

        private bool IsGoodBye()
        {
            Console.WriteLine("På återseende!");
            return keepGoing = false;
        }
    }
}
