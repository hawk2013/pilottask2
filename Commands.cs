using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotTask2._2
{
    public class Commands
    {
        public string Command;
        public Game game;
        public WriteReadFiles writeReadFiles;

        public void ChoiseCommand(Game game)
        {
            if (Equals(Command, "/show-words"))
            {
                foreach (string ListWord in game.CurrentWords)
                {
                    Console.WriteLine(ListWord);
                }
            }
            if(Equals(Command, "/score"))
            {

            }
            if(Equals(Command, "/total-score"))
            {
                foreach (var item in writeReadFiles.filePlayers)
                {
                    Console.WriteLine("{0} {1}", item.Name, item.Scores);
                }
            }
            Console.WriteLine(LocalizationHelper.PressKey);
            Console.ReadKey();
        }

        public Commands()
        {
            ChoiseCommand(game);
        }
    }
}
