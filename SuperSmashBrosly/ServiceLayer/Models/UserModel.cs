using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Decorators;

namespace ServiceLayer.Models
{
    public class UserModel : IUser
    {
        public int ID { get; set; }

        // Username will have to be between six and sixteen characters
        [UsernameLength(MaxLength =16, MinLength =6)]
        public string Username { get; set; }

        [PasswordValidation(MinLength=6)]
        public string Password { get; set; }

        public string LastFighterGuessed { get; set; }
        public int CorrectGuesses { get; set; } = 0;
        public int Attempts { get; set; } = 0;

    }
}
