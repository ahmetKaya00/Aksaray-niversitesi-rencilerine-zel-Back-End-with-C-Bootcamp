using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }

                if(!context.Tags.Any()){
                    context.Tags.AddRange(
                    new Tag {Text = "web programlama", Url = "web-programlama",Color = TagColors.primary},
                    new Tag {Text = "backend", Url = "backend", Color = TagColors.danger},
                    new Tag {Text = "frounded", Url = "frouned", Color = TagColors.warning},
                    new Tag {Text = "game", Url = "game", Color = TagColors.success},
                    new Tag {Text = "full stack" , Url = "full-stack", Color = TagColors.secondary}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User {UserName = "ahmetkaya", Name = "Ahmet Kaya", Email="info@ahmetkaya.com", Password="123456", Image = "p1.jpg"},
                        new User {UserName = "umutcangungor", Name = "Umutcan Gungor", Email="info@umutcan.com", Password="123456", Image = "p2.jpg"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.net core",
                            Content = "asp.net core bootcampi",
                            Url = "asp-net-core",
                            IsActive = true,
                            PublisedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment>{
                                new Comment { Text = "iyi bir kurs", PublisedOn = new DateTime(), UserId = 1},
                                new Comment { Text = "tebrikler", PublisedOn = new DateTime(), UserId = 2},
                            }
                        },
                        new Post{
                            Title = "Game Bootcamp",
                            Content = "unity game bootcampi",
                            Url = "game-bootcamp",
                            IsActive = true,
                            PublisedOn = DateTime.Now.AddDays(-12),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",
                            UserId = 1
                        },
                        new Post{
                            Title = "Web geliştirme",
                            Content = "web geliştirme adımları",
                            Url = "web-gelistirme",
                            IsActive = true,
                            PublisedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}