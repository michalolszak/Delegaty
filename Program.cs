using System;

namespace Delegaty
{
    public class Game
    {
        public string Name {get;set;}
        public int Year {get;set;}
    }

    public class Methods
    {
        public string CalculateAgeEra(int year)
        {
            int currentYear = DateTime.Now.Year - year;
            if(currentYear < 2) 
                return "XboxOne era PS4";
            else if (currentYear < 10)
                return "PS# Xbox Era";
            else if (currentYear < 17)
                return "PS2 Gamecube era";
            else if (currentYear < 21)
                return "PS1 Nintendo Era";
            else
                return "Pegasus eRA";
        }
        public string UpperCaseName(string s)
        {
            return s.ToUpper();
        }

        public string LowerCaseName(string s )
        {   
            return s.ToLower();
        }

        public void Show(string s1, string s2)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s2);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Show2(string s1, string s2)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(s2);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    class Program
    {
            public delegate string calculateAgeErafunctionPointer(int year);
            public delegate string changeTitleFunctionPointer(string name);
            public delegate void showTwoStringFunctionPointer(string s1, string s2);
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            calculateAgeErafunctionPointer funcPointer = methods.CalculateAgeEra;

            string f = "";
            while(!(f == "1" || f == "2"))
            {  
                System.Console.WriteLine( "Wybierz kolor wyswietlania tekstu");
                System.Console.WriteLine("1. bialo zielony");
                System.Console.WriteLine("2 zółto rózowy");
                f = Console.ReadKey().KeyChar.ToString();
            }
            Console.Clear();
            showTwoStringFunctionPointer show;
            if (f=="1")
            {
                show = methods.Show;
            }
            else
                show = methods.Show2;
             f = "";
            while(!(f == "1" || f == "2"))
            {
                System.Console.WriteLine( "Wybuierz wielkosc liter dla tekstu");
                System.Console.WriteLine("1. male");
                System.Console.WriteLine("2. duze");
                f = Console.ReadKey().KeyChar.ToString();
            }
            Console.Clear();
            changeTitleFunctionPointer changeTitle;
            if (f=="1")
            {
                changeTitle = methods.LowerCaseName;
            }
            else
                changeTitle = methods.UpperCaseName;

            RestOfTheProgram(funcPointer,changeTitle,show);
        }
        public static void RestOfTheProgram(calculateAgeErafunctionPointer funcPointer,
                                            changeTitleFunctionPointer changeTitlePointer,
                                            showTwoStringFunctionPointer showPointer)
        {
            Game game = new Game() { Name = "Chrono tiger", Year = 1997 };
            string era = funcPointer(game.Year);
            string name = changeTitlePointer(game.Name);
            era = changeTitlePointer(era);
            showPointer(name, era);
            Console.ReadKey();

        }
    }
}
