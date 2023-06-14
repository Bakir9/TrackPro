using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if(!context.Users.Any())
                {
                    var userData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/users.json");

                    var udata = JsonSerializer.Deserialize<List<User>>(userData);
                    context.Users.AddRange(udata);
                }

                if(!context.Payments.Any())
                {
                    var paymentsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/payments.json");

                    var pData = JsonSerializer.Deserialize<List<Payment>>(paymentsData);
                    context.Payments.AddRange(pData);
                }

                if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}