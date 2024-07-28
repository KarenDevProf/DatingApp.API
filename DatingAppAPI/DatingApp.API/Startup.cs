using DatingApp.API.Middlewares;
using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Services;
using DatingApp.DAL.Models;
using DatingApp.Repositories.Repositories;
using DatingApp.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DatingApp.API
{
    public class Startup
    {
        #region Properties

        private IConfiguration Configuration { get; set; }

        #endregion

        #region Constructor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();
            services.AddControllers().AddNewtonsoftJson();

            #region Configure Swagger  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DatingApp API", Version = "v1", Description = "API Documentation" });
            });
            #endregion

            services.AddCors();

            services.AddAutoMapper(typeof(Startup));

            services.AddMemoryCache();

            services.AddDbContext<DatingAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DatingAppConnectionString")));

            DependenceInjection(services);
        }

        private void DependenceInjection(IServiceCollection services)
        {
            services.AddScoped<DatingAppContext>();
            services.AddScoped<IDatingAppServices, DatingAppServices>();
            services.AddScoped<DbContext, DatingAppContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILikeService, LikeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                          pattern: "{controller=Default}/{action=Index}/{id?}");
            });

            //Seed database
            DbInitializer.Seed(app);
        }
    }
}
