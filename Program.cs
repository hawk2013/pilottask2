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
    class Program
    {
        static void Main(string[] args)
        {
            WriteReadFiles writeReadFiles = new WriteReadFiles();
            writeReadFiles.ReadFile();
            Game game = new Game();
            writeReadFiles.WriteAllFile(game);
            Console.ReadKey();
        }

        ~Program()
        {
            Console.WriteLine();
        }
    }
}
