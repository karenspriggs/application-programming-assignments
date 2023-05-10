using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public interface IUser
    {
        int ID { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string LastFighterGuessed { get; set; }
        int Attempts { get; set; }
    }
}
