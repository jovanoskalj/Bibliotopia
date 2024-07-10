using Bibliotopia.Data.Enums;
using Bibliotopia.Data.Static;
using Bibliotopia.Models;
using Microsoft.AspNetCore.Identity;

namespace Bibliotopia.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Publishers
                if (!context.BookPublishers.Any())
                {
                    context.BookPublishers.AddRange(new List<BookPublisher>()
                    {
                        new BookPublisher()
                        {
                            Name = "Култура",
                            LogoUrl = "https://upload.wikimedia.org/wikipedia/mk/2/20/Kultura.gif",
                            Description = "„Култура“ е основана во 1945 година и таа е најстарата издавачка куќа во Република Македонија." +
                            " Издавачката куќа била приватизирана во 2000 година. „Култура“ во своја сопственост има две книжарници." +
                            " Едната од нив се наоѓа во центарот на Скопје и важи за една од најрепрезентативните книжарници во Република Македонија. " +
                            "Оваа издавачка куќа соработува со повеќе приватни книжарници во државата, а свој книжарски простор имала и на Економскиот " +
                            "факултет во Скопје."
                        },
                          new BookPublisher()
                        {
                            Name = "Матица",
                            LogoUrl = "https://matica.com.mk/wp-content/uploads/2021/04/Matica_Logo-Final-01-4.jpg",
                            Description = "Матица Македонска, позната и како Клуб Матица — македонска издавачка куќа, со седиште во Скопје.Ова " +
                            "книгоиздавателство е основано во почетокот на 90-тите години на XX век од страна на поетот Раде Силјан, кој потоа бил и негов директор." +
                            " Со текот на времето, „Матица македонска“ прераснала во една од најголемите издавачки куќи во Македонија. Во склоп на издаваштвото," +
                            " функционира и продавница, " +
                            "која се наоѓа на бул. Климент Охридски во Скопје, но книгите од оваа издавачка куќа се застапени во голем број други книжарници низ земјата."
                        }

                    });
                    context.SaveChanges();
                }

                //Authors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "Џоџо Мојес",
                            PictureURL = "https://kultura.com.mk/wp-content/uploads/2019/01/jojo.jpg",
                            Bio = "Џоџо Мојес е англиска новинарка, сопруга и мајка на три деца, а од 2002-та писателка и сценаристка. Таа е, " +
                            "дури двапати, добитничка на престижната награда доделена од Асоцијацијата за награди на романтични новелисти. " +
                            "Во 2016-та екранизираниот наслов „Јас пред тебе“ 19 недели беше во топ 10 листата според Њујорк Тајмс."

                        },
                          new Author()
                        {
                            FullName = "Лусинда Рајли",
                            PictureURL = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRc6zTMxMk6PTqm8vGvf4ddfqcy5kd5ksaHCVh8GXFzhytNuySw",
                            Bio = "Лусинда Рајли е вистински мајстор на пишаниот збор, а благодарение на своите дела таа е веќе светски признат автор." +
                            "Нејзините книги нижат прекрасни љубовни и семејни приказни, кои вешто ги поврзуваат историјата и сегашноста." +
                            " Покрај веќе популарните „Полноќна роза“, „Ангелско дрво“ и „Девојчето на гребенот“, писателката во моментов се истакнува со серијалот „Седумте сестри“."
                        }

                    });
                    context.SaveChanges();

                }

                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Италијанска девојка",
                            Description = "Розана има само единаесет години кога се запознава со Роберто во кафеаната на своите родители во Неапол. " +
                            "Ќе успеат ли Розана и Роберто да ја зачуваат својата љубов кон музиката и еден кон друг?",
                            Price = 600,
                            BookImageUrl = "https://matica.com.mk/wp-content/uploads/2021/12/LUSINDA-RAJLI-ITALIJANSKATA-DEVOJKA-MATICA-300x480.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            PublisherId = 2,


                            BookCategory = BookCategory.Романси
                        },
                        new Book()
                        {
                            Title = "Париз за еден и други приказни",
                            Description = "„Париз за еден и други приказни“ е неодолива романтична колекција на раскази исполнета со хумор и напишана од срце.",
                            Price = 350,
                            BookImageUrl = "https://kultura.com.mk/wp-content/uploads/2019/01/73-500x732.jpg",
                            StartDate = DateTime.Now.AddDays(-5),
                            EndDate = DateTime.Now.AddDays(12),
                            PublisherId = 1,

                            BookCategory = BookCategory.Драма
                        },
                });
                    context.SaveChanges();
                }
                //Authors and Books
                if (!context.AuthorsBooks.Any())
                {
                    context.AuthorsBooks.AddRange(new List<Author_Books>()
                    {
                        new Author_Books()
                        {
                            AuthorId = 1,
                            BookId = 2
                        },
                        new Author_Books()
                        {
                             AuthorId = 2,
                            BookId = 1
                        },


                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                try
                {
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    string adminUserEmail = "admin@bibliotopia.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new ApplicationUser()
                        {
                            FullName = "Admin",
                            UserName = "admin",
                            Email = adminUserEmail,
                            EmailConfirmed = true
                        };
                        var result = await userManager.CreateAsync(newAdminUser, "Admin1234?");
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                        }
                        else
                        {
                            Console.WriteLine($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                        }
                    }

                    string appUserEmail = "user@bibliotopia.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new ApplicationUser()
                        {
                            FullName = "User",
                            UserName = "user",
                            Email = appUserEmail,
                            EmailConfirmed = true
                        };
                        var result = await userManager.CreateAsync(newAppUser, "User1234?");
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                        }
                        else
                        {
                            Console.WriteLine($"Failed to create app user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during user and role seeding: {ex.Message}");
                    throw;
                }
            }
        }


    }
}


