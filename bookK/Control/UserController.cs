using Model;
using Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class UserController
    {
        private UserDataAccess Usd = new UserDataAccess();

        //Her hentes alle brugere fra databasen
        public List<User> GetAllUsers()
        {
            return Usd.GetAllUsers();
        }

        //Metode til at oprette en ny bruger hvor den skal bruge en string med brugernavn
        public void CreateUser(string userName)
        {
            User user = new User
            {
                UserName = userName
            };
            Usd.CreateUser(user);
        }
    }
}
