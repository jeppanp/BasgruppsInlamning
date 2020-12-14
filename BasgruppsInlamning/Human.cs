using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;
using System.Windows.Markup;

namespace BasgruppsInlamning
{
    class Human
    {
        private string name;
        private int age;
        private string birthday;
        private string favouriteFood;
        private string favouriteBand;
        private string favouriteMovie;
        private string loves;
        private string hates;
        private string superPower;
        private string zodiac;
        private string reasonToPrograming;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string FavouriteFood { get => favouriteFood; set => favouriteFood = value; }
        public string FavouriteBand { get => favouriteBand; set => favouriteBand = value; }
        public string FavouriteMovie { get => favouriteMovie; set => favouriteMovie = value; }
        public string Loves { get => loves; set => loves = value; }
        public string Hates { get => hates; set => hates = value; }
        public string SuperPower { get => superPower; set => superPower = value; }
        public string Zodiac { get => zodiac; set => zodiac = value; }
        public string ReasonToPrograming { get => reasonToPrograming; set => reasonToPrograming = value; }

        public Human()
        {

        }
        public Human(string name, int age, string birthday, string favouriteFood, string favouriteBand, string favouriteMovie, string loves,
            string hates, string superPower, string zodiac, string reasonToPrograming)
        {
            this.Name = name;
            this.Age = age;
            this.Birthday = birthday;
            this.FavouriteFood = favouriteFood;
            this.FavouriteBand = favouriteBand;
            this.FavouriteMovie = favouriteMovie;
            this.Loves = loves;
            this.Hates = hates;
            this.SuperPower = superPower;
            this.Zodiac = zodiac;
            this.ReasonToPrograming = reasonToPrograming;

        }

 

        public void Describe()
        {
            Console.Clear();
            Console.WriteLine($"|{Name}|");
            Console.WriteLine($" Ålder: {Age}");
            Console.WriteLine($" Födelsedagsdag: {Birthday}");
            Console.WriteLine($" Favoritmat: {FavouriteFood}");
            Console.WriteLine($" Favoritband: {FavouriteBand}");
            Console.WriteLine($" Favoritfilm: {FavouriteMovie}");
            Console.WriteLine($" {Name} älskar: {Loves}");
            Console.WriteLine($" {Name} hatar: {Hates}");
            Console.WriteLine($" Stjärntecken: {Zodiac}");
            Console.WriteLine($" Superpower: {SuperPower}");
            Console.WriteLine($" Anledning till att programmera: {ReasonToPrograming}");
        }
        public void Change()
        {

            Console.WriteLine($"1. Namn");
            Console.WriteLine($"2. Ålder");
            Console.WriteLine($"3. Födelsedagsdag");
            Console.WriteLine($"4. Favoritmat");
            Console.WriteLine($"5. Favoritband");
            Console.WriteLine($"6. Favoritband");
            Console.WriteLine($"7. Älskar");
            Console.WriteLine($"8. Hatar");
            Console.WriteLine($"9. Stjärntecken");
            Console.WriteLine($"10. Superpower");
            Console.WriteLine($"11. Anledning till att programmera");
        }

    }

}
