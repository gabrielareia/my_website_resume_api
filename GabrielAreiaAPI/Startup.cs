using GabrielAreiaAPI.Controllers;
using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace GabrielAreiaAPI
{
    public class Startup
    {
        private const string DATABASE_URL = "PGSQL_DATABASE_URL";
        private const string SIGNING_KEY = "GA_API_BEARER_SIGNING_KEY";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ResumeContext>(
                options => options.UseNpgsql(ConnectionString()));


            services.AddTransient<IRepository<Resume>, RepositoryManager<Resume>>();
            services.AddTransient<IRepository<Ability>, RepositoryManager<Ability>>();
            services.AddTransient<IRepository<Achievement>, RepositoryManager<Achievement>>();
            services.AddTransient<IRepository<Course>, RepositoryManager<Course>>();
            services.AddTransient<IRepository<Goal>, RepositoryManager<Goal>>();
            services.AddTransient<IRepository<Experience>, RepositoryManager<Experience>>();
            services.AddTransient<IRepository<ContactInfo>, RepositoryManager<ContactInfo>>();
            services.AddTransient<IRepository<Cellphone>, RepositoryManager<Cellphone>>();
            services.AddTransient<IRepository<Email>, RepositoryManager<Email>>();
            services.AddTransient<IRepository<Website>, RepositoryManager<Website>>();

            services.AddTransient<IResumeItemsController<Ability, AbilityApi>, AbilitiesController>();
            services.AddTransient<IResumeItemsController<Achievement, Achievement>, AchievementsController>();
            services.AddTransient<IResumeItemsController<Course, CourseApi>, CoursesController>();
            services.AddTransient<IResumeItemsController<Goal, Goal>, GoalsController>();
            services.AddTransient<IResumeItemsController<Experience, Experience>, ExperienceController>();
            services.AddTransient<IResumeItemsController<Cellphone, Cellphone>, CellphoneNumbersController>();
            services.AddTransient<IResumeItemsController<Email, Email>, EmailAddressesController>();
            services.AddTransient<IResumeItemsController<Website, Website>, WebsitesController>();
            services.AddControllers();

            services.AddMvc().AddControllersAsServices();

            services.AddMvc().AddMvcOptions(o => o.EnableEndpointRouting = false);

            services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }
            ).AddJwtBearer("JwtBearer",
            options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(Environment.GetEnvironmentVariable(SIGNING_KEY))),
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = "GabrielAreia.WebApp",
                    ValidAudience = "GabrielAreiaApi"
                };
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GabrielAreiaAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                  {
                    new OpenApiSecurityScheme
                    {
                      Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                      },
                      new List<string>()
                    }
                  });
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GabrielAreiaAPI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Gets the connection string of the database in Heroku or locally.
        /// </summary>
        /// <returns>The connection string</returns>
        private string ConnectionString()
        {
            var databaseUrl = Environment.GetEnvironmentVariable(DATABASE_URL);

            if (databaseUrl == null)
            {
                throw new KeyNotFoundException("The connection string was not found.");
            }

            if (databaseUrl.Split('=')[0].Trim() == "Host") //Workaround to get the connection string locally while developing.
            {
                return databaseUrl;
            }

            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Prefer,
                TrustServerCertificate = true
            };

            return builder.ToString();
        }

    }
}
