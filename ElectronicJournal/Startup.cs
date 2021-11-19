using ElectronicJournal.Common;
using ElectronicJournal.Data;
using ElectronicJournal.Data.Repositorie;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ElectronicJournal
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var authCongiguration = Configuration.GetSection("Auth");

            services.AddDbContext<DbContext, ElectronicJournalContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IRepository<User>, BaseRepository<User>>();
            services.AddTransient<IRepository<Subject>, BaseRepository<Subject>>();

            services.Configure<AuthOptions>(authCongiguration);
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            ValidIssuer = authOptions.Issuer,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            ValidAudience = authOptions.Audience,

                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElectronicJournal", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ElectronicJournal v1"));
            }
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}