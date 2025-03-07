using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure;
using System;

namespace ProductServiceAPI.Extensions;
 
public static class RegistrationExtention
{
    public static void ServiceClassInitializer(this IServiceCollection services)
    {
       // _ = services.AddTransient<IProductAction, ProductAction>();
    }

    public static void DataClassInitializer(this IServiceCollection services,IConfiguration con)
    {
       _= services.AddDbContext<ProductDbContext>(options => {
           options.UseSqlServer(con.GetConnectionString("AzureSqlDb"));
    });
    }
}