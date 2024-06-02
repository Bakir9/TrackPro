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
                if(!context.Users.Any())
                {
                    var userData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/users.json");

                    var udata = JsonSerializer.Deserialize<List<User>>(userData);
                    context.Users.AddRange(udata);
                }
                if(!context.Activities.Any())
                {
                    var activitiesData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/activity.json");

                    var aData = JsonSerializer.Deserialize<List<Activity>>(activitiesData);
                    context.Activities.AddRange(aData);
                }
                if(!context.Payments.Any())
                {
                    var paymentsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/payments.json");

                    var pData = JsonSerializer.Deserialize<List<Payment>>(paymentsData);
                    context.Payments.AddRange(pData);
                }
                if(!context.Childs.Any())
                {
                    var childsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/childs.json");

                    var cData = JsonSerializer.Deserialize<List<Childs>>(childsData);
                    context.Childs.AddRange(cData);
                }
                if(!context.Associations.Any())
                {
                    var associationsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/association.json");

                    var asData = JsonSerializer.Deserialize<List<Association>>(associationsData);
                    context.Associations.AddRange(asData);
                }
                if(!context.Incomes.Any())
                {
                    var incomeData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/income.json");

                    var incData = JsonSerializer.Deserialize<List<Income>>(incomeData);
                    context.Incomes.AddRange(incData);
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