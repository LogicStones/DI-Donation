using API.Extensions;
using API.Helpers;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			var connectionString = Configuration.GetConnectionString("DefaultConnection");

			// Replace with your server version and type.
			// Use 'MariaDbServerVersion' for MariaDB.
			// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
			// For common usages, see pull request #1233.

			//var serverVersion = new MySqlServerVersion(new System.Version(8, 0, 29));
			var serverVersion = ServerVersion.AutoDetect(connectionString);


			// Replace 'YourDbContext' with the name of your own DbContext derived class.
			services.AddDbContext<ApplicationDbContext>(
				dbContextOptions => dbContextOptions
					.UseMySql(connectionString, serverVersion)
					// The following three options help with debugging, but should
					// be changed or removed for production.
					//.LogTo(Console.WriteLine, LogLevel.Information)
					//.EnableSensitiveDataLogging()
					//.EnableDetailedErrors()
			);


			//services.AddDbContext<ApplicationDbContext>(options =>
			//	options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

			// configure strongly typed settings objects
			var appSettingsSection = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);

			// configure jwt authentication
			//var appSettings = appSettingsSection.Get<AppSettings>();
			//var key = Encoding.ASCII.GetBytes(appSettings.Secret);

			services
				.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			//	.AddIdentity<ApplicationUser, ApplicationRole>(config =>
			//{
			//	// Signin settings
			//	config.SignIn.RequireConfirmedEmail = false;
			//	config.SignIn.RequireConfirmedPhoneNumber = false;

			//	// Lockout settings
			//	config.Lockout.AllowedForNewUsers = true;
			//	config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
			//	config.Lockout.MaxFailedAccessAttempts = 10;

			//	// Password settings
			//	config.Password.RequireDigit = true;
			//	config.Password.RequiredLength = 8;
			//	config.Password.RequireNonAlphanumeric = false;
			//	config.Password.RequireUppercase = true;
			//	config.Password.RequireLowercase = false;
			//	config.Password.RequiredUniqueChars = 6;

			//	// User settings
			//	config.User.RequireUniqueEmail = true;

			//})


			//services.AddAuthentication(x =>
			//{
			//	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			//	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			//	x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			//})
			//.AddJwtBearer(x =>
			//{
			//	x.RequireHttpsMetadata = false;
			//	x.SaveToken = true;
			//	x.TokenValidationParameters = new TokenValidationParameters
			//	{
			//		ValidateIssuerSigningKey = true,
			//		IssuerSigningKey = new SymmetricSecurityKey(key),
			//		ValidateIssuer = false,
			//		ValidateAudience = false,
			//		RequireExpirationTime = true,
			//		ValidateLifetime = true
			//	};
			//});

			services.AddControllers();

			services.AddLogging(logging =>
			{
				logging.AddConsole();
				logging.AddDebug();
			});

			services.AddScoped<ResponseEntity, ResponseEntity>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, ILogger<Startup> logger)
		{
			loggerFactory.AddFile("Logs/{Date}.txt");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.ConfigureExceptionHandler(logger);
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}