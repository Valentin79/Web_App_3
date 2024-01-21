using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Seminar_3;
using Seminar_3.Abstractions;
using Seminar_3.Mapper;
using Seminar_3.Mutatin;
using Seminar_3.Query;
using Seminar_3.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMemoryCache();
        builder.Services.AddAutoMapper(typeof(MapperProfile));
        //builder.Services.AddPooledDbContextFactory<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("db")));

        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IStorageService, StorageService>();
        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
        {
            cb.Register(c => new AppDbContext(builder.Configuration.GetConnectionString("db"))).InstancePerDependency();
        });
        //builder.Services.AddDbContext<AppDbContext>(conf => conf.UseNpgsql(builder.Configuration.GetConnectionString("db")));


        builder.Services
            .AddGraphQLServer()
            .AddQueryType<MySimpleQuery>()
            .AddMutationType<MySimpleMutation>();


        var app = builder.Build();

        app.MapGraphQL();
        AppContext.SetSwitch("Server=localhost; Database=GB3; Integrated Security=False; TrustServerCertificate=true; Trusted_Connection=True", true); // свою строку

        app.Run();
    }
}
// dotnet ef migrations add InitialCreate --context AppDbContext
// dotnet ef database update