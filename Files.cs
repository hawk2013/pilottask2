using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;


namespace PilotTask2._2
{
    public class WriteReadFiles
    {
        public dynamic filePlayers;

        public void ReadFile()
        {
            string json;
            
            using (StreamReader read = new StreamReader("game.json"))
            {
                json = read.ReadToEnd();

                if (!String.Equals(json,""))
                {
                    filePlayers = JsonConvert.DeserializeObject(json);
                    foreach (var item in filePlayers)
                    {
                        Console.WriteLine("{0} {1}", item.Name, item.Scores);
                    }
                }
                
            }
            
        }

        public void WriteAllFile(Game game)
        {
            
            string listPlayers = JsonConvert.SerializeObject(game.players);
            File.WriteAllText("game.json", listPlayers);
        }
    }
}
