using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class PlayApiRequest
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public int Playerastion { get; set; }

        public PlayApiRequest(int id, string key,int playeraction)
            {
                Id = id;
                Key = "757153521a8f474da578fd7ce77dfadc";
                Playerastion = playeraction;
            }
    }
}
