using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PilotTask2._2
{
    public class Game
    {
        static string MainWord;
        static string CurrentWord;
        static int MainWordLength;
        public int count = 0;
        public  Player player1 = new Player();
        public  Player player2 = new Player();
        public List<Player> players;
        public List<List<Player>> game = new List<List<Player>>();
        public  List<string> CurrentWords = new List<string>();
        public Commands commande;

        public Game()
        {
            LocalizationHelper.Localization();
            InputPlayers();
            ChekMainWord();
            GameProcess();
        }

        void InputPlayers()
        {
            Console.WriteLine(LocalizationHelper.WelcomeText);
            Console.WriteLine(LocalizationHelper.InputFirstName);
            player1 = new Player()
            {
                Name = Console.ReadLine(),
                Scores = 0
            };
            Console.WriteLine(LocalizationHelper.InputSecondName);
            player2 = new Player()
            {
                Name = Console.ReadLine(),
                Scores = 0
            };
            
            players = new List<Player>()
            {
                player1, player2
            };
           
        }
        /// <summary>
        /// Check and write the main word to the file
        /// </summary>
        void ChekMainWord()
        {
            bool errorFlag = true;
            while (errorFlag)
            {
                Console.WriteLine(LocalizationHelper.InputMainWord);
                MainWord = Console.ReadLine();
                MainWordLength = MainWord.Length;
                if (MainWordLength >= 8 && MainWordLength <= 30)
                {
                    for (int i = 0; i < MainWordLength; i++)
                    {
                        if (!(char.IsLetter(MainWord, i)))
                        {
                            Console.Clear();
                            Console.WriteLine(LocalizationHelper.ErrorMainWord);
                            errorFlag = true;
                            break;
                        }
                        else
                            errorFlag = false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(LocalizationHelper.ErrorWord);
                }
            }
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determines the status of the game
        /// </summary>
        /// <param name="count">Int value counting totel words.</param>
        /// <param name="pointOne">Int value counting number of the first player words.</param>
        /// <param name="pointTwo">Int value counting number of the second player words.</param>
        void PrintGameStatus(int count)
        {
            Console.WriteLine(LocalizationHelper.PrintGameStatus + " {0}", MainWord);
            Timers.TimerCursor = Console.CursorTop;
            if ((count % 2) == 0)
                Console.WriteLine("{0}", player1.Name + LocalizationHelper.InputWord);
            else
                Console.WriteLine("{0}", player2.Name + LocalizationHelper.InputWord);
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public void GameProcess()
        {
            int pointOne = 0, pointTwo = 0, count = 0;
            CurrentWords = new List<string>
            {
                MainWord
            };

            while (true)
            {
                int countWord = 0;   
                PrintGameStatus(count);
                Timers.StartTimer();
                CurrentWord = Console.ReadLine();

                // If there isn't word then exit the cycle and the player lose
                if (string.IsNullOrEmpty(CurrentWord) || Timers.oneMinute == new TimeSpan(0, 0, 0))
                {
                    Timers.timer.Stop();
                    break;
                }
                if (String.Equals(CurrentWord.Substring(0,1), "/"))
                {
                    commande.Command = CurrentWord;
                    Timers.timer.Stop();
                    Console.Clear();
                    Commands commands = new Commands();

                }

                else
                {
                    int playWordLength = CurrentWord.Length;

                    //There is a comparison of letters of the main word and the player
                    int[] massLetters = new int[MainWordLength];
                    foreach (char ch in CurrentWord.ToLower())
                    {
                        for (int l = 0; l < MainWordLength; l++)
                        {
                            if (ch == MainWord.ToLower()[l])
                            {
                                if (massLetters[l] == ch)
                                    l++;
                                else
                                {
                                    massLetters[l] = ch;
                                    countWord++;
                                    break;
                                }
                            }
                        }
                    }

                    // If the word is normal comparison with the words entered earlier
                    if (Equals(playWordLength, countWord))
                    {
                        int i = 0;
                        foreach (string ListWord in CurrentWords)
                        {
                            if (String.Equals(CurrentWord, ListWord, StringComparison.CurrentCultureIgnoreCase))
                            {
                                Console.Clear();
                                Console.WriteLine(LocalizationHelper.WordWas);
                                Timers.timer.Stop();
                                i++;
                                break;
                            }
                        }
                        if (i == 0)
                        {
                            if ((count % 2) == 0)
                            {
                                count++;
                                pointOne++;
                            }
                            else
                            {
                                count++;
                                pointTwo++;
                            }
                            Timers.timer.Stop();
                            Timers.oneMinute = new TimeSpan(0, 1, 0);
                            Console.Clear();
                            CurrentWords.Add(CurrentWord);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(LocalizationHelper.ErrorCurrentWord);
                        Timers.timer.Stop();
                    }
                }
            }
            //If the game is over, the winner is determined
            DeterminationOfWin(pointOne, pointTwo);
        }

        /// <summary>
        /// Determination of winner
        /// </summary>
        /// <param name="pointOne">Int value counting number of the first player words.</param>
        /// <param name="pointTwo">Int value counting number of the second player words.</param>
        public void DeterminationOfWin(int pointOne, int pointTwo)
        {
            string winner = string.Empty;
            if (pointOne == 0 && pointTwo == 0)
                Console.WriteLine(LocalizationHelper.DeterminationOfWin);
            else
            {
                if (pointOne > pointTwo)
                {
                    winner = player1.Name;
                    player1.Scores++;
                }
                if (pointOne == pointTwo && pointOne != 0)
                {
                    winner = player2.Name;
                    player2.Scores++;
                }
                Console.WriteLine(LocalizationHelper.Winner + winner);
            }
        }
    }
}
