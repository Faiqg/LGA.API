using System;
using Microsoft.Extensions.DependencyInjection;

namespace LGA.API.Data
{
    public class LGADbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<LGAContext>();
        }
    }
}
