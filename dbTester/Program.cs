using Mobs.Data;
using Mobs.Logic.Providers;
using Mobs.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new dbMobs();
            var user = new UserModel {
                EmailAddress = "Fieldejnr@live.co.uk",
                FullName = "Robert Nathan Field",
                Password = "Arsenal2008",
            };
            UserModel user2;
            var err = UserProvider.Get(1, out user2);
            if (err != null) {
                Console.WriteLine(err);
            }

            user2.FullName = "Joe Blow";
            err = UserProvider.Update(user2);

            if (err != null)
            {
                Console.WriteLine(err);

            }

        }
        }
}
