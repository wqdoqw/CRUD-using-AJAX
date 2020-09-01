using REST_PRAC4_s4340813.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace REST_PRAC4_s4340813.Controllers
{
    public class PlayerController : ApiController
    {
        static String file = @"C:\Users\USER\Downloads\REST PRAC4 s4340813\REST PRAC4 s4340813\REST PRAC4 s4340813\players.txt";
        static readonly IPlayerRepository repository = new PlayerRepository();
        
        // GET: api/Player
        public IEnumerable<Player> GetAll()
        {
            return repository.GetAll();
        }
        
        // GET: api/Player/5
        public Player GetPlayer(string id)
        {
            Player item = repository.GetPlayerByName(id);
            
            if (item == null)
            {

                item = repository.GetPlayerByID(id);

            }

            if(item == null)
            {
                item = repository.GetPlayerByTeam(id);
            }
            if(item == null)
            {
                item = repository.GetPlayerByDoB(id);
            }
            return item;

        }
  
        // POST: api/Player
        public HttpResponseMessage Post([FromBody]Player item)
        {
            file = @"C:\Users\USER\Downloads\REST PRAC4 s4340813\REST PRAC4 s4340813\REST PRAC4 s4340813\players.txt";
            String line = "p" + item.Registration_ID + "," + item.Player_name + "," + item.Team_name + "," + item.Date_of_birth;

            int num = Convert.ToInt32(item.Registration_ID);
            repository.writePlayers(line,file);
            item = repository.Add(item);
            var response = Request.CreateResponse<Player>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Registration_ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }
     
    
        public void PutPlayer(string id, Player item)
        {
            String line = "P" + item.Registration_ID + "," + item.Player_name + "," + item.Team_name + "," + item.Date_of_birth;
            
            item.Registration_ID = id;
         
            if (!repository.Update(item))
            {
                 throw new HttpResponseException(HttpStatusCode.NotFound);
               
            }
        }
        // DELETE: api/Player/5
        public void Delete(string name)
        {
          
           Player item = repository.GetPlayerByID(name);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(name);
         
        }

    }
}
