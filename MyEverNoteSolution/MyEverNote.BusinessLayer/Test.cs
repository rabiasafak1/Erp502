using MyEverNote.DataAccessLayer;
using MyEverNote.DataAccessLayer.EntityFrameWork;
using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.BusinessLayer
{
    public class Test
    {
        //private Repository<Category> repo_Category = new Repository<Category>();
        //private Repository<EverNoteUser> repo_User = new Repository<EverNoteUser>();
        //public Test()
        //{
        //    //DatabaseContext db = new DatabaseContext();
        //    ////db.Database.CreateIfNotExists();
        //    //db.EverNoteUsers.ToList();

        //    List<Category> categories = repo_Category.List();
        //}
        //public void InsertTest()
        //{
        //    int result = repo_User.Insert(new EverNoteUser()
        //    {
        //        Name = "Necla",
        //        SurName = "Şafak",
        //        Email = "necla.safak@hotmail.com",
        //        ActivateGuid = Guid.NewGuid(),
        //        IsActive = true,
        //        IsAdmin = false,
        //        UserName = "neclaaa",
        //        Password = "456123",
        //        CreatedOn = DateTime.Now,
        //        ModifiedOn=DateTime.Now.AddMinutes(5),
        //        ModifiedUserName="rabiasafak"
        //    });
            
        //}
        //public void UpdateTest()
        //{
        //    EverNoteUser user = repo_User.Find(x => x.Name == "Necla");
        //    if(user != null)
        //    {
        //        user.UserName = "rabias";
        //        repo_User.Update(user);
        //    }
        //}
        //public void DeleteTest()
        //{
        //    EverNoteUser user = repo_User.Find(x => x.UserName == "rabias");
        //    if (user != null)
        //    {
        //        repo_User.Delete(user);
        //    }
        //}
    }
}
