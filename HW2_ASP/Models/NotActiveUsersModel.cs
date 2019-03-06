using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW2_ASP.Models
{
    public class NotActiveUsersModel
    {
        public List<User> Users;

        public NotActiveUsersModel()
        {
            using (var tmpMusicUser = new MusicPortal())
            {

                Users = tmpMusicUser.Users.ToList();
            }
        }
    }
}