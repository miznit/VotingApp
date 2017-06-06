using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class UserManager
    {
        public static List<User>GetUsers()
        {
            var user = new List<User>();

            user.Add(new User { LastName = "O'Reilly", FirstNames = "Paddy Dougal", DateOfBirth = "1977/07/07", ElectoralID = "PMR123456" });

            user.Add(new User { LastName = "Baker", FirstNames = "Norma-Jean", DateOfBirth = "1966/06/06", ElectoralID = "TTH123456" });

            user.Add(new User { LastName = "Dover", FirstNames = "Ben James", DateOfBirth = "1955/05/05", ElectoralID = "RAN123456" });


            return user;
        }

    }
}
