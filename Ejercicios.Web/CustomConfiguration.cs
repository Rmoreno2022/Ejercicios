using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.EntityFrameworkCore;
using Ejercicios.Web.Data;
using Ejercicios.Web.Data.Abstractions;
using Ejercicios.Web.Data.Seeders;
using Ejercicios.Web.Services.Abstractions;

using Ejercicios.Web.Services.Implementations;
using System.Threading.RateLimiting;

namespace Ejercicios.Web
{
    public static class CustomConfiguration
    {
        public static WebApplicationBuilder AddCustomConfiguration(this WebApplicationBuilder builder)
        {

            string? cnn = builder.Configuration.GetConnectionString("MyConnection");

            // Data Context
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });

            //Mapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Toast Notification Setup
            builder.Services.AddNotyf(config =>
            {
                config.DurationInSeconds = 10;
                config.IsDismissable = true;
                config.Position = NotyfPosition.BottomRight;
            });

            //services
            AddServices(builder);

            return builder;

        }
        private static void AddServices(WebApplicationBuilder builder)
        {
    
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITipService, TipService>();
            builder.Services.AddScoped<IPasswordGeneratorService, PasswordGeneratorService>();
            builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
            builder.Services.AddScoped<IExpenseService, ExpenseService>();
            builder.Services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddTransient<ReservationSeeder>();
            builder.Services.AddTransient<ExpenseCategorySeeder>();
            builder.Services.AddScoped<INotesRepository, NotesRepository>();
            builder.Services.AddScoped<INotesService, NotesService>();
            builder.Services.AddTransient<NoteCategorySeeder>();

            builder.Services.AddTransient<IEventRepository, EventRepository>();
            builder.Services.AddTransient<IEventService, EventService>();
            builder.Services.AddTransient<SeedDb>();
            builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
            builder.Services.AddTransient<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IMemoryGameService, MemoryGameService>();
            builder.Services.AddScoped<IMemoryGameRepository, MemoryGameRepository>();
            builder.Services.AddTransient<MemoryGameSeeder>();
            builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();
            builder.Services.AddScoped<ISurveyService, SurveyService>();
            builder.Services.AddTransient<SurveySeeder>();
        }
        public static WebApplication AddCustomWebApplicationConfiguration(this WebApplication app)
        {
            app.UseNotyf();

            SeedData(app);

            return app;
        }
        private static void SeedData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var seedDb = scope.ServiceProvider.GetRequiredService<SeedDb>();
            seedDb.SeedAsync().Wait();

            var expenseSeeder = scope.ServiceProvider.GetRequiredService<ExpenseCategorySeeder>();
            expenseSeeder.SeedAsync().Wait();

            var reservationSeeder = scope.ServiceProvider.GetRequiredService<ReservationSeeder>();
            reservationSeeder.SeedAsync().Wait();

            var noteSeeder = scope.ServiceProvider.GetRequiredService<NoteCategorySeeder>();
            noteSeeder.SeedAsync().Wait();

            var memorySeeder = scope.ServiceProvider.GetRequiredService<MemoryGameSeeder>();
            memorySeeder.SeedAsync().Wait();

            var surveySeeder = scope.ServiceProvider.GetRequiredService<SurveySeeder>();
            surveySeeder.SeedAsync().Wait();


        }




    }
}