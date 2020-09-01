using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_PRAC4_s4340813.Models
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Player GetPlayerByDoB(string dob);
        Player GetPlayerByTeam(string team);
        Player GetPlayerByName(string name);
        Player GetPlayerByID(string id);

        Player Add(Player item);
        void Remove(string id);

        bool Update(Player item);
        void deletePlayers(int ID, String file);
        void writePlayers(String line, String file);
        List<String> readPlayers(String file);

   
    }
}