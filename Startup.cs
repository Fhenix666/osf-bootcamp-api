using BootCamp.Adm.Data;
using BootCamp.Adm.IRepository;
using BootCamp.Adm.Manager;
using BootCamp.Adm.Manager.Interfaces;
using BootCamp.Adm.Repository;
using BootCamp.Adm.Repository.Interfaces;
using BootCamp.Adm.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BootCamp.Adm
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            
            services.Configure<ApiConfigSettings>(Configuration.GetSection(nameof(ApiConfigSettings)));
            services.Configure<JwtSetting>(Configuration.GetSection(nameof(JwtSetting)));

            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddControllers().AddNewtonsoftJson();

            services.AddControllersWithViews();

            #region === [ DI ] ===

            #region === [ Repository ] ===

            
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserStatusRepository), typeof(UserStatusRepository));

            #endregion

            #region === [ Manager ] ===
            services.AddScoped(typeof(ISecurityManager), typeof(SecurityManager));

            services.AddScoped(typeof(IUserManager), typeof(UserManager));
            services.AddScoped(typeof(IUserStatusManager), typeof(UserStatusManager));

            #endregion

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Swagger Documentation", Version = "Version 1.0" });
            });
        }
		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=access}/{action=Index}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GMSAPI");
            });
        }

    }
}
