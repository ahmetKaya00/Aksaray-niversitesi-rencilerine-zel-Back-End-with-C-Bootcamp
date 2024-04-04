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
                    new Tag {Text = "web programlama"},
                    new Tag {Text = "backent"},
                    new Tag {Text = "frounded"},
                    new Tag {Text = "game"},
                    new Tag {Text = "full stack"}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User {UserName = "ahmetkaya"},
                        new User {UserName = "umutcangungor"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.net core",
                            Content = "asp.net core bootcampi",
                            IsActive = true,
                            PublisedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1
                        },
                        new Post{
                            Title = "Game Bootcamp",
                            Content = "unity game bootcampi",
                            IsActive = true,
                            PublisedOn = DateTime.Now.AddDays(-12),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",
                            UserId = 1
                        },
                        new Post{
                            Title = "Web geliştirme",
                            Content = "web geliştirme adımları",
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