using Mobs.Data;
using Mobs.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Logic.Providers
{
    public static class UserCategoryProvider
    {
        public static MobsError Create(UserCategoryModel model)
        {
            var context = "UserCategoryProvider.Create";
            try
            {
                using (var db = new dbMobs())
                {
                    if (db.UserCategories.Any(e => e.Name == model.Name && e.UserId == model.UserId)) {
                        return new MobsError(context, MobsErrorEnum.EmailAddressInUse);
                    }
                    var dbe = new UserCategory
                    {
                        Name = model.Name, UserId = model.UserId,

                    };
                    db.UserCategories.Add(dbe);
                    db.SaveChanges();
                    model.Id = dbe.Id;
              
                }
            }
            catch (Exception e)
            {

                new MobsError(context,e);
            }
            return null;
        }

        public static MobsError Update(UserCategoryModel model)
        {
            var context = "UserCategoryProvider.Update";
            try
            {
                using (var db = new dbMobs())
                {
                     if (db.UserCategories.Any(e => e.Name == model.Name  && e.Id!= model.Id && e.UserId == model.UserId))
                    {
                        return new MobsError(context, MobsErrorEnum.DuplicateCategory);
                    }

                    var dbe = db.UserCategories.Find(model.Id);
                    if (dbe == null) {
                        return new MobsError(context, MobsErrorEnum.DataNotFound);
                    }

                    dbe.Name = model.Name;
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {

                new MobsError(context, e);
            }
            return null;
        }

        public static MobsError Delete(int id)
        {
            var context = "UserCategoryProvider.Delete";
            try
            {
                using (var db = new dbMobs())
                {
                   
                    var dbe = db.UserCategories.Find(id);
                    if (dbe == null)
                    {
                        return new MobsError(context, MobsErrorEnum.DataNotFound);
                    }
                    if (dbe.Whiteboards.Any()) {
                        return new MobsError(context, MobsErrorEnum.UserCategoryInUse);

                    }

                    db.Entry(dbe).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {

                new MobsError(context, e);
            }
            return null;
        }


    }
}
