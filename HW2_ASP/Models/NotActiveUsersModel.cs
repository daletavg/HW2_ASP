using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW2_ASP.Models
{
    public class NotActiveUsersModel
    {
        public List<UserToActive> UserToActives = new List<UserToActive>();

        public NotActiveUsersModel()
        {
            using (var tmpMusicUser = new MusicPortal())
            {

                var tmp = tmpMusicUser.Users.ToList();
                foreach (var user in tmp)
                {
                    if (user.is_activate == true)
                    {
                        continue;
                    }

                    UserToActives.Add(new UserToActive()
                    {
                        IsActivate = false,
                        Login = user.login,
                        Name = user.name,
                        Surname = user.surname
                    });
                }
            }
        }
    }
}