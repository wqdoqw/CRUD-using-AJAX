using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace REST_PRAC4_s4340813.Models
{
    public class PlayerRepository : IPlayerRepository
    {
 
        private List<Player> players = new List<Player>();

        public PlayerRepository()
        {
            String file = @"C:\Users\USER\Downloads\REST PRAC4 s4340813\REST PRAC4 s4340813\REST PRAC4 s4340813\players.txt";
            List<String> player = readPlayers(file);

            foreach (String line in player)
            {
                String[] tokens = line.Split(',');


                Add(new Player
                {

                    Registration_ID = tokens[0].Substring(1),
                    Player_name = tokens[1],
                    Team_name = tokens[2],
                    Date_of_birth = tokens[3]

                });

            }

        }

        public Player Add(Player item)
        {
        
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

        
            players.Add(item);
            return item;
        }
        public IEnumerable<Player> GetAll()
        {
            return players;
        }
        public Player GetPlayerByID(string id)
        {
            return players.Find(p => p.Registration_ID == id);
        }

        public Player GetPlayerByName(string name)
        {
            return players.Find(p => p.Player_name == name);
        }
        public Player GetPlayerByTeam(string team)
        {
            return players.Find(p => p.Team_name == team);
        }
        public Player GetPlayerByDoB(string dob)
        {
            return players.Find(p => p.Date_of_birth == dob);
        }

        public void Remove(string id)
        {

   
            players.RemoveAll(p => p.Registration_ID == id);
               
        }

        public bool Update(Player item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = players.FindIndex(p => p.Registration_ID == item.Registration_ID);
            if (index == -1)
            {
                return false;
            }

            players.RemoveAt(index);
            players.Add(item);
            return true;
        }
        public List<String> readPlayers(String file)
        {
            List<String> books = new List<String>();
            String line;


            StreamReader sr = new StreamReader(file);
            line = sr.ReadLine();

            while (line != null)
            {
                books.Add(line);
                line = sr.ReadLine();

            }
            sr.Close();
            return books;
        }

        public void writePlayers(String line, String file)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(file, true);
            writer.WriteLine(line);
            writer.Close();
            writer.Dispose();

        }
        public void deletePlayers(int ID, String file)
        {
            string tempFile = Path.GetTempFileName();
            string lineVar = null;

            using (var sr = new StreamReader(file))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;
                line = sr.ReadLine();
                while (line != null)
                {
                    String[] tokens = line.Split(',');
                    int id = Convert.ToInt32(tokens[0].Substring(1));

                    if (id == ID)
                        sw.WriteLine(lineVar);
                }
            }

            File.Delete(file);
            File.Move(tempFile, file);
        }
    }
}