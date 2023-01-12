using Microsoft.AspNetCore.Identity;
using RunSocial.Enum;
using RunSocial.Models;
using System.Diagnostics;
using System.Net;

namespace RunSocial.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Clubes.Any())
                {
                    context.Clubes.AddRange(new List<Clube>()
                    {
                        new Clube()
                        {
                            Titulo = "Running Club 1",
                            Imagem = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Descricao = "This is the description of the first cinema",
                            CategoriaClube = CategoriaClube.Cidade,
                            Endereco = new Endereco()
                            {
                                Rua = "123 Main St",
                                Cidade = "Charlotte",
                                Estado = "NC"
                            }
                         },
                        new Clube()
                        {
                            Titulo = "Running Club 2",
                            Imagem = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Descricao = "This is the description of the first cinema",
                            CategoriaClube = CategoriaClube.Resistência,
                            Endereco = new Endereco()
                            {
                                Rua = "123 Main St",
                                Cidade = "Charlotte",
                                Estado = "NC"
                            }
                        },
                        new Clube()
                        {
                            Titulo = "Running Club 3",
                            Imagem = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Descricao = "This is the description of the first club",
                            CategoriaClube = CategoriaClube.Trilha,
                            Endereco = new Endereco()
                            {
                                Rua = "123 Main St",
                                Cidade = "Charlotte",
                                Estado = "NC"
                            }
                        },
                        new Clube()
                        {
                            Titulo = "Running Club 3",
                            Imagem = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Descricao = "This is the description of the first club",
                            CategoriaClube = CategoriaClube.Cidade,
                            Endereco = new Endereco()
                            {
                                Rua = "123 Main St",
                                Cidade  = "Michigan",
                                Estado = "NC"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Corridas.Any())
                {
                    context.Corridas.AddRange(new List<Corrida>()
                    {
                        new Corrida()
                        {
                            Titulo = "Running Race 1",
                            Imagem = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Descricao = "This is the description of the first race",
                            CategoriaCorrida = CategoriaCorrida.Maratona,
                            Endereco = new Endereco()
                            {
                                Rua = "123 Main St",
                                Cidade  = "Charlotte",
                                Estado = "NC"
                            }
                        },
                        new Corrida()
                        {
                            Titulo = "Running Race 2",
                            Imagem = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Descricao = "This is the description of the first race",
                            CategoriaCorrida = CategoriaCorrida.Ultra,
                            EnderecoId = 5,
                            Endereco = new Endereco()
                            {
                                Rua = "123 Main St",
                                Cidade = "Charlotte",
                                Estado = "NC"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Usuario()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Endereco = new Endereco()
                        {
                            Rua = "123 Main St",
                            Cidade = "Charlotte",
                            Estado = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new Usuario()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Endereco = new Endereco()
                        {
                            Rua = "123 Main St",
                            Cidade = "Charlotte",
                            Estado = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
