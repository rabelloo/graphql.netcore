using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Core;
using StarWars.Data;
using System.IO.Compression;

namespace StarWars.WebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services
                // gzip
                .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest)
                .AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>())

                // DbContext
                .AddDbContext<StarWarsContext>(options => {
                    if (_env.IsEnvironment("Test"))
                        options.UseInMemoryDatabase(databaseName: "StarWars");
                    else
                        options.UseSqlServer(Configuration["ConnectionStrings:StarWars"]);
                })

                // GraphQL
                .AddSingleton<IDocumentExecuter, DocumentExecuter>()
                .AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>()
                .AddSingleton<DataLoaderDocumentListener>()
                .AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService))

                // StarWars Schema
                .AddScoped<ISchema, StarWarsSchema>()
                .AddTransient<StarWarsQuery>()
                .AddTransient<StarWarsMutation>()

                // Droid
                .AddSingleton<DroidType>()
                .AddSingleton<DroidInputType>()
                .AddTransient<DroidQuery>()
                .AddTransient<DroidMutation>()
                .AddTransient<IDroidRepository, DroidRepository>()

                // Film
                .AddSingleton<FilmType>()
                .AddTransient<FilmQuery>()
                .AddTransient<IFilmRepository, FilmRepository>()
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, StarWarsContext db)
        {
            if (_env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                new StarWarsSeed(db);
            }
            else
                app
                .UseHsts()
                .UseHttpsRedirection();

            app
            .UseMvc()
            .UseDefaultFiles()
            .UseStaticFiles()
            .UseResponseCompression()
            ;
        }
    }
}
