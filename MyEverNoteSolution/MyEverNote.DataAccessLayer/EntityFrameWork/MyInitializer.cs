using FakeData;
using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEverNote.DataAccessLayer.EntityFrameWork
{
   public class MyInitializer:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Adding Admin User
            EverNoteUser admin = new EverNoteUser()
            {
                Name="Rabia",
                SurName="Şafak",
                Email="rabia.safak@hotmail.com",
                ActivateGuid=Guid.NewGuid(),
                IsActive=true,
                IsAdmin=true,
                UserName="rabiasafak",
                Password="12345",
                CreatedOn=DateTime.Now,
                ModifiedOn=DateTime.Now.AddMinutes(5),
                ModifiedUserName="rabiasafak",
                ProfilImageFileName="userImg.jpg"
            };
            //Adding Standart User
            EverNoteUser standartUser = new EverNoteUser()
            {
                Name = "Harun",
                SurName = "Akbaş",
                Email = "harunakbas34@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                UserName = "harunakbas",
                Password = "54321",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUserName = "rabiasafak",
                ProfilImageFileName = "userImg.jpg"
            };

            context.EverNoteUsers.Add(admin);
            context.EverNoteUsers.Add(standartUser);

            //Adding Fake User
            for (int i = 0; i < 8; i++)
            {
                EverNoteUser user = new EverNoteUser()
                {
                    Name = NameData.GetFirstName(),
                    SurName = NameData.GetSurname(),
                    Email = NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    UserName = $"user{i}",
                    Password = "123",
                    CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-2),DateTime.Now),
                    ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-2), DateTime.Now),
                    ModifiedUserName = $"user{i}",
                    ProfilImageFileName = "userImg.jpg"
                };
                context.EverNoteUsers.Add(user);
            }

            context.SaveChanges();

            //User List For Using
            List<EverNoteUser> userList = context.EverNoteUsers.ToList();

            //Adding Fake Categories
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title=PlaceData.GetStreetName(),
                    Description=PlaceData.GetAddress(),
                    CreatedOn=DateTime.Now,
                    ModifiedOn=DateTime.Now,
                    ModifiedUserName="rabiasafak"
                };
                context.Categories.Add(cat);
                //Adding Fake Notes
                for (int k = 0; k < NumberData.GetNumber(5,9); k++)
                {
                    EverNoteUser owner = userList[NumberData.GetNumber(0, userList.Count - 1)];
                    Note note = new Note()
                    {
                        Title=TextData.GetAlphabetical(NumberData.GetNumber(5,25)),
                        Text= TextData.GetSentences(NumberData.GetNumber(1,3)),
                        Category=cat,
                        IsDraft=false,
                        LikeCount=NumberData.GetNumber(1,9),
                        Owner=owner,
                        CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-2), DateTime.Now),
                        ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-2), DateTime.Now),
                        ModifiedUserName=owner.UserName
                    };
                    cat.Notes.Add(note);
                    //Adding Fake Comments
                    for (int j = 0; j < NumberData.GetNumber(3,5); j++)
                    {
                        EverNoteUser comment_owner = userList[NumberData.GetNumber(0, userList.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = TextData.GetSentence(),
                        Owner=comment_owner,
                        CreatedOn= DateTimeData.GetDatetime(DateTime.Now.AddYears(-2), DateTime.Now),
                        ModifiedOn= DateTimeData.GetDatetime(DateTime.Now.AddYears(-2), DateTime.Now),
                        ModifiedUserName=comment_owner.UserName,
                        //Note=note
                        };
                        note.Comments.Add(comment);
                        //Adding Fake Likes
                        for (int m = 0; m < note.LikeCount; m++)
                        {
                            Liked liked = new Liked()
                            {
                                LikedUser=userList[m]
                            };
                            note.Likes.Add(liked);
                        }

                    }

                }
                context.SaveChanges();
            }

        }
    }
}
