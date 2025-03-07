using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure; 

namespace ProductServiceAPI.Extensions;
 
public static class RegistrationExtention
{
    public static void ServiceClassInitializer(this IServiceCollection services)
    {
        _ = services.AddTransient<IProductServices, ProductServices>();
    }

    public static void DataClassInitializer(this IServiceCollection services,ConfigurationManager con)
    { 
        _ = services.AddDbContext<ProductDbContext>(options => {
           options.UseSqlServer(con.GetConnectionString("AzureSqlDb"));
    });
        //_ = services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}