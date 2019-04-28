using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PilotTask2._2
{
    /// <summary>
    /// Language selection
    /// </summary>
    public class LocalizationHelper
    {
        public static bool Choise;
        public static string json;

        public static string WelcomeText
        {
            get
            {
                if (Choise)
                    return "Игра в слова.\n"+
                        "Правила: В начале игры пользователь вводит слово определенной длины: суть игры заключается в том,\n" +
                        "чтобы 2 пользователя поочередно вводили слова, состоящие из букв первоначально указанного слова.\n" +
                        "Проигрывает тот, кто в свою очередь не вводит слово. На ввод слова 1 минута.";
                else
                    return "Word game.\n"+
                        "Rules: At the beginning of the game, the user enters a word of a certain length: the essence of the game is \n " +
                        "so that 2 users alternately enter words consisting of the letters of the originally specified word. \n" +
                        "The one who in turn does not enter a word loses. On input of a word 1 minute.\n";
            }
        }
        public static string TimeOver
        {
            get
            {
                if (Choise)
                    return "Время вышло.";
                else
                    return "Time is over";
            }
        }
        public static string InputFirstName
        {
            get
            {
                if (Choise)
                    return "Введите имя первого игрока:";
                else
                    return "Input name the first player:";
            }
        }
        public static string InputSecondName
        {
            get
            {
                if (Choise)
                    return "Введите имя второго игрока:";
                else
                    return "Input name the second player:";
            }
        }
        public static string InputMainWord
        {
            get
            {
                if (Choise)
                    return "Введите начальное слово от 8 до 30 букв:";
                else
                    return "Enter a starting word from 8 to 30 letters:";
            }
        }

        public static string ErrorMainWord
        {
            get
            {
                if (Choise)
                    return "В слове есть число или символ повторите ввод.";
                else
                    return "There is a number or character in the word, repeat input.";
            }
        }
        public static string ErrorWord
        {
            get
            {
                if (Choise)
                    return "Недостаточно букв в слове.";
                else
                    return "Not enough letters in the word.";
            }
        }
        
        public static string InputWord
        {
            get
            {
                if (Choise)
                    return " введите слово";
                else
                    return " input word";
            }
        }

        public static string WordWas
        {
            get
            {
                if (Choise)
                    return "Это слово уже было.";
                else
                    return "This word has already been.";
            }
        }

        public static string ErrorCurrentWord
        {
            get
            {
                if (Choise)
                    return "Такое слово нельзя составить.";
                else
                    return "This word can't be compiled.";
            }
        }
        public static string DeterminationOfWin
        {
            get
            {
                if (Choise)
                    return "Победитель не определился";
                else
                    return "Winner not determined";
            }
        }
        public static string Winner
        {
            get
            {
                if (Choise)
                    return "Победитель ";
                else
                    return "Winner ";
            }
        }
        public static string PrintGameStatus
        {
            get
            {
                if (Choise)
                    return "Главное слово";
                else
                    return "Main word";
            }
        }

        public static string PressKey
        {
            get
            {
                if (Choise)
                    return "Нажмите любую кнопку для продолжения игры";
                else
                    return "Press any key to continue game";
            }
        }
        public static void Localization()
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            if (String.Equals(culture.ToString(), "ru-RU", StringComparison.InvariantCultureIgnoreCase))
                Console.WriteLine("Выберите язык: Ru/En");
            else
                Console.WriteLine("Language selection: Ru/En");
            string language = Console.ReadLine();
            if (String.Equals(language, "Ru", StringComparison.InvariantCultureIgnoreCase))
                Choise = true;
            else
                Choise = false;
        }

        public LocalizationHelper()
        {
            Localization();
            
        }

      /*  public static List<Player> Language()
        {
            Player player1, player2;
            if (Choise)
            {
                Console.WriteLine("Игра в слова.");
                Console.WriteLine("Правила: В начале игры пользователь вводит слово определенной длины: суть игры заключается в том,\n" +
                        "чтобы 2 пользователя поочередно вводили слова, состоящие из букв первоначально указанного слова.\n" +
                        "Проигрывает тот, кто в свою очередь не вводит слово. На ввод слова 1 минута.\n");
                Console.WriteLine("Введите имя первого игрока:");
                player1 = new Player()
                {
                    Name = Console.ReadLine(),
                    Scores = Player.pointWin1
                };
                Console.WriteLine("Введите имя второго игрока:");
                player2 = new Player()
                {
                    Name = Console.ReadLine(),
                    Scores = Player.pointWin2
                };
            }
            else
            {
                Console.WriteLine("Word game.");
                Console.WriteLine("Rules: At the beginning of the game, the user enters a word of a certain length: the essence of the game is \n " +
                        "so that 2 users alternately enter words consisting of the letters of the originally specified word. \n" +
                        "The one who in turn does not enter a word loses. On input of a word 1 minute.\n");
                Console.WriteLine("Input name the first player:");
                player1 = new Player()
                {
                    Name = Console.ReadLine(),
                    Scores = Player.pointWin1
                };
                Console.WriteLine("Input name the second player:");
                player2 = new Player()
                {
                    Name = Console.ReadLine(),
                    Scores = Player.pointWin2
                };
            }
            List<Player> players = new List<Player>()
                {
                    player1,player2
                };
            json = JsonConvert.SerializeObject(players);
            return players;
        }*/
    }
}
