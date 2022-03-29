using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(WebApplication app) 
        {
            var serviceScope = app.Services.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            if (context == null)
            {
                throw new ApplicationException(nameof(context));
            }

            SeedData(context);
         }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any()) 
            {
                Console.WriteLine("--> Seeding data.....");

                context.Platforms.AddRange(
                    new Platform (){ Name = "Dot Net" , Cost = "Free", Publisher = "Microsoft"},
                    new Platform() { Name = "SQL Server Express", Cost = "Free", Publisher = "Microsoft" },
                    new Platform() { Name = "Kubernetes", Cost = "Free", Publisher = "Cloud Native Computing Foundation" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

        }
    }
}
