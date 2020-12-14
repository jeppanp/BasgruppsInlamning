using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualBasic.FileIO;

namespace BasgruppsInlamning
{
    class Program
    {
        public static List<Human> groupList = new List<Human>();
        static void Main(string[] args)
        {
          
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
    }
}
