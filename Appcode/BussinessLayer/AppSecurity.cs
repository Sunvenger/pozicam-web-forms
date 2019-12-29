using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pozicam_web_forms.Appcode.Models;

namespace pozicam_web_forms.Appcode.BussinessLayer
{
    public class AppSecurity
    {
        public static bool CheckUser(User usr)
        {
            if (usr == null) return false;
            using (var context = new pozicamskEntities())
            {
                var dbUser = (from u in context.User
                              where u.Id == usr.Id
                              select u).First();
                if (
                    usr.Password == dbUser.Password &&
                    usr.Email == dbUser.Email &&
                    usr.IsVerified == true
                    )
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckAdmin(User usr)
        {
            if (usr == null) return false;
            using (var context = new pozicamskEntities())
            {
                var dbUser = (from u in context.User
                              where u.Id == usr.Id
                              select u).First();
                if (
                    usr.Password == dbUser.Password &&
                    usr.Email == dbUser.Email &&
                    usr.IsVerified == true&&
                    usr.IsAdmin == true
                    )
                {
                    return true;
                }
            }

            return false;
        }


    }
}