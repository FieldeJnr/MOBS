using Mobs.Data;
using Mobs.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Logic.Providers
{
    public static class UserProvider
    {

        public static MobsError Create(UserModel model)
        {
            var context = "UserProvider.Create";
            try
            {
                using (var db = new dbMobs())
                {
                    if (db.Users.Any(e => e.EmailAddress == model.EmailAddress)) {
                        return new MobsError(context, MobsErrorEnum.EmailAddressInUse);
                    }
                    var dbe = new User
                    {
                        EmailAddress = model.EmailAddress,
                        FullName = model.FullName,
                        Password = model.Password,
                    };
                    db.Users.Add(dbe);
                    db.SaveChanges();
                    model.Id = dbe.Id;
              
                }
            }
            catch (Exception e)
            {

                return new MobsError(context,e);
            }
            return null;
        }
     /// <summary>
     /// Will check the emailaddress is valid user and check password matches
     /// </summary>
     /// <param name="emailAddress"></param>
     /// <param name="password"></param>
     /// <returns> If emailaddress not found return DataNotFound, For invalid password returns InvalidPassword, return null for correct email and password</returns>
        public static MobsError ValidateUser(string emailAddress, string password)
        {
            var context = "UserProvider.ValidateUser";

            try
            {
                using (var db = new dbMobs())
                {

                    var user = db.Users.FirstOrDefault(u => u.EmailAddress == emailAddress);
                    if (user == null)
                    {
                        return new MobsError(context, MobsErrorEnum.DataNotFound);
                    }
                    if (user.Password != password)
                    {
                        return new MobsError(context, MobsErrorEnum.InvalidPassword);
                    }

                    return null;
                }
            }
            catch (Exception e)
            {


                return new MobsError(context, e);
            }
            return null;
        }

        public static MobsError Get(int userId, out UserModel model)
        {
            model = null;
            var context = "UserProvider.Get";
            try
            {
                using (var db = new dbMobs())
                {


                    model = (from u in db.Users
                                 where u.Id == userId
                                 select new UserModel
                                 {
                                     Id = u.Id,
                                     EmailAddress = u.EmailAddress,
                                     FullName = u.FullName,
                                     Password = u.Password,
                                     
                                 }).FirstOrDefault();
                
                    if (model == null)
                    {
                        return new MobsError(context, MobsErrorEnum.DataNotFound);
                    }
                   

                }
            }
            catch (Exception e)
            {

                return new MobsError(context, e);
            }
            return null;
        }

        

        public static MobsError Update(UserModel model)
        {
            var context = "UserProvider.Update";
            try
            {
                using (var db = new dbMobs())
                {
                     if (db.Users.Any(e => e.EmailAddress == model.EmailAddress  && e.Id!= model.Id))
                    {
                        return new MobsError(context, MobsErrorEnum.EmailAddressInUse);
                    }

                    var dbe = db.Users.Find(model.Id);
                    if (dbe == null) {
                        return new MobsError(context, MobsErrorEnum.DataNotFound);
                    }

                    dbe.EmailAddress = model.EmailAddress;
                    dbe.FullName = model.FullName;
                    dbe.Password = model.Password;
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {

               return new MobsError(context, e);
            }
            return null;
        }

        public static MobsError Delete(int userId)
        {
            var context = "UserProvider.Delete";
            try
            {
                using (var db = new dbMobs())
                {
                   
                    var dbe = db.Users.Find(userId);
                    if (dbe == null)
                    {
                        return new MobsError(context, MobsErrorEnum.DataNotFound);
                    }

                    //Remove user categories.
                    foreach (var cat in dbe.UserCategories.ToList())
                    {
                        db.Entry(cat).State = System.Data.Entity.EntityState.Deleted;
                    }

                    // Remove user whiteboards and following baord items.
                    foreach (var board in dbe.Whiteboards.ToList())
                    {
                        db.Entry(board).State = System.Data.Entity.EntityState.Deleted;

                        foreach (var item in board.WhiteboardItems.ToList())
                        {
                            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        }

                    }

                    db.Entry(dbe).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {

               return new MobsError(context, e);
            }
            return null;
        }


    }
}
